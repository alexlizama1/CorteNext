using CorteNext.Models;

namespace CorteNext.Data.Repositories
{
  public interface IFondoTrackerRepository
  {
    void MarkCompleted(
        DateTime date,
        ShiftType shift);
  }
}