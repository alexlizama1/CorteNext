using CorteNext.Configuration;
using System.Data.SQLite;

namespace CorteNext.Data
{
  public sealed class SQLiteConnectionFactory : IDatabaseConnectionFactory
  {
    private readonly DatabaseSettings _settings;

    public SQLiteConnectionFactory(DatabaseSettings settings)
    {
      _settings = settings;
    }

    public SQLiteConnection CreateConnection()
    {
      return new SQLiteConnection(_settings.ConnectionString);
    }
  }
}