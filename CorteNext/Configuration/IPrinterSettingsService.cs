namespace CorteNext.Services
{
  public interface IPrinterSettingsService
  {
    string? ReceiptPrinterName { get; }

    IReadOnlyList<string> GetInstalledPrinters();

    void SetReceiptPrinter(
        string printerName);

    bool IsReceiptPrinterValid();
  }
}