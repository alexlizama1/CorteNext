using CorteNext.Models;
using System.Data.SQLite;

namespace CorteNext.Data.Repositories
{
  public sealed class FondoTrackerRepository
      : IFondoTrackerRepository
  {
    private readonly IDatabaseConnectionFactory _connectionFactory;

    public FondoTrackerRepository(
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
        case ShiftType.FondoAM:

          InsertAM(
              connection,
              dateLog);

          break;


        case ShiftType.FondoDrive:

          UpdateShift(
              connection,
              dateLog,
              "drive",
              2);

          break;


        case ShiftType.FondoPM:

          UpdateShift(
              connection,
              dateLog,
              "pm",
              3);

          break;


        default:

          throw new ArgumentOutOfRangeException(
              nameof(shift),
              shift,
              "Invalid Fondo shift.");
      }
    }

    private static void InsertAM(
        SQLiteConnection connection,
        string dateLog)
    {
      const string sql = """
                INSERT INTO fondoTrackerTB
                (
                    dateLog,
                    am,
                    pm,
                    drive
                )
                VALUES
                (
                    @dateLog,
                    1,
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

    private static void UpdateShift(
        SQLiteConnection connection,
        string dateLog,
        string column,
        int value)
    {
      string sql = $"""
                UPDATE fondoTrackerTB
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