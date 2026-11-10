using CorteNext.Models;

namespace CorteNext.Services
{
  public interface IUserService
  {
    IReadOnlyList<UserAccount> GetUsers();

    void AddUser(
        UserAccount user);

    void UpdateUser(
        UserAccount user);

    void UpdatePin(
        int userId,
        string pin);

    void DeleteUser(
        int id);
  }
}