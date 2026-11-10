using CorteNext.Controls;

namespace CorteNext.Forms
{
  partial class FondoForm
  {
    private System.ComponentModel.IContainer? components = null;

    // =========================================================
    // PANELS
    // =========================================================

    private Panel pnlHeader;
    private Panel pnlTotal;
    private Panel pnlStaff;
    private Panel pnlFooter;

    // =========================================================
    // HEADER
    // =========================================================

    private Label lblTitle;
    private Label lblDate;

    // =========================================================
    // AMOUNT CONTROLS
    // =========================================================

    private TouchAmountBox amountOne;
    private TouchAmountBox amountFive;
    private TouchAmountBox amountTen;
    private TouchAmountBox amountQuarter1;
    private TouchAmountBox amountQuarter2;

    // =========================================================
    // TOTAL
    // =========================================================

    private Label lblTotalCaption;
    private Label lblTotalValue;

    // =========================================================
    // STAFF
    // =========================================================

    private Button btnStaffName;

    // =========================================================
    // FOOTER
    // =========================================================

    private Button btnCancel;
    private Button btnSave;

    // =========================================================
    // LAYOUT TABLES
    // =========================================================

    private TableLayoutPanel tblMain;
    private TableLayoutPanel tblAmounts;
    private TableLayoutPanel tblTotal;
    private TableLayoutPanel tblFooter;

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
    // INITIALIZE COMPONENT
    // =========================================================

    private void InitializeComponent()
    {
      pnlHeader = new Panel();
      pnlTotal = new Panel();
      pnlStaff = new Panel();
      pnlFooter = new Panel();

      lblTitle = new Label();
      lblDate = new Label();

      amountOne = new TouchAmountBox();
      amountFive = new TouchAmountBox();
      amountTen = new TouchAmountBox();
      amountQuarter1 = new TouchAmountBox();
      amountQuarter2 = new TouchAmountBox();

      lblTotalCaption = new Label();
      lblTotalValue = new Label();

      btnStaffName = new Button();

      btnCancel = new Button();
      btnSave = new Button();

      tblMain = new TableLayoutPanel();
      tblAmounts = new TableLayoutPanel();
      tblTotal = new TableLayoutPanel();
      tblFooter = new TableLayoutPanel();

      SuspendLayout();

      // =====================================================
      // FONDO FORM
      // =====================================================

      AutoScaleMode =
          AutoScaleMode.Dpi;

      BackColor =
          Color.FromArgb(
              245,
              247,
              250);

      ClientSize =
          new Size(
              1200,
              800);

      MinimumSize =
          new Size(
              1000,
              700);

      FormBorderStyle =
          FormBorderStyle.None;

      Text =
          "Fondo";

      Load +=
          FondoForm_Load;

      // =====================================================
      // HEADER PANEL
      // =====================================================

      pnlHeader.Dock =
          DockStyle.Top;

      pnlHeader.Height =
          100;

      pnlHeader.BackColor =
          Color.FromArgb(
              31,
              41,
              55);

      // -----------------------------------------------------
      // Title
      // -----------------------------------------------------

      lblTitle.Dock =
          DockStyle.Top;

      lblTitle.Height =
          62;

      lblTitle.Text =
          "FONDO";

      lblTitle.TextAlign =
          ContentAlignment.BottomCenter;

      lblTitle.Font =
          new Font(
              "Segoe UI",
              26F,
              FontStyle.Bold);

      lblTitle.ForeColor =
          Color.White;

      // -----------------------------------------------------
      // Date
      // -----------------------------------------------------

      lblDate.Dock =
          DockStyle.Fill;

      lblDate.Text =
          string.Empty;

      lblDate.TextAlign =
          ContentAlignment.TopCenter;

      lblDate.Font =
          new Font(
              "Segoe UI",
              14F,
              FontStyle.Regular);

      lblDate.ForeColor =
          Color.FromArgb(
              191,
              219,
              254);

      pnlHeader.Controls.Add(
          lblDate);

      pnlHeader.Controls.Add(
          lblTitle);

      // =====================================================
      // MAIN TABLE
      // =====================================================

      tblMain.Dock =
          DockStyle.Fill;

      tblMain.Padding =
          new Padding(
              22,
              18,
              22,
              18);

      tblMain.BackColor =
          Color.FromArgb(
              245,
              247,
              250);

      tblMain.ColumnCount =
          1;

      tblMain.RowCount =
          4;

      tblMain.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              100F));

      /*
       * Amount boxes use most of the available screen.
       * The remaining areas stay large enough for touch.
       */

      tblMain.RowStyles.Add(
          new RowStyle(
              SizeType.Percent,
              58F));

