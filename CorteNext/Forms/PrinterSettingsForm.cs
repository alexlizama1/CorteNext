using CorteNext.Services;

namespace CorteNext.Forms
{
  public partial class PrinterSettingsForm : Form
  {
    private readonly IPrinterSettingsService _printerSettingsService;

    public event EventHandler? PrinterSettingsCompleted;

    public PrinterSettingsForm(
        IPrinterSettingsService printerSettingsService)
    {
      InitializeComponent();

      _printerSettingsService =
          printerSettingsService;
    }

    // =========================================================
    // LOAD
    // =========================================================

    private void PrinterSettingsForm_Load(
        object sender,
        EventArgs e)
    {
      LoadPrinters();
      UpdateCurrentPrinter();
      UpdateSaveState();
    }

    // =========================================================
    // LOAD PRINTERS
    // =========================================================

    private void LoadPrinters()
    {
      try
      {
        IReadOnlyList<string> printers =
            _printerSettingsService
                .GetInstalledPrinters();

        lstPrinters.DataSource =
            printers.ToList();

        lstPrinters.ClearSelected();

        string? currentPrinter =
            _printerSettingsService
                .ReceiptPrinterName;

        if (!string.IsNullOrWhiteSpace(
                currentPrinter))
        {
          int index =
              lstPrinters.FindStringExact(
                  currentPrinter);

          if (index >= 0)
          {
            lstPrinters.SelectedIndex =
                index;
          }
        }

        lblPrinterCount.Text =
            printers.Count == 1
                ? "1 PRINTER FOUND"
                : $"{printers.Count} PRINTERS FOUND";
      }
      catch (Exception ex)
      {
        MessageBox.Show(
            ex.Message,
            "Unable to Load Printers",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
      }
    }

    // =========================================================
    // CURRENT PRINTER
    // =========================================================

    private void UpdateCurrentPrinter()
    {
      string? printer =
          _printerSettingsService
              .ReceiptPrinterName;

      if (string.IsNullOrWhiteSpace(printer))
      {
        lblCurrentPrinterValue.Text =
            "NOT CONFIGURED";

        lblCurrentPrinterValue.ForeColor =
            Color.FromArgb(
                185,
                28,
                28);

        return;
      }

      lblCurrentPrinterValue.Text =
          printer;

      lblCurrentPrinterValue.ForeColor =
          Color.FromArgb(
              22,
              101,
              52);
    }

    // =========================================================
    // PRINTER SELECTED
    // =========================================================

    private void lstPrinters_SelectedIndexChanged(
        object sender,
        EventArgs e)
    {
      UpdateSaveState();
    }

    // =========================================================
    // SAVE STATE
    // =========================================================

    private void UpdateSaveState()
    {
      btnSave.Enabled =
          lstPrinters.SelectedItem
          is string;

      btnSave.BackColor =
          btnSave.Enabled
              ? Color.FromArgb(
                  34,
                  197,
                  94)
              : Color.FromArgb(
                  156,
                  163,
                  175);
    }

    // =========================================================
    // SAVE
    // =========================================================

    private void btnSave_Click(
        object sender,
        EventArgs e)
    {
      if (lstPrinters.SelectedItem
          is not string printerName)
      {
        MessageBox.Show(
            "Select a printer first.",
            "Printer Settings",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);

        return;
      }

      try
      {
        _printerSettingsService
            .SetReceiptPrinter(
                printerName);

        UpdateCurrentPrinter();

        MessageBox.Show(
            $"Receipt printer set to:\n\n{printerName}",
            "Printer Settings",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
      }
      catch (Exception ex)
      {
        MessageBox.Show(
            ex.Message,
            "Unable to Save Printer",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
      }
    }

    // =========================================================
    // DONE
    // =========================================================

    private void btnDone_Click(
        object sender,
        EventArgs e)
    {
      PrinterSettingsCompleted?.Invoke(
          this,
          EventArgs.Empty);

      Close();
    }
  }
}