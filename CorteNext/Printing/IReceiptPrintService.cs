using CorteNext.Models;

namespace CorteNext.Printing
{
  public interface IReceiptPrintService
  {
    void PrintCorte(CorteRecord record);
  }
}