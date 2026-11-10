namespace CorteNext.Data
{
  public static class DatabasePathProvider
  {
    private const string DatabaseFileName =
        "cortedb.sqlite";

    public static string DataDirectory =>
        Path.Combine(
            Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData),
            "CorteNext",
            "Data");

    public static string BackupDirectory =>
        Path.Combine(
            DataDirectory,
            "Backups");

    public static string DatabasePath =>
        Path.Combine(
            DataDirectory,
            DatabaseFileName);

    public static string LegacyDatabasePath =>
        @"C:\db\cortedb.sqlite";

    public static void PrepareDatabaseLocation()
    {
      Directory.CreateDirectory(
          DataDirectory);

      Directory.CreateDirectory(
          BackupDirectory);

      MigrateLegacyDatabaseIfNeeded();
    }

    private static void MigrateLegacyDatabaseIfNeeded()
    {
      if (File.Exists(DatabasePath))
      {
        return;
      }

      if (!File.Exists(LegacyDatabasePath))
      {
        return;
      }

      File.Copy(
          LegacyDatabasePath,
          DatabasePath,
          overwrite: false);

      CopySidecarIfPresent(
          LegacyDatabasePath + "-wal",
          DatabasePath + "-wal");

      CopySidecarIfPresent(
          LegacyDatabasePath + "-shm",
          DatabasePath + "-shm");
    }

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
          overwrite: false);
    }
  }
}