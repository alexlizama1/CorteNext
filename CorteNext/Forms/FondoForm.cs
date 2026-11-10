using CorteNext.Models;
using CorteNext.Services;

namespace CorteNext.Forms
{
  public partial class FondoForm : Form
  {
    private readonly IFondoService _fondoService;
    private readonly ShiftType _shift;

    private string _staffName = string.Empty;

    public event EventHandler? FondoCompleted;

    public FondoForm(
        IFondoService fondoService,
        ShiftType shift)
    {
      InitializeComponent();

      _fondoService = fondoService;
      _shift = shift;

      ConfigureAmountBoxes();
      ConfigureShift();
      WireAmountEvents();
    }

    // =========================================================
    // FORM LOAD
    // =========================================================

    private void FondoForm_Load(object sender, EventArgs e)
    {
      lblDate.Text =
          DateTime.Now.ToString(
              "dddd, MMMM d, yyyy");

      LoadStartingFondo();

      UpdateTotal();
      UpdateSaveState();
    }

    private void ConfigureAmountBoxes()
    {
      ConfigureAmountBox(
          amountOne,
          "$1 BILLS");

      ConfigureAmountBox(
          amountFive,
          "$5 BILLS");

      ConfigureAmountBox(
          amountTen,
          "$10 BILLS");

      ConfigureAmountBox(
          amountQuarter1,
          "QUARTERS");

      ConfigureAmountBox(
          amountQuarter2,
          "QUARTERS 2");
    }

    private void LoadStartingFondo()
    {
      try
      {
        string shift =
            GetDatabaseShift();

        StartFondo? startingFondo =
            _fondoService.GetStartingFondo(shift);

        if (startingFondo == null)
        {
          amountOne.Value = 0M;
          amountFive.Value = 0M;
          amountTen.Value = 0M;
          amountQuarter1.Value = 0M;
          amountQuarter2.Value = 0M;

          UpdateTotal();

          MessageBox.Show(
              $"No starting Fondo configuration was found for {shift}.",
              "Starting Fondo",
              MessageBoxButtons.OK,
              MessageBoxIcon.Warning);

          return;
        }

        amountOne.Value =
            startingFondo.One;

        amountFive.Value =
            startingFondo.Five;

        amountTen.Value =
            startingFondo.Ten;

        amountQuarter1.Value =
            startingFondo.Quarter;

        // The second quarter entry starts empty.
        amountQuarter2.Value =
            0M;

        UpdateTotal();
      }
      catch (Exception ex)
      {
        MessageBox.Show(
            ex.Message,
            "Unable to Load Starting Fondo",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
      }
    }
    // =========================================================
    // SHIFT CONFIGURATION
    // =========================================================

    private void ConfigureShift()
    {
      switch (_shift)
      {
        case ShiftType.FondoAM:
          lblTitle.Text = "AM FONDO";

          amountQuarter2.Visible = true;
          break;

        case ShiftType.FondoDrive:
          lblTitle.Text = "DRIVE FONDO";

          amountQuarter2.Visible = false;
          break;

        case ShiftType.FondoPM:
          lblTitle.Text = "PM FONDO";

          amountQuarter2.Visible = false;
          break;

        default:
          throw new ArgumentOutOfRangeException(
              nameof(_shift),
              _shift,
              "Invalid Fondo shift.");
      }
    }

    // =========================================================
    // AMOUNT EVENTS
    // =========================================================

    private void WireAmountEvents()
    {
      amountOne.ValueChanged += Amount_ValueChanged;
      amountFive.ValueChanged += Amount_ValueChanged;
      amountTen.ValueChanged += Amount_ValueChanged;
      amountQuarter1.ValueChanged += Amount_ValueChanged;
      amountQuarter2.ValueChanged += Amount_ValueChanged;
    }

    private void Amount_ValueChanged(
        object? sender,
        EventArgs e)
    {
      UpdateTotal();
    }

    // =========================================================
    // TOTAL
    // =========================================================

    private decimal CalculateTotal()
    {
      decimal total =
          amountOne.Value +
          amountFive.Value +
          amountTen.Value +
          amountQuarter1.Value;

      if (amountQuarter2.Visible)
      {
        total += amountQuarter2.Value;
      }

      return total;
    }

    private void UpdateTotal()
    {
      lblTotalValue.Text =
          CalculateTotal().ToString("C2");
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

      if (string.IsNullOrWhiteSpace(keyboard.Value))
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
      btnSave.Enabled =
          !string.IsNullOrWhiteSpace(
              _staffName);
    }

    // =========================================================
    // SAVE FONDO
    // =========================================================

    private void btnSave_Click(
        object sender,
        EventArgs e)
    {
      if (string.IsNullOrWhiteSpace(_staffName))
      {
        MessageBox.Show(
            "Enter the staff name before saving.",
            "Staff Name Required",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning);

        return;
      }

      FondoRecord record = new()
      {
        Date = DateTime.Now,

        Time =
              DateTime.Now.ToShortTimeString(),

        One =
              amountOne.Value,

        Five =
              amountFive.Value,

        Ten =
              amountTen.Value,

        Quarter1 =
              amountQuarter1.Value,

        Quarter2 =
              amountQuarter2.Visible
                  ? amountQuarter2.Value
                  : 0M,

        StaffName =
              _staffName,

        Shift =
              GetDatabaseShift()
      };

      try
      {
        _fondoService.SaveFondo(record);

        MessageBox.Show(
            "Fondo saved successfully.",
            "Fondo",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);

        FondoCompleted?.Invoke(
            this,
            EventArgs.Empty);

        Close();
      }
      catch (Exception ex)
      {
        MessageBox.Show(
            ex.Message,
            "Unable to Save Fondo",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
      }
    }

    // =========================================================
    // DATABASE SHIFT VALUE
    // =========================================================

    private string GetDatabaseShift()
    {
      return _shift switch
      {
        ShiftType.FondoAM =>
            "am",

        ShiftType.FondoDrive =>
            "drive",

        ShiftType.FondoPM =>
            "pm",

        _ =>
            throw new InvalidOperationException(
                "Invalid Fondo shift.")
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