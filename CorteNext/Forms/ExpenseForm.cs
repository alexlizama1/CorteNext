using CorteNext.Models;
using CorteNext.Services;

namespace CorteNext.Forms
{
  public partial class ExpenseForm : Form
  {
    private readonly IExpenseService _expenseService;
    private readonly ICorteService _corteService;
    private readonly string _shift;

    private string _company = string.Empty;
    private string _description = string.Empty;

    private int? _selectedExpenseId;
    private bool _corteCompleted;

    public decimal TotalExpenses { get; private set; }

    // =========================================================
    // CONSTRUCTOR
    // =========================================================

    public ExpenseForm(
        IExpenseService expenseService,
        ICorteService corteService,
        string shift)
    {
      InitializeComponent();

      _expenseService = expenseService;
      _corteService = corteService;
      _shift = shift;
    }

    // =========================================================
    // LOAD
    // =========================================================

    private void ExpenseForm_Load(
        object sender,
        EventArgs e)
    {
      ConfigureShift();

      lblDate.Text =
          DateTime.Today.ToString(
              "dddd, MMMM d, yyyy");

      ConfigureGrid();

      CheckCorteStatus();

      LoadExpenses();

      ClearEntryFields();

      ApplyEditState();
    }

    // =========================================================
    // SHIFT
    // =========================================================

    private void ConfigureShift()
    {
      lblTitle.Text =
          _shift.ToLowerInvariant() switch
          {
            "am" =>
                      "AM EXPENSES",

            "pm" =>
                      "PM EXPENSES",

            _ =>
                      "EXPENSES"
          };
    }

    // =========================================================
    // CHECK CORTE STATUS
    // =========================================================

    private void CheckCorteStatus()
    {
      try
      {
        _corteCompleted =
            _corteService.CorteExists(
                DateTime.Today,
                _shift);
      }
      catch (Exception ex)
      {
        _corteCompleted = true;

        MessageBox.Show(
            ex.Message,
            "Unable to Check Corte Status",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
      }
    }

    // =========================================================
    // APPLY EDIT STATE
    // =========================================================

    private void ApplyEditState()
    {
      if (_corteCompleted)
      {
        lblTitle.Text +=
            " - COMPLETED";

        lblTitle.ForeColor =
            Color.FromArgb(
                253,
                224,
                71);

        amountExpense.Enabled =
            false;

        btnCompany.Enabled =
            false;

        btnDescription.Enabled =
            false;

        btnAdd.Enabled =
            false;

        btnNoExpense.Enabled =
            false;

        btnDelete.Enabled =
            false;

        btnAdd.Text =
            "CORTE COMPLETED";

        btnDelete.Text =
            "CORTE COMPLETED";

        btnAdd.BackColor =
            Color.FromArgb(
                156,
                163,
                175);

        btnNoExpense.BackColor =
            Color.FromArgb(
                156,
                163,
                175);

        btnDelete.BackColor =
            Color.FromArgb(
                156,
                163,
                175);

        return;
      }

      amountExpense.Enabled =
          true;

      btnCompany.Enabled =
          true;

      btnDescription.Enabled =
          true;

      btnNoExpense.Enabled =
          true;

      btnAdd.Text =
          "ADD EXPENSE";

      btnDelete.Text =
          "DELETE";

      UpdateAddButton();
      UpdateDeleteButton();
    }

    // =========================================================
    // GRID
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

      dgvExpenses.MultiSelect =
          false;

      dgvExpenses.ReadOnly =
          true;

      dgvExpenses.SelectionMode =
          DataGridViewSelectionMode.FullRowSelect;

      dgvExpenses.RowHeadersVisible =
          false;

      dgvExpenses.RowTemplate.Height =
          58;

      dgvExpenses.ColumnHeadersHeight =
          60;

      dgvExpenses.ColumnHeadersHeightSizeMode =
          DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
    }

    // =========================================================
    // LOAD EXPENSES
    // =========================================================

