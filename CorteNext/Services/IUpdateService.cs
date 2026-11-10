using CorteNext.Models;

namespace CorteNext.Services
{
  public interface IUpdateService
  {
    Version GetCurrentVersion();

    Task<UpdateInfo?> CheckForUpdateAsync();

    Task<string> DownloadInstallerAsync(
        UpdateInfo updateInfo,
        IProgress<int>? progress = null);

    void LaunchInstaller(
        string installerPath);
  }
}