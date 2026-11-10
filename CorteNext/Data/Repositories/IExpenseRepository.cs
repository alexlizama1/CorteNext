using CorteNext.Models;

namespace CorteNext.Data.Repositories
{
  public interface IExpenseRepository
  {
    IReadOnlyList<ExpenseRecord> GetByDateAndShift(
        DateTime date,
        string shift);

    IReadOnlyList<ExpenseRecord> GetByDate(
        DateTime date);

    IReadOnlyList<ExpenseRecord> GetRecent(
        int count);

    IReadOnlyList<DateTime> GetExpenseDates(
        DateTime startDate,
        DateTime endDate);

    void Add(
        ExpenseRecord record);

    void Delete(
        int id);

    void DeleteNoExpense(
        DateTime date,
        string shift);
  }
}