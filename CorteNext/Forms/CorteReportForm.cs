using CorteNext.Models;
using CorteNext.Printing;
using CorteNext.Services;

namespace CorteNext.Forms
{
  public partial class CorteReportForm : Form
  {
    private readonly ICorteService _corteService;

    private List<CorteRecord> _records = new();

    private string? _shiftFilter;

    public event EventHandler? CorteReportCompleted;
    private DateTime _selectedDate = DateTime.Today;
    private readonly IReceiptPrintService _receiptPrintService;


    public CorteReportForm(
      ICorteService corteService,
      IReceiptPrintService receiptPrintService)
    {
      InitializeComponent();

      _corteService = corteService;
      _receiptPrintService = receiptPrintService;
    }

    // =========================================================
    // FORM LOAD
    // =========================================================

    private void CorteReportForm_Load(
        object sender,
        EventArgs e)
    {
      lblDate.Text =
          DateTime.Now.ToString(
              "dddd, MMMM d, yyyy");

      ConfigureGrid();

      LoadToday();
    }

    // =========================================================
    // GRID
    // =========================================================

    private void ConfigureGrid()
    {
      dgvCortes.AutoGenerateColumns = false;

      dgvCortes.AllowUserToAddRows = false;
      dgvCortes.AllowUserToDeleteRows = false;
      dgvCortes.AllowUserToResizeRows = false;

      dgvCortes.MultiSelect = false;
      dgvCortes.ReadOnly = true;

      dgvCortes.RowHeadersVisible = false;

      dgvCortes.SelectionMode =
          DataGridViewSelectionMode.FullRowSelect;

      dgvCortes.RowTemplate.Height = 100;

      dgvCortes.ColumnHeadersHeight = 60;

      dgvCortes.ColumnHeadersHeightSizeMode =
          DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

      dgvCortes.DefaultCellStyle.Font =
          new Font(
              "Segoe UI",
              12F,
              FontStyle.Regular);

      dgvCortes.ColumnHeadersDefaultCellStyle.Font =
          new Font(
              "Segoe UI",
              12F,
              FontStyle.Bold);
    }

    // =========================================================
    // TODAY
    // =========================================================

    private void btnToday_Click(
        object sender,
        EventArgs e)
    {
      LoadToday();
    }

    private void LoadToday()
    {
      try
      {
        _selectedDate =
            DateTime.Today;

        _records =
            _corteService
                .GetCortesByDate(
                    _selectedDate)
                .ToList();

        _shiftFilter = null;

        lblReportMode.Text =
            "TODAY";

        lblDate.Text =
            _selectedDate.ToString(
                "dddd, MMMM d, yyyy");

        ApplyFilter();
      }
      catch (Exception ex)
      {
        ShowLoadError(ex);
      }
    }

    // =========================================================
    // LAST 10
    // =========================================================

    private void btnLast10_Click(
        object sender,
        EventArgs e)
    {
      try
      {
        _records =
            _corteService
                .GetRecentCortes(10)
                .ToList();

        _shiftFilter = null;

        lblReportMode.Text =
            "LAST 10 CORTE RECORDS";

        ApplyFilter();
      }
      catch (Exception ex)
      {
        ShowLoadError(ex);
      }
    }

    // =========================================================
    // ALL SHIFTS
    // =========================================================

    private void btnAllShifts_Click(
        object sender,
        EventArgs e)
    {
      _shiftFilter = null;

      ApplyFilter();
    }

    // =========================================================
    // AM
    // =========================================================

    private void btnAM_Click(
        object sender,
        EventArgs e)
    {
      _shiftFilter = "am";

      ApplyFilter();
    }

    // =========================================================
    // PM
    // =========================================================

    private void btnPM_Click(
        object sender,
        EventArgs e)
    {
      _shiftFilter = "pm";

      ApplyFilter();
    }

    // =========================================================
    // AM DRIVE
    // =========================================================

    private void btnAMDrive_Click(
        object sender,
        EventArgs e)
    {
      _shiftFilter = "amDrive";

      ApplyFilter();
    }

    // =========================================================
    // PM DRIVE
    // =========================================================

    private void btnPMDrive_Click(
        object sender,
        EventArgs e)
    {
      _shiftFilter = "pmDrive";

      ApplyFilter();
    }

    // =========================================================
    // APPLY FILTER
    // =========================================================

