using CorteNext.Models;
using CorteNext.Services;

namespace CorteNext.Forms
{
  public partial class CorteForm : Form
  {
    private readonly ICorteService _corteService;
    private readonly IFondoService _fondoService;
    private readonly IExpenseService _expenseService;
    private readonly ShiftType _shift;
    private decimal _fondo;
    private bool _fondoLoaded;
    private bool _corteAlreadyCompleted;
    private string _staffName = string.Empty;

    public event EventHandler? CorteCompleted;

    public CorteForm(
       ICorteService corteService,
       IFondoService fondoService,
       IExpenseService expenseService,
       ShiftType shift)
    {
      InitializeComponent();

      _corteService = corteService;
      _fondoService = fondoService;
      _expenseService = expenseService;
      _shift = shift;

      ConfigureShift();
      WireAmountEvents();
      ConfigureExpenseControl();
      ConfigureAmountControls();
    }

    private void ConfigureExpenseControl()
    {
      amountExpenses.OpenNumberPad =
          false;

      amountExpenses.ReadOnly =
          false;

      amountExpenses.TouchRequested +=
          amountExpenses_TouchRequested;
    }

    private void amountExpenses_TouchRequested(
        object? sender,
        EventArgs e)
    {
      if (!amountExpenses.Visible)
        return;

      try
      {
        using ExpenseForm expenseForm =
            new(
                _expenseService,
                _corteService,
                GetDatabaseShift());

        DialogResult result =
            expenseForm.ShowDialog(this);

        if (result != DialogResult.OK)
          return;

        amountExpenses.Value =
            expenseForm.TotalExpenses;

        Recalculate();
      }
      catch (Exception ex)
      {
        MessageBox.Show(
            ex.Message,
            "Unable to Open Expenses",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
      }
    }

    private void LoadExpenses()
    {
      if (!amountExpenses.Visible)
      {
        amountExpenses.Value = 0M;
        return;
      }

      try
      {
        decimal total =
            _expenseService.GetTotal(
                DateTime.Today,
                GetDatabaseShift());

        amountExpenses.Value =
            total;
      }
      catch (Exception ex)
      {
        amountExpenses.Value = 0M;

        MessageBox.Show(
            ex.Message,
            "Unable to Load Expenses",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
      }
    }

    // =========================================================
    // LOAD
    // =========================================================

    private void CorteForm_Load(
        object sender,
        EventArgs e)
    {
      try
      {
        lblDate.Text =
            DateTime.Today.ToString(
                "dddd, MMMM d, yyyy");

        CheckExistingCorte();
        LoadFondo();
        LoadExpenses();

        Recalculate();
        UpdateSaveState();
      }
      catch (Exception ex)
      {
        MessageBox.Show(
            ex.ToString(),
            "Unable to Load Corte",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
      }
    }

    private void ConfigureAmountControls()
    {
      // Cash denominations remain positive-only.
      amountOne.AllowNegative = false;
      amountFive.AllowNegative = false;
      amountTen.AllowNegative = false;
      amountTwenty.AllowNegative = false;
      amountFifty.AllowNegative = false;
      amountHundred.AllowNegative = false;
      amountQuarter.AllowNegative = false;

      // Drive Tip remains positive-only.
      amountDriveTip.AllowNegative = false;

      // SALES ONLY can be positive or negative.
      amountSales.AllowNegative = true;
    }

    private void CheckExistingCorte()
    {
      try
      {
        string shift =
            GetDatabaseShift();

        _corteAlreadyCompleted =
            _corteService.CorteExists(
                DateTime.Now,
                shift);

        if (!_corteAlreadyCompleted)
        {
          return;
        }

        lblTitle.Text +=
            " - COMPLETED";

        lblTitle.ForeColor =
            Color.FromArgb(
                253,
                224,
                71);

        MessageBox.Show(
            $"{GetCorteDisplayName()} has already been completed today.\n\n" +
            "A second record cannot be saved.",
            "Corte Already Completed",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
      }
      catch (Exception ex)
      {
        _corteAlreadyCompleted = true;

        MessageBox.Show(
            ex.Message,
            "Unable to Check Corte Status",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
      }
    }

    private string GetCorteDisplayName()
    {
      return _shift switch
      {
        ShiftType.CorteAM =>
            "AM Corte",

        ShiftType.CortePM =>
            "PM Corte",

        ShiftType.CorteAMDrive =>
            "AM Drive Corte",

        ShiftType.CortePMDrive =>
            "PM Drive Corte",

        _ =>
            "Corte"
      };
    }

    private void LoadFondo()
    {
      try
      {
        string fondoShift =
            GetFondoDatabaseShift();

        FondoRecord? fondoRecord =
            _fondoService.GetFondo(
                DateTime.Now,
                fondoShift);

        if (fondoRecord == null)
        {
          _fondo = 0M;
          _fondoLoaded = false;

          lblFondoValue.Text = "NOT FOUND";
          lblFondoValue.ForeColor = Color.FromArgb(
              185,
              28,
              28);

          UpdateSaveState();

          MessageBox.Show(
              $"{GetFondoDisplayName()} Fondo has not been completed for today.\n\n" +
              "Corte cannot be saved until the required Fondo is completed.",
              "Fondo Required",
              MessageBoxButtons.OK,
              MessageBoxIcon.Warning);

          return;
        }

        _fondo = fondoRecord.Total;
        _fondoLoaded = true;

        lblFondoValue.Text =
            _fondo.ToString("C2");

        lblFondoValue.ForeColor =
            Color.FromArgb(
                185,
                28,
                28);

        UpdateSaveState();
      }
      catch (Exception ex)
      {
        _fondo = 0M;
        _fondoLoaded = false;

        lblFondoValue.Text = "ERROR";

        lblFondoValue.ForeColor =
            Color.FromArgb(
                185,
                28,
                28);

        UpdateSaveState();

        MessageBox.Show(
            ex.Message,
            "Unable to Load Fondo",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
      }
    }

    private string GetFondoDatabaseShift()
    {
      return _shift switch
      {
        ShiftType.CorteAM =>
            "am",

        ShiftType.CortePM =>
            "pm",

        ShiftType.CorteAMDrive =>
            "drive",

        ShiftType.CortePMDrive =>
            "drive",

        _ =>
            throw new InvalidOperationException(
                "Invalid Corte shift.")
      };
    }

    private string GetFondoDisplayName()
    {
      return _shift switch
      {
        ShiftType.CorteAM =>
            "AM",

        ShiftType.CortePM =>
            "PM",

        ShiftType.CorteAMDrive or
        ShiftType.CortePMDrive =>
            "Drive",

        _ =>
            "Unknown"
      };
    }



    // =========================================================
    // SHIFT CONFIGURATION
    // =========================================================

    private void ConfigureShift()
    {
      switch (_shift)
      {
        case ShiftType.CorteAM:

          lblTitle.Text =
              "AM CORTE";

          amountDriveTip.Visible = true;
          amountExpenses.Visible = true;

          break;


        case ShiftType.CortePM:

          lblTitle.Text =
              "PM CORTE";

          amountDriveTip.Visible = true;
          amountExpenses.Visible = true;

          break;


        case ShiftType.CorteAMDrive:

          lblTitle.Text =
              "AM DRIVE CORTE";

          amountDriveTip.Visible = false;
          amountExpenses.Visible = false;

          break;


        case ShiftType.CortePMDrive:

          lblTitle.Text =
              "PM DRIVE CORTE";

          amountDriveTip.Visible = false;
          amountExpenses.Visible = false;

          break;


        default:

          throw new ArgumentOutOfRangeException(
              nameof(_shift),
              _shift,
              "Invalid Corte shift.");
      }
    }

    // =========================================================
    // TOUCH AMOUNT EVENTS
    // =========================================================

    private void WireAmountEvents()
    {
      amountOne.ValueChanged +=
          Amount_ValueChanged;

      amountFive.ValueChanged +=
          Amount_ValueChanged;

      amountTen.ValueChanged +=
          Amount_ValueChanged;

      amountTwenty.ValueChanged +=
          Amount_ValueChanged;

      amountFifty.ValueChanged +=
          Amount_ValueChanged;

      amountHundred.ValueChanged +=
          Amount_ValueChanged;

      amountQuarter.ValueChanged +=
          Amount_ValueChanged;

      amountDriveTip.ValueChanged +=
          Amount_ValueChanged;

      amountExpenses.ValueChanged +=
          Amount_ValueChanged;

      amountSales.ValueChanged +=
          Amount_ValueChanged;
    }

    private void Amount_ValueChanged(
        object? sender,
        EventArgs e)
    {
      Recalculate();
    }

    // =========================================================
    // CREATE CURRENT RECORD
    // =========================================================

    private CorteRecord CreateCurrentRecord()
    {
      return new CorteRecord
      {
        Date =
              DateTime.Now,

        Time =
              DateTime.Now.ToShortTimeString(),

        // -------------------------------------------------
        // Cash
        // -------------------------------------------------

        One =
              amountOne.Value,

        Five =
              amountFive.Value,

        Ten =
              amountTen.Value,

        Twenty =
              amountTwenty.Value,

        Fifty =
              amountFifty.Value,

        Hundred =
              amountHundred.Value,

        Quarter =
              amountQuarter.Value,

        // -------------------------------------------------
        // Drive Tips
        // -------------------------------------------------

        DriveTip =
              amountDriveTip.Visible
                  ? amountDriveTip.Value
                  : 0M,

        // -------------------------------------------------
        // Expenses
        // -------------------------------------------------

        Expenses =
              amountExpenses.Visible
                  ? amountExpenses.Value
                  : 0M,

        // -------------------------------------------------
        // Fondo
        // -------------------------------------------------

        Fondo =
              _fondo,

        // -------------------------------------------------
        // Sales
        // -------------------------------------------------

        Sales =
              amountSales.Value,

        // -------------------------------------------------
        // Staff
        // -------------------------------------------------

        StaffName =
              _staffName,

        // -------------------------------------------------
        // Shift
        // -------------------------------------------------

        Shift =
              GetDatabaseShift()
      };
    }

    // =========================================================
    // RECALCULATE
    // =========================================================

    private void Recalculate()
    {
      CorteRecord record =
          CreateCurrentRecord();

      _corteService.Calculate(
          record);

      // -----------------------------------------------------
      // Total Cash
      // -----------------------------------------------------

      lblTotalCashValue.Text =
          record.TotalCash.ToString("C2");

      // -----------------------------------------------------
      // Gross
      // -----------------------------------------------------

      lblGrossValue.Text =
          record.GrossTotal.ToString("C2");

      // -----------------------------------------------------
      // Fondo
      // -----------------------------------------------------

      lblFondoValue.Text =
          record.Fondo.ToString("C2");

      // -----------------------------------------------------
      // Net
      // -----------------------------------------------------

      lblNetValue.Text =
          record.NetTotal.ToString("C2");

      // -----------------------------------------------------
      // Short / Over
      // -----------------------------------------------------

      lblShortOverValue.Text =
          record.ShortOver.ToString("C2");

      UpdateShortOverAppearance(
          record.ShortOver);
    }

    // =========================================================
    // SHORT / OVER APPEARANCE
    // =========================================================

    private void UpdateShortOverAppearance(
        decimal value)
    {
      // -----------------------------------------------------
      // SHORT
      // -----------------------------------------------------

      if (value < 0)
      {
        lblShortOverCaption.Text =
            "SHORT";

        lblShortOverCaption.ForeColor =
            Color.FromArgb(
                185,
                28,
                28);

        lblShortOverValue.ForeColor =
            Color.FromArgb(
                185,
                28,
                28);

        pnlShortOver.BackColor =
            Color.FromArgb(
                254,
                226,
                226);

        return;
      }

      // -----------------------------------------------------
      // OVER
      // -----------------------------------------------------

      if (value > 0)
      {
        lblShortOverCaption.Text =
            "OVER";

        lblShortOverCaption.ForeColor =
            Color.FromArgb(
                21,
                128,
                61);

        lblShortOverValue.ForeColor =
            Color.FromArgb(
                21,
                128,
                61);

        pnlShortOver.BackColor =
            Color.FromArgb(
                220,
                252,
                231);

        return;
      }

      // -----------------------------------------------------
      // BALANCED
      // -----------------------------------------------------

      lblShortOverCaption.Text =
          "BALANCED";

      lblShortOverCaption.ForeColor =
          Color.FromArgb(
              30,
              64,
              175);

      lblShortOverValue.ForeColor =
          Color.FromArgb(
              30,
              64,
              175);

      pnlShortOver.BackColor =
          Color.FromArgb(
              219,
              234,
              254);
    }

    // =========================================================
    // STAFF NAME
    // =========================================================

    private void btnStaffName_Click(
        object sender,
        EventArgs e)
    {
      using KeyboardForm keyboard =
          new(_staffName);

      DialogResult result =
          keyboard.ShowDialog(this);

      if (result != DialogResult.OK)
      {
        return;
      }

      if (string.IsNullOrWhiteSpace(
              keyboard.Value))
      {
        MessageBox.Show(
            "Please enter the staff name.",
            "Staff Name",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning);

        return;
      }

      _staffName =
          keyboard.Value.Trim();

      btnStaffName.Text =
          _staffName;

      btnStaffName.BackColor =
          Color.FromArgb(
              220,
              252,
              231);

      btnStaffName.ForeColor =
          Color.FromArgb(
              22,
              101,
              52);

      UpdateSaveState();
    }

    // =========================================================
    // SAVE BUTTON STATE
    // =========================================================

    private void UpdateSaveState()
    {
      bool staffEntered =
          !string.IsNullOrWhiteSpace(
              _staffName);

      btnSave.Enabled =
          staffEntered &&
          _fondoLoaded &&
          !_corteAlreadyCompleted;

      if (btnSave.Enabled)
      {
        btnSave.Text =
            "SAVE CORTE";

        btnSave.BackColor =
            Color.FromArgb(
                34,
                197,
                94);

        btnSave.ForeColor =
            Color.White;
      }
      else
      {
        btnSave.BackColor =
            Color.FromArgb(
                156,
                163,
                175);

        btnSave.ForeColor =
            Color.White;

        btnSave.Text =
            _corteAlreadyCompleted
                ? "ALREADY COMPLETED"
                : "SAVE CORTE";
      }
    }

    // =========================================================
    // SAVE CORTE
    // =========================================================

    private void btnSave_Click(
    object sender,
    EventArgs e)
    {
      if (_corteAlreadyCompleted)
      {
        MessageBox.Show(
            "This Corte shift has already been completed today.",
            "Corte Already Completed",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);

        return;
      }

      if (!_fondoLoaded)
      {
        MessageBox.Show(
            "The required Fondo has not been completed.\n\n" +
            "Corte cannot be saved.",
            "Fondo Required",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning);

        return;
      }

      if (string.IsNullOrWhiteSpace(_staffName))
      {
        MessageBox.Show(
            "Enter the staff name before saving.",
            "Staff Name Required",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning);

        return;
      }

      try
      {
        CorteRecord record =
            CreateCurrentRecord();

        _corteService.SaveCorte(record);

        MessageBox.Show(
            "Corte saved successfully.",
            "Corte",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);

        CorteCompleted?.Invoke(
            this,
            EventArgs.Empty);

        Close();
      }
      catch (Exception ex)
      {
        MessageBox.Show(
            ex.Message,
            "Unable to Save Corte",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
      }
    }

    // =========================================================
    // DATABASE SHIFT
    // =========================================================

    private string GetDatabaseShift()
    {
      return _shift switch
      {
        ShiftType.CorteAM =>
            "am",

        ShiftType.CortePM =>
            "pm",

        ShiftType.CorteAMDrive =>
            "amDrive",

        ShiftType.CortePMDrive =>
            "pmDrive",

        _ =>
            throw new InvalidOperationException(
                "Invalid Corte shift.")
      };
    }

    // =========================================================
    // CANCEL
    // =========================================================

    private void btnCancel_Click(
        object sender,
        EventArgs e)
    {
      Close();
    }


  }
}