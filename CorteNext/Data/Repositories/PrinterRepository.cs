using System.Data.SQLite;

namespace CorteNext.Data.Repositories
{
  public sealed class PrinterRepository
      : IPrinterRepository
  {
    private readonly IDatabaseConnectionFactory _connectionFactory;

    public PrinterRepository(
        IDatabaseConnectionFactory connectionFactory)
    {
      _connectionFactory = connectionFactory;
    }

    public string? GetReceiptPrinter()
    {
      using SQLiteConnection connection =
          _connectionFactory.CreateConnection();

      connection.Open();

      const string sql = """
                SELECT printerName
                FROM printerTB
                WHERE id = 1
                LIMIT 1;
                """;

      using SQLiteCommand command =
          new(sql, connection);

      object? result =
          command.ExecuteScalar();

      if (result == null ||
          result == DBNull.Value)
      {
        return null;
      }

      string printerName =
          Convert.ToString(result)
          ?? string.Empty;

      return string.IsNullOrWhiteSpace(
          printerName)
              ? null
              : printerName;
    }

    public void SaveReceiptPrinter(
        string printerName)
    {
      if (string.IsNullOrWhiteSpace(
              printerName))
      {
        throw new ArgumentException(
            "Printer name cannot be empty.",
            nameof(printerName));
      }

      using SQLiteConnection connection =
          _connectionFactory.CreateConnection();

      connection.Open();

      const string updateSql = """
                UPDATE printerTB
                SET printerName = @printerName
                WHERE id = 1;
                """;

      using SQLiteCommand updateCommand =
          new(updateSql, connection);

      updateCommand.Parameters.AddWithValue(
          "@printerName",
          printerName);

      int rowsUpdated =
          updateCommand.ExecuteNonQuery();

      if (rowsUpdated > 0)
        return;

      const string insertSql = """
                INSERT INTO printerTB
                (
                    id,
                    printerName
                )
                VALUES
                (
                    1,
                    @printerName
                );
                """;

      using SQLiteCommand insertCommand =
          new(insertSql, connection);

      insertCommand.Parameters.AddWithValue(
          "@printerName",
          printerName);

      insertCommand.ExecuteNonQuery();
    }
  }
}