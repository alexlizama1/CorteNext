using CorteNext.Models;
using System.Data.SQLite;

namespace CorteNext.Data.Repositories
{
  public sealed class CorteTrackerRepository
      : ICorteTrackerRepository
  {
    private readonly IDatabaseConnectionFactory _connectionFactory;

    public CorteTrackerRepository(
        IDatabaseConnectionFactory connectionFactory)
    {
      _connectionFactory = connectionFactory;
    }

    public void MarkCompleted(
        DateTime date,
        ShiftType shift)
    {
      string dateLog =
          date.ToString("MM/dd/yyyy");

      using SQLiteConnection connection =
          _connectionFactory.CreateConnection();

      connection.Open();

      switch (shift)
      {
        case ShiftType.CorteAM:
          InsertAM(
              connection,
              dateLog);
          break;

        case ShiftType.CortePM:
          UpdateShift(
              connection,
              dateLog,
              "pm",
              2);
          break;

        case ShiftType.CorteAMDrive:
          UpdateShift(
              connection,
              dateLog,
              "amDrive",
              3);
          break;

        case ShiftType.CortePMDrive:
          UpdateShift(
              connection,
              dateLog,
              "pmDrive",
              4);
          break;

        default:
          throw new ArgumentOutOfRangeException(
              nameof(shift),
              shift,
              "Invalid Corte shift.");
      }
    }

    // =========================================================
    // AM
    // =========================================================

    private static void InsertAM(
        SQLiteConnection connection,
        string dateLog)
    {
      const string sql = """
                INSERT INTO corteTrackerTB
                (
                    dateLog,
                    am,
                    pm,
                    amDrive,
                    pmDrive
                )
                VALUES
                (
                    @dateLog,
                    1,
                    0,
                    0,
                    0
                );
                """;

      using SQLiteCommand command =
          new(sql, connection);

      command.Parameters.AddWithValue(
          "@dateLog",
          dateLog);

      command.ExecuteNonQuery();
    }

    // =========================================================
    // UPDATE SHIFT
    // =========================================================

    private static void UpdateShift(
        SQLiteConnection connection,
        string dateLog,
        string column,
        int value)
    {
      string sql = $"""
                UPDATE corteTrackerTB
                SET {column} = @value
                WHERE dateLog = @dateLog;
                """;

      using SQLiteCommand command =
          new(sql, connection);

      command.Parameters.AddWithValue(
          "@value",
          value);

      command.Parameters.AddWithValue(
          "@dateLog",
          dateLog);

      command.ExecuteNonQuery();
    }
  }
}