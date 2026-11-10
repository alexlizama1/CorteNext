using CorteNext.Models;
using System.Data.SQLite;

namespace CorteNext.Data.Repositories
{
  public sealed class StartFondoRepository : IStartFondoRepository
  {
    private readonly IDatabaseConnectionFactory _connectionFactory;

    public StartFondoRepository(
        IDatabaseConnectionFactory connectionFactory)
    {
      _connectionFactory = connectionFactory;
    }

    public StartFondo? GetByShift(string shift)
    {
      using SQLiteConnection connection =
          _connectionFactory.CreateConnection();

      connection.Open();

      const string sql = """
                SELECT
                    one,
                    five,
                    ten,
                    quarter,
                    shift
                FROM startFondoTB
                WHERE shift = @shift
                LIMIT 1;
                """;

      using SQLiteCommand command =
          new(sql, connection);

      command.Parameters.AddWithValue(
          "@shift",
          shift);

      using SQLiteDataReader reader =
          command.ExecuteReader();

      if (!reader.Read())
        return null;

      return new StartFondo
      {
        One = Convert.ToDecimal(
              reader["one"]),

        Five = Convert.ToDecimal(
              reader["five"]),

        Ten = Convert.ToDecimal(
              reader["ten"]),

        Quarter = Convert.ToDecimal(
              reader["quarter"]),

        Shift =
              Convert.ToString(
                  reader["shift"])
              ?? string.Empty
      };
    }
  }
}