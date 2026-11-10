namespace CorteNext.Forms
{
  partial class KeyboardForm
  {
    private System.ComponentModel.IContainer? components = null;

    private Label lblDisplay;
    private TableLayoutPanel tblKeyboard;

    private Button btnShiftLeft;
    private Button btnShiftRight;

    private Button btnSpace;
    private Button btnBackspace;
    private Button btnClear;

    private Button btnCancel;
    private Button btnEnter;

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        components?.Dispose();
      }

      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      lblDisplay = new Label();
      tblKeyboard = new TableLayoutPanel();

      SuspendLayout();

      // =========================================================
      // KeyboardForm
      // =========================================================

      AutoScaleMode = AutoScaleMode.Dpi;

      BackColor = Color.FromArgb(245, 247, 250);

      ClientSize = new Size(1700, 1000);

      FormBorderStyle = FormBorderStyle.FixedDialog;

      StartPosition = FormStartPosition.CenterParent;

      MaximizeBox = false;
      MinimizeBox = false;

      Text = "Keyboard";

      Load += KeyboardForm_Load;

      // =========================================================
      // Display
      // =========================================================

      lblDisplay.Dock = DockStyle.Top;

      lblDisplay.Height = 105;

      lblDisplay.Text = string.Empty;

      lblDisplay.TextAlign = ContentAlignment.MiddleLeft;

      lblDisplay.Padding = new Padding(25, 0, 25, 0);

      lblDisplay.BackColor = Color.FromArgb(31, 41, 55);

      lblDisplay.ForeColor = Color.White;

      lblDisplay.Font = new Font(
          "Segoe UI",
          25F,
          FontStyle.Bold);

      // =========================================================
      // Keyboard Layout
      // =========================================================

      tblKeyboard.Dock = DockStyle.Fill;

      tblKeyboard.Padding = new Padding(15);

      tblKeyboard.ColumnCount = 10;
      tblKeyboard.RowCount = 5;

      for (int column = 0; column < 10; column++)
      {
        tblKeyboard.ColumnStyles.Add(
            new ColumnStyle(
                SizeType.Percent,
                10F));
      }

      for (int row = 0; row < 5; row++)
      {
        tblKeyboard.RowStyles.Add(
            new RowStyle(
                SizeType.Percent,
                20F));
      }

      // =========================================================
      // ROW 1 - Numbers
      // =========================================================

      string[] numbers =
      {
                "1", "2", "3", "4", "5",
                "6", "7", "8", "9", "0"
            };

      for (int i = 0; i < numbers.Length; i++)
      {
        Button button =
            CreateKeyButton(
                numbers[i],
                false);

        button.Click += NumberButton_Click;

        tblKeyboard.Controls.Add(
            button,
            i,
            0);
      }

      // =========================================================
      // ROW 2 - QWERTY
      // =========================================================

      string[] row1 =
      {
                "Q", "W", "E", "R", "T",
                "Y", "U", "I", "O", "P"
            };

      AddLetterRow(
          row1,
          1,
          0);

      // =========================================================
      // ROW 3 - ASDF
      // =========================================================

      string[] row2 =
      {
                "A", "S", "D", "F", "G",
                "H", "J", "K", "L"
            };

      AddLetterRow(
          row2,
          2,
          0);

      // =========================================================
      // ROW 4 - Shift + ZXCVBNM + Shift
      // =========================================================

      btnShiftLeft =
          CreateActionButton("SHIFT");

      btnShiftLeft.Click += btnShift_Click;

      tblKeyboard.Controls.Add(
          btnShiftLeft,
          0,
          3);

      string[] row3 =
      {
                "Z", "X", "C", "V",
                "B", "N", "M"
            };

      for (int i = 0; i < row3.Length; i++)
      {
        Button button =
            CreateKeyButton(
                row3[i],
                true);

        button.Click += LetterButton_Click;

        tblKeyboard.Controls.Add(
            button,
            i + 1,
            3);
      }

      btnShiftRight =
          CreateActionButton("SHIFT");

      btnShiftRight.Click += btnShift_Click;

      tblKeyboard.Controls.Add(
          btnShiftRight,
          8,
          3);

      tblKeyboard.SetColumnSpan(
          btnShiftRight,
          2);

      // =========================================================
      // ROW 5 - Action Keys
      // =========================================================

      btnCancel =
          CreateActionButton("CANCEL");

      btnClear =
          CreateActionButton("CLEAR");

      btnSpace =
          CreateActionButton("SPACE");

      btnBackspace =
          CreateActionButton("BACK");

      btnEnter =
          CreateActionButton("ENTER");

      // ---------------------------------------------------------
      // Events
      // ---------------------------------------------------------

      btnCancel.Click += btnCancel_Click;

      btnClear.Click += btnClear_Click;

      btnSpace.Click += btnSpace_Click;

      btnBackspace.Click += btnBackspace_Click;

      btnEnter.Click += btnEnter_Click;

      // ---------------------------------------------------------
      // Cancel
      // ---------------------------------------------------------

      tblKeyboard.Controls.Add(
          btnCancel,
          0,
          4);

      tblKeyboard.SetColumnSpan(
          btnCancel,
          2);

      // ---------------------------------------------------------
      // Clear
      // ---------------------------------------------------------

      tblKeyboard.Controls.Add(
          btnClear,
          2,
          4);

      tblKeyboard.SetColumnSpan(
          btnClear,
          2);

      // ---------------------------------------------------------
      // Space
      // ---------------------------------------------------------

      tblKeyboard.Controls.Add(
          btnSpace,
          4,
          4);

      tblKeyboard.SetColumnSpan(
          btnSpace,
          3);

      // ---------------------------------------------------------
      // Back
      // ---------------------------------------------------------

      tblKeyboard.Controls.Add(
          btnBackspace,
          7,
          4);

      // ---------------------------------------------------------
      // Enter
      // ---------------------------------------------------------

      tblKeyboard.Controls.Add(
          btnEnter,
          8,
          4);

      tblKeyboard.SetColumnSpan(
          btnEnter,
          2);

      // =========================================================
      // Action Button Colors
      // =========================================================

      btnCancel.BackColor =
          Color.FromArgb(239, 68, 68);

      btnCancel.ForeColor =
          Color.White;

      btnClear.BackColor =
          Color.FromArgb(251, 191, 36);

      btnClear.ForeColor =
          Color.FromArgb(31, 41, 55);

      btnBackspace.BackColor =
          Color.FromArgb(96, 165, 250);

      btnBackspace.ForeColor =
          Color.White;

      btnEnter.BackColor =
          Color.FromArgb(34, 197, 94);

      btnEnter.ForeColor =
          Color.White;

      // =========================================================
      // Add Main Controls
      // =========================================================

      Controls.Add(tblKeyboard);
      Controls.Add(lblDisplay);

      ResumeLayout(false);
    }

    // =============================================================
    // Add Letter Row
    // =============================================================

    private void AddLetterRow(
        string[] letters,
        int row,
        int startColumn)
    {
      for (int i = 0; i < letters.Length; i++)
      {
        Button button =
            CreateKeyButton(
                letters[i],
                true);

        button.Click += LetterButton_Click;

        tblKeyboard.Controls.Add(
            button,
            startColumn + i,
            row);
      }
    }

    // =============================================================
    // Create Keyboard Key
    // =============================================================

    private static Button CreateKeyButton(
        string text,
        bool letter)
    {
      Button button = new()
      {
        Text = text,

        Tag = letter
              ? "letter"
              : null,

        Dock = DockStyle.Fill,

        Margin = new Padding(5),

        Font = new Font(
              "Segoe UI",
              19F,
              FontStyle.Bold),

        BackColor = Color.White,

        ForeColor =
              Color.FromArgb(31, 41, 55),

        FlatStyle = FlatStyle.Flat,

        Cursor = Cursors.Hand,

        TabStop = false
      };

      button.FlatAppearance.BorderColor =
          Color.FromArgb(209, 213, 219);

      button.FlatAppearance.BorderSize = 1;

      return button;
    }

    // =============================================================
    // Create Action Key
    // =============================================================

    private static Button CreateActionButton(
        string text)
    {
      Button button =
          CreateKeyButton(
              text,
              false);

      button.Font = new Font(
          "Segoe UI",
          13F,
          FontStyle.Bold);

      return button;
    }
  }
}