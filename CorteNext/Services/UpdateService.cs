using CorteNext.Models;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Reflection;

namespace CorteNext.Services
{
  public sealed class UpdateService : IUpdateService
  {
    private readonly HttpClient _httpClient;
    private readonly string _versionUrl;

    public UpdateService(
        HttpClient httpClient,
        string versionUrl)
    {
      _httpClient =
          httpClient;

      _versionUrl =
          versionUrl;
    }

    // =========================================================
    // CURRENT VERSION
    // =========================================================

    public Version GetCurrentVersion()
    {
      return Assembly
          .GetExecutingAssembly()
          .GetName()
          .Version
          ?? new Version(1, 0, 0, 0);
    }

    // =========================================================
    // CHECK FOR UPDATE
    // =========================================================

    public async Task<UpdateInfo?>
        CheckForUpdateAsync()
    {
      if (string.IsNullOrWhiteSpace(
              _versionUrl))
      {
        return null;
      }

      try
      {
        UpdateInfo? updateInfo =
            await _httpClient
                .GetFromJsonAsync<UpdateInfo>(
                    _versionUrl);

        if (updateInfo == null)
        {
          return null;
        }

        if (string.IsNullOrWhiteSpace(
                updateInfo.Version))
        {
          return null;
        }

        if (!Version.TryParse(
                updateInfo.Version.Trim(),
                out Version? latestVersion))
        {
          return null;
        }

        Version currentVersion =
            GetCurrentVersion();

        if (latestVersion <=
            currentVersion)
        {
          return null;
        }

        if (string.IsNullOrWhiteSpace(
                updateInfo.InstallerUrl))
        {
          return null;
        }

        return updateInfo;
      }
      catch
      {
        /*
         * Update checking must never stop CorteNext
         * from starting.
         *
         * No internet, timeout, bad JSON, or server
         * problems simply mean no update notification.
         */
        return null;
      }
    }

    // =========================================================
    // DOWNLOAD INSTALLER
    // =========================================================

    public async Task<string> DownloadInstallerAsync(
        UpdateInfo updateInfo,
        IProgress<int>? progress = null)
    {
      ArgumentNullException.ThrowIfNull(
          updateInfo);

      if (string.IsNullOrWhiteSpace(
              updateInfo.InstallerUrl))
      {
        throw new InvalidOperationException(
            "The update does not contain an installer URL.");
      }

      if (!Uri.TryCreate(
              updateInfo.InstallerUrl,
              UriKind.Absolute,
              out Uri? installerUri))
      {
        throw new InvalidOperationException(
            "The installer URL is invalid.");
      }

      if (!string.Equals(
              installerUri.Scheme,
              Uri.UriSchemeHttps,
              StringComparison.OrdinalIgnoreCase))
      {
        throw new InvalidOperationException(
            "CorteNext updates must use HTTPS.");
      }

      string updateDirectory =
          Path.Combine(
              Path.GetTempPath(),
              "CorteNext",
              "Updates");

      Directory.CreateDirectory(
          updateDirectory);

      string safeVersion =
          string.Join(
              "_",
              updateInfo.Version.Split(
                  Path.GetInvalidFileNameChars()));

      string installerPath =
          Path.Combine(
              updateDirectory,
              $"CorteNext-Setup-{safeVersion}.exe");

      using HttpResponseMessage response =
          await _httpClient.GetAsync(
              installerUri,
              HttpCompletionOption.ResponseHeadersRead);

      response.EnsureSuccessStatusCode();

      long? totalBytes =
          response.Content.Headers.ContentLength;

      await using Stream inputStream =
          await response.Content
              .ReadAsStreamAsync();

      await using FileStream outputStream =
          new(
              installerPath,
              FileMode.Create,
              FileAccess.Write,
              FileShare.None,
              bufferSize: 81920,
              useAsync: true);

      byte[] buffer =
          new byte[81920];

      long downloadedBytes =
          0;

      int bytesRead;

      while ((bytesRead =
              await inputStream.ReadAsync(
                  buffer.AsMemory(
                      0,
                      buffer.Length))) > 0)
      {
        await outputStream.WriteAsync(
            buffer.AsMemory(
                0,
                bytesRead));

        downloadedBytes +=
            bytesRead;

        if (totalBytes.HasValue &&
            totalBytes.Value > 0)
        {
          int percentage =
              (int)Math.Round(
                  downloadedBytes * 100D /
                  totalBytes.Value);

          progress?.Report(
              Math.Clamp(
                  percentage,
                  0,
                  100));
        }
      }

      await outputStream.FlushAsync();

      if (!File.Exists(
              installerPath))
      {
        throw new InvalidOperationException(
            "The update installer was not downloaded.");
      }

      if (new FileInfo(
              installerPath).Length == 0)
      {
        File.Delete(
            installerPath);

        throw new InvalidOperationException(
            "The downloaded update installer is empty.");
      }

      progress?.Report(100);

      return installerPath;
    }

    // =========================================================
    // LAUNCH INSTALLER
    // =========================================================

    public void LaunchInstaller(
        string installerPath)
    {
      if (string.IsNullOrWhiteSpace(
              installerPath))
      {
        throw new ArgumentException(
            "Installer path is required.",
            nameof(installerPath));
      }

      if (!File.Exists(
              installerPath))
      {
        throw new FileNotFoundException(
            "The update installer could not be found.",
            installerPath);
      }

      ProcessStartInfo startInfo =
          new()
          {
            FileName =
                  installerPath,

            UseShellExecute =
                  true,

            WorkingDirectory =
                  Path.GetDirectoryName(
                      installerPath)
                  ?? Path.GetTempPath()
          };

      Process.Start(
          startInfo);
    }
  }
}