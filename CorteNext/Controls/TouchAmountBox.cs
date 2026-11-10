using CorteNext.Forms;
using System.ComponentModel;

namespace CorteNext.Controls
{
  public class TouchAmountBox : UserControl
  {
    private readonly Label _lblCaption;
    private readonly Label _lblValue;
    private bool _openNumberPad = true;
    private decimal _value;
    private bool _allowNegative;
    private bool _readOnly;

    public event EventHandler? ValueChanged;
    public event EventHandler? TouchRequested;
    public TouchAmountBox()
    {
      Height = 115;
      Width = 300;

      BackColor = Color.White;
      Padding = new Padding(2);

      Cursor = Cursors.Hand;

      // =========================================================
      // CAPTION LABEL
      // =========================================================

      _lblCaption = new Label
      {
        Dock = DockStyle.Top,

        Height = 38,

        Text = "Amount",

        TextAlign =
              ContentAlignment.MiddleLeft,

        Padding =
              new Padding(12, 0, 0, 0),

        Font =
              new Font(
                  "Segoe UI",
                  13F,
                  FontStyle.Bold),

        ForeColor =
              Color.FromArgb(
                  75,
                  85,
                  99),

        BackColor =
              Color.FromArgb(
                  229,
                  231,
                  235),

        Cursor =
              Cursors.Hand
      };

      // =========================================================
      // VALUE LABEL
      // =========================================================

      _lblValue = new Label
      {
        Dock = DockStyle.Fill,

        Text = "0.00",

        TextAlign =
              ContentAlignment.MiddleRight,

        Padding =
              new Padding(10, 0, 15, 0),

        Font =
              new Font(
                  "Segoe UI",
                  25F,
                  FontStyle.Bold),

        ForeColor =
              Color.FromArgb(
                  17,
                  24,
                  39),

        BackColor =
              Color.White,

        Cursor =
              Cursors.Hand
      };

      // =========================================================
      // ADD CONTROLS
      // =========================================================

      Controls.Add(_lblValue);
      Controls.Add(_lblCaption);

      // =========================================================
      // CLICK EVENTS
      // =========================================================

      Click += Control_Click;

      _lblCaption.Click += Control_Click;
      _lblValue.Click += Control_Click;
    }

    // =============================================================
    // CAPTION
    // =============================================================

    [Category("Touch Amount")]
    [DefaultValue("Amount")]
    [DesignerSerializationVisibility(
        DesignerSerializationVisibility.Visible)]
    public string Caption
    {
      get => _lblCaption.Text;

      set
      {
        _lblCaption.Text =
            value ?? string.Empty;
      }
    }

    // =============================================================
    // VALUE
    // =============================================================

    [Category("Touch Amount")]
    [DefaultValue(typeof(decimal), "0")]
    [DesignerSerializationVisibility(
        DesignerSerializationVisibility.Visible)]
    public decimal Value
    {
      get => _value;

      set
      {
        if (_value == value)
          return;

        _value = value;

        UpdateDisplay();

        ValueChanged?.Invoke(
            this,
            EventArgs.Empty);
      }
    }

    // =============================================================
    // ALLOW NEGATIVE
    // =============================================================

    [Category("Touch Amount")]
    [DefaultValue(false)]
    [DesignerSerializationVisibility(
        DesignerSerializationVisibility.Visible)]
    public bool AllowNegative
    {
      get => _allowNegative;

      set
      {
        _allowNegative = value;
      }
    }

    // =============================================================
    // READ ONLY
    // =============================================================

    [Category("Touch Amount")]
    [DefaultValue(false)]
    [DesignerSerializationVisibility(
        DesignerSerializationVisibility.Visible)]
    public bool ReadOnly
    {
      get => _readOnly;

      set
      {
        _readOnly = value;

        UpdateReadOnlyAppearance();
      }
    }

    [Category("Touch Amount")]
    [DefaultValue(true)]
    [DesignerSerializationVisibility(
    DesignerSerializationVisibility.Visible)]
    public bool OpenNumberPad
    {
      get => _openNumberPad;
      set => _openNumberPad = value;
    }

    // =============================================================
    // TOUCH / CLICK
    // =============================================================

    private void Control_Click(
        object? sender,
        EventArgs e)
    {
      if (ReadOnly)
        return;

      if (!OpenNumberPad)
      {
        TouchRequested?.Invoke(
            this,
            EventArgs.Empty);

        return;
      }

      using NumberPadForm numberPad =
          new(
              initialValue: Value,
              allowNegative: AllowNegative);

      if (numberPad.ShowDialog(this) !=
          DialogResult.OK)
      {
        return;
      }

      Value =
          numberPad.Value;
    }

    // =============================================================
    // UPDATE DISPLAY
    // =============================================================

    private void UpdateDisplay()
    {
      _lblValue.Text =
          Value.ToString("0.00");
    }

    // =============================================================
    // READ-ONLY APPEARANCE
    // =============================================================

    private void UpdateReadOnlyAppearance()
    {
      if (ReadOnly)
      {
        _lblValue.BackColor =
            Color.FromArgb(
                243,
                244,
                246);

        _lblValue.ForeColor =
            Color.FromArgb(
                107,
                114,
                128);

        Cursor =
            Cursors.Default;

        _lblValue.Cursor =
            Cursors.Default;

        _lblCaption.Cursor =
            Cursors.Default;
      }
      else
      {
        _lblValue.BackColor =
            Color.White;

        _lblValue.ForeColor =
            Color.FromArgb(
                17,
                24,
                39);

        Cursor =
            Cursors.Hand;

        _lblValue.Cursor =
            Cursors.Hand;

        _lblCaption.Cursor =
            Cursors.Hand;
      }
    }

    // =============================================================
    // RESET
    // =============================================================

    public void ResetValue()
    {
      Value = 0M;
    }
  }
}