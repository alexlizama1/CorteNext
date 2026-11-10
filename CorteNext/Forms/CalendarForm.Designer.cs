namespace CorteNext.Forms
{
  partial class CalendarForm
  {
    private System.ComponentModel.IContainer? components = null;

    // =========================================================
    // PANELS
    // =========================================================

    private Panel pnlHeader;
    private Panel pnlNavigation;
    private Panel pnlFooter;

    // =========================================================
    // LABELS
    // =========================================================

    private Label lblTitle;
    private Label lblMonthYear;

    // =========================================================
    // NAVIGATION
    // =========================================================

    private Button btnPrevious;
    private Button btnNext;

    // =========================================================
    // FOOTER
    // =========================================================

    private Button btnToday;
    private Button btnCancel;
    private Button btnSelect;

    // =========================================================
    // DAY HEADERS
    // =========================================================

    private TableLayoutPanel tblDayHeaders;

    private Label lblSunday;
    private Label lblMonday;
    private Label lblTuesday;
    private Label lblWednesday;
    private Label lblThursday;
    private Label lblFriday;
    private Label lblSaturday;

    // =========================================================
    // DAYS
    // =========================================================

    private TableLayoutPanel tblDays;

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
      pnlNavigation = new Panel();
      pnlFooter = new Panel();

      lblTitle = new Label();
      lblMonthYear = new Label();

      btnPrevious = new Button();
      btnNext = new Button();

      btnToday = new Button();
      btnCancel = new Button();
      btnSelect = new Button();

      tblDayHeaders = new TableLayoutPanel();

      lblSunday = new Label();
      lblMonday = new Label();
      lblTuesday = new Label();
      lblWednesday = new Label();
      lblThursday = new Label();
      lblFriday = new Label();
      lblSaturday = new Label();

      tblDays = new TableLayoutPanel();

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
              1400,
              1000);

      MinimumSize =
          new Size(
              1200,
              850);

      FormBorderStyle =
          FormBorderStyle.FixedDialog;

      StartPosition =
          FormStartPosition.CenterParent;

      MaximizeBox =
          false;

      MinimizeBox =
          false;

      Text =
          "Select Date";

      Load +=
          CalendarForm_Load;

      // =====================================================
      // HEADER
      // =====================================================

      pnlHeader.Dock =
          DockStyle.Top;

      pnlHeader.Height =
          90;

      pnlHeader.BackColor =
          Color.FromArgb(
              31,
              41,
              55);

      lblTitle.Dock =
          DockStyle.Fill;

      lblTitle.Text =
          "SELECT DATE";

      lblTitle.TextAlign =
          ContentAlignment.MiddleCenter;

      lblTitle.Font =
          new Font(
              "Segoe UI",
              24F,
              FontStyle.Bold);

      lblTitle.ForeColor =
          Color.White;

      pnlHeader.Controls.Add(
          lblTitle);

      // =====================================================
      // MONTH NAVIGATION
      // =====================================================

      pnlNavigation.Dock =
          DockStyle.Top;

      pnlNavigation.Height =
          105;

      pnlNavigation.Padding =
          new Padding(
              20,
              12,
              20,
              12);

      pnlNavigation.BackColor =
          Color.FromArgb(
              229,
              231,
              235);

      // -----------------------------------------------------
      // Previous
      // -----------------------------------------------------

      ConfigureNavigationButton(
          btnPrevious,
          "◀ PREVIOUS");

      btnPrevious.Dock =
          DockStyle.Left;

      btnPrevious.Width =
          260;

      btnPrevious.Click +=
          btnPrevious_Click;

      // -----------------------------------------------------
      // Next
      // -----------------------------------------------------

      ConfigureNavigationButton(
          btnNext,
          "NEXT ▶");

      btnNext.Dock =
          DockStyle.Right;

      btnNext.Width =
          260;

      btnNext.Click +=
          btnNext_Click;

      // -----------------------------------------------------
      // Month / year
      // -----------------------------------------------------

      lblMonthYear.Dock =
          DockStyle.Fill;

      lblMonthYear.Text =
          string.Empty;

      lblMonthYear.TextAlign =
          ContentAlignment.MiddleCenter;

      lblMonthYear.Font =
          new Font(
              "Segoe UI",
              22F,
              FontStyle.Bold);

      lblMonthYear.ForeColor =
          Color.FromArgb(
              31,
              41,
              55);

      pnlNavigation.Controls.Add(
          lblMonthYear);

      pnlNavigation.Controls.Add(
          btnPrevious);

      pnlNavigation.Controls.Add(
          btnNext);

      // =====================================================
      // DAY HEADERS
      // =====================================================

      tblDayHeaders.Dock =
          DockStyle.Top;

      tblDayHeaders.Height =
          55;

      tblDayHeaders.Padding =
          new Padding(
              15,
              0,
              15,
              0);

      tblDayHeaders.ColumnCount =
          7;

      tblDayHeaders.RowCount =
          1;

      for (int column = 0;
           column < 7;
           column++)
      {
        tblDayHeaders.ColumnStyles.Add(
            new ColumnStyle(
                SizeType.Percent,
                14.2857F));
      }

      tblDayHeaders.RowStyles.Add(
          new RowStyle(
              SizeType.Percent,
              100F));

      ConfigureDayHeader(
          lblSunday,
          "SUN");

      ConfigureDayHeader(
          lblMonday,
          "MON");

      ConfigureDayHeader(
          lblTuesday,
          "TUE");

      ConfigureDayHeader(
          lblWednesday,
          "WED");

      ConfigureDayHeader(
          lblThursday,
          "THU");

      ConfigureDayHeader(
          lblFriday,
          "FRI");

      ConfigureDayHeader(
          lblSaturday,
          "SAT");

      tblDayHeaders.Controls.Add(
          lblSunday,
          0,
          0);

      tblDayHeaders.Controls.Add(
          lblMonday,
          1,
          0);

      tblDayHeaders.Controls.Add(
          lblTuesday,
          2,
          0);

      tblDayHeaders.Controls.Add(
          lblWednesday,
          3,
          0);

      tblDayHeaders.Controls.Add(
          lblThursday,
          4,
          0);

      tblDayHeaders.Controls.Add(
          lblFriday,
          5,
          0);

      tblDayHeaders.Controls.Add(
          lblSaturday,
          6,
          0);

      // =====================================================
      // DAY GRID
      // =====================================================

      tblDays.Dock =
          DockStyle.Fill;

      tblDays.Padding =
          new Padding(15);

      tblDays.BackColor =
          Color.FromArgb(
              245,
              247,
              250);

      tblDays.ColumnCount =
          7;

      tblDays.RowCount =
          6;

      for (int column = 0;
           column < 7;
           column++)
      {
        tblDays.ColumnStyles.Add(
            new ColumnStyle(
                SizeType.Percent,
                14.2857F));
      }

      for (int row = 0;
           row < 6;
           row++)
      {
        tblDays.RowStyles.Add(
            new RowStyle(
                SizeType.Percent,
                16.6667F));
      }

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
              14,
              20,
              14);

      pnlFooter.BackColor =
          Color.FromArgb(
              229,
              231,
              235);

      // =====================================================
      // TODAY
      // =====================================================

      btnToday.Dock =
          DockStyle.Left;

      btnToday.Width =
          260;

      btnToday.Text =
          "TODAY";

      btnToday.Font =
          new Font(
              "Segoe UI",
              16F,
              FontStyle.Bold);

      btnToday.BackColor =
          Color.FromArgb(
              59,
              130,
              246);

      btnToday.ForeColor =
          Color.White;

      btnToday.FlatStyle =
          FlatStyle.Flat;

      btnToday.FlatAppearance.BorderSize =
          0;

      btnToday.Cursor =
          Cursors.Hand;

      btnToday.TabStop =
          false;

      btnToday.Click +=
          btnToday_Click;

      // =====================================================
      // CANCEL
      // =====================================================

      btnCancel.Dock =
          DockStyle.Left;

      btnCancel.Width =
          260;

      btnCancel.Text =
          "CANCEL";

      btnCancel.Font =
          new Font(
              "Segoe UI",
              16F,
              FontStyle.Bold);

      btnCancel.BackColor =
          Color.FromArgb(
              239,
              68,
              68);

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

      // =====================================================
      // SELECT DATE
      // =====================================================

      btnSelect.Dock =
          DockStyle.Right;

      btnSelect.Width =
          400;

      btnSelect.Text =
          "SELECT DATE";

      btnSelect.Font =
          new Font(
              "Segoe UI",
              16F,
              FontStyle.Bold);

      btnSelect.BackColor =
          Color.FromArgb(
              34,
              197,
              94);

      btnSelect.ForeColor =
          Color.White;

      btnSelect.FlatStyle =
          FlatStyle.Flat;

      btnSelect.FlatAppearance.BorderSize =
          0;

      btnSelect.Cursor =
          Cursors.Hand;

      btnSelect.TabStop =
          false;

      btnSelect.Click +=
          btnSelect_Click;

      pnlFooter.Controls.Add(
          btnToday);

      pnlFooter.Controls.Add(
          btnCancel);

      pnlFooter.Controls.Add(
          btnSelect);

      // =====================================================
      // ADD FORM CONTROLS
      // =====================================================

      Controls.Add(
          tblDays);

      Controls.Add(
          pnlFooter);

      Controls.Add(
          tblDayHeaders);

      Controls.Add(
          pnlNavigation);

      Controls.Add(
          pnlHeader);

      ResumeLayout(false);
    }

    // =========================================================
    // NAVIGATION BUTTON
    // =========================================================

    private static void ConfigureNavigationButton(
        Button button,
        string text)
    {
      button.Text =
          text;

      button.Font =
          new Font(
              "Segoe UI",
              16F,
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
    // DAY HEADER
    // =========================================================

    private static void ConfigureDayHeader(
        Label label,
        string text)
    {
      label.Dock =
          DockStyle.Fill;

      label.Text =
          text;

      label.TextAlign =
          ContentAlignment.MiddleCenter;

      label.Font =
          new Font(
              "Segoe UI",
              13F,
              FontStyle.Bold);

      label.ForeColor =
          Color.FromArgb(
              75,
              85,
              99);

      label.BackColor =
          Color.FromArgb(
              229,
              231,
              235);

      label.Margin =
          new Padding(3);
    }
  }
}