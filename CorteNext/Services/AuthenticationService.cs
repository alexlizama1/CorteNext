using CorteNext.Data.Repositories;
using CorteNext.Models;

namespace CorteNext.Services
{
  public sealed class AuthenticationService
      : IAuthenticationService
  {
    private readonly IUserRepository _userRepository;

    public AuthenticationService(
        IUserRepository userRepository)
    {
      _userRepository = userRepository;
    }

    public IReadOnlyList<UserAccount> GetUsers()
    {
      return _userRepository.GetAll();
    }

    public UserAccount? Authenticate(
        string userName,
        string password)
    {
      if (string.IsNullOrWhiteSpace(userName))
        return null;

      if (string.IsNullOrWhiteSpace(password))
        return null;

      UserAccount? user =
          _userRepository.GetByUserName(
              userName);

      if (user == null)
        return null;

      if (user.Password != password)
        return null;

      return user;
    }
  }
}