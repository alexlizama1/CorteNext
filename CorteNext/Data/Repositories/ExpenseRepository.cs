using CorteNext.Models;
using System.Data.SQLite;
using System.Globalization;

namespace CorteNext.Data.Repositories
{
  public sealed class ExpenseRepository : IExpenseRepository
  {
    private readonly IDatabaseConnectionFactory _connectionFactory;

    public ExpenseRepository(
        IDatabaseConnectionFactory connectionFactory)
    {
      _connectionFactory = connectionFactory;
    }

    // =========================================================
    // GET
    // =========================================================

    public IReadOnlyList<ExpenseRecord> GetByDateAndShift(
        DateTime date,
        string shift)
    {
      List<ExpenseRecord> records = new();

      using SQLiteConnection connection =
          _connectionFactory.CreateConnection();

      connection.Open();

      const string sql = """
                SELECT
                    id,
                    dateLog,
                    timer,
                    amount,
                    company,
                    description,
                    shift
                FROM expenseTB
                WHERE dateLog = @dateLog
                  AND shift = @shift
                ORDER BY id;
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

      while (reader.Read())
      {
        records.Add(
            CreateRecord(reader));
      }

      return records;
    }

    // =========================================================
    // ADD
    // =========================================================

    public void Add(
        ExpenseRecord record)
    {
      using SQLiteConnection connection =
          _connectionFactory.CreateConnection();

      connection.Open();

      const string sql = """
                INSERT INTO expenseTB
                (
                    dateLog,
                    timer,
                    amount,
                    company,
                    description,
                    shift
                )
                VALUES
                (
                    @dateLog,
                    @timer,
                    @amount,
                    @company,
                    @description,
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
          "@amount",
          record.Amount);

      command.Parameters.AddWithValue(
          "@company",
          record.Company);

      command.Parameters.AddWithValue(
          "@description",
          record.Description);

      command.Parameters.AddWithValue(
          "@shift",
          record.Shift);

      command.ExecuteNonQuery();
    }

    // =========================================================
    // DELETE
    // =========================================================

    public void Delete(int id)
    {
      using SQLiteConnection connection =
          _connectionFactory.CreateConnection();

      connection.Open();

      const string sql = """
                DELETE FROM expenseTB
                WHERE id = @id;
                """;

      using SQLiteCommand command =
          new(sql, connection);

      command.Parameters.AddWithValue(
          "@id",
          id);

      command.ExecuteNonQuery();
    }

    // =========================================================
    // CREATE RECORD
    // =========================================================

    private static ExpenseRecord CreateRecord(
        SQLiteDataReader reader)
    {
      string dateText =
          Convert.ToString(
              reader["dateLog"])
          ?? string.Empty;

      DateTime.TryParseExact(
          dateText,
          "MM/dd/yyyy",
          CultureInfo.InvariantCulture,
          DateTimeStyles.None,
          out DateTime date);

      return new ExpenseRecord
      {
        Id =
              Convert.ToInt32(
                  reader["id"]),

        Date =
              date,

        Time =
              Convert.ToString(
                  reader["timer"])
              ?? string.Empty,

        Amount =
              Convert.ToDecimal(
                  reader["amount"]),

        Company =
              Convert.ToString(
                  reader["company"])
              ?? string.Empty,

        Description =
              Convert.ToString(
                  reader["description"])
              ?? string.Empty,

        Shift =
              Convert.ToString(
                  reader["shift"])
              ?? string.Empty
      };
    }

    public void DeleteNoExpense(
        DateTime date,
        string shift)
    {
      using SQLiteConnection connection =
          _connectionFactory.CreateConnection();

      connection.Open();

      const string sql = """
        DELETE FROM expenseTB
        WHERE dateLog = @dateLog
          AND LOWER(TRIM(shift)) = LOWER(TRIM(@shift))
          AND amount = 0
          AND company = 'No Expense';
        """;

      using SQLiteCommand command =
          new(sql, connection);

      command.Parameters.AddWithValue(
          "@dateLog",
          date.ToString("MM/dd/yyyy"));

      command.Parameters.AddWithValue(
          "@shift",
          shift);

      command.ExecuteNonQuery();
    }

