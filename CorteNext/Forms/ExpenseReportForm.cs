using CorteNext.Models;
using CorteNext.Services;

namespace CorteNext.Forms
{
  public partial class ExpenseReportForm : Form
  {
    private readonly IExpenseService _expenseService;
    private readonly ICorteService _corteService;

    private List<ExpenseRecord> _records = new();

    private DateTime _selectedDate =
        DateTime.Today;

    private string? _shiftFilter;

    public event EventHandler? ExpenseReportCompleted;

    // =========================================================
    // CONSTRUCTOR
    // =========================================================

    public ExpenseReportForm(
        IExpenseService expenseService,
        ICorteService corteService)
    {
      InitializeComponent();

      _expenseService =
          expenseService;

      _corteService =
          corteService;
    }

    // =========================================================
    // FORM LOAD
    // =========================================================

    private void ExpenseReportForm_Load(
        object sender,
        EventArgs e)
    {
      ConfigureGrid();

      LoadToday();
    }

    // =========================================================
    // CONFIGURE GRID
    // =========================================================

    private void ConfigureGrid()
    {
      dgvExpenses.AutoGenerateColumns =
          false;

      dgvExpenses.AllowUserToAddRows =
          false;

      dgvExpenses.AllowUserToDeleteRows =
          false;

      dgvExpenses.AllowUserToResizeRows =
          false;

      dgvExpenses.AllowUserToOrderColumns =
          false;

      dgvExpenses.MultiSelect =
          false;

      dgvExpenses.ReadOnly =
          true;

      dgvExpenses.RowHeadersVisible =
          false;

      dgvExpenses.SelectionMode =
          DataGridViewSelectionMode.FullRowSelect;

      dgvExpenses.RowTemplate.Height =
          58;

      dgvExpenses.ColumnHeadersHeight =
          60;

      dgvExpenses.ColumnHeadersHeightSizeMode =
          DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

      dgvExpenses.ClearSelection();

      UpdateDeleteButton();
    }

    // =========================================================
    // TODAY
    // =========================================================

    private void btnToday_Click(
        object sender,
        EventArgs e)
    {
      LoadToday();
    }

    private void LoadToday()
    {
      try
      {
        _selectedDate =
            DateTime.Today;

        _records =
            _expenseService
                .GetExpensesByDate(
                    _selectedDate)
                .ToList();

        _shiftFilter =
            null;

        lblReportMode.Text =
            "TODAY";

        lblDate.Text =
            _selectedDate.ToString(
                "dddd, MMMM d, yyyy");

        ApplyFilter();
      }
      catch (Exception ex)
      {
        ShowError(
            ex,
            "Unable to Load Expenses");
      }
    }

    // =========================================================
    // SELECT DATE
    // =========================================================

    private void btnSelectDate_Click(
        object sender,
        EventArgs e)
    {
      using CalendarForm calendar =
          new(
              _selectedDate,
              LoadAvailableExpenseDates);

      if (calendar.ShowDialog(this) !=
          DialogResult.OK)
      {
        return;
      }

      LoadDate(
          calendar.SelectedDate);
    }

    private IReadOnlyList<DateTime>
    LoadAvailableExpenseDates(
        DateTime displayedMonth)
    {
      DateTime firstDay =
          new(
              displayedMonth.Year,
              displayedMonth.Month,
              1);

      DateTime lastDay =
          firstDay
              .AddMonths(1)
              .AddDays(-1);

      return _expenseService.GetExpenseDates(
          firstDay,
          lastDay);
    }

    private void LoadDate(
        DateTime date)
    {
      try
      {
        _selectedDate =
            date.Date;

        _records =
            _expenseService
                .GetExpensesByDate(
                    _selectedDate)
                .ToList();

        _shiftFilter =
            null;

        lblReportMode.Text =
            "SELECTED DATE";

        lblDate.Text =
            _selectedDate.ToString(
                "dddd, MMMM d, yyyy");

        ApplyFilter();
      }
      catch (Exception ex)
      {
        ShowError(
            ex,
            "Unable to Load Expenses");
      }
    }

    // =========================================================
    // LAST 10
    // =========================================================

    private void btnLast10_Click(
        object sender,
        EventArgs e)
    {
      try
      {
        _records =
            _expenseService
                .GetRecentExpenses(10)
                .ToList();

        _shiftFilter =
            null;

        lblReportMode.Text =
            "LAST 10 EXPENSE RECORDS";

        lblDate.Text =
            string.Empty;

        ApplyFilter();
      }
      catch (Exception ex)
      {
        ShowError(
            ex,
            "Unable to Load Expenses");
      }
    }

    // =========================================================
    // ALL SHIFTS
    // =========================================================

    private void btnAll_Click(
        object sender,
        EventArgs e)
    {
      _shiftFilter =
          null;

      ApplyFilter();
    }

    // =========================================================
    // AM FILTER
    // =========================================================

    private void btnAM_Click(
        object sender,
        EventArgs e)
    {
      _shiftFilter =
          "am";

      ApplyFilter();
    }

    // =========================================================
    // PM FILTER
    // =========================================================

    private void btnPM_Click(
        object sender,
        EventArgs e)
    {
      _shiftFilter =
          "pm";

      ApplyFilter();
    }

    // =========================================================
    // APPLY FILTER
    // =========================================================

