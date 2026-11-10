using CorteNext.Controls;

namespace CorteNext.Forms
{
  partial class CorteForm
  {
    private System.ComponentModel.IContainer? components = null;

    // =========================================================
    // MAIN CONTAINERS
    // =========================================================

    private Panel pnlHeader;
    private Panel pnlTotals;
    private Panel pnlShortOver;
    private Panel pnlFooter;

    private TableLayoutPanel tblMain;
    private TableLayoutPanel tblCash;
    private TableLayoutPanel tblExtraAmounts;
    private TableLayoutPanel tblTotals;

    // =========================================================
    // HEADER
    // =========================================================

    private Label lblTitle;
    private Label lblDate;

    // =========================================================
    // CASH ENTRY
    // =========================================================

    private TouchAmountBox amountOne;
    private TouchAmountBox amountFive;
    private TouchAmountBox amountTen;
    private TouchAmountBox amountTwenty;
    private TouchAmountBox amountFifty;
    private TouchAmountBox amountHundred;
    private TouchAmountBox amountQuarter;

    // =========================================================
    // OTHER AMOUNTS
    // =========================================================

    private TouchAmountBox amountDriveTip;
    private TouchAmountBox amountExpenses;
    private TouchAmountBox amountSales;

    // =========================================================
    // TOTALS
    // =========================================================

    private Label lblTotalCashCaption;
    private Label lblTotalCashValue;

    private Label lblGrossCaption;
    private Label lblGrossValue;

    private Label lblFondoCaption;
    private Label lblFondoValue;

    private Label lblNetCaption;
    private Label lblNetValue;

    // =========================================================
    // SHORT / OVER
    // =========================================================

    private Label lblShortOverCaption;
    private Label lblShortOverValue;

    // =========================================================
    // STAFF / ACTIONS
    // =========================================================

    private Button btnStaffName;
    private Button btnCancel;
    private Button btnSave;

    // =========================================================
    // DISPOSE
    // =========================================================

    protected override void Dispose(bool disposing)
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
      pnlHeader = new Panel();
      pnlTotals = new Panel();
      pnlShortOver = new Panel();
      pnlFooter = new Panel();

      tblMain = new TableLayoutPanel();
      tblCash = new TableLayoutPanel();
      tblExtraAmounts = new TableLayoutPanel();
      tblTotals = new TableLayoutPanel();

      lblTitle = new Label();
      lblDate = new Label();

      amountOne = new TouchAmountBox();
      amountFive = new TouchAmountBox();
      amountTen = new TouchAmountBox();
      amountTwenty = new TouchAmountBox();
      amountFifty = new TouchAmountBox();
      amountHundred = new TouchAmountBox();
      amountQuarter = new TouchAmountBox();

      amountDriveTip = new TouchAmountBox();
      amountExpenses = new TouchAmountBox();
      amountSales = new TouchAmountBox();

      lblTotalCashCaption = new Label();
      lblTotalCashValue = new Label();

      lblGrossCaption = new Label();
      lblGrossValue = new Label();

      lblFondoCaption = new Label();
      lblFondoValue = new Label();

      lblNetCaption = new Label();
      lblNetValue = new Label();

      lblShortOverCaption = new Label();
      lblShortOverValue = new Label();

      btnStaffName = new Button();
      btnCancel = new Button();
      btnSave = new Button();

      pnlHeader.SuspendLayout();
      pnlTotals.SuspendLayout();
      pnlShortOver.SuspendLayout();
      pnlFooter.SuspendLayout();

      tblMain.SuspendLayout();
      tblCash.SuspendLayout();
      tblExtraAmounts.SuspendLayout();
      tblTotals.SuspendLayout();

      SuspendLayout();

      // =========================================================
      // CORTE FORM
      // =========================================================

      AutoScaleMode = AutoScaleMode.Dpi;

      BackColor =
          Color.FromArgb(245, 247, 250);

