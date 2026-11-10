using System.Data.SQLite;

namespace CorteNext.Data
{
  public interface IDatabaseConnectionFactory
  {
    SQLiteConnection CreateConnection();
  }
}