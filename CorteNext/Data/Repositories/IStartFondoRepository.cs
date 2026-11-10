using CorteNext.Models;

namespace CorteNext.Data.Repositories
{
  public interface IStartFondoRepository
  {
    StartFondo? GetByShift(string shift);
  }
}