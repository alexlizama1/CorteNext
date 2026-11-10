namespace CorteNext.Forms
{
  partial class PinPadForm
  {
    private System.ComponentModel.IContainer? components = null;

    private Label lblDisplay;
    private Label lblPinCount;

    private TableLayoutPanel tblKeys;

    private Button btn0;
    private Button btn1;
    private Button btn2;
    private Button btn3;
    private Button btn4;
    private Button btn5;
    private Button btn6;
    private Button btn7;
    private Button btn8;
    private Button btn9;

    private Button btnClear;
    private Button btnBackspace;
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
      lblPinCount = new Label();

      tblKeys = new TableLayoutPanel();

      btn0 = CreateNumberButton("0");
      btn1 = CreateNumberButton("1");
      btn2 = CreateNumberButton("2");
      btn3 = CreateNumberButton("3");
      btn4 = CreateNumberButton("4");
      btn5 = CreateNumberButton("5");
      btn6 = CreateNumberButton("6");
      btn7 = CreateNumberButton("7");
      btn8 = CreateNumberButton("8");
      btn9 = CreateNumberButton("9");

      btnClear =
          CreateActionButton("CLEAR");

      btnBackspace =
          CreateActionButton("BACK");

      btnCancel =
          CreateActionButton("CANCEL");

      btnEnter =
          CreateActionButton("ENTER");

      SuspendLayout();

      // =====================================================
      // FORM
      // =====================================================

      AutoScaleMode =
          AutoScaleMode.Dpi;

      BackColor =
          Color.FromArgb(245, 247, 250);

      ClientSize =
          new Size(1200, 1200);

      FormBorderStyle =
          FormBorderStyle.FixedDialog;

      StartPosition =
          FormStartPosition.CenterParent;

      MaximizeBox = false;
      MinimizeBox = false;

      Text =
          "Enter PIN";

      Load +=
          PinPadForm_Load;

      // =====================================================
      // DISPLAY
      // =====================================================

      lblDisplay.Dock =
          DockStyle.Top;

      lblDisplay.Height =
          130;

      lblDisplay.Text =
          "ENTER PIN";

      lblDisplay.TextAlign =
          ContentAlignment.MiddleCenter;

      lblDisplay.BackColor =
          Color.FromArgb(31, 41, 55);

      lblDisplay.ForeColor =
          Color.White;

      lblDisplay.Font =
          new Font(
              "Segoe UI",
              28F,
              FontStyle.Bold);

      // =====================================================
      // PIN COUNT
      // =====================================================

      lblPinCount.Dock =
          DockStyle.Top;

      lblPinCount.Height =
          65;

      lblPinCount.Text =
          "0 / 6";

      lblPinCount.TextAlign =
          ContentAlignment.MiddleCenter;

      lblPinCount.BackColor =
          Color.FromArgb(55, 65, 81);

      lblPinCount.ForeColor =
          Color.WhiteSmoke;

      lblPinCount.Font =
          new Font(
              "Segoe UI",
              12F,
              FontStyle.Regular);

      // =====================================================
      // TABLE
      // =====================================================

      tblKeys.Dock =
          DockStyle.Fill;

      tblKeys.Padding =
          new Padding(15);

      tblKeys.ColumnCount =
          3;

      tblKeys.RowCount =
          5;

      for (int i = 0; i < 3; i++)
      {
        tblKeys.ColumnStyles.Add(
            new ColumnStyle(
                SizeType.Percent,
                33.33F));
      }

      for (int i = 0; i < 5; i++)
      {
          tblKeys.RowStyles.Add(
              new RowStyle(
                  SizeType.Percent,
                  15F));
   
      }

      // =====================================================
      // NUMBER EVENTS
      // =====================================================

      btn0.Click += NumberButton_Click;
      btn1.Click += NumberButton_Click;
      btn2.Click += NumberButton_Click;
      btn3.Click += NumberButton_Click;
      btn4.Click += NumberButton_Click;
      btn5.Click += NumberButton_Click;
      btn6.Click += NumberButton_Click;
      btn7.Click += NumberButton_Click;
      btn8.Click += NumberButton_Click;
      btn9.Click += NumberButton_Click;

      // =====================================================
      // ROW 1
      // =====================================================

      tblKeys.Controls.Add(
          btn7,
          0,
          0);

      tblKeys.Controls.Add(
          btn8,
          1,
          0);

      tblKeys.Controls.Add(
          btn9,
          2,
          0);

      // =====================================================
      // ROW 2
      // =====================================================

      tblKeys.Controls.Add(
          btn4,
          0,
          1);

      tblKeys.Controls.Add(
          btn5,
          1,
          1);

      tblKeys.Controls.Add(
          btn6,
          2,
          1);

      // =====================================================
      // ROW 3
      // =====================================================

      tblKeys.Controls.Add(
          btn1,
          0,
          2);

      tblKeys.Controls.Add(
          btn2,
          1,
          2);

      tblKeys.Controls.Add(
          btn3,
          2,
          2);

      // =====================================================
      // ROW 4
      // =====================================================

      btnClear.Click +=
          btnClear_Click;

      btnBackspace.Click +=
          btnBackspace_Click;

      tblKeys.Controls.Add(
          btnClear,
          0,
          3);

      tblKeys.Controls.Add(
          btn0,
          1,
          3);

      tblKeys.Controls.Add(
          btnBackspace,
          2,
          3);

      // =====================================================
      // ROW 5
      // =====================================================

      btnCancel.Click +=
          btnCancel_Click;

      btnEnter.Click +=
          btnEnter_Click;

      btnEnter.Enabled =
          false;

      btnCancel.BackColor =
          Color.FromArgb(239, 68, 68);

      btnCancel.ForeColor =
          Color.White;

      btnEnter.BackColor =
          Color.FromArgb(156, 163, 175);

      btnEnter.ForeColor =
          Color.White;

      btnClear.BackColor =
          Color.FromArgb(251, 191, 36);

      btnBackspace.BackColor =
          Color.FromArgb(96, 165, 250);

      btnBackspace.ForeColor =
          Color.White;

      tblKeys.Controls.Add(
          btnCancel,
          0,
          4);

      tblKeys.Controls.Add(
          btnEnter,
          1,
          4);

      tblKeys.SetColumnSpan(
          btnEnter,
          2);

      // =====================================================

      Controls.Add(
          tblKeys);

      Controls.Add(
          lblPinCount);

      Controls.Add(
          lblDisplay);

      ResumeLayout(false);
    }

    // =========================================================
    // NUMBER BUTTON
    // =========================================================

    private static Button CreateNumberButton(
        string text)
    {
      Button button = new()
      {
        Text = text,

        Dock =
              DockStyle.Fill,

        Margin =
              new Padding(7),

        Font =
              new Font(
                  "Segoe UI",
                  27F,
                  FontStyle.Bold),

        BackColor =
              Color.White,

        ForeColor =
              Color.FromArgb(31, 41, 55),

        FlatStyle =
              FlatStyle.Flat,

        Cursor =
              Cursors.Hand,

        TabStop =
              false
      };

      button.FlatAppearance.BorderColor =
          Color.FromArgb(209, 213, 219);

      button.FlatAppearance.BorderSize =
          1;

      return button;
    }

    // =========================================================
    // ACTION BUTTON
    // =========================================================

    private static Button CreateActionButton(
        string text)
    {
      Button button =
          CreateNumberButton(text);

      button.Font =
          new Font(
              "Segoe UI",
              14F,
              FontStyle.Bold);

      return button;
    }
  }
}