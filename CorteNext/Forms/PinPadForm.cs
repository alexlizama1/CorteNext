using System.ComponentModel;

namespace CorteNext.Forms
{
  public partial class PinPadForm : Form
  {
    private string _pin = string.Empty;

    private const int RequiredPinLength = 6;

    [Browsable(false)]
    [DesignerSerializationVisibility(
        DesignerSerializationVisibility.Hidden)]
    public string Pin { get; private set; } = string.Empty;

    public PinPadForm()
    {
      InitializeComponent();
    }

    private void PinPadForm_Load(
        object sender,
        EventArgs e)
    {
      UpdateDisplay();
    }

    // =========================================================
    // NUMBERS
    // =========================================================

    private void NumberButton_Click(
        object sender,
        EventArgs e)
    {
      if (sender is not Button button)
        return;

      if (_pin.Length >= RequiredPinLength)
        return;

      _pin += button.Text;

      UpdateDisplay();
      UpdateEnterButton();
    }

    // =========================================================
    // BACKSPACE
    // =========================================================

    private void btnBackspace_Click(
        object sender,
        EventArgs e)
    {
      if (_pin.Length == 0)
        return;

      _pin = _pin[..^1];

      UpdateDisplay();
      UpdateEnterButton();
    }

    // =========================================================
    // CLEAR
    // =========================================================

    private void btnClear_Click(
        object sender,
        EventArgs e)
    {
      _pin = string.Empty;

      UpdateDisplay();
      UpdateEnterButton();
    }

    // =========================================================
    // DISPLAY
    // =========================================================

    private void UpdateDisplay()
    {
      lblDisplay.Text =
          _pin.Length == 0
              ? "ENTER PIN"
              : new string('●', _pin.Length);

      lblPinCount.Text =
          $"{_pin.Length} / {RequiredPinLength}";
    }

    // =========================================================
    // ENTER STATE
    // =========================================================

    private void UpdateEnterButton()
    {
      btnEnter.Enabled =
          _pin.Length == RequiredPinLength;

      btnEnter.BackColor =
          btnEnter.Enabled
              ? Color.FromArgb(34, 197, 94)
              : Color.FromArgb(156, 163, 175);
    }

    // =========================================================
    // ENTER
    // =========================================================

    private void btnEnter_Click(
        object sender,
        EventArgs e)
    {
      if (_pin.Length != RequiredPinLength)
        return;

      Pin = _pin;

      DialogResult =
          DialogResult.OK;

      Close();
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
  }
}