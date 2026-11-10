using CorteNext.Models;

namespace CorteNext.Data.Repositories
{
  public interface ICorteRepository
  {
    void Add(
        CorteRecord record);

    CorteRecord? GetByDateAndShift(
        DateTime date,
        string shift);

    IReadOnlyList<CorteRecord> GetByDate(
        DateTime date);

    IReadOnlyList<CorteRecord> GetRecent(
        int count);

    IReadOnlyList<DateTime> GetReportDates(
        DateTime startDate,
        DateTime endDate);
  }
}