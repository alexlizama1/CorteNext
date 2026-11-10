using CorteNext.Models;

namespace CorteNext.Services
{
  public interface IExpenseService
  {
    IReadOnlyList<ExpenseRecord> GetExpenses(
        DateTime date,
        string shift);

    IReadOnlyList<ExpenseRecord> GetExpensesByDate(
        DateTime date);

    IReadOnlyList<ExpenseRecord> GetRecentExpenses(
        int count);

    IReadOnlyList<DateTime> GetExpenseDates(
        DateTime startDate,
        DateTime endDate);

    decimal GetTotal(
        DateTime date,
        string shift);

    void AddExpense(
        ExpenseRecord record);

    void AddNoExpense(
        DateTime date,
        string shift);

    void DeleteExpense(
        int id);
  }
}