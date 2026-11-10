using CorteNext.Models;
using System.Data.SQLite;

namespace CorteNext.Data.Repositories
{
  public sealed class FondoRepository : IFondoRepository
  {
    private readonly IDatabaseConnectionFactory _connectionFactory;

    public FondoRepository(
        IDatabaseConnectionFactory connectionFactory)
    {
      _connectionFactory = connectionFactory;
    }

    public FondoRecord? GetByDateAndShift(
    DateTime date,
    string shift)
    {
      using SQLiteConnection connection =
          _connectionFactory.CreateConnection();

      connection.Open();

      const string sql = """
        SELECT
            id,
            dateLog,
            timer,
            one,
            five,
            ten,
            quarter1,
            quarter2,
            total,
            staffName,
            shift
        FROM fondoTB
        WHERE dateLog = @dateLog
          AND LOWER(TRIM(shift)) = LOWER(TRIM(@shift))
        ORDER BY id DESC
        LIMIT 1;
        """;

      using SQLiteCommand command =
          new(sql, connection);

      command.Parameters.AddWithValue(
          "@dateLog",
          date.ToString("MM/dd/yyyy"));

      command.Parameters.AddWithValue(
          "@shift",
          shift);

      using SQLiteDataReader reader =
          command.ExecuteReader();

      if (!reader.Read())
        return null;

      return new FondoRecord
      {
        Id =
              Convert.ToInt32(
                  reader["id"]),

        Date =
              DateTime.ParseExact(
                  Convert.ToString(
                      reader["dateLog"])!,
                  "MM/dd/yyyy",
                  System.Globalization.CultureInfo.InvariantCulture),

        Time =
              Convert.ToString(
                  reader["timer"])
              ?? string.Empty,

        One =
              Convert.ToDecimal(
                  reader["one"]),

        Five =
              Convert.ToDecimal(
                  reader["five"]),

        Ten =
              Convert.ToDecimal(
                  reader["ten"]),

        Quarter1 =
              Convert.ToDecimal(
                  reader["quarter1"]),

        Quarter2 =
              Convert.ToDecimal(
                  reader["quarter2"]),

        Total =
              Convert.ToDecimal(
                  reader["total"]),

        StaffName =
              Convert.ToString(
                  reader["staffName"])
              ?? string.Empty,

        Shift =
              Convert.ToString(
                  reader["shift"])
              ?? string.Empty
      };
    }

    public void Add(FondoRecord record)
    {
      using SQLiteConnection connection =
          _connectionFactory.CreateConnection();

      connection.Open();

      const string sql = """
                INSERT INTO fondoTB
                (
                    dateLog,
                    timer,
                    one,
                    five,
                    ten,
                    quarter1,
                    quarter2,
                    total,
                    staffName,
                    shift
                )
                VALUES
                (
                    @dateLog,
                    @timer,
                    @one,
                    @five,
                    @ten,
                    @quarter1,
                    @quarter2,
                    @total,
                    @staffName,
                    @shift
                );
                """;

      using SQLiteCommand command =
          new(sql, connection);

      command.Parameters.AddWithValue(
          "@dateLog",
          record.Date.ToString("MM/dd/yyyy"));

      command.Parameters.AddWithValue(
          "@timer",
          record.Time);

      command.Parameters.AddWithValue(
          "@one",
          record.One);

      command.Parameters.AddWithValue(
          "@five",
          record.Five);

      command.Parameters.AddWithValue(
          "@ten",
          record.Ten);

      command.Parameters.AddWithValue(
          "@quarter1",
          record.Quarter1);

      command.Parameters.AddWithValue(
          "@quarter2",
          record.Quarter2);

      command.Parameters.AddWithValue(
          "@total",
          record.Total);

      command.Parameters.AddWithValue(
          "@staffName",
          record.StaffName);

      command.Parameters.AddWithValue(
          "@shift",
          record.Shift);

      command.ExecuteNonQuery();
    }

    public bool Exists(
    DateTime date,
    string shift)
    {
      using SQLiteConnection connection =
          _connectionFactory.CreateConnection();

      connection.Open();

      const string sql = """
        SELECT EXISTS
        (
            SELECT 1
            FROM fondoTB
            WHERE TRIM(dateLog) = @dateLog
              AND LOWER(TRIM(shift)) = LOWER(TRIM(@shift))
        );
        """;

      using SQLiteCommand command =
          new(sql, connection);

      command.Parameters.AddWithValue(
          "@dateLog",
          date.ToString("MM/dd/yyyy"));

      command.Parameters.AddWithValue(
          "@shift",
          shift);

      long result =
          Convert.ToInt64(
              command.ExecuteScalar());

      return result == 1;
    }

  }
}