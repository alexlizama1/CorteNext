namespace CorteNext.Models
{
  public sealed class UserSession
  {
    public UserAccount? CurrentUser { get; private set; }

    public bool IsLoggedIn =>
        CurrentUser != null;

    public bool IsAdmin =>
        CurrentUser?.AccessLevel > 4;

    public void Login(UserAccount user)
    {
      ArgumentNullException.ThrowIfNull(user);

      CurrentUser = user;
    }

    public void Logout()
    {
      CurrentUser = null;
    }
  }
}