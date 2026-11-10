using CorteNext.Models;

namespace CorteNext.Services
{
  public interface ITrackerService
  {
    DailyTracker GetDailyTracker(
        DateTime date);
  }
}