      ClientSize =
          new Size(1200, 850);

      MinimumSize =
          new Size(1050, 750);

      FormBorderStyle =
          FormBorderStyle.None;

      Text = "Corte";

      Load +=
          CorteForm_Load;

      // =========================================================
      // HEADER
      // =========================================================

      pnlHeader.Dock =
          DockStyle.Top;

      pnlHeader.Height =
          100;

      pnlHeader.BackColor =
          Color.FromArgb(31, 41, 55);

      // ---------------------------------------------------------
      // Title
      // ---------------------------------------------------------

      lblTitle.Dock =
          DockStyle.Top;

      lblTitle.Height =
          60;

      lblTitle.Text =
          "CORTE";

      lblTitle.TextAlign =
          ContentAlignment.BottomCenter;

      lblTitle.Font =
          new Font(
              "Segoe UI",
              24F,
              FontStyle.Bold);

      lblTitle.ForeColor =
          Color.White;

      // ---------------------------------------------------------
      // Date
      // ---------------------------------------------------------

      lblDate.Dock =
          DockStyle.Fill;

      lblDate.Text =
          "Date";

      lblDate.TextAlign =
          ContentAlignment.TopCenter;

      lblDate.Font =
          new Font(
              "Segoe UI",
              13F,
              FontStyle.Regular);

      lblDate.ForeColor =
          Color.FromArgb(191, 219, 254);

      pnlHeader.Controls.Add(
          lblDate);

      pnlHeader.Controls.Add(
          lblTitle);

      // =========================================================
      // MAIN TABLE
      // =========================================================

      tblMain.Dock =
          DockStyle.Fill;

      tblMain.Padding =
          new Padding(20);

      tblMain.ColumnCount =
          1;

      tblMain.RowCount =
          6;

