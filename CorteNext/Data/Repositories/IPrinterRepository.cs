namespace CorteNext.Data.Repositories
{
  public interface IPrinterRepository
  {
    string? GetReceiptPrinter();

    void SaveReceiptPrinter(
        string printerName);
  }
}