    private void LoadExpenses()
    {
      try
      {
        IReadOnlyList<ExpenseRecord> records =
            _expenseService.GetExpenses(
                DateTime.Today,
                _shift);

        dgvExpenses.DataSource =
            null;

        dgvExpenses.DataSource =
            records.ToList();

        TotalExpenses =
            records.Sum(
                expense =>
                    expense.Amount);

        lblTotalValue.Text =
            TotalExpenses.ToString("C2");

        dgvExpenses.ClearSelection();

        _selectedExpenseId =
            null;

        UpdateDeleteButton();
      }
      catch (Exception ex)
      {
        MessageBox.Show(
            ex.Message,
            "Unable to Load Expenses",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
      }
    }

    // =========================================================
    // COMPANY
    // =========================================================

    private void btnCompany_Click(
        object sender,
        EventArgs e)
    {
      if (_corteCompleted)
        return;

      using KeyboardForm keyboard =
          new(_company);

      if (keyboard.ShowDialog(this) !=
          DialogResult.OK)
      {
        return;
      }

      _company =
          keyboard.Value.Trim();

      btnCompany.Text =
          string.IsNullOrWhiteSpace(
              _company)
              ? "TOUCH TO ENTER COMPANY"
              : _company;

      UpdateAddButton();
    }

    // =========================================================
    // DESCRIPTION
    // =========================================================

    private void btnDescription_Click(
        object sender,
        EventArgs e)
    {
      if (_corteCompleted)
        return;

      using KeyboardForm keyboard =
          new(_description);

      if (keyboard.ShowDialog(this) !=
          DialogResult.OK)
      {
        return;
      }

      _description =
          keyboard.Value.Trim();

      btnDescription.Text =
          string.IsNullOrWhiteSpace(
              _description)
              ? "TOUCH TO ENTER DESCRIPTION"
              : _description;

      UpdateAddButton();
    }

    // =========================================================
    // AMOUNT
    // =========================================================

    private void amountExpense_ValueChanged(
        object? sender,
        EventArgs e)
    {
      UpdateAddButton();
    }

    // =========================================================
    // ADD BUTTON
    // =========================================================

    private void UpdateAddButton()
    {
      if (_corteCompleted)
      {
        btnAdd.Enabled = false;

        btnAdd.Text =
            "CORTE COMPLETED";

        btnAdd.BackColor =
            Color.FromArgb(
                156,
                163,
                175);

        return;
      }

      btnAdd.Enabled =
          amountExpense.Value > 0 &&
          !string.IsNullOrWhiteSpace(
              _company) &&
          !string.IsNullOrWhiteSpace(
              _description);

      btnAdd.Text =
          "ADD EXPENSE";

      btnAdd.BackColor =
          btnAdd.Enabled
              ? Color.FromArgb(
                  34,
                  197,
                  94)
              : Color.FromArgb(
                  156,
                  163,
                  175);
    }

    // =========================================================
    // ADD EXPENSE
    // =========================================================

    private void btnAdd_Click(
        object sender,
        EventArgs e)
    {
      if (_corteCompleted)
      {
        ShowLockedMessage();
        return;
      }

      try
      {
        ExpenseRecord record = new()
        {
          Date =
                DateTime.Today,

          Time =
                DateTime.Now.ToShortTimeString(),

          Amount =
                amountExpense.Value,

          Company =
                _company,

          Description =
                _description,

          Shift =
                _shift
        };

        _expenseService.AddExpense(
            record);

        LoadExpenses();

        ClearEntryFields();
      }
      catch (Exception ex)
      {
        MessageBox.Show(
            ex.Message,
            "Unable to Add Expense",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
      }
    }

    // =========================================================
    // NO EXPENSE
    // =========================================================

    private void btnNoExpense_Click(
        object sender,
        EventArgs e)
    {
      if (_corteCompleted)
      {
        ShowLockedMessage();
        return;
      }

      try
      {
        IReadOnlyList<ExpenseRecord> existing =
            _expenseService.GetExpenses(
                DateTime.Today,
                _shift);

        bool hasRealExpenses =
            existing.Any(
                expense =>
                    expense.Amount > 0);

        if (hasRealExpenses)
        {
          MessageBox.Show(
              "Expenses have already been entered for this shift.\r\n\r\n" +
              "Delete the existing expenses before selecting NO EXPENSE.",
              "Expenses Already Entered",
              MessageBoxButtons.OK,
              MessageBoxIcon.Information);

          return;
        }

        bool alreadyEntered =
            existing.Any(
                expense =>
                    expense.Amount == 0 &&
                    string.Equals(
                        expense.Company,
                        "No Expense",
                        StringComparison.OrdinalIgnoreCase));

        if (alreadyEntered)
        {
          MessageBox.Show(
              "NO EXPENSE has already been recorded for this shift.",
              "Expenses",
              MessageBoxButtons.OK,
              MessageBoxIcon.Information);

          return;
        }

        _expenseService.AddNoExpense(
            DateTime.Today,
            _shift);

        LoadExpenses();

        MessageBox.Show(
            "No expenses recorded for this shift.",
            "Expenses",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
      }
      catch (Exception ex)
      {
        MessageBox.Show(
            ex.Message,
            "Unable to Save Expense Status",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
      }
    }

    // =========================================================
    // GRID SELECTION
    // =========================================================

    private void dgvExpenses_CellClick(
        object sender,
        DataGridViewCellEventArgs e)
    {
      if (e.RowIndex < 0)
        return;

      DataGridViewRow row =
          dgvExpenses.Rows[e.RowIndex];

      if (row.DataBoundItem
          is not ExpenseRecord record)
      {
        return;
      }

      _selectedExpenseId =
          record.Id;

      UpdateDeleteButton();
    }

    // =========================================================
    // DELETE STATE
    // =========================================================

    private void UpdateDeleteButton()
    {
      if (_corteCompleted)
      {
        btnDelete.Enabled = false;

        btnDelete.Text =
            "CORTE COMPLETED";

        btnDelete.BackColor =
            Color.FromArgb(
                156,
                163,
                175);

        return;
      }

      btnDelete.Enabled =
          _selectedExpenseId.HasValue &&
          _selectedExpenseId.Value > 0;

      btnDelete.Text =
          "DELETE";

      btnDelete.BackColor =
          btnDelete.Enabled
              ? Color.FromArgb(
                  239,
                  68,
                  68)
              : Color.FromArgb(
                  156,
                  163,
                  175);
    }

    // =========================================================
    // DELETE
    // =========================================================

    private void btnDelete_Click(
        object sender,
        EventArgs e)
    {
      if (_corteCompleted)
      {
        ShowLockedMessage();
        return;
      }

      if (!_selectedExpenseId.HasValue)
        return;

      DialogResult result =
          MessageBox.Show(
              "Delete the selected expense?",
              "Delete Expense",
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Question);

      if (result != DialogResult.Yes)
        return;

      try
      {
        _expenseService.DeleteExpense(
            _selectedExpenseId.Value);

        LoadExpenses();
      }
      catch (Exception ex)
      {
        MessageBox.Show(
            ex.Message,
            "Unable to Delete Expense",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
      }
    }

    // =========================================================
    // CLEAR ENTRY
    // =========================================================

    private void ClearEntryFields()
    {
      _company =
          string.Empty;

      _description =
          string.Empty;

      amountExpense.Value =
          0M;

      btnCompany.Text =
          "TOUCH TO ENTER COMPANY";

      btnDescription.Text =
          "TOUCH TO ENTER DESCRIPTION";

      UpdateAddButton();
    }

    // =========================================================
    // LOCK MESSAGE
    // =========================================================

    private void ShowLockedMessage()
    {
      MessageBox.Show(
          "This Corte has already been completed.\r\n\r\n" +
          "Expenses for this shift can no longer be changed.",
          "Expenses Locked",
          MessageBoxButtons.OK,
          MessageBoxIcon.Warning);
    }

    // =========================================================
    // CANCEL
    // =========================================================

    private void btnCancel_Click(
        object sender,
        EventArgs e)
    {
      DialogResult =
          DialogResult.Cancel;

      Close();
    }

    // =========================================================
    // DONE
    // =========================================================

    private void btnDone_Click(
        object sender,
        EventArgs e)
    {
      try
      {
        TotalExpenses =
            _expenseService.GetTotal(
                DateTime.Today,
                _shift);

        DialogResult =
            DialogResult.OK;

        Close();
      }
      catch (Exception ex)
      {
        MessageBox.Show(
            ex.Message,
            "Unable to Complete Expenses",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
      }
    }
  }
}