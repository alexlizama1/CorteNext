namespace CorteNext.Forms
{
  partial class CorteReportForm
  {
    private System.ComponentModel.IContainer? components = null;

    // =========================================================
    // PANELS
    // =========================================================

    private Panel pnlHeader;
    private Panel pnlTopActions;
    private Panel pnlShiftFilters;
    private Panel pnlStatus;
    private Panel pnlFooter;

    // =========================================================
    // LABELS
    // =========================================================

    private Label lblTitle;
    private Label lblDate;
    private Label lblReportMode;
    private Label lblRecordCount;

    // =========================================================
    // REPORT BUTTONS
    // =========================================================

    private Button btnToday;
    private Button btnSelectDate;
    private Button btnLast10;

    // =========================================================
    // SHIFT FILTER BUTTONS
    // =========================================================

    private Button btnAllShifts;
    private Button btnAM;
    private Button btnPM;
    private Button btnAMDrive;
    private Button btnPMDrive;

    // =========================================================
    // FOOTER BUTTONS
    // =========================================================

    private Button btnPrint;
    private Button btnDone;

    // =========================================================
    // GRID
    // =========================================================

    private DataGridView dgvCortes;

    private DataGridViewTextBoxColumn colDate;
    private DataGridViewTextBoxColumn colTime;
    private DataGridViewTextBoxColumn colShift;
    private DataGridViewTextBoxColumn colTotalCash;
    private DataGridViewTextBoxColumn colExpenses;
    private DataGridViewTextBoxColumn colFondo;
    private DataGridViewTextBoxColumn colSales;
    private DataGridViewTextBoxColumn colShortOver;
    private DataGridViewTextBoxColumn colStaff;

    // =========================================================
    // TABLES
    // =========================================================

    private TableLayoutPanel tblTopActions;
    private TableLayoutPanel tblShiftFilters;
    private TableLayoutPanel tblFooter;

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
      pnlTopActions = new Panel();
      pnlShiftFilters = new Panel();
      pnlStatus = new Panel();
      pnlFooter = new Panel();

      lblTitle = new Label();
      lblDate = new Label();
      lblReportMode = new Label();
      lblRecordCount = new Label();

      btnToday = new Button();
      btnSelectDate = new Button();
      btnLast10 = new Button();

      btnAllShifts = new Button();
      btnAM = new Button();
      btnPM = new Button();
      btnAMDrive = new Button();
      btnPMDrive = new Button();

      btnPrint = new Button();
      btnDone = new Button();

      dgvCortes = new DataGridView();

      colDate = new DataGridViewTextBoxColumn();
      colTime = new DataGridViewTextBoxColumn();
      colShift = new DataGridViewTextBoxColumn();
      colTotalCash = new DataGridViewTextBoxColumn();
      colExpenses = new DataGridViewTextBoxColumn();
      colFondo = new DataGridViewTextBoxColumn();
      colSales = new DataGridViewTextBoxColumn();
      colShortOver = new DataGridViewTextBoxColumn();
      colStaff = new DataGridViewTextBoxColumn();

      tblTopActions = new TableLayoutPanel();
      tblShiftFilters = new TableLayoutPanel();
      tblFooter = new TableLayoutPanel();

      ((System.ComponentModel.ISupportInitialize)dgvCortes)
          .BeginInit();

      SuspendLayout();

      // =====================================================
      // CORTE REPORT FORM
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
              1400,
              850);

      MinimumSize =
          new Size(
              1100,
              700);

      FormBorderStyle =
          FormBorderStyle.None;

      Text =
          "Corte Report";

      Load +=
          CorteReportForm_Load;

      // =====================================================
      // HEADER
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
          60;

      lblTitle.Text =
          "CORTE REPORT";

      lblTitle.TextAlign =
          ContentAlignment.BottomCenter;

      lblTitle.Font =
          new Font(
              "Segoe UI",
              24F,
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
              13F,
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
      // TOP ACTIONS
      // =====================================================

      pnlTopActions.Dock =
          DockStyle.Top;

      pnlTopActions.Height =
          150;

      pnlTopActions.Padding =
          new Padding(
              15,
              10,
              15,
              10);

      pnlTopActions.BackColor =
          Color.FromArgb(
              229,
              231,
              235);

      tblTopActions.Dock =
          DockStyle.Fill;

      tblTopActions.ColumnCount =
          3;

      tblTopActions.RowCount =
          1;

      for (int i = 0; i < 3; i++)
      {
        tblTopActions.ColumnStyles.Add(
            new ColumnStyle(
                SizeType.Percent,
                33.33F));
      }

      // -----------------------------------------------------
      // Today
      // -----------------------------------------------------

      ConfigureActionButton(
          btnToday,
          "TODAY",
          Color.FromArgb(
              59,
              130,
              246),
          Color.White);

      btnToday.Click +=
          btnToday_Click;

      // -----------------------------------------------------
      // Select Date
      // -----------------------------------------------------

      ConfigureActionButton(
          btnSelectDate,
          "SELECT DATE",
          Color.White,
          Color.FromArgb(
              31,
              41,
              55));

      btnSelectDate.Click +=
          btnSelectDate_Click;

      // -----------------------------------------------------
      // Last 10
      // -----------------------------------------------------

      ConfigureActionButton(
          btnLast10,
          "LAST 10",
          Color.FromArgb(
              243,
              232,
              255),
          Color.FromArgb(
              88,
              28,
              135));

      btnLast10.Click +=
          btnLast10_Click;

      tblTopActions.Controls.Add(
          btnToday,
          0,
          0);

      tblTopActions.Controls.Add(
          btnSelectDate,
          1,
          0);

      tblTopActions.Controls.Add(
          btnLast10,
          2,
          0);

      pnlTopActions.Controls.Add(
          tblTopActions);

      // =====================================================
      // SHIFT FILTERS
      // =====================================================

      pnlShiftFilters.Dock =
          DockStyle.Top;

      pnlShiftFilters.Height =
          150;

      pnlShiftFilters.Padding =
          new Padding(
              15,
              8,
              15,
              8);

      pnlShiftFilters.BackColor =
          Color.FromArgb(
              245,
              247,
              250);

      tblShiftFilters.Dock =
          DockStyle.Fill;

      tblShiftFilters.ColumnCount =
          5;

      tblShiftFilters.RowCount =
          1;

      for (int i = 0; i < 5; i++)
      {
        tblShiftFilters.ColumnStyles.Add(
            new ColumnStyle(
                SizeType.Percent,
                20F));
      }

      // -----------------------------------------------------
      // All
      // -----------------------------------------------------

      ConfigureFilterButton(
          btnAllShifts,
          "ALL");

      btnAllShifts.Click +=
          btnAllShifts_Click;

      // -----------------------------------------------------
      // AM
      // -----------------------------------------------------

      ConfigureFilterButton(
          btnAM,
          "AM");

      btnAM.Click +=
          btnAM_Click;

      // -----------------------------------------------------
      // PM
      // -----------------------------------------------------

      ConfigureFilterButton(
          btnPM,
          "PM");

      btnPM.Click +=
          btnPM_Click;

      // -----------------------------------------------------
      // AM Drive
      // -----------------------------------------------------

      ConfigureFilterButton(
          btnAMDrive,
          "AM DRIVE");

      btnAMDrive.Click +=
          btnAMDrive_Click;

      // -----------------------------------------------------
      // PM Drive
      // -----------------------------------------------------

      ConfigureFilterButton(
          btnPMDrive,
          "PM DRIVE");

      btnPMDrive.Click +=
          btnPMDrive_Click;

      tblShiftFilters.Controls.Add(
          btnAllShifts,
          0,
          0);

      tblShiftFilters.Controls.Add(
          btnAM,
          1,
          0);

      tblShiftFilters.Controls.Add(
          btnPM,
          2,
          0);

      tblShiftFilters.Controls.Add(
          btnAMDrive,
          3,
          0);

      tblShiftFilters.Controls.Add(
          btnPMDrive,
          4,
          0);

      pnlShiftFilters.Controls.Add(
          tblShiftFilters);

      // =====================================================
      // STATUS PANEL
      // =====================================================

      pnlStatus.Dock =
          DockStyle.Top;

      pnlStatus.Height =
          65;

      pnlStatus.Padding =
          new Padding(
              25,
              0,
              25,
              0);

      pnlStatus.BackColor =
          Color.FromArgb(
              219,
              234,
              254);

      // -----------------------------------------------------
      // Report Mode
      // -----------------------------------------------------

      lblReportMode.Dock =
          DockStyle.Left;

      lblReportMode.Width =
          550;

      lblReportMode.Text =
          "TODAY";

      lblReportMode.TextAlign =
          ContentAlignment.MiddleLeft;

      lblReportMode.Font =
          new Font(
              "Segoe UI",
              15F,
              FontStyle.Bold);

      lblReportMode.ForeColor =
          Color.FromArgb(
              30,
              64,
              175);

      // -----------------------------------------------------
      // Record Count
      // -----------------------------------------------------

      lblRecordCount.Dock =
          DockStyle.Right;

      lblRecordCount.Width =
          300;

      lblRecordCount.Text =
          "0 RECORDS";

      lblRecordCount.TextAlign =
          ContentAlignment.MiddleRight;

      lblRecordCount.Font =
          new Font(
              "Segoe UI",
              15F,
              FontStyle.Bold);

      lblRecordCount.ForeColor =
          Color.FromArgb(
              30,
              64,
              175);

      pnlStatus.Controls.Add(
          lblRecordCount);

      pnlStatus.Controls.Add(
          lblReportMode);

      // =====================================================
      // DATA GRID
      // =====================================================

      dgvCortes.Dock =          DockStyle.Fill;
      dgvCortes.BackgroundColor =          Color.White;
      dgvCortes.BorderStyle =          BorderStyle.None;
      dgvCortes.AutoGenerateColumns =          false;
      dgvCortes.AllowUserToAddRows =          false;
      dgvCortes.AllowUserToDeleteRows =          false;
      dgvCortes.AllowUserToResizeRows =          false;
      dgvCortes.AllowUserToOrderColumns =          false;
      dgvCortes.MultiSelect =          false;
      dgvCortes.ReadOnly =          true;
      dgvCortes.RowHeadersVisible =          false;
      dgvCortes.SelectionMode =          DataGridViewSelectionMode.FullRowSelect;

      dgvCortes.AutoSizeColumnsMode =          DataGridViewAutoSizeColumnsMode.Fill;
      dgvCortes.RowTemplate.Height =          65;
      dgvCortes.ColumnHeadersHeight =          60;

      dgvCortes.ColumnHeadersHeightSizeMode =
          DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      dgvCortes.EnableHeadersVisualStyles =          false;

      dgvCortes.ColumnHeadersDefaultCellStyle.BackColor =
          Color.FromArgb(
              31,
              41,
              55);

      dgvCortes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

      dgvCortes.ColumnHeadersDefaultCellStyle.Font =
          new Font(
              "Segoe UI",
              12F,
              FontStyle.Bold);

      dgvCortes.ColumnHeadersDefaultCellStyle.Alignment =
          DataGridViewContentAlignment.MiddleCenter;

      dgvCortes.DefaultCellStyle.Font =
          new Font(
              "Segoe UI",
              12F,
              FontStyle.Regular);

      dgvCortes.DefaultCellStyle.SelectionBackColor =
          Color.FromArgb(
              191,
              219,
              254);

      dgvCortes.DefaultCellStyle.SelectionForeColor =
          Color.FromArgb(
              17,
              24,
              39);

      dgvCortes.GridColor =
          Color.FromArgb(
              209,
              213,
              219);

      // =====================================================
      // DATE COLUMN
      // =====================================================

      colDate.Name =          "colDate";
      colDate.HeaderText =          "DATE";
      colDate.DataPropertyName =          "Date";
      colDate.ReadOnly =          true;
      colDate.FillWeight =          12F;
      colDate.DefaultCellStyle.Format =          "MM/dd/yyyy";
      colDate.DefaultCellStyle.Alignment =
          DataGridViewContentAlignment.MiddleCenter;

      // =====================================================
      // TIME COLUMN
      // =====================================================

      colTime.Name =          "colTime";
      colTime.HeaderText =          "TIME";
      colTime.DataPropertyName =          "Time";
      colTime.ReadOnly =          true;
      colTime.FillWeight =          10F;
      colTime.DefaultCellStyle.Alignment =
          DataGridViewContentAlignment.MiddleCenter;

      // =====================================================
      // SHIFT COLUMN
      // =====================================================

      colShift.Name =          "colShift";
      colShift.HeaderText =          "SHIFT";
      colShift.DataPropertyName =          "Shift";
      colShift.ReadOnly =          true;
      colShift.FillWeight =          10F;
      colShift.DefaultCellStyle.Alignment =
          DataGridViewContentAlignment.MiddleCenter;

      // =====================================================
      // TOTAL CASH
      // =====================================================

      colTotalCash.Name =          "colTotalCash";

      colTotalCash.HeaderText =          "CASH";

      colTotalCash.DataPropertyName =          "TotalCash";

      ConfigureMoneyColumn(          colTotalCash,          12F);

      // =====================================================
      // EXPENSES
      // =====================================================

      colExpenses.Name =          "colExpenses";
      colExpenses.HeaderText =          "EXPENSES";
      colExpenses.DataPropertyName =          "Expenses";
      ConfigureMoneyColumn(          colExpenses,          12F);

      // =====================================================
      // FONDO
      // =====================================================

      colFondo.Name =          "colFondo";
      colFondo.HeaderText =          "FONDO";
      colFondo.DataPropertyName =          "Fondo";
      ConfigureMoneyColumn(          colFondo,          11F);

      // =====================================================
      // SALES
      // =====================================================

      colSales.Name =          "colSales";
      colSales.HeaderText =          "SALES";
      colSales.DataPropertyName =          "Sales";
      ConfigureMoneyColumn(          colSales,          12F);

      // =====================================================
      // SHORT / OVER
      // =====================================================

      colShortOver.Name =          "colShortOver";
      colShortOver.HeaderText =          "SHORT / OVER";
      colShortOver.DataPropertyName =          "ShortOver";
      ConfigureMoneyColumn(          colShortOver,          14F);
      colShortOver.DefaultCellStyle.Font =
          new Font(
              "Segoe UI",
              12F,
              FontStyle.Bold);

      // =====================================================
      // STAFF
      // =====================================================

      colStaff.Name =          "colStaff";
      colStaff.HeaderText =          "STAFF";
      colStaff.DataPropertyName =          "StaffName";
      colStaff.ReadOnly =          true;
      colStaff.FillWeight =          15F;
      colStaff.DefaultCellStyle.Alignment =
          DataGridViewContentAlignment.MiddleCenter;

      // -----------------------------------------------------
      // Add columns
      // -----------------------------------------------------

      dgvCortes.Columns.AddRange(
          colDate,
          colTime,
          colShift,
          colTotalCash,
          colExpenses,
          colFondo,
          colSales,
          colShortOver,
          colStaff);

      // =====================================================
      // FOOTER
      // =====================================================

      pnlFooter.Dock =          DockStyle.Bottom;

      pnlFooter.Height =          250;

      pnlFooter.Padding =
          new Padding(
              20,
              12,
              20,
              12);

      pnlFooter.BackColor =
          Color.FromArgb(
              229,
              231,
              235);

      tblFooter.Dock =          DockStyle.Fill;
      tblFooter.ColumnCount =          2;
      tblFooter.RowCount =          1;

      tblFooter.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              50F));

      tblFooter.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              50F));

      // -----------------------------------------------------
      // Print
      // -----------------------------------------------------

      ConfigureFooterButton(
          btnPrint,
          "PRINT SELECTED",
          Color.FromArgb(
              59,
              130,
              246));

      btnPrint.Click +=
          btnPrint_Click;

      // -----------------------------------------------------
      // Done
      // -----------------------------------------------------

      ConfigureFooterButton(
          btnDone,
          "DONE",
          Color.FromArgb(
              34,
              197,
              94));

      btnDone.Click +=
          btnDone_Click;

      tblFooter.Controls.Add(
          btnPrint,
          1,
          0);

      tblFooter.Controls.Add(
          btnDone,
          0,
          0);

      pnlFooter.Controls.Add(
          tblFooter);

      // =====================================================
      // ADD MAIN CONTROLS
      //
      // Docking order:
      // Fill first, then footer/top panels.
      // =====================================================

      Controls.Add(
          dgvCortes);

      Controls.Add(
          pnlFooter);

      Controls.Add(
          pnlStatus);

      Controls.Add(
          pnlShiftFilters);

      Controls.Add(
          pnlTopActions);

      Controls.Add(
          pnlHeader);

      // =====================================================
      // FINISH
      // =====================================================

      ((System.ComponentModel.ISupportInitialize)dgvCortes)
          .EndInit();

      ResumeLayout(false);
    }

    // =========================================================
    // ACTION BUTTON
    // =========================================================

    private static void ConfigureActionButton(
        Button button,
        string text,
        Color backgroundColor,
        Color foregroundColor)
    {
      button.Dock =
          DockStyle.Fill;

      button.Margin =
          new Padding(7);

      button.Text =
          text;

      button.Font =
          new Font(
              "Segoe UI",
              16F,
              FontStyle.Bold);

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
          1;

      button.Cursor =
          Cursors.Hand;

      button.TabStop =
          false;
    }

    // =========================================================
    // FILTER BUTTON
    // =========================================================

    private static void ConfigureFilterButton(
        Button button,
        string text)
    {
      button.Dock =
          DockStyle.Fill;

      button.Margin =
          new Padding(6);

      button.Text =
          text;

      button.Font =
          new Font(
              "Segoe UI",
              14F,
              FontStyle.Bold);

      button.BackColor =
          Color.White;

      button.ForeColor =
          Color.FromArgb(
              31,
              41,
              55);

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
    // MONEY COLUMN
    // =========================================================

    private static void ConfigureMoneyColumn(
        DataGridViewTextBoxColumn column,
        float fillWeight)
    {
      column.ReadOnly =
          true;

      column.FillWeight =
          fillWeight;

      column.DefaultCellStyle.Format =
          "C2";

      column.DefaultCellStyle.Alignment =
          DataGridViewContentAlignment.MiddleRight;
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
          new Padding(8);

      button.Text =
          text;

      button.Font =
          new Font(
              "Segoe UI",
              17F,
              FontStyle.Bold);

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