using System.ComponentModel;

namespace CorteNext.Forms
{
  public partial class CalendarForm : Form
  {
    private readonly Func<
        DateTime,
        IReadOnlyList<DateTime>>?
        _highlightedDateProvider;

    private readonly HashSet<DateTime>
        _highlightedDates = new();

    private DateTime _displayMonth;

    [Browsable(false)]
    [DesignerSerializationVisibility(
        DesignerSerializationVisibility.Hidden)]
    public DateTime SelectedDate
    {
      get;
      private set;
    }

    // =========================================================
    // CONSTRUCTOR
    // =========================================================

    public CalendarForm(
        DateTime? initialDate = null,
        Func<DateTime, IReadOnlyList<DateTime>>?
            highlightedDateProvider = null)
    {
      InitializeComponent();

      SelectedDate =
          initialDate?.Date ??
          DateTime.Today;

      _displayMonth =
          new DateTime(
              SelectedDate.Year,
              SelectedDate.Month,
              1);

      _highlightedDateProvider =
          highlightedDateProvider;
    }

    // =========================================================
    // LOAD
    // =========================================================

    private void CalendarForm_Load(
        object sender,
        EventArgs e)
    {
      RefreshCalendar();

      UpdateSelectButton();
    }

    // =========================================================
    // REFRESH CALENDAR
    // =========================================================

    private void RefreshCalendar()
    {
      LoadHighlightedDates();

      DisplayCalendar();
    }

    // =========================================================
    // LOAD HIGHLIGHTED DATES
    // =========================================================

    private void LoadHighlightedDates()
    {
      _highlightedDates.Clear();

      if (_highlightedDateProvider == null)
      {
        return;
      }

      try
      {
        IReadOnlyList<DateTime> dates =
            _highlightedDateProvider(
                _displayMonth);

        foreach (DateTime date in dates)
        {
          _highlightedDates.Add(
              date.Date);
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(
            ex.Message,
            "Unable to Load Available Dates",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
      }
    }

    // =========================================================
    // DISPLAY CALENDAR
    // =========================================================

    private void DisplayCalendar()
    {
      tblDays.SuspendLayout();

      try
      {
        tblDays.Controls.Clear();

        lblMonthYear.Text =
            _displayMonth.ToString(
                "MMMM yyyy");

        int daysInMonth =
            DateTime.DaysInMonth(
                _displayMonth.Year,
                _displayMonth.Month);

        int firstDayColumn =
            (int)_displayMonth.DayOfWeek;

        int cellIndex =
            firstDayColumn;

        for (int day = 1;
             day <= daysInMonth;
             day++)
        {
          DateTime date =
              new(
                  _displayMonth.Year,
                  _displayMonth.Month,
                  day);

          Button button =
              CreateDayButton(
                  date);

          int row =
              cellIndex / 7;

          int column =
              cellIndex % 7;

          tblDays.Controls.Add(
              button,
              column,
              row);

          cellIndex++;
        }
      }
      finally
      {
        tblDays.ResumeLayout();
      }
    }

    // =========================================================
    // CREATE DAY BUTTON
    // =========================================================

    private Button CreateDayButton(
        DateTime date)
    {
      Button button = new()
      {
        Text =
              date.Day.ToString(),

        Tag =
              date,

        Dock =
              DockStyle.Fill,

        Margin =
              new Padding(5),

        Font =
              new Font(
                  "Segoe UI",
                  18F,
                  FontStyle.Bold),

        BackColor =
              Color.White,

        ForeColor =
              Color.FromArgb(
                  31,
                  41,
                  55),

        FlatStyle =
              FlatStyle.Flat,

        Cursor =
              Cursors.Hand,

        TabStop =
              false
      };

      button.FlatAppearance.BorderColor =
          Color.FromArgb(
              209,
              213,
              219);

      button.FlatAppearance.BorderSize =
          1;

      // =====================================================
      // CORTE REPORT AVAILABLE
      // =====================================================

      if (_highlightedDates.Contains(
              date.Date))
      {
        button.BackColor =
            Color.FromArgb(
                191,
                219,
                254);

        button.ForeColor =
            Color.FromArgb(
                30,
                64,
                175);

        button.FlatAppearance.BorderColor =
            Color.FromArgb(
                59,
                130,
                246);

        button.FlatAppearance.BorderSize =
            3;
      }

      // =====================================================
      // TODAY
      //
      // If today contains reports, the blue report
      // background remains and the border is emphasized.
      // =====================================================

      if (date.Date ==
          DateTime.Today)
      {
        if (!_highlightedDates.Contains(
                date.Date))
        {
          button.BackColor =
              Color.FromArgb(
                  239,
                  246,
                  255);

          button.ForeColor =
              Color.FromArgb(
                  30,
                  64,
                  175);
        }

        button.FlatAppearance.BorderColor =
            Color.FromArgb(
                37,
                99,
                235);

        button.FlatAppearance.BorderSize =
            4;
      }

      // =====================================================
      // SELECTED DATE
      //
      // This is last so green always takes priority.
      // =====================================================

      if (date.Date ==
          SelectedDate.Date)
      {
        button.BackColor =
            Color.FromArgb(
                34,
                197,
                94);

        button.ForeColor =
            Color.White;

        button.FlatAppearance.BorderColor =
            Color.FromArgb(
                21,
                128,
                61);

        button.FlatAppearance.BorderSize =
            4;
      }

      button.Click +=
          DayButton_Click;

      return button;
    }

    // =========================================================
    // DAY SELECTED
    // =========================================================

    private void DayButton_Click(
        object? sender,
        EventArgs e)
    {
      if (sender is not Button button)
      {
        return;
      }

      if (button.Tag is not DateTime date)
      {
        return;
      }

      SelectedDate =
          date.Date;

      DisplayCalendar();

      UpdateSelectButton();
    }

    // =========================================================
    // SELECT BUTTON
    // =========================================================

    private void UpdateSelectButton()
    {
      btnSelect.Enabled =
          true;

      btnSelect.Text =
          $"SELECT {SelectedDate:MM/dd/yyyy}";

      btnSelect.BackColor =
          Color.FromArgb(
              34,
              197,
              94);

      btnSelect.ForeColor =
          Color.White;
    }

    private void btnSelect_Click(
        object sender,
        EventArgs e)
    {
      DialogResult =
          DialogResult.OK;

      Close();
    }

    // =========================================================
    // PREVIOUS MONTH
    // =========================================================

    private void btnPrevious_Click(
        object sender,
        EventArgs e)
    {
      _displayMonth =
          _displayMonth.AddMonths(-1);

      RefreshCalendar();
    }

    // =========================================================
    // NEXT MONTH
    // =========================================================

    private void btnNext_Click(
        object sender,
        EventArgs e)
    {
      _displayMonth =
          _displayMonth.AddMonths(1);

      RefreshCalendar();
    }

    // =========================================================
    // TODAY
    // =========================================================

    private void btnToday_Click(
        object sender,
        EventArgs e)
    {
      SelectedDate =
          DateTime.Today;

      _displayMonth =
          new DateTime(
              SelectedDate.Year,
              SelectedDate.Month,
              1);

      RefreshCalendar();

      UpdateSelectButton();
    }

    // =========================================================
    // CANCEL
    // =========================================================

    private void btnCancel_Click(
        object sender,
        EventArgs e)
    {
      DialogResult =
          DialogResult.Cancel;

      Close();
    }
  }
}