using System.Data.SQLite;

namespace CorteNext.Data
{
  public sealed class DatabaseMigrationService
      : IDatabaseMigrationService
  {
    /*
     * Version 1 represents the current CorteNext schema.
     *
     * When the schema changes later:
     *
     * 1. Increase CurrentSchemaVersion.
     * 2. Add another migration case.
     * 3. Never modify an older migration after release.
     */
    private const int CurrentSchemaVersion = 1;

    private readonly IDatabaseConnectionFactory
        _connectionFactory;

    private readonly string _databasePath;
    private readonly string _backupDirectory;

    public DatabaseMigrationService(
        IDatabaseConnectionFactory connectionFactory,
        string databasePath,
        string backupDirectory)
    {
      _connectionFactory =
          connectionFactory;

      _databasePath =
          databasePath;

      _backupDirectory =
          backupDirectory;
    }

    // =========================================================
    // MIGRATE
    // =========================================================

    public void Migrate()
    {
      Directory.CreateDirectory(
          Path.GetDirectoryName(
              _databasePath)
          ?? DatabasePathProvider.DataDirectory);

      Directory.CreateDirectory(
          _backupDirectory);

      using SQLiteConnection connection =
          _connectionFactory.CreateConnection();

      connection.Open();

      ConfigureConnection(
          connection);

      int currentVersion =
          GetSchemaVersion(
              connection);

      if (currentVersion >
          CurrentSchemaVersion)
      {
        throw new InvalidOperationException(
            "The CorteNext database was created by a " +
            "newer application version.\r\n\r\n" +
            $"Database schema: {currentVersion}\r\n" +
            $"Supported schema: {CurrentSchemaVersion}\r\n\r\n" +
            "Install the newer CorteNext application before " +
            "opening this database.");
      }

      if (currentVersion ==
          CurrentSchemaVersion)
      {
        VerifyIntegrity(
            connection);

        return;
      }

      /*
       * Close the connection before copying the database
       * and any SQLite sidecar files.
       */
      connection.Close();

      string backupPath =
          CreateBackup();

      try
      {
        connection.Open();

        ConfigureConnection(
            connection);

        ApplyPendingMigrations(
            connection,
            currentVersion);

        VerifyIntegrity(
            connection);

        connection.Close();

        DeleteOldBackups(
            keepNewest: 10);
      }
      catch
      {
        if (connection.State !=
            System.Data.ConnectionState.Closed)
        {
          connection.Close();
        }

        RestoreBackup(
            backupPath);

        throw;
      }
    }

    // =========================================================
    // CONNECTION CONFIGURATION
    // =========================================================

    private static void ConfigureConnection(
        SQLiteConnection connection)
    {
      using SQLiteCommand command =
          connection.CreateCommand();

      command.CommandText = """
                PRAGMA foreign_keys = ON;
                PRAGMA busy_timeout = 10000;
                """;

      command.ExecuteNonQuery();
    }

    // =========================================================
    // CURRENT VERSION
    // =========================================================

    private static int GetSchemaVersion(
        SQLiteConnection connection)
    {
      using SQLiteCommand command =
          connection.CreateCommand();

      command.CommandText =
          "PRAGMA user_version;";

      object? result =
          command.ExecuteScalar();

      return Convert.ToInt32(
          result);
    }

    // =========================================================
    // PENDING MIGRATIONS
    // =========================================================

    private static void ApplyPendingMigrations(
        SQLiteConnection connection,
        int startingVersion)
    {
      int version =
          startingVersion;

      while (version <
             CurrentSchemaVersion)
      {
        int targetVersion =
            version + 1;

        using SQLiteTransaction transaction =
            connection.BeginTransaction();

        try
        {
          ApplyMigration(
              connection,
              transaction,
              targetVersion);

          SetSchemaVersion(
              connection,
              transaction,
              targetVersion);

          transaction.Commit();

          version =
              targetVersion;
        }
        catch
        {
          transaction.Rollback();
          throw;
        }
      }
    }

    // =========================================================
    // APPLY ONE MIGRATION
    // =========================================================

    private static void ApplyMigration(
        SQLiteConnection connection,
        SQLiteTransaction transaction,
        int targetVersion)
    {
      switch (targetVersion)
      {
        case 1:
          ApplyVersion1Baseline(
              connection,
              transaction);
          break;

        /*
         * Future example:
         *
         * case 2:
         *     ApplyVersion2(
         *         connection,
         *         transaction);
         *     break;
         */

        default:
          throw new InvalidOperationException(
              $"No database migration exists for " +
              $"schema version {targetVersion}.");
      }
    }

    private static void ApplyVersion2(
    SQLiteConnection connection,
    SQLiteTransaction transaction)
    {
      using SQLiteCommand command =
          connection.CreateCommand();

      command.Transaction =
          transaction;

      command.CommandText = """
        ALTER TABLE CorteTB
        ADD COLUMN notes TEXT NULL;
        """;

      command.ExecuteNonQuery();
    }

    // =========================================================
    // VERSION 1 BASELINE
    // =========================================================

    private static void ApplyVersion1Baseline(
        SQLiteConnection connection,
        SQLiteTransaction transaction)
    {
      /*
       * Version 1 represents the schema already used by
       * CorteNext.
       *
       * This validates the core application tables rather
       * than recreating or replacing an existing database.
       */

      string[] expectedTables =
      {
                "FondoTB",
                "CorteTB",
                "expenseTB"
            };

      foreach (string tableName in expectedTables)
      {
        if (!TableExists(
                connection,
                transaction,
                tableName))
        {
          throw new InvalidOperationException(
              $"The CorteNext database is missing the " +
              $"required table '{tableName}'.\r\n\r\n" +
              "The existing database was not changed.");
        }
      }
    }

    // =========================================================
    // TABLE EXISTS
    // =========================================================

    private static bool TableExists(
        SQLiteConnection connection,
        SQLiteTransaction transaction,
        string tableName)
    {
      using SQLiteCommand command =
          connection.CreateCommand();

      command.Transaction =
          transaction;

      command.CommandText = """
                SELECT COUNT(*)
                FROM sqlite_master
                WHERE type = 'table'
                  AND LOWER(name) = LOWER(@tableName);
                """;

      command.Parameters.AddWithValue(
          "@tableName",
          tableName);

      long count =
          Convert.ToInt64(
              command.ExecuteScalar());

      return count > 0;
    }

    // =========================================================
    // SET VERSION
    // =========================================================

    private static void SetSchemaVersion(
        SQLiteConnection connection,
        SQLiteTransaction transaction,
        int version)
    {
      using SQLiteCommand command =
          connection.CreateCommand();

      command.Transaction =
          transaction;

      /*
       * PRAGMA does not accept a normal parameter for this
       * assignment. The value is an internal integer generated
       * by the application, not user-provided text.
       */
      command.CommandText =
          $"PRAGMA user_version = {version};";

      command.ExecuteNonQuery();
    }

    // =========================================================
    // INTEGRITY CHECK
    // =========================================================

    private static void VerifyIntegrity(
        SQLiteConnection connection)
    {
      using SQLiteCommand command =
          connection.CreateCommand();

      command.CommandText =
          "PRAGMA integrity_check;";

      string result =
          Convert.ToString(
              command.ExecuteScalar())
          ?? string.Empty;

      if (!string.Equals(
              result.Trim(),
              "ok",
              StringComparison.OrdinalIgnoreCase))
      {
        throw new InvalidOperationException(
            "The CorteNext database integrity check failed." +
            "\r\n\r\n" +
            $"SQLite result: {result}");
      }
    }

    // =========================================================
    // BACKUP
    // =========================================================

    private string CreateBackup()
    {
      if (!File.Exists(
              _databasePath))
      {
        throw new FileNotFoundException(
            "The CorteNext database could not be found.",
            _databasePath);
      }

      string timestamp =
          DateTime.Now.ToString(
              "yyyyMMdd-HHmmss");

      string backupPath =
          Path.Combine(
              _backupDirectory,
              $"cortedb-before-migration-{timestamp}.sqlite");

      File.Copy(
          _databasePath,
          backupPath,
          overwrite: false);

      CopySidecarIfPresent(
          _databasePath + "-wal",
          backupPath + "-wal");

      CopySidecarIfPresent(
          _databasePath + "-shm",
          backupPath + "-shm");

      return backupPath;
    }

    // =========================================================
    // RESTORE
    // =========================================================

    private void RestoreBackup(
        string backupPath)
    {
      if (!File.Exists(
              backupPath))
      {
        throw new FileNotFoundException(
            "The CorteNext database migration failed, " +
            "and its backup could not be found.",
            backupPath);
      }

      DeleteIfPresent(
          _databasePath);

      DeleteIfPresent(
          _databasePath + "-wal");

      DeleteIfPresent(
          _databasePath + "-shm");

      File.Copy(
          backupPath,
          _databasePath,
          overwrite: true);

      RestoreSidecarIfPresent(
          backupPath + "-wal",
          _databasePath + "-wal");

      RestoreSidecarIfPresent(
          backupPath + "-shm",
          _databasePath + "-shm");
    }

    // =========================================================
    // BACKUP RETENTION
    // =========================================================

    private void DeleteOldBackups(
        int keepNewest)
    {
      if (keepNewest < 1 ||
          !Directory.Exists(
              _backupDirectory))
      {
        return;
      }

      FileInfo[] backups =
          new DirectoryInfo(
              _backupDirectory)
              .GetFiles(
                  "cortedb-before-migration-*.sqlite")
              .OrderByDescending(
                  file =>
                      file.CreationTimeUtc)
              .ToArray();

      foreach (FileInfo backup
               in backups.Skip(keepNewest))
      {
        DeleteIfPresent(
            backup.FullName);

        DeleteIfPresent(
            backup.FullName + "-wal");

        DeleteIfPresent(
            backup.FullName + "-shm");
      }
    }

    // =========================================================
    // FILE HELPERS
    // =========================================================

    private static void CopySidecarIfPresent(
        string source,
        string destination)
    {
      if (!File.Exists(source))
      {
        return;
      }

      File.Copy(
          source,
          destination,
          overwrite: true);
    }

    private static void RestoreSidecarIfPresent(
        string source,
        string destination)
    {
      if (!File.Exists(source))
      {
        return;
      }

      File.Copy(
          source,
          destination,
          overwrite: true);
    }

    private static void DeleteIfPresent(
        string path)
    {
      if (File.Exists(path))
      {
        File.Delete(path);
      }
    }
  }
}