      tblMain.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              100F));

      tblMain.RowStyles.Add(
          new RowStyle(
              SizeType.Percent,
              35F));

      tblMain.RowStyles.Add(
          new RowStyle(
              SizeType.Percent,
              17F));

      tblMain.RowStyles.Add(
          new RowStyle(
              SizeType.Percent,
              20F));

      tblMain.RowStyles.Add(
          new RowStyle(
              SizeType.Percent,
              12F));

      tblMain.RowStyles.Add(
          new RowStyle(
              SizeType.Percent,
              9F));

      tblMain.RowStyles.Add(
          new RowStyle(
              SizeType.Percent,
              7F));

      // =========================================================
      // CASH TABLE
      // =========================================================

      tblCash.Dock =
          DockStyle.Fill;

      tblCash.ColumnCount =
          4;

      tblCash.RowCount =
          2;

      for (int i = 0; i < 4; i++)
      {
        tblCash.ColumnStyles.Add(
            new ColumnStyle(
                SizeType.Percent,
                25F));
      }

      tblCash.RowStyles.Add(
          new RowStyle(
              SizeType.Percent,
              50F));

      tblCash.RowStyles.Add(
          new RowStyle(
              SizeType.Percent,
              50F));

      // ---------------------------------------------------------
      // $1
      // ---------------------------------------------------------

      ConfigureAmountBox(
          amountOne,
          "$1 BILLS");

      tblCash.Controls.Add(
          amountOne,
          0,
          0);

      // ---------------------------------------------------------
      // $5
      // ---------------------------------------------------------

      ConfigureAmountBox(
          amountFive,
          "$5 BILLS");

      tblCash.Controls.Add(
          amountFive,
          1,
          0);

      // ---------------------------------------------------------
      // $10
      // ---------------------------------------------------------

      ConfigureAmountBox(
          amountTen,
          "$10 BILLS");

      tblCash.Controls.Add(
          amountTen,
          2,
          0);

      // ---------------------------------------------------------
      // $20
      // ---------------------------------------------------------

      ConfigureAmountBox(
          amountTwenty,
          "$20 BILLS");

      tblCash.Controls.Add(
          amountTwenty,
          3,
          0);

      // ---------------------------------------------------------
      // $50
      // ---------------------------------------------------------

      ConfigureAmountBox(
          amountFifty,
          "$50 BILLS");

      tblCash.Controls.Add(
          amountFifty,
          0,
          1);

      // ---------------------------------------------------------
      // $100
      // ---------------------------------------------------------

      ConfigureAmountBox(
          amountHundred,
          "$100 BILLS");

      tblCash.Controls.Add(
          amountHundred,
          1,
          1);

      // ---------------------------------------------------------
      // Quarters
      // ---------------------------------------------------------

      ConfigureAmountBox(
          amountQuarter,
          "QUARTERS");

      tblCash.Controls.Add(
          amountQuarter,
          2,
          1);

      tblCash.SetColumnSpan(
          amountQuarter,
          2);

      // =========================================================
      // EXTRA AMOUNT TABLE
      // =========================================================

      tblExtraAmounts.Dock =
          DockStyle.Fill;

      tblExtraAmounts.ColumnCount =
          3;

      tblExtraAmounts.RowCount =
          1;

      tblExtraAmounts.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              33.33F));

      tblExtraAmounts.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              33.33F));

      tblExtraAmounts.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              33.34F));

      ConfigureAmountBox(
          amountDriveTip,
          "DRIVE TIPS");

      ConfigureAmountBox(
          amountExpenses,
          "EXPENSES");

      ConfigureAmountBox(
          amountSales,
          "SALES");

      tblExtraAmounts.Controls.Add(
          amountDriveTip,
          0,
          0);

      tblExtraAmounts.Controls.Add(
          amountExpenses,
          1,
          0);

      tblExtraAmounts.Controls.Add(
          amountSales,
          2,
          0);

      // =========================================================
      // TOTALS PANEL
      // =========================================================

      pnlTotals.Dock =
          DockStyle.Fill;

      pnlTotals.BackColor =
          Color.FromArgb(239, 246, 255);

      pnlTotals.Padding =
          new Padding(20, 10, 20, 10);

      // =========================================================
      // TOTALS TABLE
      // =========================================================

      tblTotals.Dock =
          DockStyle.Fill;

      tblTotals.ColumnCount =
          2;

      tblTotals.RowCount =
          4;

      tblTotals.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              50F));

      tblTotals.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              50F));

      for (int i = 0; i < 4; i++)
      {
        tblTotals.RowStyles.Add(
            new RowStyle(
                SizeType.Percent,
                25F));
      }

      // =========================================================
      // TOTAL CASH
      // =========================================================

      ConfigureTotalCaption(
          lblTotalCashCaption,
          "TOTAL CASH");

      ConfigureTotalValue(
          lblTotalCashValue,
          "$0.00",
          Color.FromArgb(31, 41, 55));

      tblTotals.Controls.Add(
          lblTotalCashCaption,
          0,
          0);

      tblTotals.Controls.Add(
          lblTotalCashValue,
          1,
          0);

      // =========================================================
      // GROSS TOTAL
      // =========================================================

      ConfigureTotalCaption(
          lblGrossCaption,
          "GROSS TOTAL");

      ConfigureTotalValue(
          lblGrossValue,
          "$0.00",
          Color.FromArgb(31, 41, 55));

      tblTotals.Controls.Add(
          lblGrossCaption,
          0,
          1);

      tblTotals.Controls.Add(
          lblGrossValue,
          1,
          1);

      // =========================================================
      // FONDO
      // =========================================================

      ConfigureTotalCaption(
          lblFondoCaption,
          "FONDO");

      ConfigureTotalValue(
          lblFondoValue,
          "$0.00",
          Color.FromArgb(185, 28, 28));

      tblTotals.Controls.Add(
          lblFondoCaption,
          0,
          2);

      tblTotals.Controls.Add(
          lblFondoValue,
          1,
          2);

      // =========================================================
      // NET TOTAL
      // =========================================================

      ConfigureTotalCaption(
          lblNetCaption,
          "NET TOTAL");

      ConfigureTotalValue(
          lblNetValue,
          "$0.00",
          Color.FromArgb(22, 101, 52));

      lblNetCaption.Font =
          new Font(
              "Segoe UI",
              17F,
              FontStyle.Bold);

      lblNetValue.Font =
          new Font(
              "Segoe UI",
              20F,
              FontStyle.Bold);

      tblTotals.Controls.Add(
          lblNetCaption,
          0,
          3);

      tblTotals.Controls.Add(
          lblNetValue,
          1,
          3);

      pnlTotals.Controls.Add(
          tblTotals);

      // =========================================================
      // SHORT / OVER
      // =========================================================

      pnlShortOver.Dock =
          DockStyle.Fill;

      pnlShortOver.BackColor =
          Color.FromArgb(219, 234, 254);

      lblShortOverCaption.Dock =
          DockStyle.Left;

      lblShortOverCaption.Width =
          500;

      lblShortOverCaption.Text =
          "BALANCED";

      lblShortOverCaption.TextAlign =
          ContentAlignment.MiddleRight;

      lblShortOverCaption.Font =
          new Font(
              "Segoe UI",
              23F,
              FontStyle.Bold);

      lblShortOverCaption.ForeColor =
          Color.FromArgb(30, 64, 175);

      lblShortOverValue.Dock =
          DockStyle.Fill;

      lblShortOverValue.Text =
          "$0.00";

      lblShortOverValue.TextAlign =
          ContentAlignment.MiddleLeft;

      lblShortOverValue.Padding =
          new Padding(35, 0, 0, 0);

      lblShortOverValue.Font =
          new Font(
              "Segoe UI",
              30F,
              FontStyle.Bold);

      lblShortOverValue.ForeColor =
          Color.FromArgb(30, 64, 175);

      pnlShortOver.Controls.Add(
          lblShortOverValue);

      pnlShortOver.Controls.Add(
          lblShortOverCaption);

      // =========================================================
      // STAFF NAME
      // =========================================================

      btnStaffName.Dock =
          DockStyle.Fill;

      btnStaffName.Margin =
          new Padding(8);

      btnStaffName.Text =
          "TOUCH TO ENTER STAFF NAME";

      btnStaffName.Font =
          new Font(
              "Segoe UI",
              16F,
              FontStyle.Bold);

      btnStaffName.BackColor =
          Color.White;

      btnStaffName.ForeColor =
          Color.FromArgb(31, 41, 55);

      btnStaffName.FlatStyle =
          FlatStyle.Flat;

      btnStaffName.FlatAppearance.BorderColor =
          Color.FromArgb(156, 163, 175);

      btnStaffName.FlatAppearance.BorderSize =
          2;

      btnStaffName.Cursor =
          Cursors.Hand;

      btnStaffName.TabStop =
          false;

      btnStaffName.Click +=
          btnStaffName_Click;

      // =========================================================
      // FOOTER
      // =========================================================

      pnlFooter.Dock =
          DockStyle.Fill;

      pnlFooter.Padding =
          new Padding(10, 5, 10, 5);

      pnlFooter.BackColor =
          Color.FromArgb(229, 231, 235);

      // ---------------------------------------------------------
      // Cancel
      // ---------------------------------------------------------

      btnCancel.Dock =
          DockStyle.Left;

      btnCancel.Width =
          300;

      btnCancel.Text =
          "CANCEL";

      btnCancel.Font =
          new Font(
              "Segoe UI",
              16F,
              FontStyle.Bold);

      btnCancel.BackColor =
          Color.FromArgb(239, 68, 68);

      btnCancel.ForeColor =
          Color.White;

      btnCancel.FlatStyle =
          FlatStyle.Flat;

      btnCancel.FlatAppearance.BorderSize =
          0;

      btnCancel.Cursor =
          Cursors.Hand;

      btnCancel.TabStop =
          false;

      btnCancel.Click +=
          btnCancel_Click;

      // ---------------------------------------------------------
      // Save
      // ---------------------------------------------------------

      btnSave.Dock =
          DockStyle.Right;

      btnSave.Width =
          330;

      btnSave.Text =
          "SAVE CORTE";

      btnSave.Font =
          new Font(
              "Segoe UI",
              16F,
              FontStyle.Bold);

      btnSave.BackColor =
          Color.FromArgb(34, 197, 94);

      btnSave.ForeColor =
          Color.White;

      btnSave.FlatStyle =
          FlatStyle.Flat;

      btnSave.FlatAppearance.BorderSize =
          0;

      btnSave.Cursor =
          Cursors.Hand;

      btnSave.TabStop =
          false;

      btnSave.Enabled =
          false;

      btnSave.Click +=
          btnSave_Click;

      pnlFooter.Controls.Add(
          btnCancel);

      pnlFooter.Controls.Add(
          btnSave);

      // =========================================================
      // BUILD MAIN LAYOUT
      // =========================================================

      tblMain.Controls.Add(
          tblCash,
          0,
          0);

      tblMain.Controls.Add(
          tblExtraAmounts,
          0,
          1);

      tblMain.Controls.Add(
          pnlTotals,
          0,
          2);

      tblMain.Controls.Add(
          pnlShortOver,
          0,
          3);

      tblMain.Controls.Add(
          btnStaffName,
          0,
          4);

      tblMain.Controls.Add(
          pnlFooter,
          0,
          5);

      // =========================================================
      // ADD FORM CONTROLS
      // =========================================================

      Controls.Add(
          tblMain);

      Controls.Add(
          pnlHeader);

      // =========================================================
      // FINISH
      // =========================================================

      pnlHeader.ResumeLayout(false);

      tblCash.ResumeLayout(false);
      tblExtraAmounts.ResumeLayout(false);
      tblTotals.ResumeLayout(false);

      pnlTotals.ResumeLayout(false);
      pnlShortOver.ResumeLayout(false);
      pnlFooter.ResumeLayout(false);

      tblMain.ResumeLayout(false);

      ResumeLayout(false);
    }

    // =============================================================
    // TOUCH AMOUNT BOX
    // =============================================================

    private static void ConfigureAmountBox(
        TouchAmountBox control,
        string caption)
    {
      control.Caption =
          caption;

      control.Dock =
          DockStyle.Fill;

      control.Margin =
          new Padding(7);

      control.Value =
          0M;

      control.AllowNegative =
          false;

      control.ReadOnly =
          false;
    }

    // =============================================================
    // TOTAL CAPTION
    // =============================================================

    private static void ConfigureTotalCaption(
        Label label,
        string text)
    {
      label.Dock =
          DockStyle.Fill;

      label.Text =
          text;

      label.TextAlign =
          ContentAlignment.MiddleRight;

      label.Padding =
          new Padding(0, 0, 20, 0);

      label.Font =
          new Font(
              "Segoe UI",
              15F,
              FontStyle.Bold);

      label.ForeColor =
          Color.FromArgb(75, 85, 99);
    }

    // =============================================================
    // TOTAL VALUE
    // =============================================================

    private static void ConfigureTotalValue(
        Label label,
        string text,
        Color color)
    {
      label.Dock =
          DockStyle.Fill;

      label.Text =
          text;

      label.TextAlign =
          ContentAlignment.MiddleLeft;

      label.Padding =
          new Padding(20, 0, 0, 0);

      label.Font =
          new Font(
              "Segoe UI",
              17F,
              FontStyle.Bold);

      label.ForeColor =
          color;
    }
  }
}