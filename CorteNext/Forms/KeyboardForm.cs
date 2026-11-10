namespace CorteNext.Forms
{
  public partial class KeyboardForm : Form
  {
    private bool _upperCase = true;

    public string Value { get; private set; } = string.Empty;

    public KeyboardForm(string initialValue = "")
    {
      InitializeComponent();

      Value = initialValue ?? string.Empty;
    }

    private void KeyboardForm_Load(object sender, EventArgs e)
    {
      lblDisplay.Text = Value;

      UpdateLetterKeys();
      UpdateShiftButtons();
    }

    // =========================================================
    // LETTER KEYS
    // =========================================================

    private void LetterButton_Click(object sender, EventArgs e)
    {
      if (sender is not Button button)
        return;

      lblDisplay.Text += button.Text;
    }

    // =========================================================
    // NUMBER KEYS
    // =========================================================

    private void NumberButton_Click(object sender, EventArgs e)
    {
      if (sender is not Button button)
        return;

      lblDisplay.Text += button.Text;
    }

    // =========================================================
    // SHIFT
    // =========================================================

    private void btnShift_Click(object sender, EventArgs e)
    {
      _upperCase = !_upperCase;

      UpdateLetterKeys();
      UpdateShiftButtons();
    }

    private void UpdateLetterKeys()
    {
      UpdateLetterKeysRecursive(this);
    }

    private void UpdateLetterKeysRecursive(Control parent)
    {
      foreach (Control control in parent.Controls)
      {
        if (control is Button button &&
            string.Equals(
                button.Tag?.ToString(),
                "letter",
                StringComparison.OrdinalIgnoreCase))
        {
          button.Text = _upperCase
              ? button.Text.ToUpperInvariant()
              : button.Text.ToLowerInvariant();
        }

        if (control.HasChildren)
        {
          UpdateLetterKeysRecursive(control);
        }
      }
    }

    private void UpdateShiftButtons()
    {
      Color backgroundColor = _upperCase
          ? Color.FromArgb(59, 130, 246)
          : Color.FromArgb(209, 213, 219);

      Color foregroundColor = _upperCase
          ? Color.White
          : Color.FromArgb(31, 41, 55);

      btnShiftLeft.BackColor = backgroundColor;
      btnShiftRight.BackColor = backgroundColor;

      btnShiftLeft.ForeColor = foregroundColor;
      btnShiftRight.ForeColor = foregroundColor;
    }

    // =========================================================
    // SPACE
    // =========================================================

    private void btnSpace_Click(object sender, EventArgs e)
    {
      lblDisplay.Text += " ";
    }

    // =========================================================
    // BACKSPACE
    // =========================================================

    private void btnBackspace_Click(object sender, EventArgs e)
    {
      if (lblDisplay.Text.Length == 0)
        return;

      lblDisplay.Text =
          lblDisplay.Text[..^1];
    }

    // =========================================================
    // CLEAR
    // =========================================================

    private void btnClear_Click(object sender, EventArgs e)
    {
      lblDisplay.Text = string.Empty;
    }

    // =========================================================
    // CANCEL
    // =========================================================

    private void btnCancel_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;

      Close();
    }

    // =========================================================
    // ENTER
    // =========================================================

    private void btnEnter_Click(object sender, EventArgs e)
    {
      Value = lblDisplay.Text.Trim();

      DialogResult = DialogResult.OK;

      Close();
    }
  }
}