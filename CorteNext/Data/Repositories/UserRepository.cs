using CorteNext.Models;
using System.Data.SQLite;

namespace CorteNext.Data.Repositories
{
  public sealed class UserRepository : IUserRepository
  {
    private readonly IDatabaseConnectionFactory _connectionFactory;

    public UserRepository(
        IDatabaseConnectionFactory connectionFactory)
    {
      _connectionFactory = connectionFactory;
    }

    // =========================================================
    // GET ALL USERS
    // Does not retrieve passwords.
    // =========================================================

    public IReadOnlyList<UserAccount> GetAll()
    {
      List<UserAccount> users = new();

      using SQLiteConnection connection =
          _connectionFactory.CreateConnection();

      connection.Open();

      const string sql = """
                SELECT
                    id,
                    firstname,
                    lastname,
                    username,
                    accesslevel
                FROM userAdminTB
                ORDER BY firstname, lastname;
                """;

      using SQLiteCommand command =
          new(sql, connection);

      using SQLiteDataReader reader =
          command.ExecuteReader();

      while (reader.Read())
      {
        users.Add(
            new UserAccount
            {
              Id =
                    Convert.ToInt32(
                        reader["id"]),

              FirstName =
                    Convert.ToString(
                        reader["firstname"])
                    ?? string.Empty,

              LastName =
                    Convert.ToString(
                        reader["lastname"])
                    ?? string.Empty,

              UserName =
                    Convert.ToString(
                        reader["username"])
                    ?? string.Empty,

              AccessLevel =
                    Convert.ToInt32(
                        reader["accesslevel"])
            });
      }

      return users;
    }

    // =========================================================
    // GET USER BY USERNAME
    //
    // This method retrieves the password because it is used
    // by AuthenticationService during login.
    // =========================================================

    public UserAccount? GetByUserName(
        string userName)
    {
      using SQLiteConnection connection =
          _connectionFactory.CreateConnection();

      connection.Open();

      const string sql = """
                SELECT
                    id,
                    firstname,
                    lastname,
                    username,
                    password,
                    accesslevel
                FROM userAdminTB
                WHERE username = @username
                LIMIT 1;
                """;

      using SQLiteCommand command =
          new(sql, connection);

      command.Parameters.AddWithValue(
          "@username",
          userName);

      using SQLiteDataReader reader =
          command.ExecuteReader();

      if (!reader.Read())
      {
        return null;
      }

      return new UserAccount
      {
        Id =
              Convert.ToInt32(
                  reader["id"]),

        FirstName =
              Convert.ToString(
                  reader["firstname"])
              ?? string.Empty,

        LastName =
              Convert.ToString(
                  reader["lastname"])
              ?? string.Empty,

        UserName =
              Convert.ToString(
                  reader["username"])
              ?? string.Empty,

        Password =
              Convert.ToString(
                  reader["password"])
              ?? string.Empty,

        AccessLevel =
              Convert.ToInt32(
                  reader["accesslevel"])
      };
    }

    // =========================================================
    // ADD USER
    // =========================================================

    public void Add(
        UserAccount user)
    {
      using SQLiteConnection connection =
          _connectionFactory.CreateConnection();

      connection.Open();

      const string sql = """
                INSERT INTO userAdminTB
                (
                    firstname,
                    lastname,
                    username,
                    password,
                    accesslevel,
                    datecreated,
                    timecreated
                )
                VALUES
                (
                    @firstname,
                    @lastname,
                    @username,
                    @password,
                    @accesslevel,
                    @datecreated,
                    @timecreated
                );
                """;

      using SQLiteCommand command =
          new(sql, connection);

      command.Parameters.AddWithValue(
          "@firstname",
          user.FirstName);

      command.Parameters.AddWithValue(
          "@lastname",
          user.LastName);

      command.Parameters.AddWithValue(
          "@username",
          user.UserName);

      command.Parameters.AddWithValue(
          "@password",
          user.Password);

      command.Parameters.AddWithValue(
          "@accesslevel",
          user.AccessLevel);

      command.Parameters.AddWithValue(
          "@datecreated",
          DateTime.Now.ToString(
              "MM/dd/yyyy"));

      command.Parameters.AddWithValue(
          "@timecreated",
          DateTime.Now.ToShortTimeString());

      command.ExecuteNonQuery();
    }

    // =========================================================
    // UPDATE USER PROFILE
    //
    // Important:
    // Password is NOT updated here.
    // =========================================================

    public void Update(
        UserAccount user)
    {
      using SQLiteConnection connection =
          _connectionFactory.CreateConnection();

      connection.Open();

      const string sql = """
                UPDATE userAdminTB
                SET
                    firstname = @firstname,
                    lastname = @lastname,
                    username = @username,
                    accesslevel = @accesslevel
                WHERE id = @id;
                """;

      using SQLiteCommand command =
          new(sql, connection);

      command.Parameters.AddWithValue(
          "@firstname",
          user.FirstName);

      command.Parameters.AddWithValue(
          "@lastname",
          user.LastName);

      command.Parameters.AddWithValue(
          "@username",
          user.UserName);

      command.Parameters.AddWithValue(
          "@accesslevel",
          user.AccessLevel);

      command.Parameters.AddWithValue(
          "@id",
          user.Id);

      command.ExecuteNonQuery();
    }

    // =========================================================
    // UPDATE PIN
    //
    // Only called when the administrator explicitly changes
    // the user's PIN.
    // =========================================================

    public void UpdatePin(
        int userId,
        string pin)
    {
      using SQLiteConnection connection =
          _connectionFactory.CreateConnection();

      connection.Open();

      const string sql = """
                UPDATE userAdminTB
                SET password = @password
                WHERE id = @id;
                """;

      using SQLiteCommand command =
          new(sql, connection);

      command.Parameters.AddWithValue(
          "@password",
          pin);

      command.Parameters.AddWithValue(
          "@id",
          userId);

      command.ExecuteNonQuery();
    }

    // =========================================================
    // DELETE USER
    // =========================================================

    public void Delete(
        int id)
    {
      using SQLiteConnection connection =
          _connectionFactory.CreateConnection();

      connection.Open();

      const string sql = """
                DELETE FROM userAdminTB
                WHERE id = @id;
                """;

      using SQLiteCommand command =
          new(sql, connection);

      command.Parameters.AddWithValue(
          "@id",
          id);

      command.ExecuteNonQuery();
    }
  }
}