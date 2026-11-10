using CorteNext.Models;

namespace CorteNext.Data.Repositories
{
  public interface ICorteTrackerRepository
  {
    void MarkCompleted(
        DateTime date,
        ShiftType shift);
  }
}