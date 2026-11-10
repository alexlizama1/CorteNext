using CorteNext.Data.Repositories;
using CorteNext.Models;

namespace CorteNext.Services
{
  public sealed class ExpenseService : IExpenseService
  {
    private readonly IExpenseRepository _expenseRepository;

    public ExpenseService(
        IExpenseRepository expenseRepository)
    {
      _expenseRepository = expenseRepository;
    }

    // =========================================================
    // GET EXPENSES
    // =========================================================

    public IReadOnlyList<ExpenseRecord> GetExpenses(
        DateTime date,
        string shift)
    {
      return _expenseRepository.GetByDateAndShift(
          date,
          shift);
    }

    // =========================================================
    // TOTAL
    // =========================================================

    public decimal GetTotal(
        DateTime date,
        string shift)
    {
      IReadOnlyList<ExpenseRecord> records =
          GetExpenses(
              date,
              shift);

      return records.Sum(
          expense => expense.Amount);
    }

    // =========================================================
    // ADD
    // =========================================================

    public void AddExpense(
        ExpenseRecord record)
    {
      ArgumentNullException.ThrowIfNull(record);

      ValidateExpense(record);

      // If NO EXPENSE was previously selected,
      // remove that marker before adding a real expense.
      _expenseRepository.DeleteNoExpense(
          record.Date,
          record.Shift);

      _expenseRepository.Add(
          record);
    }

    // =========================================================
    // NO EXPENSE
    // =========================================================

    public void AddNoExpense(
        DateTime date,
        string shift)
    {
      if (string.IsNullOrWhiteSpace(shift))
      {
        throw new InvalidOperationException(
            "Expense shift is required.");
      }

      ExpenseRecord record = new()
      {
        Date = date,

        Time =
              DateTime.Now.ToShortTimeString(),

        Amount = 0M,

        Company =
              "No Expense",

        Description =
              "No Expense",

        Shift =
              shift
      };

      _expenseRepository.Add(record);
    }

    // =========================================================
    // DELETE
    // =========================================================

    public void DeleteExpense(int id)
    {
      if (id <= 0)
      {
        throw new ArgumentOutOfRangeException(
            nameof(id),
            "A valid expense ID is required.");
      }

      _expenseRepository.Delete(id);
    }

    // =========================================================
    // VALIDATION
    // =========================================================

    private static void ValidateExpense(
        ExpenseRecord record)
    {
      if (record.Amount <= 0)
      {
        throw new InvalidOperationException(
            "Expense amount must be greater than zero.");
      }

      if (string.IsNullOrWhiteSpace(
              record.Company))
      {
        throw new InvalidOperationException(
            "Company is required.");
      }

      if (string.IsNullOrWhiteSpace(
              record.Description))
      {
        throw new InvalidOperationException(
            "Description is required.");
      }

      if (string.IsNullOrWhiteSpace(
              record.Shift))
      {
        throw new InvalidOperationException(
            "Expense shift is required.");
      }
    }

    public IReadOnlyList<ExpenseRecord> GetExpensesByDate(
    DateTime date)
    {
      return _expenseRepository.GetByDate(
          date);
    }

    public IReadOnlyList<ExpenseRecord> GetRecentExpenses(
        int count)
    {
      return _expenseRepository.GetRecent(
          count);
    }

    public IReadOnlyList<DateTime> GetExpenseDates(
    DateTime startDate,
    DateTime endDate)
    {
      startDate =
          startDate.Date;

      endDate =
          endDate.Date;

      if (endDate < startDate)
      {
        throw new ArgumentException(
            "The ending date cannot be earlier than the starting date.");
      }

      return _expenseRepository.GetExpenseDates(
          startDate,
          endDate);
    }
  }
}