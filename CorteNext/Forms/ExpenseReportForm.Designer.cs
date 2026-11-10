namespace CorteNext.Forms
{
  partial class ExpenseReportForm
  {
    private System.ComponentModel.IContainer? components = null;

    // =========================================================
    // PANELS
    // =========================================================

    private Panel pnlHeader;
    private Panel pnlTopActions;
    private Panel pnlShiftFilters;
    private Panel pnlStatus;
    private Panel pnlTotal;
    private Panel pnlFooter;

    // =========================================================
    // LABELS
    // =========================================================

    private Label lblTitle;
    private Label lblDate;

    private Label lblReportMode;
    private Label lblRecordCount;

    private Label lblTotalCaption;
    private Label lblTotalValue;

    // =========================================================
    // ACTION BUTTONS
    // =========================================================

    private Button btnToday;
    private Button btnSelectDate;
    private Button btnLast10;

    // =========================================================
    // FILTER BUTTONS
    // =========================================================

    private Button btnAll;
    private Button btnAM;
    private Button btnPM;

    // =========================================================
    // FOOTER BUTTONS
    // =========================================================

    private Button btnDelete;
    private Button btnDone;

    // =========================================================
    // GRID
    // =========================================================

    private DataGridView dgvExpenses;

    private DataGridViewTextBoxColumn colDate;
    private DataGridViewTextBoxColumn colTime;
    private DataGridViewTextBoxColumn colCompany;
    private DataGridViewTextBoxColumn colDescription;
    private DataGridViewTextBoxColumn colAmount;
    private DataGridViewTextBoxColumn colShift;

    // =========================================================
    // TABLES
    // =========================================================

    private TableLayoutPanel tblTopActions;
    private TableLayoutPanel tblShiftFilters;
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
      pnlTopActions = new Panel();
      pnlShiftFilters = new Panel();
      pnlStatus = new Panel();
      pnlTotal = new Panel();
      pnlFooter = new Panel();

      lblTitle = new Label();
      lblDate = new Label();
      lblReportMode = new Label();
      lblRecordCount = new Label();
      lblTotalCaption = new Label();
      lblTotalValue = new Label();

      btnToday = new Button();
      btnSelectDate = new Button();
      btnLast10 = new Button();

      btnAll = new Button();
      btnAM = new Button();
      btnPM = new Button();

      btnDelete = new Button();
      btnDone = new Button();

      dgvExpenses = new DataGridView();

      colDate = new DataGridViewTextBoxColumn();
      colTime = new DataGridViewTextBoxColumn();
      colCompany = new DataGridViewTextBoxColumn();
      colDescription = new DataGridViewTextBoxColumn();
      colAmount = new DataGridViewTextBoxColumn();
      colShift = new DataGridViewTextBoxColumn();

      tblTopActions = new TableLayoutPanel();
      tblShiftFilters = new TableLayoutPanel();
      tblFooter = new TableLayoutPanel();

      ((System.ComponentModel.ISupportInitialize)dgvExpenses)
          .BeginInit();

      SuspendLayout();

      // =====================================================
      // FORM
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
              1350,
              850);

      MinimumSize =
          new Size(
              1050,
              700);

      FormBorderStyle =
          FormBorderStyle.None;

      Text =
          "Expense History";

      Load +=
          ExpenseReportForm_Load;

      // =====================================================
      // HEADER
      // =====================================================

      pnlHeader.Dock =
          DockStyle.Top;

      pnlHeader.Height =
          105;

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
          65;

      lblTitle.Text =
          "EXPENSE HISTORY";

      lblTitle.TextAlign =
          ContentAlignment.BottomCenter;

      lblTitle.Font =
          new Font(
              "Segoe UI",
              25F,
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
      // TOP ACTIONS
      //
      // TODAY / SELECT DATE / LAST 10
      // =====================================================

      pnlTopActions.Dock =
          DockStyle.Top;

      pnlTopActions.Height =
          120;

      pnlTopActions.Padding =
          new Padding(
              12,
              12,
              12,
              8);

      pnlTopActions.BackColor =
          Color.FromArgb(
              229,
              231,
              235);

      tblTopActions.Dock =
          DockStyle.Fill;

      tblTopActions.Margin =
          new Padding(0);

      tblTopActions.Padding =
          new Padding(0);

      tblTopActions.AutoSize =
          false;

      tblTopActions.GrowStyle =
          TableLayoutPanelGrowStyle.FixedSize;

      tblTopActions.ColumnCount =
          3;

      tblTopActions.RowCount =
          1;

      tblTopActions.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              33.3333F));

      tblTopActions.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              33.3333F));

      tblTopActions.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              33.3334F));

      tblTopActions.RowStyles.Add(
          new RowStyle(
              SizeType.Percent,
              100F));

      ConfigureActionButton(
          btnToday,
          "TODAY",
          Color.FromArgb(
              59,
              130,
              246),
          Color.White);

      ConfigureActionButton(
          btnSelectDate,
          "SELECT DATE",
          Color.White,
          Color.FromArgb(
              31,
              41,
              55));

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

      btnToday.Click +=
          btnToday_Click;

      btnSelectDate.Click +=
          btnSelectDate_Click;

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
      //
      // ALL / AM / PM
      // =====================================================

      pnlShiftFilters.Dock =
          DockStyle.Top;

      pnlShiftFilters.Height =
          105;

      pnlShiftFilters.Padding =
          new Padding(
              12,
              8,
              12,
              10);

      pnlShiftFilters.BackColor =
          Color.FromArgb(
              245,
              247,
              250);

      tblShiftFilters.Dock =
          DockStyle.Fill;

      tblShiftFilters.Margin =
          new Padding(0);

      tblShiftFilters.Padding =
          new Padding(0);

      tblShiftFilters.AutoSize =
          false;

      tblShiftFilters.GrowStyle =
          TableLayoutPanelGrowStyle.FixedSize;

      tblShiftFilters.ColumnCount =
          3;

      tblShiftFilters.RowCount =
          1;

      tblShiftFilters.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              33.3333F));

      tblShiftFilters.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              33.3333F));

      tblShiftFilters.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              33.3334F));

      tblShiftFilters.RowStyles.Add(
          new RowStyle(
              SizeType.Percent,
              100F));

      ConfigureFilterButton(
          btnAll,
          "ALL");

      ConfigureFilterButton(
          btnAM,
          "AM");

      ConfigureFilterButton(
          btnPM,
          "PM");

      btnAll.Click +=
          btnAll_Click;

      btnAM.Click +=
          btnAM_Click;

      btnPM.Click +=
          btnPM_Click;

      tblShiftFilters.Controls.Add(
          btnAll,
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

      pnlShiftFilters.Controls.Add(
          tblShiftFilters);

      // =====================================================
      // STATUS
      // =====================================================

      pnlStatus.Dock =
          DockStyle.Top;

      pnlStatus.Height =
          68;

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
      // Report mode
      // -----------------------------------------------------

      lblReportMode.Dock =
          DockStyle.Left;

      lblReportMode.Width =
          600;

      lblReportMode.Text =
          "TODAY";

      lblReportMode.TextAlign =
          ContentAlignment.MiddleLeft;

      lblReportMode.Font =
          new Font(
              "Segoe UI",
              16F,
              FontStyle.Bold);

      lblReportMode.ForeColor =
          Color.FromArgb(
              30,
              64,
              175);

      // -----------------------------------------------------
      // Record count
      // -----------------------------------------------------

      lblRecordCount.Dock =
          DockStyle.Right;

      lblRecordCount.Width =
          320;

      lblRecordCount.Text =
          "0 RECORDS";

      lblRecordCount.TextAlign =
          ContentAlignment.MiddleRight;

      lblRecordCount.Font =
          new Font(
              "Segoe UI",
              16F,
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
      // EXPENSE GRID
      // =====================================================

      dgvExpenses.Dock =
          DockStyle.Fill;

      dgvExpenses.Margin =
          new Padding(0);

      dgvExpenses.BackgroundColor =
          Color.White;

      dgvExpenses.BorderStyle =
          BorderStyle.None;

      dgvExpenses.AutoGenerateColumns =
          false;

      dgvExpenses.AllowUserToAddRows =
          false;

      dgvExpenses.AllowUserToDeleteRows =
          false;

      dgvExpenses.AllowUserToResizeRows =
          false;

      dgvExpenses.AllowUserToOrderColumns =
          false;

      dgvExpenses.MultiSelect =
          false;

      dgvExpenses.ReadOnly =
          true;

      dgvExpenses.RowHeadersVisible =
          false;

      dgvExpenses.SelectionMode =
          DataGridViewSelectionMode.FullRowSelect;

      dgvExpenses.AutoSizeColumnsMode =
          DataGridViewAutoSizeColumnsMode.Fill;

      dgvExpenses.RowTemplate.Height =
          65;

      dgvExpenses.ColumnHeadersHeight =
          65;

      dgvExpenses.ColumnHeadersHeightSizeMode =
          DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

      dgvExpenses.EnableHeadersVisualStyles =
          false;

      dgvExpenses.ColumnHeadersDefaultCellStyle.BackColor =
          Color.FromArgb(
              31,
              41,
              55);

      dgvExpenses.ColumnHeadersDefaultCellStyle.ForeColor =
          Color.White;

      dgvExpenses.ColumnHeadersDefaultCellStyle.Font =
          new Font(
              "Segoe UI",
              14F,
              FontStyle.Bold);

      dgvExpenses.ColumnHeadersDefaultCellStyle.Alignment =
          DataGridViewContentAlignment.MiddleCenter;

      dgvExpenses.DefaultCellStyle.Font =
          new Font(
              "Segoe UI",
              14F,
              FontStyle.Regular);

      dgvExpenses.DefaultCellStyle.SelectionBackColor =
          Color.FromArgb(
              191,
              219,
              254);

      dgvExpenses.DefaultCellStyle.SelectionForeColor =
          Color.FromArgb(
              17,
              24,
              39);

      dgvExpenses.DefaultCellStyle.Padding =
          new Padding(
              5);

      dgvExpenses.AlternatingRowsDefaultCellStyle.BackColor =
          Color.FromArgb(
              249,
              250,
              251);

      dgvExpenses.GridColor =
          Color.FromArgb(
              209,
              213,
              219);

      dgvExpenses.SelectionChanged +=
          dgvExpenses_SelectionChanged;

      // =====================================================
      // DATE COLUMN
      // =====================================================

      colDate.Name =
          "colDate";

      colDate.HeaderText =
          "DATE";

      colDate.DataPropertyName =
          "Date";

      colDate.ReadOnly =
          true;

      colDate.FillWeight =
          14F;

      colDate.MinimumWidth =
          100;

      colDate.DefaultCellStyle.Format =
          "MM/dd/yyyy";

      colDate.DefaultCellStyle.Alignment =
          DataGridViewContentAlignment.MiddleCenter;

      // =====================================================
      // TIME COLUMN
      // =====================================================

      colTime.Name =
          "colTime";

      colTime.HeaderText =
          "TIME";

      colTime.DataPropertyName =
          "Time";

      colTime.ReadOnly =
          true;

      colTime.FillWeight =
          12F;

      colTime.MinimumWidth =
          90;

      colTime.DefaultCellStyle.Alignment =
          DataGridViewContentAlignment.MiddleCenter;

      // =====================================================
      // COMPANY COLUMN
      // =====================================================

      colCompany.Name =
          "colCompany";

      colCompany.HeaderText =
          "COMPANY";

      colCompany.DataPropertyName =
          "Company";

      colCompany.ReadOnly =
          true;

      colCompany.FillWeight =
          23F;

      colCompany.MinimumWidth =
          140;

      colCompany.DefaultCellStyle.Alignment =
          DataGridViewContentAlignment.MiddleLeft;

      // =====================================================
      // DESCRIPTION COLUMN
      // =====================================================

      colDescription.Name =
          "colDescription";

      colDescription.HeaderText =
          "DESCRIPTION";

      colDescription.DataPropertyName =
          "Description";

      colDescription.ReadOnly =
          true;

      colDescription.FillWeight =
          30F;

      colDescription.MinimumWidth =
          180;

      colDescription.DefaultCellStyle.Alignment =
          DataGridViewContentAlignment.MiddleLeft;

      // =====================================================
      // AMOUNT COLUMN
      // =====================================================

      colAmount.Name =
          "colAmount";

      colAmount.HeaderText =
          "AMOUNT";

      colAmount.DataPropertyName =
          "Amount";

      colAmount.ReadOnly =
          true;

      colAmount.FillWeight =
          14F;

      colAmount.MinimumWidth =
          110;

      colAmount.DefaultCellStyle.Format =
          "C2";

      colAmount.DefaultCellStyle.Alignment =
          DataGridViewContentAlignment.MiddleRight;

      colAmount.DefaultCellStyle.Font =
          new Font(
              "Segoe UI",
              14F,
              FontStyle.Bold);

      // =====================================================
      // SHIFT COLUMN
      // =====================================================

      colShift.Name =
          "colShift";

      colShift.HeaderText =
          "SHIFT";

      colShift.DataPropertyName =
          "Shift";

      colShift.ReadOnly =
          true;

      colShift.FillWeight =
          10F;

      colShift.MinimumWidth =
          80;

      colShift.DefaultCellStyle.Alignment =
          DataGridViewContentAlignment.MiddleCenter;

      dgvExpenses.Columns.AddRange(
          colDate,
          colTime,
          colCompany,
          colDescription,
          colAmount,
          colShift);

      // =====================================================
      // TOTAL
      // =====================================================

      pnlTotal.Dock =
          DockStyle.Bottom;

      pnlTotal.Height =
          105;

      pnlTotal.Padding =
          new Padding(
              25,
              6,
              25,
              6);

      pnlTotal.BackColor =
          Color.FromArgb(
              219,
              234,
              254);

      lblTotalCaption.Dock =
          DockStyle.Left;

      lblTotalCaption.Width =
          550;

      lblTotalCaption.Text =
          "TOTAL EXPENSES";

      lblTotalCaption.TextAlign =
          ContentAlignment.MiddleRight;

      lblTotalCaption.Padding =
          new Padding(
              0,
              0,
              25,
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

      lblTotalValue.Dock =
          DockStyle.Fill;

      lblTotalValue.Text =
          "$0.00";

      lblTotalValue.TextAlign =
          ContentAlignment.MiddleLeft;

      lblTotalValue.Padding =
          new Padding(
              25,
              0,
              0,
              0);

      lblTotalValue.Font =
          new Font(
              "Segoe UI",
              30F,
              FontStyle.Bold);

      lblTotalValue.ForeColor =
          Color.FromArgb(
              22,
              101,
              52);

      pnlTotal.Controls.Add(
          lblTotalValue);

      pnlTotal.Controls.Add(
          lblTotalCaption);

      // =====================================================
      // FOOTER
      // =====================================================

      pnlFooter.Dock =
          DockStyle.Bottom;

      pnlFooter.Height =
          125;

      pnlFooter.Padding =
          new Padding(
              16,
              12,
              16,
              12);

      pnlFooter.BackColor =
          Color.FromArgb(
              229,
              231,
              235);

      tblFooter.Dock =
          DockStyle.Fill;

      tblFooter.Margin =
          new Padding(0);

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

      tblFooter.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              50F));

      tblFooter.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              50F));

      tblFooter.RowStyles.Add(
          new RowStyle(
              SizeType.Percent,
              100F));

      // -----------------------------------------------------
      // Delete selected
      // -----------------------------------------------------

      ConfigureFooterButton(
          btnDelete,
          "DELETE SELECTED",
          Color.FromArgb(
              156,
              163,
              175));

      btnDelete.Enabled =
          false;

      btnDelete.Click +=
          btnDelete_Click;

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
          btnDelete,
          0,
          0);

      tblFooter.Controls.Add(
          btnDone,
          1,
          0);

      pnlFooter.Controls.Add(
          tblFooter);

      // =====================================================
      // ADD CONTROLS
      //
      // Order matters for DockStyle.
      // =====================================================

      Controls.Add(
          dgvExpenses);

      Controls.Add(
          pnlTotal);

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

      ((System.ComponentModel.ISupportInitialize)dgvExpenses)
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
          new Padding(
              7);

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
          new Font(
              "Segoe UI",
              18F,
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
          2;

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
          new Padding(
              7);

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
          new Font(
              "Segoe UI",
              17F,
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
          new Padding(
              8);

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
          new Font(
              "Segoe UI",
              19F,
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