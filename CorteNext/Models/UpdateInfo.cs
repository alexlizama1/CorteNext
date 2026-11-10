namespace CorteNext.Models
{
  public sealed class UpdateInfo
  {
    public string Version { get; set; } =
        string.Empty;

    public string InstallerUrl { get; set; } =
        string.Empty;

    public string ReleaseNotes { get; set; } =
        string.Empty;
  }
}