    private void ApplyFilter()
    {
      IEnumerable<ExpenseRecord> filtered =
          _records;

      if (!string.IsNullOrWhiteSpace(
              _shiftFilter))
      {
        filtered =
            filtered.Where(
                record =>
                    string.Equals(
                        record.Shift,
                        _shiftFilter,
                        StringComparison.OrdinalIgnoreCase));
      }

      List<ExpenseRecord> displayRecords =
          filtered.ToList();

      dgvExpenses.DataSource =
          null;

      dgvExpenses.DataSource =
          displayRecords;

      dgvExpenses.ClearSelection();

      // -----------------------------------------------------
      // Total
      // -----------------------------------------------------

      decimal total =
          displayRecords.Sum(
              record =>
                  record.Amount);

      lblTotalValue.Text =
          total.ToString("C2");

      // -----------------------------------------------------
      // Count
      // -----------------------------------------------------

      lblRecordCount.Text =
          displayRecords.Count == 1
              ? "1 RECORD"
              : $"{displayRecords.Count} RECORDS";

      UpdateDeleteButton();
    }

    // =========================================================
    // GRID SELECTION
    // =========================================================

    private void dgvExpenses_SelectionChanged(
        object sender,
        EventArgs e)
    {
      UpdateDeleteButton();
    }

    // =========================================================
    // GET SELECTED EXPENSE
    // =========================================================

    private ExpenseRecord? GetSelectedExpense()
    {
      if (dgvExpenses.SelectedRows.Count == 0)
      {
        return null;
      }

      return dgvExpenses
          .SelectedRows[0]
          .DataBoundItem
          as ExpenseRecord;
    }

    // =========================================================
    // CHECK IF EXPENSE IS LOCKED
    // =========================================================

    private bool IsExpenseLocked(
        ExpenseRecord expense)
    {
      if (string.IsNullOrWhiteSpace(
              expense.Shift))
      {
        return false;
      }

      /*
       * Expenses currently belong to AM or PM Corte.
       *
       * Once that Corte exists, the corresponding
       * expense history becomes read-only.
       */
      return _corteService.CorteExists(
          expense.Date,
          expense.Shift);
    }

    // =========================================================
    // UPDATE DELETE BUTTON
    // =========================================================

    private void UpdateDeleteButton()
    {
      ExpenseRecord? expense =
          GetSelectedExpense();

      // -----------------------------------------------------
      // Nothing selected
      // -----------------------------------------------------

      if (expense == null)
      {
        btnDelete.Enabled =
            false;

        btnDelete.Text =
            "DELETE SELECTED";

        btnDelete.BackColor =
            Color.FromArgb(
                156,
                163,
                175);

        return;
      }

      // -----------------------------------------------------
      // Corte already completed
      // -----------------------------------------------------

      bool locked =
          IsExpenseLocked(expense);

      if (locked)
      {
        btnDelete.Enabled =
            false;

        btnDelete.Text =
            "CORTE COMPLETED";

        btnDelete.BackColor =
            Color.FromArgb(
                156,
                163,
                175);

        return;
      }

      // -----------------------------------------------------
      // Expense can be deleted
      // -----------------------------------------------------

      btnDelete.Enabled =
          true;

      btnDelete.Text =
          "DELETE SELECTED";

      btnDelete.BackColor =
          Color.FromArgb(
              239,
              68,
              68);
    }

    // =========================================================
    // DELETE EXPENSE
    // =========================================================

    private void btnDelete_Click(
        object sender,
        EventArgs e)
    {
      ExpenseRecord? expense =
          GetSelectedExpense();

      if (expense == null)
      {
        return;
      }

      // -----------------------------------------------------
      // Second safety check
      // -----------------------------------------------------

      if (IsExpenseLocked(expense))
      {
        MessageBox.Show(
            "This expense belongs to a completed Corte " +
            "and cannot be deleted.",
            "Expense Locked",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning);

        return;
      }

      DialogResult result =
          MessageBox.Show(
              $"Delete this expense?\r\n\r\n" +
              $"Company: {expense.Company}\r\n" +
              $"Description: {expense.Description}\r\n" +
              $"Amount: {expense.Amount:C2}\r\n" +
              $"Shift: {GetShiftDisplayName(expense.Shift)}",
              "Delete Expense",
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Question);

      if (result !=
          DialogResult.Yes)
      {
        return;
      }

      try
      {
        _expenseService.DeleteExpense(
            expense.Id);

        ReloadCurrentView();
      }
      catch (Exception ex)
      {
        ShowError(
            ex,
            "Unable to Delete Expense");
      }
    }

    // =========================================================
    // RELOAD CURRENT VIEW
    // =========================================================

    private void ReloadCurrentView()
    {
      try
      {
        if (string.Equals(
                lblReportMode.Text,
                "LAST 10 EXPENSE RECORDS",
                StringComparison.Ordinal))
        {
          _records =
              _expenseService
                  .GetRecentExpenses(10)
                  .ToList();

          ApplyFilter();

          return;
        }

        _records =
            _expenseService
                .GetExpensesByDate(
                    _selectedDate)
                .ToList();

        ApplyFilter();
      }
      catch (Exception ex)
      {
        ShowError(
            ex,
            "Unable to Reload Expenses");
      }
    }

    // =========================================================
    // SHIFT DISPLAY
    // =========================================================

    private static string GetShiftDisplayName(
        string shift)
    {
      return shift.ToLowerInvariant() switch
      {
        "am" =>
            "AM",

        "pm" =>
            "PM",

        _ =>
            shift.ToUpperInvariant()
      };
    }

    // =========================================================
    // DONE
    // =========================================================

    private void btnDone_Click(
        object sender,
        EventArgs e)
    {
      ExpenseReportCompleted?.Invoke(
          this,
          EventArgs.Empty);

      Close();
    }

    // =========================================================
    // ERROR
    // =========================================================

    private static void ShowError(
        Exception ex,
        string title)
    {
      MessageBox.Show(
          ex.Message,
          title,
          MessageBoxButtons.OK,
          MessageBoxIcon.Error);
    }
  }
}