    public IReadOnlyList<ExpenseRecord> GetByDate(
    DateTime date)
    {
      List<ExpenseRecord> records =
          new();

      using SQLiteConnection connection =
          _connectionFactory.CreateConnection();

      connection.Open();

      const string sql = """
        SELECT
            id,
            dateLog,
            timer,
            amount,
            company,
            description,
            shift
        FROM expenseTB
        WHERE TRIM(dateLog) = @dateLog
        ORDER BY id DESC;
        """;

      using SQLiteCommand command =
          new(sql, connection);

      command.Parameters.AddWithValue(
          "@dateLog",
          date.ToString("MM/dd/yyyy"));

      using SQLiteDataReader reader =
          command.ExecuteReader();

      while (reader.Read())
      {
        records.Add(
            CreateRecord(reader));
      }

      return records;
    }

    public IReadOnlyList<ExpenseRecord> GetRecent(
    int count)
    {
      if (count <= 0)
      {
        return Array.Empty<ExpenseRecord>();
      }

      List<ExpenseRecord> records =
          new();

      using SQLiteConnection connection =
          _connectionFactory.CreateConnection();

      connection.Open();

      const string sql = """
        SELECT
            id,
            dateLog,
            timer,
            amount,
            company,
            description,
            shift
        FROM expenseTB
        ORDER BY id DESC
        LIMIT @count;
        """;

      using SQLiteCommand command =
          new(sql, connection);

      command.Parameters.AddWithValue(
          "@count",
          count);

      using SQLiteDataReader reader =
          command.ExecuteReader();

      while (reader.Read())
      {
        records.Add(
            CreateRecord(reader));
      }

      return records;
    }

    public IReadOnlyList<DateTime> GetExpenseDates(
    DateTime startDate,
    DateTime endDate)
    {
      List<DateTime> dates =
          new();

      using SQLiteConnection connection =
          _connectionFactory.CreateConnection();

      connection.Open();

      /*
       * dateLog is stored as MM/dd/yyyy.
       *
       * Convert the text to yyyy-MM-dd during the query
       * so range filtering and sorting work correctly.
       *
       * Only dates containing an expense greater than
       * zero are returned.
       */
      const string sql = """
        SELECT DISTINCT
            TRIM(dateLog) AS expenseDate
        FROM expenseTB
        WHERE amount > 0
          AND
          (
              substr(TRIM(dateLog), 7, 4) || '-' ||
              substr(TRIM(dateLog), 1, 2) || '-' ||
              substr(TRIM(dateLog), 4, 2)
          )
          BETWEEN @startDate AND @endDate
        ORDER BY
          (
              substr(TRIM(dateLog), 7, 4) || '-' ||
              substr(TRIM(dateLog), 1, 2) || '-' ||
              substr(TRIM(dateLog), 4, 2)
          );
        """;

      using SQLiteCommand command =
          new(
              sql,
              connection);

      command.Parameters.AddWithValue(
          "@startDate",
          startDate.Date.ToString(
              "yyyy-MM-dd"));

      command.Parameters.AddWithValue(
          "@endDate",
          endDate.Date.ToString(
              "yyyy-MM-dd"));

      using SQLiteDataReader reader =
          command.ExecuteReader();

      while (reader.Read())
      {
        string dateText =
            Convert.ToString(
                reader["expenseDate"])
            ?? string.Empty;

        bool parsed =
            DateTime.TryParseExact(
                dateText,
                "MM/dd/yyyy",
                System.Globalization
                    .CultureInfo.InvariantCulture,
                System.Globalization
                    .DateTimeStyles.None,
                out DateTime expenseDate);

        if (!parsed)
        {
          continue;
        }

        dates.Add(
            expenseDate.Date);
      }

      return dates;
    }

  }
}