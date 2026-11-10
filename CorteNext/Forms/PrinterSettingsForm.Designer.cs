namespace CorteNext.Forms
{
  partial class PrinterSettingsForm
  {
    private System.ComponentModel.IContainer? components = null;

    private Panel pnlHeader;
    private Panel pnlCurrentPrinter;
    private Panel pnlFooter;

    private Label lblTitle;
    private Label lblInstructions;

    private Label lblCurrentPrinterCaption;
    private Label lblCurrentPrinterValue;

    private Label lblPrinterCount;

    private ListBox lstPrinters;

    private Button btnSave;
    private Button btnDone;

    private TableLayoutPanel tblFooter;

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        components?.Dispose();
      }

      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      pnlHeader = new Panel();
      pnlCurrentPrinter = new Panel();
      pnlFooter = new Panel();

      lblTitle = new Label();
      lblInstructions = new Label();

      lblCurrentPrinterCaption = new Label();
      lblCurrentPrinterValue = new Label();

      lblPrinterCount = new Label();

      lstPrinters = new ListBox();

      btnSave = new Button();
      btnDone = new Button();

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
              1000,
              750);

      MinimumSize =
          new Size(
              900,
              650);

      FormBorderStyle =
          FormBorderStyle.None;

      Text =
          "Printer Settings";

      Load +=
          PrinterSettingsForm_Load;

      // =====================================================
      // HEADER
      // =====================================================

      pnlHeader.Dock =
          DockStyle.Top;

      pnlHeader.Height =
          125;

      pnlHeader.BackColor =
          Color.FromArgb(
              31,
              41,
              55);

      lblTitle.Dock =
          DockStyle.Top;

      lblTitle.Height =
          70;

      lblTitle.Text =
          "RECEIPT PRINTER";

      lblTitle.TextAlign =
          ContentAlignment.BottomCenter;

      lblTitle.Font =
          new Font(
              "Segoe UI",
              25F,
              FontStyle.Bold);

      lblTitle.ForeColor =
          Color.White;

      lblInstructions.Dock =
          DockStyle.Fill;

      lblInstructions.Text =
          "Select the printer used for Corte receipts";

      lblInstructions.TextAlign =
          ContentAlignment.TopCenter;

      lblInstructions.Font =
          new Font(
              "Segoe UI",
              13F,
              FontStyle.Regular);

      lblInstructions.ForeColor =
          Color.FromArgb(
              191,
              219,
              254);

      pnlHeader.Controls.Add(
          lblInstructions);

      pnlHeader.Controls.Add(
          lblTitle);

      // =====================================================
      // CURRENT PRINTER
      // =====================================================

      pnlCurrentPrinter.Dock =
          DockStyle.Top;

      pnlCurrentPrinter.Height =
          120;

      pnlCurrentPrinter.Padding =
          new Padding(
              30,
              10,
              30,
              10);

      pnlCurrentPrinter.BackColor =
          Color.FromArgb(
              219,
              234,
              254);

      lblCurrentPrinterCaption.Dock =
          DockStyle.Top;

      lblCurrentPrinterCaption.Height =
          42;

      lblCurrentPrinterCaption.Text =
          "CURRENT RECEIPT PRINTER";

      lblCurrentPrinterCaption.TextAlign =
          ContentAlignment.MiddleCenter;

      lblCurrentPrinterCaption.Font =
          new Font(
              "Segoe UI",
              14F,
              FontStyle.Bold);

      lblCurrentPrinterCaption.ForeColor =
          Color.FromArgb(
              30,
              64,
              175);

      lblCurrentPrinterValue.Dock =
          DockStyle.Fill;

      lblCurrentPrinterValue.Text =
          "NOT CONFIGURED";

      lblCurrentPrinterValue.TextAlign =
          ContentAlignment.MiddleCenter;

      lblCurrentPrinterValue.Font =
          new Font(
              "Segoe UI",
              18F,
              FontStyle.Bold);

      lblCurrentPrinterValue.ForeColor =
          Color.FromArgb(
              185,
              28,
              28);

      pnlCurrentPrinter.Controls.Add(
          lblCurrentPrinterValue);

      pnlCurrentPrinter.Controls.Add(
          lblCurrentPrinterCaption);

      // =====================================================
      // PRINTER COUNT
      // =====================================================

      lblPrinterCount.Dock =
          DockStyle.Top;

      lblPrinterCount.Height =
          60;

      lblPrinterCount.Padding =
          new Padding(
              25,
              0,
              0,
              0);

      lblPrinterCount.Text =
          "0 PRINTERS FOUND";

      lblPrinterCount.TextAlign =
          ContentAlignment.MiddleLeft;

      lblPrinterCount.Font =
          new Font(
              "Segoe UI",
              14F,
              FontStyle.Bold);

      lblPrinterCount.ForeColor =
          Color.FromArgb(
              75,
              85,
              99);

      // =====================================================
      // PRINTER LIST
      // =====================================================

      lstPrinters.Dock =
          DockStyle.Fill;

      lstPrinters.Margin =
          new Padding(25);

      lstPrinters.BorderStyle =
          BorderStyle.FixedSingle;

      lstPrinters.Font =
          new Font(
              "Segoe UI",
              17F,
              FontStyle.Regular);

      lstPrinters.ItemHeight =
          55;

      lstPrinters.IntegralHeight =
          false;

      lstPrinters.BackColor =
          Color.White;

      lstPrinters.ForeColor =
          Color.FromArgb(
              31,
              41,
              55);

      lstPrinters.SelectedIndexChanged +=
          lstPrinters_SelectedIndexChanged;

      // =====================================================
      // FOOTER
      // =====================================================

      pnlFooter.Dock =
          DockStyle.Bottom;

      pnlFooter.Height =
          115;

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

      // =====================================================
      // SAVE
      // =====================================================

      ConfigureFooterButton(
          btnSave,
          "SAVE PRINTER",
          Color.FromArgb(
              156,
              163,
              175));

      btnSave.Enabled =
          false;

      btnSave.Click +=
          btnSave_Click;

      // =====================================================
      // DONE
      // =====================================================

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
          btnSave,
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
      // =====================================================

      Controls.Add(
          lstPrinters);

      Controls.Add(
          pnlFooter);

      Controls.Add(
          lblPrinterCount);

      Controls.Add(
          pnlCurrentPrinter);

      Controls.Add(
          pnlHeader);

      ResumeLayout(false);
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