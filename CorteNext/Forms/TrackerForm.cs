using CorteNext.Models;
using CorteNext.Services;

namespace CorteNext.Forms
{
  public partial class TrackerForm : Form
  {
    private readonly ITrackerService _trackerService;

    private DateTime _selectedDate =
        DateTime.Today;

    public event EventHandler? TrackerCompleted;

    public TrackerForm(
        ITrackerService trackerService)
    {
      InitializeComponent();

      _trackerService =
          trackerService;
    }

    // =========================================================
    // LOAD
    // =========================================================

    private void TrackerForm_Load(
        object sender,
        EventArgs e)
    {
      LoadTracker(
          DateTime.Today);
    }

    // =========================================================
    // LOAD TRACKER
    // =========================================================

    private void LoadTracker(
        DateTime date)
    {
      try
      {
        _selectedDate =
            date.Date;

        DailyTracker tracker =
            _trackerService.GetDailyTracker(
                _selectedDate);

        lblDate.Text =
            _selectedDate.ToString(
                "dddd, MMMM d, yyyy");

        // =================================================
        // FONDO
        // =================================================

        SetStatus(
            lblFondoAMStatus,
            tracker.FondoAMCompleted);

        SetStatus(
            lblFondoDriveStatus,
            tracker.FondoDriveCompleted);

        SetStatus(
            lblFondoPMStatus,
            tracker.FondoPMCompleted);

        // =================================================
        // CORTE
        // =================================================

        SetStatus(
            lblCorteAMStatus,
            tracker.CorteAMCompleted);

        SetStatus(
            lblCorteAMDriveStatus,
            tracker.CorteAMDriveCompleted);

        SetStatus(
            lblCortePMDriveStatus,
            tracker.CortePMDriveCompleted);

        SetStatus(
            lblCortePMStatus,
            tracker.CortePMCompleted);

        // =================================================
        // OVERALL DAY STATUS
        // =================================================

        UpdateDayStatus(
            tracker);
      }
      catch (Exception ex)
      {
        MessageBox.Show(
            ex.Message,
            "Unable to Load Tracker",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
      }
    }

    // =========================================================
    // STATUS APPEARANCE
    // =========================================================

    private static void SetStatus(
        Label label,
        bool completed)
    {
      if (completed)
      {
        label.Text =
            "COMPLETED";

        label.BackColor =
            Color.FromArgb(
                220,
                252,
                231);

        label.ForeColor =
            Color.FromArgb(
                22,
                101,
                52);

        return;
      }

      label.Text =
          "NOT COMPLETED";

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
    // DAY STATUS
    // =========================================================

    private void UpdateDayStatus(
        DailyTracker tracker)
    {
      if (tracker.DayCompleted)
      {
        lblDayStatus.Text =
            "DAY COMPLETED";

        lblDayStatus.BackColor =
            Color.FromArgb(
                34,
                197,
                94);

        lblDayStatus.ForeColor =
            Color.White;

        return;
      }

      if (tracker.AllFondoCompleted)
      {
        lblDayStatus.Text =
            "FONDO COMPLETE - CORTE IN PROGRESS";

        lblDayStatus.BackColor =
            Color.FromArgb(
                254,
                249,
                195);

        lblDayStatus.ForeColor =
            Color.FromArgb(
                133,
                77,
                14);

        return;
      }

      lblDayStatus.Text =
          "DAY IN PROGRESS";

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
    }

    // =========================================================
    // TODAY
    // =========================================================

    private void btnToday_Click(
        object sender,
        EventArgs e)
    {
      LoadTracker(
          DateTime.Today);
    }

    // =========================================================
    // SELECT DATE
    // =========================================================

    private void btnSelectDate_Click(
        object sender,
        EventArgs e)
    {
      using CalendarForm calendar =
          new(_selectedDate);

      if (calendar.ShowDialog(this) !=
          DialogResult.OK)
      {
        return;
      }

      LoadTracker(
          calendar.SelectedDate);
    }

    // =========================================================
    // REFRESH
    // =========================================================

    private void btnRefresh_Click(
        object sender,
        EventArgs e)
    {
      LoadTracker(
          _selectedDate);
    }

    // =========================================================
    // DONE
    // =========================================================

    private void btnDone_Click(
        object sender,
        EventArgs e)
    {
      TrackerCompleted?.Invoke(
          this,
          EventArgs.Empty);

      Close();
    }
  }
}