using CorteNext.Data.Repositories;
using CorteNext.Models;

namespace CorteNext.Services
{
  public sealed class UserService : IUserService
  {
    private readonly IUserRepository _userRepository;

    public UserService(
        IUserRepository userRepository)
    {
      _userRepository = userRepository;
    }

    // =========================================================
    // GET USERS
    // =========================================================

    public IReadOnlyList<UserAccount> GetUsers()
    {
      return _userRepository.GetAll();
    }

    // =========================================================
    // ADD USER
    // =========================================================

    public void AddUser(
        UserAccount user)
    {
      ArgumentNullException.ThrowIfNull(user);

      ValidateProfile(user);
      ValidatePin(user.Password);

      UserAccount? existing =
          _userRepository.GetByUserName(
              user.UserName);

      if (existing != null)
      {
        throw new InvalidOperationException(
            "That username already exists.");
      }

      _userRepository.Add(user);
    }

    // =========================================================
    // UPDATE USER
    // =========================================================

    public void UpdateUser(
        UserAccount user)
    {
      ArgumentNullException.ThrowIfNull(user);

      if (user.Id <= 0)
      {
        throw new InvalidOperationException(
            "A valid user is required.");
      }

      ValidateProfile(user);

      UserAccount? existing =
          _userRepository.GetByUserName(
              user.UserName);

      if (existing != null &&
          existing.Id != user.Id)
      {
        throw new InvalidOperationException(
            "That username is already being used.");
      }

      // Updates profile only.
      // Existing PIN is not changed here.
      _userRepository.Update(user);
    }

    // =========================================================
    // UPDATE PIN
    // =========================================================

    public void UpdatePin(
        int userId,
        string pin)
    {
      if (userId <= 0)
      {
        throw new InvalidOperationException(
            "A valid user is required.");
      }

      ValidatePin(pin);

      _userRepository.UpdatePin(
          userId,
          pin);
    }

    // =========================================================
    // DELETE USER
    // =========================================================

    public void DeleteUser(
        int id)
    {
      if (id <= 0)
      {
        throw new ArgumentOutOfRangeException(
            nameof(id),
            "A valid user ID is required.");
      }

      _userRepository.Delete(id);
    }

    // =========================================================
    // PROFILE VALIDATION
    // =========================================================

    private static void ValidateProfile(
        UserAccount user)
    {
      if (string.IsNullOrWhiteSpace(
              user.FirstName))
      {
        throw new InvalidOperationException(
            "First name is required.");
      }

      if (string.IsNullOrWhiteSpace(
              user.LastName))
      {
        throw new InvalidOperationException(
            "Last name is required.");
      }

      if (string.IsNullOrWhiteSpace(
              user.UserName))
      {
        throw new InvalidOperationException(
            "Username is required.");
      }

      if (user.AccessLevel <= 0)
      {
        throw new InvalidOperationException(
            "Access level is required.");
      }
    }

    // =========================================================
    // PIN VALIDATION
    // =========================================================

    private static void ValidatePin(
        string pin)
    {
      if (string.IsNullOrWhiteSpace(pin))
      {
        throw new InvalidOperationException(
            "PIN is required.");
      }

      if (pin.Length != 6)
      {
        throw new InvalidOperationException(
            "PIN must contain exactly 6 digits.");
      }

      if (!pin.All(char.IsDigit))
      {
        throw new InvalidOperationException(
            "PIN must contain numbers only.");
      }
    }
  }
}