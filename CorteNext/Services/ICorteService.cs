using CorteNext.Models;

namespace CorteNext.Services
{
  public interface ICorteService
  {
    CorteRecord Calculate(
        CorteRecord record);

    void SaveCorte(
        CorteRecord record);

    CorteRecord? GetCorte(
        DateTime date,
        string shift);

    bool CorteExists(
        DateTime date,
        string shift);

    IReadOnlyList<CorteRecord> GetCortesByDate(
        DateTime date);

    IReadOnlyList<CorteRecord> GetRecentCortes(
        int count);

    IReadOnlyList<DateTime> GetCorteDates(
        DateTime startDate,
        DateTime endDate);
  }
}