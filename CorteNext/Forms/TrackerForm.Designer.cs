namespace CorteNext.Forms
{
  partial class TrackerForm
  {
    private System.ComponentModel.IContainer? components = null;

    // =========================================================
    // PANELS
    // =========================================================

    private Panel pnlHeader;
    private Panel pnlDayStatus;
    private Panel pnlFooter;

    // =========================================================
    // LABELS
    // =========================================================

    private Label lblTitle;
    private Label lblDate;
    private Label lblDayStatus;

    private Label lblFondoTitle;
    private Label lblCorteTitle;

    // =========================================================
    // FONDO LABELS
    // =========================================================

    private Label lblFondoAM;
    private Label lblFondoDrive;
    private Label lblFondoPM;

    private Label lblFondoAMStatus;
    private Label lblFondoDriveStatus;
    private Label lblFondoPMStatus;

    // =========================================================
    // CORTE LABELS
    // =========================================================

    private Label lblCorteAM;
    private Label lblCorteAMDrive;
    private Label lblCortePMDrive;
    private Label lblCortePM;

    private Label lblCorteAMStatus;
    private Label lblCorteAMDriveStatus;
    private Label lblCortePMDriveStatus;
    private Label lblCortePMStatus;

    // =========================================================
    // BUTTONS
    // =========================================================

    private Button btnToday;
    private Button btnSelectDate;
    private Button btnRefresh;
    private Button btnDone;

    // =========================================================
    // TABLES
    // =========================================================

    private TableLayoutPanel tblMain;
    private TableLayoutPanel tblFondo;
    private TableLayoutPanel tblCorte;
    private TableLayoutPanel tblActions;
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
    // INITIALIZE COMPONENT
    // =========================================================

    private void InitializeComponent()
    {
      pnlHeader = new Panel();
      pnlDayStatus = new Panel();
      pnlFooter = new Panel();

      lblTitle = new Label();
      lblDate = new Label();
      lblDayStatus = new Label();

      lblFondoTitle = new Label();
      lblCorteTitle = new Label();

      lblFondoAM = new Label();
      lblFondoDrive = new Label();
      lblFondoPM = new Label();

      lblFondoAMStatus = new Label();
      lblFondoDriveStatus = new Label();
      lblFondoPMStatus = new Label();

      lblCorteAM = new Label();
      lblCorteAMDrive = new Label();
      lblCortePMDrive = new Label();
      lblCortePM = new Label();

      lblCorteAMStatus = new Label();
      lblCorteAMDriveStatus = new Label();
      lblCortePMDriveStatus = new Label();
      lblCortePMStatus = new Label();

      btnToday = new Button();
      btnSelectDate = new Button();
      btnRefresh = new Button();
      btnDone = new Button();

      tblMain = new TableLayoutPanel();
      tblFondo = new TableLayoutPanel();
      tblCorte = new TableLayoutPanel();
      tblActions = new TableLayoutPanel();
      tblFooter = new TableLayoutPanel();

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
              1200,
              820);

      MinimumSize =
          new Size(
              1000,
              700);

      FormBorderStyle =
          FormBorderStyle.None;

      Text =
          "Daily Tracker";

      Load +=
          TrackerForm_Load;

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

      lblTitle.Dock =
          DockStyle.Top;

      lblTitle.Height =
          62;

      lblTitle.Text =
          "DAILY TRACKER";

      lblTitle.TextAlign =
          ContentAlignment.BottomCenter;

      lblTitle.Font =
          new Font(
              "Segoe UI",
              24F,
              FontStyle.Bold);

      lblTitle.ForeColor =
          Color.White;

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
      // DAY STATUS
      // =====================================================

      pnlDayStatus.Dock =
          DockStyle.Top;

      pnlDayStatus.Height =
          90;

      pnlDayStatus.Padding =
          new Padding(
              20,
              10,
              20,
              10);

      pnlDayStatus.BackColor =
          Color.FromArgb(
              245,
              247,
              250);

      lblDayStatus.Dock =
          DockStyle.Fill;

      lblDayStatus.Text =
          "DAY IN PROGRESS";

      lblDayStatus.TextAlign =
          ContentAlignment.MiddleCenter;

      lblDayStatus.Font =
          new Font(
              "Segoe UI",
              19F,
              FontStyle.Bold);

      lblDayStatus.BackColor =
          Color.FromArgb(
              219,
              234,
              254);

      lblDayStatus.ForeColor =
          Color.FromArgb(
              30,
              64,
              175);

      pnlDayStatus.Controls.Add(
          lblDayStatus);

      // =====================================================
      // MAIN TABLE
      // =====================================================

      tblMain.Dock =
          DockStyle.Fill;

      tblMain.Padding =
          new Padding(
              25);

      tblMain.ColumnCount =
          2;

      tblMain.RowCount =
          2;

      tblMain.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              50F));

      tblMain.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              50F));

      tblMain.RowStyles.Add(
          new RowStyle(
              SizeType.Percent,
              78F));

      tblMain.RowStyles.Add(
          new RowStyle(
              SizeType.Percent,
              22F));

      // =====================================================
      // FONDO TABLE
      // =====================================================

      tblFondo.Dock =
          DockStyle.Fill;

      tblFondo.Margin =
          new Padding(
              10);

      tblFondo.Padding =
          new Padding(
              15);

      tblFondo.BackColor =
          Color.White;

      tblFondo.ColumnCount =
          2;

      tblFondo.RowCount =
          4;

      tblFondo.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              42F));

      tblFondo.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              58F));

      tblFondo.RowStyles.Add(
          new RowStyle(
              SizeType.Percent,
              22F));

      tblFondo.RowStyles.Add(
          new RowStyle(
              SizeType.Percent,
              26F));

      tblFondo.RowStyles.Add(
          new RowStyle(
              SizeType.Percent,
              26F));

      tblFondo.RowStyles.Add(
          new RowStyle(
              SizeType.Percent,
              26F));

      // -----------------------------------------------------
      // Fondo title
      // -----------------------------------------------------

      ConfigureSectionTitle(
          lblFondoTitle,
          "FONDO");

      tblFondo.Controls.Add(
          lblFondoTitle,
          0,
          0);

      tblFondo.SetColumnSpan(
          lblFondoTitle,
          2);

      // -----------------------------------------------------
      // AM Fondo
      // -----------------------------------------------------

      ConfigureShiftLabel(
          lblFondoAM,
          "AM");

      ConfigureStatusLabel(
          lblFondoAMStatus);

      tblFondo.Controls.Add(
          lblFondoAM,
          0,
          1);

      tblFondo.Controls.Add(
          lblFondoAMStatus,
          1,
          1);

      // -----------------------------------------------------
      // Drive Fondo
      // -----------------------------------------------------

      ConfigureShiftLabel(
          lblFondoDrive,
          "DRIVE");

      ConfigureStatusLabel(
          lblFondoDriveStatus);

      tblFondo.Controls.Add(
          lblFondoDrive,
          0,
          2);

      tblFondo.Controls.Add(
          lblFondoDriveStatus,
          1,
          2);

      // -----------------------------------------------------
      // PM Fondo
      // -----------------------------------------------------

      ConfigureShiftLabel(
          lblFondoPM,
          "PM");

      ConfigureStatusLabel(
          lblFondoPMStatus);

      tblFondo.Controls.Add(
          lblFondoPM,
          0,
          3);

      tblFondo.Controls.Add(
          lblFondoPMStatus,
          1,
          3);

      // =====================================================
      // CORTE TABLE
      // =====================================================

      tblCorte.Dock =
          DockStyle.Fill;

      tblCorte.Margin =
          new Padding(
              10);

      tblCorte.Padding =
          new Padding(
              15);

      tblCorte.BackColor =
          Color.White;

      tblCorte.ColumnCount =
          2;

      tblCorte.RowCount =
          5;

      tblCorte.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              42F));

      tblCorte.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              58F));

      tblCorte.RowStyles.Add(
          new RowStyle(
              SizeType.Percent,
              20F));

      tblCorte.RowStyles.Add(
          new RowStyle(
              SizeType.Percent,
              20F));

      tblCorte.RowStyles.Add(
          new RowStyle(
              SizeType.Percent,
              20F));

      tblCorte.RowStyles.Add(
          new RowStyle(
              SizeType.Percent,
              20F));

      tblCorte.RowStyles.Add(
          new RowStyle(
              SizeType.Percent,
              20F));

      // -----------------------------------------------------
      // Corte title
      // -----------------------------------------------------

      ConfigureSectionTitle(
          lblCorteTitle,
          "CORTE");

      tblCorte.Controls.Add(
          lblCorteTitle,
          0,
          0);

      tblCorte.SetColumnSpan(
          lblCorteTitle,
          2);

      // -----------------------------------------------------
      // AM Corte
      // -----------------------------------------------------

      ConfigureShiftLabel(
          lblCorteAM,
          "AM");

      ConfigureStatusLabel(
          lblCorteAMStatus);

      tblCorte.Controls.Add(
          lblCorteAM,
          0,
          1);

      tblCorte.Controls.Add(
          lblCorteAMStatus,
          1,
          1);

      // -----------------------------------------------------
      // AM Drive Corte
      // -----------------------------------------------------

      ConfigureShiftLabel(
          lblCorteAMDrive,
          "AM DRIVE");

      ConfigureStatusLabel(
          lblCorteAMDriveStatus);

      tblCorte.Controls.Add(
          lblCorteAMDrive,
          0,
          2);

      tblCorte.Controls.Add(
          lblCorteAMDriveStatus,
          1,
          2);

      // -----------------------------------------------------
      // PM Drive Corte
      // -----------------------------------------------------

      ConfigureShiftLabel(
          lblCortePMDrive,
          "PM DRIVE");

      ConfigureStatusLabel(
          lblCortePMDriveStatus);

      tblCorte.Controls.Add(
          lblCortePMDrive,
          0,
          3);

      tblCorte.Controls.Add(
          lblCortePMDriveStatus,
          1,
          3);

      // -----------------------------------------------------
      // PM Corte
      // -----------------------------------------------------

      ConfigureShiftLabel(
          lblCortePM,
          "PM");

      ConfigureStatusLabel(
          lblCortePMStatus);

      tblCorte.Controls.Add(
          lblCortePM,
          0,
          4);

      tblCorte.Controls.Add(
          lblCortePMStatus,
          1,
          4);

      // =====================================================
      // ACTION BUTTON TABLE
      // =====================================================

      tblActions.Dock =
          DockStyle.Fill;

      tblActions.Margin =
          new Padding(
              10);

      tblActions.ColumnCount =
          3;

      tblActions.RowCount =
          1;

      tblActions.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              33.33F));

      tblActions.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              33.33F));

      tblActions.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              33.34F));

      // -----------------------------------------------------
      // Today
      // -----------------------------------------------------

      ConfigureActionButton(
          btnToday,
          "TODAY",
          Color.FromArgb(
              59,
              130,
              246));

      btnToday.Click +=
          btnToday_Click;

      // -----------------------------------------------------
      // Select date
      // -----------------------------------------------------

      ConfigureActionButton(
          btnSelectDate,
          "SELECT DATE",
          Color.FromArgb(
              107,
              114,
              128));

      btnSelectDate.Click +=
          btnSelectDate_Click;

      // -----------------------------------------------------
      // Refresh
      // -----------------------------------------------------

      ConfigureActionButton(
          btnRefresh,
          "REFRESH",
          Color.FromArgb(
              14,
              165,
              233));

      btnRefresh.Click +=
          btnRefresh_Click;

      tblActions.Controls.Add(
          btnToday,
          0,
          0);

      tblActions.Controls.Add(
          btnSelectDate,
          1,
          0);

      tblActions.Controls.Add(
          btnRefresh,
          2,
          0);

      // =====================================================
      // MAIN TABLE CONTENT
      // =====================================================

      tblMain.Controls.Add(
          tblFondo,
          0,
          0);

      tblMain.Controls.Add(
          tblCorte,
          1,
          0);

      tblMain.Controls.Add(
          tblActions,
          0,
          1);

      tblMain.SetColumnSpan(
          tblActions,
          2);

      // =====================================================
      // FOOTER
      // =====================================================

      pnlFooter.Dock =
          DockStyle.Bottom;

      pnlFooter.Height =
          110;

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

      tblFooter.Dock =
          DockStyle.Fill;

      tblFooter.ColumnCount =
          3;

      tblFooter.RowCount =
          1;

      tblFooter.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              25F));

      tblFooter.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              50F));

      tblFooter.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              25F));

      // -----------------------------------------------------
      // Done
      // -----------------------------------------------------

      btnDone.Dock =
          DockStyle.Fill;

      btnDone.Margin =
          new Padding(
              8);

      btnDone.Text =
          "DONE";

      btnDone.Font =
          new Font(
              "Segoe UI",
              18F,
              FontStyle.Bold);

      btnDone.BackColor =
          Color.FromArgb(
              34,
              197,
              94);

      btnDone.ForeColor =
          Color.White;

      btnDone.FlatStyle =
          FlatStyle.Flat;

      btnDone.FlatAppearance.BorderSize =
          0;

      btnDone.Cursor =
          Cursors.Hand;

      btnDone.TabStop =
          false;

      btnDone.Click +=
          btnDone_Click;

      /*
       * Leave columns 0 and 2 empty so the DONE button
       * stays centered and comfortably sized for touch.
       */

      tblFooter.Controls.Add(
          btnDone,
          1,
          0);

      pnlFooter.Controls.Add(
          tblFooter);

      // =====================================================
      // ADD FORM CONTROLS
      // =====================================================

      Controls.Add(
          tblMain);

      Controls.Add(
          pnlFooter);

      Controls.Add(
          pnlDayStatus);

      Controls.Add(
          pnlHeader);

      // =====================================================
      // FINISH
      // =====================================================

      ResumeLayout(false);
    }

    // =========================================================
    // SECTION TITLE
    // =========================================================

    private static void ConfigureSectionTitle(
        Label label,
        string text)
    {
      label.Dock =
          DockStyle.Fill;

      label.Margin =
          new Padding(
              4);

      label.Text =
          text;

      label.TextAlign =
          ContentAlignment.MiddleCenter;

      label.Font =
          new Font(
              "Segoe UI",
              21F,
              FontStyle.Bold);

      label.BackColor =
          Color.FromArgb(
              31,
              41,
              55);

      label.ForeColor =
          Color.White;
    }

    // =========================================================
    // SHIFT LABEL
    // =========================================================

    private static void ConfigureShiftLabel(
        Label label,
        string text)
    {
      label.Dock =
          DockStyle.Fill;

      label.Margin =
          new Padding(
              5);

      label.Text =
          text;

      label.TextAlign =
          ContentAlignment.MiddleRight;

      label.Padding =
          new Padding(
              0,
              0,
              15,
              0);

      label.Font =
          new Font(
              "Segoe UI",
              16F,
              FontStyle.Bold);

      label.BackColor =
          Color.FromArgb(
              249,
              250,
              251);

      label.ForeColor =
          Color.FromArgb(
              31,
              41,
              55);
    }

    // =========================================================
    // STATUS LABEL
    // =========================================================

    private static void ConfigureStatusLabel(
        Label label)
    {
      label.Dock =
          DockStyle.Fill;

      label.Margin =
          new Padding(
              5);

      label.Text =
          "NOT COMPLETED";

      label.TextAlign =
          ContentAlignment.MiddleCenter;

      label.Font =
          new Font(
              "Segoe UI",
              15F,
              FontStyle.Bold);

      label.BackColor =
          Color.FromArgb(
              229,
              231,
              235);

      label.ForeColor =
          Color.FromArgb(
              107,
              114,
              128);
    }

    // =========================================================
    // ACTION BUTTON
    // =========================================================

    private static void ConfigureActionButton(
        Button button,
        string text,
        Color backgroundColor)
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
              16F,
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