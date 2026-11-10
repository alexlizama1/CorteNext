namespace CorteNext.Configuration
{
  public sealed class DatabaseSettings
  {
    public string DatabasePath { get; }

    public DatabaseSettings(string databasePath)
    {
      if (string.IsNullOrWhiteSpace(databasePath))
      {
        throw new ArgumentException(
            "Database path cannot be empty.",
            nameof(databasePath));
      }

      DatabasePath = databasePath;
    }

    public string ConnectionString =>
        $"Data Source={DatabasePath};Version=3;";
  }
}