      tblMain.RowStyles.Add(
          new RowStyle(
              SizeType.Percent,
              14F));

      tblMain.RowStyles.Add(
          new RowStyle(
              SizeType.Percent,
              13F));

      tblMain.RowStyles.Add(
          new RowStyle(
              SizeType.Percent,
              15F));

      // =====================================================
      // AMOUNT TABLE
      // =====================================================

      tblAmounts.Dock =
          DockStyle.Fill;

      tblAmounts.Margin =
          new Padding(0);

      tblAmounts.Padding =
          new Padding(2);

      tblAmounts.BackColor =
          Color.FromArgb(
              245,
              247,
              250);

      tblAmounts.ColumnCount =
          2;

      tblAmounts.RowCount =
          3;

      tblAmounts.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              50F));

      tblAmounts.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              50F));

      tblAmounts.RowStyles.Add(
          new RowStyle(
              SizeType.Percent,
              33.33F));

      tblAmounts.RowStyles.Add(
          new RowStyle(
              SizeType.Percent,
              33.33F));

      tblAmounts.RowStyles.Add(
          new RowStyle(
              SizeType.Percent,
              33.34F));

      // =====================================================
      // $1 BILLS
      // =====================================================

      ConfigureAmountBox(
          amountOne,
          "$1 BILLS");

      // =====================================================
      // $5 BILLS
      // =====================================================

      ConfigureAmountBox(
          amountFive,
          "$5 BILLS");

      // =====================================================
      // $10 BILLS
      // =====================================================

      ConfigureAmountBox(
          amountTen,
          "$10 BILLS");

      // =====================================================
      // QUARTERS
      // =====================================================

      ConfigureAmountBox(
          amountQuarter1,
          "QUARTERS");

      // =====================================================
      // QUARTERS 2
      // =====================================================

      ConfigureAmountBox(
          amountQuarter2,
          "QUARTERS 2");

      // -----------------------------------------------------
      // Add amount controls
      // -----------------------------------------------------

      tblAmounts.Controls.Add(
          amountOne,
          0,
          0);

      tblAmounts.Controls.Add(
          amountFive,
          1,
          0);

      tblAmounts.Controls.Add(
          amountTen,
          0,
          1);

      tblAmounts.Controls.Add(
          amountQuarter1,
          1,
          1);

      tblAmounts.Controls.Add(
          amountQuarter2,
          0,
          2);

      tblAmounts.SetColumnSpan(
          amountQuarter2,
          2);

      // =====================================================
      // TOTAL PANEL
      // =====================================================

      pnlTotal.Dock =
          DockStyle.Fill;

      pnlTotal.Margin =
          new Padding(
              8,
              10,
              8,
              6);

      pnlTotal.Padding =
          new Padding(
              20,
              5,
              20,
              5);

      pnlTotal.BackColor =
          Color.FromArgb(
              219,
              234,
              254);

      tblTotal.Dock =
          DockStyle.Fill;

      tblTotal.Margin =
          new Padding(0);

      tblTotal.ColumnCount =
          2;

      tblTotal.RowCount =
          1;

      tblTotal.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              45F));

      tblTotal.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              55F));

      tblTotal.RowStyles.Add(
          new RowStyle(
              SizeType.Percent,
              100F));

      // -----------------------------------------------------
      // Total caption
      // -----------------------------------------------------

      lblTotalCaption.Dock =
          DockStyle.Fill;

      lblTotalCaption.Text =
          "TOTAL FONDO";

      lblTotalCaption.TextAlign =
          ContentAlignment.MiddleRight;

      lblTotalCaption.Padding =
          new Padding(
              0,
              0,
              24,
              0);

      lblTotalCaption.Font =
          new Font(
              "Segoe UI",
              21F,
              FontStyle.Bold);

      lblTotalCaption.ForeColor =
          Color.FromArgb(
              30,
              64,
              175);

      // -----------------------------------------------------
      // Total value
      // -----------------------------------------------------

      lblTotalValue.Dock =
          DockStyle.Fill;

      lblTotalValue.Text =
          "$0.00";

      lblTotalValue.TextAlign =
          ContentAlignment.MiddleLeft;

      lblTotalValue.Padding =
          new Padding(
              24,
              0,
              0,
              0);

      lblTotalValue.Font =
          new Font(
              "Segoe UI",
              32F,
              FontStyle.Bold);

      lblTotalValue.ForeColor =
          Color.FromArgb(
              22,
              101,
              52);

      tblTotal.Controls.Add(
          lblTotalCaption,
          0,
          0);

      tblTotal.Controls.Add(
          lblTotalValue,
          1,
          0);

      pnlTotal.Controls.Add(
          tblTotal);

      // =====================================================
      // STAFF PANEL
      // =====================================================

      pnlStaff.Dock =
          DockStyle.Fill;

      pnlStaff.Margin =
          new Padding(
              8,
              6,
              8,
              6);

      pnlStaff.Padding =
          new Padding(
              2);

      pnlStaff.BackColor =
          Color.FromArgb(
              245,
              247,
              250);

      // -----------------------------------------------------
      // Staff button
      // -----------------------------------------------------

      btnStaffName.Dock =
          DockStyle.Fill;

      btnStaffName.Margin =
          new Padding(0);

      btnStaffName.Text =
          "TOUCH TO ENTER STAFF NAME";

      btnStaffName.TextAlign =
          ContentAlignment.MiddleCenter;

      btnStaffName.Font =
          new Font(
              "Segoe UI",
              18F,
              FontStyle.Bold);

      btnStaffName.BackColor =
          Color.White;

      btnStaffName.ForeColor =
          Color.FromArgb(
              31,
              41,
              55);

      btnStaffName.FlatStyle =
          FlatStyle.Flat;

      btnStaffName.FlatAppearance.BorderColor =
          Color.FromArgb(
              156,
              163,
              175);

      btnStaffName.FlatAppearance.BorderSize =
          2;

      btnStaffName.Cursor =
          Cursors.Hand;

      btnStaffName.TabStop =
          false;

      btnStaffName.Click +=
          btnStaffName_Click;

      pnlStaff.Controls.Add(
          btnStaffName);

      // =====================================================
      // FOOTER PANEL
      // =====================================================

      pnlFooter.Dock =
          DockStyle.Fill;

      pnlFooter.Margin =
          new Padding(
              8,
              6,
              8,
              0);

      pnlFooter.Padding =
          new Padding(
              4);

      pnlFooter.BackColor =
          Color.FromArgb(
              229,
              231,
              235);

      tblFooter.Dock =
          DockStyle.Fill;

      tblFooter.Margin =
          new Padding(0);

      tblFooter.ColumnCount =
          3;

      tblFooter.RowCount =
          1;

      tblFooter.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              32F));

      tblFooter.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              8F));

      tblFooter.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              60F));

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
              68),
          Color.White);

      btnCancel.Click +=
          btnCancel_Click;

      // =====================================================
      // SAVE FONDO
      // =====================================================

      ConfigureFooterButton(
          btnSave,
          "SAVE FONDO",
          Color.FromArgb(
              34,
              197,
              94),
          Color.FromArgb(
              5,
              46,
              22));

      btnSave.Click +=
          btnSave_Click;

      tblFooter.Controls.Add(
          btnCancel,
          0,
          0);

      tblFooter.Controls.Add(
          btnSave,
          2,
          0);

      pnlFooter.Controls.Add(
          tblFooter);

      // =====================================================
      // BUILD MAIN TABLE
      // =====================================================

      tblMain.Controls.Add(
          tblAmounts,
          0,
          0);

      tblMain.Controls.Add(
          pnlTotal,
          0,
          1);

      tblMain.Controls.Add(
          pnlStaff,
          0,
          2);

      tblMain.Controls.Add(
          pnlFooter,
          0,
          3);

      // =====================================================
      // ADD FORM CONTROLS
      // =====================================================

      Controls.Add(
          tblMain);

      Controls.Add(
          pnlHeader);

      // =====================================================
      // FINISH
      // =====================================================

      ResumeLayout(false);
    }

    // =========================================================
    // AMOUNT BOX
    // =========================================================

    private static void ConfigureAmountBox(
        TouchAmountBox control,
        string caption)
    {
      control.Caption =
          caption;

      control.Dock =
          DockStyle.Fill;

      control.Margin =
          new Padding(
              10);

      control.MinimumSize =
          new Size(
              280,
              115);

      control.Value =
          0M;

      control.AllowNegative =
          false;

      control.ReadOnly =
          false;

      control.OpenNumberPad =
          true;
    }

    // =========================================================
    // FOOTER BUTTON
    // =========================================================

    private static void ConfigureFooterButton(
        Button button,
        string text,
        Color backgroundColor,
        Color foregroundColor)
    {
      button.Dock =
          DockStyle.Fill;

      button.Margin =
          new Padding(
              8);

      button.Text =
          text;

      button.Font =
          new Font(
              "Segoe UI",
              19F,
              FontStyle.Bold);

      button.BackColor =
          backgroundColor;

      button.ForeColor =
          foregroundColor;

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