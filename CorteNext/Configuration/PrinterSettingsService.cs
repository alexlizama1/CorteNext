using CorteNext.Data.Repositories;
using System.Drawing.Printing;

namespace CorteNext.Services
{
  public sealed class PrinterSettingsService
      : IPrinterSettingsService
  {
    private readonly IPrinterRepository _printerRepository;

    private string? _receiptPrinterName;

    public PrinterSettingsService(
        IPrinterRepository printerRepository)
    {
      _printerRepository =
          printerRepository;

      _receiptPrinterName =
          _printerRepository
              .GetReceiptPrinter();
    }

    public string? ReceiptPrinterName =>
        _receiptPrinterName;

    public IReadOnlyList<string> GetInstalledPrinters()
    {
      List<string> printers = new();

      foreach (string printerName
               in PrinterSettings.InstalledPrinters)
      {
        printers.Add(
            printerName);
      }

      return printers;
    }

    public void SetReceiptPrinter(
        string printerName)
    {
      if (string.IsNullOrWhiteSpace(
              printerName))
      {
        throw new InvalidOperationException(
            "Select a printer.");
      }

      PrinterSettings settings =
          new()
          {
            PrinterName =
                  printerName
          };

      if (!settings.IsValid)
      {
        throw new InvalidOperationException(
            "The selected printer is not valid.");
      }

      _printerRepository
          .SaveReceiptPrinter(
              printerName);

      _receiptPrinterName =
          printerName;
    }

    public bool IsReceiptPrinterValid()
    {
      if (string.IsNullOrWhiteSpace(
              _receiptPrinterName))
      {
        return false;
      }

      PrinterSettings settings =
          new()
          {
            PrinterName =
                  _receiptPrinterName
          };

      return settings.IsValid;
    }
  }
}