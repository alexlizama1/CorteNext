using CorteNext.Models;

namespace CorteNext.Services
{
  public interface IAuthenticationService
  {
    IReadOnlyList<UserAccount> GetUsers();

    UserAccount? Authenticate(
        string userName,
        string password);
  }
}