namespace CorteNext.Models
{
  public sealed class UserAccount
  {
    public int Id { get; set; }

    public string FirstName { get; set; } =
        string.Empty;

    public string LastName { get; set; } =
        string.Empty;

    public string UserName { get; set; } =
        string.Empty;

    public string Password { get; set; } =
        string.Empty;

    public int AccessLevel { get; set; }

    public string DisplayName
    {
      get
      {
        string name =
            $"{FirstName} {LastName}".Trim();

        return string.IsNullOrWhiteSpace(name)
            ? UserName
            : name;
      }
    }
  }
}