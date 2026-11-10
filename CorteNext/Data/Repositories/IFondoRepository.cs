using CorteNext.Models;

namespace CorteNext.Data.Repositories
{
  public interface IFondoRepository
  {
    FondoRecord? GetByDateAndShift(
        DateTime date,
        string shift);
    bool Exists(
DateTime date,
string shift);

    void Add(FondoRecord record);


  }
}