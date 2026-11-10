using CorteNext.Models;
using System.Data.SQLite;
using System.Globalization;

namespace CorteNext.Data.Repositories
{
  public sealed class CorteRepository : ICorteRepository
  {
    private readonly IDatabaseConnectionFactory _connectionFactory;

    public CorteRepository(
        IDatabaseConnectionFactory connectionFactory)
    {
      _connectionFactory = connectionFactory;
    }

    // =========================================================
    // ADD
    // =========================================================

    public void Add(CorteRecord record)
    {
      using SQLiteConnection connection =
          _connectionFactory.CreateConnection();

      connection.Open();

      const string sql = """
                INSERT INTO CorteTB
                (
                    dateLog,
                    timer,
                    one,
                    five,
                    ten,
                    twenty,
                    fifty,
                    hundred,
                    quarter,
                    totalCash,
                    driveTip,
                    expenses,
                    grossTotal,
                    fondo,
                    netTotal,
                    sales,
                    shortOver,
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
                    @twenty,
                    @fifty,
                    @hundred,
                    @quarter,
                    @totalCash,
                    @driveTip,
                    @expenses,
                    @grossTotal,
                    @fondo,
                    @netTotal,
                    @sales,
                    @shortOver,
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
          "@twenty",
          record.Twenty);

      command.Parameters.AddWithValue(
          "@fifty",
          record.Fifty);

      command.Parameters.AddWithValue(
          "@hundred",
          record.Hundred);

      command.Parameters.AddWithValue(
          "@quarter",
          record.Quarter);

      command.Parameters.AddWithValue(
          "@totalCash",
          record.TotalCash);

      command.Parameters.AddWithValue(
          "@driveTip",
          record.DriveTip);

      command.Parameters.AddWithValue(
          "@expenses",
          record.Expenses);

      command.Parameters.AddWithValue(
          "@grossTotal",
          record.GrossTotal);

      command.Parameters.AddWithValue(
          "@fondo",
          record.Fondo);

      command.Parameters.AddWithValue(
          "@netTotal",
          record.NetTotal);

      command.Parameters.AddWithValue(
          "@sales",
          record.Sales);

      command.Parameters.AddWithValue(
          "@shortOver",
          record.ShortOver);

      command.Parameters.AddWithValue(
          "@staffName",
          record.StaffName);

      command.Parameters.AddWithValue(
          "@shift",
          record.Shift);

      command.ExecuteNonQuery();
    }

    // =========================================================
    // GET BY DATE / SHIFT
    // =========================================================

    public CorteRecord? GetByDateAndShift(
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
                    twenty,
                    fifty,
                    hundred,
                    quarter,
                    totalCash,
                    driveTip,
                    expenses,
                    grossTotal,
                    fondo,
                    netTotal,
                    sales,
                    shortOver,
                    staffName,
                    shift
                FROM CorteTB
                WHERE dateLog = @dateLog
                  AND shift = @shift
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

      return new CorteRecord
      {
        Id =
              Convert.ToInt32(reader["id"]),

        Date =
              DateTime.ParseExact(
                  Convert.ToString(
                      reader["dateLog"])!,
                  "MM/dd/yyyy",
                  CultureInfo.InvariantCulture),

        Time =
              Convert.ToString(reader["timer"])
              ?? string.Empty,

        One =
              Convert.ToDecimal(reader["one"]),

        Five =
              Convert.ToDecimal(reader["five"]),

        Ten =
              Convert.ToDecimal(reader["ten"]),

        Twenty =
              Convert.ToDecimal(reader["twenty"]),

        Fifty =
              Convert.ToDecimal(reader["fifty"]),

        Hundred =
              Convert.ToDecimal(reader["hundred"]),

        Quarter =
              Convert.ToDecimal(reader["quarter"]),

        TotalCash =
              Convert.ToDecimal(reader["totalCash"]),

        DriveTip =
              Convert.ToDecimal(reader["driveTip"]),

        Expenses =
              Convert.ToDecimal(reader["expenses"]),

        GrossTotal =
              Convert.ToDecimal(reader["grossTotal"]),

        Fondo =
              Convert.ToDecimal(reader["fondo"]),

        NetTotal =
              Convert.ToDecimal(reader["netTotal"]),

        Sales =
              Convert.ToDecimal(reader["sales"]),

        ShortOver =
              Convert.ToDecimal(reader["shortOver"]),

        StaffName =
              Convert.ToString(reader["staffName"])
              ?? string.Empty,

        Shift =
              Convert.ToString(reader["shift"])
              ?? string.Empty
      };
    }

    public IReadOnlyList<CorteRecord> GetByDate(
    DateTime date)
    {
      List<CorteRecord> records = new();

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
            twenty,
            fifty,
            hundred,
            quarter,
            totalCash,
            driveTip,
            expenses,
            grossTotal,
            fondo,
            netTotal,
            sales,
            shortOver,
            staffName,
            shift
        FROM CorteTB
        WHERE dateLog = @dateLog
        ORDER BY id;
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

    public IReadOnlyList<CorteRecord> GetRecent(
    int count)
    {
      if (count <= 0)
      {
        return Array.Empty<CorteRecord>();
      }

      List<CorteRecord> records = new();

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
            twenty,
            fifty,
            hundred,
            quarter,
            totalCash,
            driveTip,
            expenses,
            grossTotal,
            fondo,
            netTotal,
            sales,
            shortOver,
            staffName,
            shift
        FROM CorteTB
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

    private static CorteRecord CreateRecord(
    SQLiteDataReader reader)
    {
      string dateText =
          Convert.ToString(
              reader["dateLog"])
          ?? string.Empty;

      DateTime.TryParseExact(
          dateText,
          "MM/dd/yyyy",
          System.Globalization.CultureInfo.InvariantCulture,
          System.Globalization.DateTimeStyles.None,
          out DateTime date);

      return new CorteRecord
      {
        Id =
              Convert.ToInt32(reader["id"]),

        Date =
              date,

        Time =
              Convert.ToString(reader["timer"])
              ?? string.Empty,

        One =
              Convert.ToDecimal(reader["one"]),

        Five =
              Convert.ToDecimal(reader["five"]),

        Ten =
              Convert.ToDecimal(reader["ten"]),

        Twenty =
              Convert.ToDecimal(reader["twenty"]),

        Fifty =
              Convert.ToDecimal(reader["fifty"]),

        Hundred =
              Convert.ToDecimal(reader["hundred"]),

        Quarter =
              Convert.ToDecimal(reader["quarter"]),

        TotalCash =
              Convert.ToDecimal(reader["totalCash"]),

        DriveTip =
              Convert.ToDecimal(reader["driveTip"]),

        Expenses =
              Convert.ToDecimal(reader["expenses"]),

        GrossTotal =
              Convert.ToDecimal(reader["grossTotal"]),

        Fondo =
              Convert.ToDecimal(reader["fondo"]),

        NetTotal =
              Convert.ToDecimal(reader["netTotal"]),

        Sales =
              Convert.ToDecimal(reader["sales"]),

        ShortOver =
              Convert.ToDecimal(reader["shortOver"]),

        StaffName =
              Convert.ToString(reader["staffName"])
              ?? string.Empty,

        Shift =
              Convert.ToString(reader["shift"])
              ?? string.Empty
      };
    }

    public IReadOnlyList<DateTime> GetReportDates(
      DateTime startDate,
      DateTime endDate)
    {
      List<DateTime> dates =
          new();

      using SQLiteConnection connection =
          _connectionFactory.CreateConnection();

      connection.Open();

      const string sql = """
        SELECT DISTINCT
            TRIM(dateLog) AS reportDate
        FROM CorteTB
        WHERE
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
                reader["reportDate"])
            ?? string.Empty;

        if (DateTime.TryParseExact(
                dateText.Trim(),
                "MM/dd/yyyy",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out DateTime reportDate))
        {
          dates.Add(
              reportDate.Date);
        }
      }

      return dates;
    }
  }
}