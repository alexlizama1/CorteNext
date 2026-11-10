using CorteNext.Models;

namespace CorteNext.Data.Repositories
{
  public interface IUserRepository
  {
    // =========================================================
    // GET ALL USERS
    // =========================================================

    IReadOnlyList<UserAccount> GetAll();

    // =========================================================
    // GET USER BY USERNAME
    // =========================================================

    UserAccount? GetByUserName(
        string userName);

    // =========================================================
    // ADD USER
    // =========================================================

    void Add(
        UserAccount user);

    // =========================================================
    // UPDATE USER PROFILE
    // Does NOT change the user's PIN.
    // =========================================================

    void Update(
        UserAccount user);

    // =========================================================
    // UPDATE PIN
    // =========================================================

    void UpdatePin(
        int userId,
        string pin);

    // =========================================================
    // DELETE USER
    // =========================================================

    void Delete(
        int id);
  }
}