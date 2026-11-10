using CorteNext.Models;

namespace CorteNext.Services
{
  public interface IFondoService
  {
    FondoRecord? GetFondo(
        DateTime date,
        string shift);

    StartFondo? GetStartingFondo(
        string shift);

    bool FondoExists(
    DateTime date,
    string shift);

    void SaveFondo(
        FondoRecord record);

  }
}