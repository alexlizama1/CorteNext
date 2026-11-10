namespace CorteNext.Forms
{
  partial class NumberPadForm
  {
    private System.ComponentModel.IContainer? components = null;

    // =========================================================
    // MAIN LAYOUT
    // =========================================================

    private TableLayoutPanel tblMain;
    private TableLayoutPanel tblKeys;
    private TableLayoutPanel tblFooter;

    // =========================================================
    // DISPLAY
    // =========================================================

    private Panel pnlDisplay;
    private Label lblDisplay;

    // =========================================================
    // NUMBER BUTTONS
    // =========================================================

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

    // =========================================================
    // FUNCTION BUTTONS
    // =========================================================

    private Button btnDecimal;
    private Button btnBackspace;
    private Button btnClear;
    private Button btnNegative;

    // =========================================================
    // FOOTER BUTTONS
    // =========================================================

    private Button btnCancel;
    private Button btnOK;

    // =========================================================
    // DISPOSE
    // =========================================================

    protected override void Dispose(
        bool disposing)
    {
      if (disposing)
      {
        components?.Dispose();
      }

      base.Dispose(disposing);
    }

    // =========================================================
    // INITIALIZE
    // =========================================================

    private void InitializeComponent()
    {
      tblMain = new TableLayoutPanel();
      tblKeys = new TableLayoutPanel();
      tblFooter = new TableLayoutPanel();

      pnlDisplay = new Panel();
      lblDisplay = new Label();

      btn0 = new Button();
      btn1 = new Button();
      btn2 = new Button();
      btn3 = new Button();
      btn4 = new Button();
      btn5 = new Button();
      btn6 = new Button();
      btn7 = new Button();
      btn8 = new Button();
      btn9 = new Button();

      btnDecimal = new Button();
      btnBackspace = new Button();
      btnClear = new Button();
      btnNegative = new Button();

      btnCancel = new Button();
      btnOK = new Button();

      SuspendLayout();

      // =====================================================
      // FORM
      // =====================================================

      AutoScaleMode =
          AutoScaleMode.Dpi;

      BackColor =
          Color.FromArgb(
              229,
              231,
              235);

      ClientSize =
          new Size(
              1200,
              1500);

      MinimumSize =
          new Size(
              900,
              1200);

      MaximumSize =
          new Size(
              900,
              1200);

      FormBorderStyle =
          FormBorderStyle.FixedDialog;

      StartPosition =
          FormStartPosition.CenterParent;

      MaximizeBox =
          false;

      MinimizeBox =
          false;

      ShowInTaskbar =
          false;

      Text =
          "Enter Amount";

      // =====================================================
      // MAIN TABLE
      //
      // Display = 20%
      // Keypad  = 65%
      // Footer  = 15%
      // =====================================================

      tblMain.Dock =
          DockStyle.Fill;

      tblMain.Margin =
          new Padding(0);

      tblMain.Padding =
          new Padding(18);

      tblMain.AutoSize =
          false;

      tblMain.GrowStyle =
          TableLayoutPanelGrowStyle.FixedSize;

      tblMain.ColumnCount =
          1;

      tblMain.RowCount =
          3;

      tblMain.ColumnStyles.Clear();

      tblMain.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              100F));

      tblMain.RowStyles.Clear();

      tblMain.RowStyles.Add(
          new RowStyle(
              SizeType.Percent,
              20F));

      tblMain.RowStyles.Add(
          new RowStyle(
              SizeType.Percent,
              65F));

      tblMain.RowStyles.Add(
          new RowStyle(
              SizeType.Percent,
              15F));

      // =====================================================
      // DISPLAY PANEL
      // =====================================================

      pnlDisplay.Dock =
          DockStyle.Fill;

      pnlDisplay.Margin =
          new Padding(
              6,
              6,
              6,
              12);

      pnlDisplay.Padding =
          new Padding(
              14,
              10,
              14,
              10);

      pnlDisplay.BackColor =
          Color.White;

      // =====================================================
      // DISPLAY LABEL
      // =====================================================

      lblDisplay.Dock =
          DockStyle.Fill;

      lblDisplay.AutoSize =
          false;

      lblDisplay.AutoEllipsis =
          false;

      lblDisplay.Text =
          "0.00";

      lblDisplay.TextAlign =
          ContentAlignment.MiddleRight;

      lblDisplay.Padding =
          new Padding(
              10,
              0,
              15,
              4);

      lblDisplay.Font =
          new System.Drawing.Font(
              "Segoe UI",
              38F,
              System.Drawing.FontStyle.Bold);

      lblDisplay.ForeColor =
          Color.FromArgb(
              17,
              24,
              39);

      lblDisplay.BackColor =
          Color.White;

      pnlDisplay.Controls.Add(
          lblDisplay);

      // =====================================================
      // KEYPAD TABLE
      //
      // 3 columns
      // 5 proportional rows
      // =====================================================

      tblKeys.Dock =
          DockStyle.Fill;

      tblKeys.Margin =
          new Padding(0);

      tblKeys.Padding =
          new Padding(0);

      tblKeys.AutoSize =
          false;

      tblKeys.GrowStyle =
          TableLayoutPanelGrowStyle.FixedSize;

      tblKeys.ColumnCount =
          3;

      tblKeys.RowCount =
          5;

      tblKeys.ColumnStyles.Clear();

      tblKeys.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              33.3333F));

      tblKeys.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              33.3333F));

      tblKeys.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              33.3334F));

      tblKeys.RowStyles.Clear();

      for (int row = 0; row < 5; row++)
      {
        tblKeys.RowStyles.Add(
            new RowStyle(
                SizeType.Percent,
                20F));
      }

      // =====================================================
      // NUMBER BUTTONS
      // =====================================================

      ConfigureNumberButton(
          btn7,
          "7");

      ConfigureNumberButton(
          btn8,
          "8");

      ConfigureNumberButton(
          btn9,
          "9");

      ConfigureNumberButton(
          btn4,
          "4");

      ConfigureNumberButton(
          btn5,
          "5");

      ConfigureNumberButton(
          btn6,
          "6");

      ConfigureNumberButton(
          btn1,
          "1");

      ConfigureNumberButton(
          btn2,
          "2");

      ConfigureNumberButton(
          btn3,
          "3");

      ConfigureNumberButton(
          btn0,
          "0");

      // =====================================================
      // NEGATIVE
      // =====================================================

      ConfigureFunctionButton(
          btnNegative,
          "+ / -",
          Color.FromArgb(
              243,
              232,
              255),
          Color.FromArgb(
              88,
              28,
              135));

      // =====================================================
      // DECIMAL
      // =====================================================

      ConfigureFunctionButton(
          btnDecimal,
          ".",
          Color.White,
          Color.FromArgb(
              31,
              41,
              55));

      // =====================================================
      // CLEAR
      // =====================================================

      ConfigureFunctionButton(
          btnClear,
          "CLEAR",
          Color.FromArgb(
              254,
              226,
              226),
          Color.FromArgb(
              153,
              27,
              27));

      // =====================================================
      // BACKSPACE
      // =====================================================

      ConfigureFunctionButton(
          btnBackspace,
          "⌫",
          Color.FromArgb(
              254,
              249,
              195),
          Color.FromArgb(
              133,
              77,
              14));

      // =====================================================
      // NUMBER EVENTS
      // =====================================================

      btn0.Click +=
          NumberButton_Click;

      btn1.Click +=
          NumberButton_Click;

      btn2.Click +=
          NumberButton_Click;

      btn3.Click +=
          NumberButton_Click;

      btn4.Click +=
          NumberButton_Click;

      btn5.Click +=
          NumberButton_Click;

      btn6.Click +=
          NumberButton_Click;

      btn7.Click +=
          NumberButton_Click;

      btn8.Click +=
          NumberButton_Click;

      btn9.Click +=
          NumberButton_Click;

      // =====================================================
      // FUNCTION EVENTS
      // =====================================================

      btnNegative.Click +=
          btnNegative_Click;

      btnDecimal.Click +=
          btnDecimal_Click;

      btnClear.Click +=
          btnClear_Click;

      btnBackspace.Click +=
          btnBackspace_Click;

      // =====================================================
      // KEY POSITIONS
      //
      //     7       8       9
      //
      //     4       5       6
      //
      //     1       2       3
      //
      //    +/-      0       .
      //
      //       CLEAR       BACKSPACE
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

      tblKeys.Controls.Add(
          btnNegative,
          0,
          3);

      tblKeys.Controls.Add(
          btn0,
          1,
          3);

      tblKeys.Controls.Add(
          btnDecimal,
          2,
          3);

      tblKeys.Controls.Add(
          btnClear,
          0,
          4);

      tblKeys.SetColumnSpan(
          btnClear,
          2);

      tblKeys.Controls.Add(
          btnBackspace,
          2,
          4);

      // =====================================================
      // FOOTER TABLE
      // =====================================================

      tblFooter.Dock =
          DockStyle.Fill;

      tblFooter.Margin =
          new Padding(
              0,
              10,
              0,
              0);

      tblFooter.Padding =
          new Padding(0);

      tblFooter.AutoSize =
          false;

      tblFooter.GrowStyle =
          TableLayoutPanelGrowStyle.FixedSize;

      tblFooter.ColumnCount =
          2;

      tblFooter.RowCount =
          1;

      tblFooter.ColumnStyles.Clear();

      tblFooter.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              42F));

      tblFooter.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              58F));

      tblFooter.RowStyles.Clear();

      tblFooter.RowStyles.Add(
          new RowStyle(
              SizeType.Percent,
              100F));

      // =====================================================
      // CANCEL
      // =====================================================

      ConfigureFooterButton(
          btnCancel,
          "CANCEL",
          Color.FromArgb(
              239,
              68,
              68));

      btnCancel.Click +=
          btnCancel_Click;

      // =====================================================
      // OK
      // =====================================================

      ConfigureFooterButton(
          btnOK,
          "OK",
          Color.FromArgb(
              34,
              197,
              94));

      btnOK.Click +=
          btnOK_Click;

      tblFooter.Controls.Add(
          btnCancel,
          0,
          0);

      tblFooter.Controls.Add(
          btnOK,
          1,
          0);

      // =====================================================
      // ADD MAIN CONTENT
      // =====================================================

      tblMain.Controls.Add(
          pnlDisplay,
          0,
          0);

      tblMain.Controls.Add(
          tblKeys,
          0,
          1);

      tblMain.Controls.Add(
          tblFooter,
          0,
          2);

      Controls.Add(
          tblMain);

      // =====================================================
      // FINISH
      // =====================================================

      ResumeLayout(false);
    }

    // =========================================================
    // NUMBER BUTTON
    // =========================================================

    private static void ConfigureNumberButton(
        Button button,
        string text)
    {
      button.Dock =
          DockStyle.Fill;

      button.Margin =
          new Padding(7);

      button.AutoSize =
          false;

      button.MinimumSize =
          Size.Empty;

      button.MaximumSize =
          Size.Empty;

      button.Text =
          text;

      button.TextAlign =
          ContentAlignment.MiddleCenter;

      button.Font =
          new System.Drawing.Font(
              "Segoe UI",
              34F,
              System.Drawing.FontStyle.Bold);

      button.BackColor =
          Color.White;

      button.ForeColor =
          Color.FromArgb(
              17,
              24,
              39);

      button.FlatStyle =
          FlatStyle.Flat;

      button.FlatAppearance.BorderColor =
          Color.FromArgb(
              156,
              163,
              175);

      button.FlatAppearance.BorderSize =
          2;

      button.Cursor =
          Cursors.Hand;

      button.TabStop =
          false;
    }

    // =========================================================
    // FUNCTION BUTTON
    // =========================================================

    private static void ConfigureFunctionButton(
        Button button,
        string text,
        Color backgroundColor,
        Color foregroundColor)
    {
      button.Dock =
          DockStyle.Fill;

      button.Margin =
          new Padding(7);

      button.AutoSize =
          false;

      button.MinimumSize =
          Size.Empty;

      button.MaximumSize =
          Size.Empty;

      button.Text =
          text;

      button.TextAlign =
          ContentAlignment.MiddleCenter;

      button.Font =
          new System.Drawing.Font(
              "Segoe UI",
              22F,
              System.Drawing.FontStyle.Bold);

      button.BackColor =
          backgroundColor;

      button.ForeColor =
          foregroundColor;

      button.FlatStyle =
          FlatStyle.Flat;

      button.FlatAppearance.BorderColor =
          Color.FromArgb(
              156,
              163,
              175);

      button.FlatAppearance.BorderSize =
          2;

      button.Cursor =
          Cursors.Hand;

      button.TabStop =
          false;
    }

    // =========================================================
    // FOOTER BUTTON
    // =========================================================

    private static void ConfigureFooterButton(
        Button button,
        string text,
        Color backgroundColor)
    {
      button.Dock =
          DockStyle.Fill;

      button.Margin =
          new Padding(7);

      button.AutoSize =
          false;

      button.MinimumSize =
          Size.Empty;

      button.MaximumSize =
          Size.Empty;

      button.Text =
          text;

      button.TextAlign =
          ContentAlignment.MiddleCenter;

      button.Font =
          new System.Drawing.Font(
              "Segoe UI",
              23F,
              System.Drawing.FontStyle.Bold);

      button.BackColor =
          backgroundColor;

      button.ForeColor =
          Color.White;

      button.FlatStyle =
          FlatStyle.Flat;

      button.FlatAppearance.BorderSize =
          0;

      button.Cursor =
          Cursors.Hand;

      button.TabStop =
          false;
    }
  }
}