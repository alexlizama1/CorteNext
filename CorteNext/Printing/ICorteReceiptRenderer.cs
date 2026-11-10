using CorteNext.Models;

namespace CorteNext.Printing
{
  public interface ICorteReceiptRenderer
  {
    Bitmap Render(CorteRecord record);
  }
}