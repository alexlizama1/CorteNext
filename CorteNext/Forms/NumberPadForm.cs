using System.ComponentModel;
using System.Globalization;

namespace CorteNext.Forms
{
  public partial class NumberPadForm : Form
  {
    private string _input = string.Empty;

    private readonly bool _allowNegative;

    // =========================================================
    // RESULT
    // =========================================================

    [Browsable(false)]
    [DesignerSerializationVisibility(
        DesignerSerializationVisibility.Hidden)]
    public decimal Value { get; private set; }

    // =========================================================
    // CONSTRUCTOR
    // =========================================================

    public NumberPadForm(
        decimal initialValue = 0M,
        bool allowNegative = false)
    {
      InitializeComponent();

      _allowNegative =
          allowNegative;

      Value =
          initialValue;

      _input =
          initialValue == 0M
              ? string.Empty
              : initialValue.ToString(
                  "0.##",
                  CultureInfo.InvariantCulture);

      btnNegative.Visible =
          _allowNegative;

      UpdateDisplay();
    }

    // =========================================================
    // NUMBER BUTTONS
    // =========================================================

    private void NumberButton_Click(
        object sender,
        EventArgs e)
    {
      if (sender is not Button button)
        return;

      string digit =
          button.Text;

      if (digit.Length != 1 ||
          !char.IsDigit(digit[0]))
      {
        return;
      }

      // Prevent unnecessary leading zeros.
      if (_input == "0")
      {
        _input =
            digit;
      }
      else if (_input == "-0")
      {
        _input =
            $"-{digit}";
      }
      else
      {
        _input +=
            digit;
      }

      UpdateDisplay();
    }

    // =========================================================
    // DECIMAL
    // =========================================================

    private void btnDecimal_Click(
        object sender,
        EventArgs e)
    {
      if (_input.Contains('.'))
        return;

      if (string.IsNullOrWhiteSpace(
              _input))
      {
        _input =
            "0.";
      }
      else if (_input == "-")
      {
        _input =
            "-0.";
      }
      else
      {
        _input +=
            ".";
      }

      UpdateDisplay();
    }

    // =========================================================
    // NEGATIVE
    // =========================================================

    private void btnNegative_Click(
        object sender,
        EventArgs e)
    {
      if (!_allowNegative)
        return;

      if (string.IsNullOrWhiteSpace(
              _input))
      {
        _input =
            "-";
      }
      else if (_input.StartsWith(
                   "-",
                   StringComparison.Ordinal))
      {
        _input =
            _input[1..];
      }
      else
      {
        _input =
            "-" + _input;
      }

      UpdateDisplay();
    }

    // =========================================================
    // BACKSPACE
    // =========================================================

    private void btnBackspace_Click(
        object sender,
        EventArgs e)
    {
      if (string.IsNullOrEmpty(
              _input))
      {
        return;
      }

      _input =
          _input[..^1];

      UpdateDisplay();
    }

    // =========================================================
    // CLEAR
    // =========================================================

    private void btnClear_Click(
        object sender,
        EventArgs e)
    {
      _input =
          string.Empty;

      Value =
          0M;

      UpdateDisplay();
    }

    // =========================================================
    // UPDATE DISPLAY
    // =========================================================

    private void UpdateDisplay()
    {
      if (string.IsNullOrWhiteSpace(
              _input) ||
          _input == "-")
      {
        lblDisplay.Text =
            _input == "-"
                ? "-"
                : "0.00";

        return;
      }

      // While entering a decimal value, preserve exactly
      // what the operator is typing.
      if (_input.EndsWith(
              ".",
              StringComparison.Ordinal))
      {
        lblDisplay.Text =
            _input;

        return;
      }

      if (decimal.TryParse(
              _input,
              NumberStyles.Number |
              NumberStyles.AllowLeadingSign,
              CultureInfo.InvariantCulture,
              out decimal amount))
      {
        Value =
            amount;

        lblDisplay.Text =
            amount.ToString(
                "N2",
                CultureInfo.CurrentCulture);

        return;
      }

      lblDisplay.Text =
          _input;
    }

    // =========================================================
    // OK
    // =========================================================

    private void btnOK_Click(
        object sender,
        EventArgs e)
    {
      if (string.IsNullOrWhiteSpace(
              _input) ||
          _input == "-" ||
          _input == "." ||
          _input == "-.")
      {
        Value =
            0M;
      }
      else
      {
        bool valid =
            decimal.TryParse(
                _input,
                NumberStyles.Number |
                NumberStyles.AllowLeadingSign,
                CultureInfo.InvariantCulture,
                out decimal amount);

        if (!valid)
        {
          MessageBox.Show(
              "Enter a valid amount.",
              "Invalid Amount",
              MessageBoxButtons.OK,
              MessageBoxIcon.Warning);

          return;
        }

        if (!_allowNegative &&
            amount < 0M)
        {
          MessageBox.Show(
              "Negative amounts are not allowed.",
              "Invalid Amount",
              MessageBoxButtons.OK,
              MessageBoxIcon.Warning);

          return;
        }

        Value =
            amount;
      }

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