    private void ApplyFilter()
    {
      IEnumerable<CorteRecord> filtered =
          _records;

      if (!string.IsNullOrWhiteSpace(
              _shiftFilter))
      {
        filtered =
            filtered.Where(
                record =>
                    string.Equals(
                        record.Shift,
                        _shiftFilter,
                        StringComparison.OrdinalIgnoreCase));
      }

      List<CorteRecord> displayRecords =
          filtered.ToList();

      dgvCortes.DataSource = null;

      dgvCortes.DataSource =
          displayRecords;

      dgvCortes.ClearSelection();

      lblRecordCount.Text =
          displayRecords.Count == 1
              ? "1 RECORD"
              : $"{displayRecords.Count} RECORDS";

      HighlightShortOver();
    }

    // =========================================================
    // SHORT / OVER COLORS
    // =========================================================

    private void HighlightShortOver()
    {
      foreach (DataGridViewRow row
               in dgvCortes.Rows)
      {
        if (row.DataBoundItem
            is not CorteRecord record)
        {
          continue;
        }

        DataGridViewCell cell =
            row.Cells["colShortOver"];

        if (record.ShortOver < 0)
        {
          cell.Style.BackColor =
              Color.FromArgb(
                  254,
                  202,
                  202);

          cell.Style.ForeColor =
              Color.FromArgb(
                  153,
                  27,
                  27);

          continue;
        }

        if (record.ShortOver > 0)
        {
          cell.Style.BackColor =
              Color.FromArgb(
                  187,
                  247,
                  208);

          cell.Style.ForeColor =
              Color.FromArgb(
                  22,
                  101,
                  52);

          continue;
        }

        cell.Style.BackColor =
            Color.FromArgb(
                219,
                234,
                254);

        cell.Style.ForeColor =
            Color.FromArgb(
                30,
                64,
                175);
      }
    }

    // =========================================================
    // SELECTED RECORD
    // =========================================================

    private CorteRecord? GetSelectedRecord()
    {
      if (dgvCortes.SelectedRows.Count == 0)
        return null;

      return dgvCortes
          .SelectedRows[0]
          .DataBoundItem
          as CorteRecord;
    }

    // =========================================================
    // PRINT
    // =========================================================

    private void btnPrint_Click(
        object sender,
        EventArgs e)
    {
      CorteRecord? record =
          GetSelectedRecord();

      if (record == null)
      {
        MessageBox.Show(
            "Select a Corte record first.",
            "Print Corte",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);

        return;
      }

      try
      {
        _receiptPrintService.PrintCorte(
            record);
      }
      catch (Exception ex)
      {
        MessageBox.Show(
            ex.Message,
            "Unable to Print Corte",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
      }
    }

    // =========================================================
    // SELECT DATE
    // =========================================================

    private void btnSelectDate_Click(
        object sender,
        EventArgs e)
    {
      using CalendarForm calendar =
          new(
              _selectedDate,
              LoadAvailableCorteDates);

      if (calendar.ShowDialog(this) !=
          DialogResult.OK)
      {
        return;
      }

      LoadDate(
          calendar.SelectedDate);
    }

    private IReadOnlyList<DateTime> LoadAvailableCorteDates(
    DateTime displayedMonth)
    {
      DateTime firstDay =
          new(
              displayedMonth.Year,
              displayedMonth.Month,
              1);

      DateTime lastDay =
          firstDay
              .AddMonths(1)
              .AddDays(-1);

      return _corteService.GetCorteDates(
          firstDay,
          lastDay);
    }

    private void LoadDate(
        DateTime date)
    {
      try
      {
        _selectedDate =
            date.Date;

        _records =
            _corteService
                .GetCortesByDate(
                    _selectedDate)
                .ToList();

        _shiftFilter = null;

        lblReportMode.Text =
            "SELECTED DATE";

        lblDate.Text =
            _selectedDate.ToString(
                "dddd, MMMM d, yyyy");

        ApplyFilter();
      }
      catch (Exception ex)
      {
        ShowLoadError(ex);
      }
    }



    // =========================================================
    // DONE
    // =========================================================

    private void btnDone_Click(
        object sender,
        EventArgs e)
    {
      CorteReportCompleted?.Invoke(
          this,
          EventArgs.Empty);

      Close();
    }

    // =========================================================
    // ERROR
    // =========================================================

    private static void ShowLoadError(
        Exception ex)
    {
      MessageBox.Show(
          ex.Message,
          "Unable to Load Corte Report",
          MessageBoxButtons.OK,
          MessageBoxIcon.Error);
    }
  }
}