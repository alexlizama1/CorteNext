using CorteNext.Controls;

namespace CorteNext.Forms
{
  partial class ExpenseForm
  {
    private System.ComponentModel.IContainer? components = null;

    // =========================================================
    // PANELS
    // =========================================================

    private Panel pnlHeader;
    private Panel pnlEntry;
    private Panel pnlTotal;
    private Panel pnlFooter;

    // =========================================================
    // HEADER
    // =========================================================

    private Label lblTitle;
    private Label lblDate;

    // =========================================================
    // ENTRY CONTROLS
    // =========================================================

    private TouchAmountBox amountExpense;

    private Button btnCompany;
    private Button btnDescription;
    private Button btnAdd;

    // =========================================================
    // GRID
    // =========================================================

    private DataGridView dgvExpenses;

    private DataGridViewTextBoxColumn colCompany;
    private DataGridViewTextBoxColumn colDescription;
    private DataGridViewTextBoxColumn colAmount;

    // =========================================================
    // TOTAL
    // =========================================================

    private Label lblTotalCaption;
    private Label lblTotalValue;

    // =========================================================
    // FOOTER
    // =========================================================

    private Button btnNoExpense;
    private Button btnDelete;
    private Button btnCancel;
    private Button btnDone;

    // =========================================================
    // LAYOUT
    // =========================================================

    private TableLayoutPanel tblMain;
    private TableLayoutPanel tblEntry;
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
      pnlEntry = new Panel();
      pnlTotal = new Panel();
      pnlFooter = new Panel();

      lblTitle = new Label();
      lblDate = new Label();

      amountExpense = new TouchAmountBox();

      btnCompany = new Button();
      btnDescription = new Button();
      btnAdd = new Button();

      dgvExpenses = new DataGridView();

      colCompany = new DataGridViewTextBoxColumn();
      colDescription = new DataGridViewTextBoxColumn();
      colAmount = new DataGridViewTextBoxColumn();

      lblTotalCaption = new Label();
      lblTotalValue = new Label();

      btnNoExpense = new Button();
      btnDelete = new Button();
      btnCancel = new Button();
      btnDone = new Button();

      tblMain = new TableLayoutPanel();
      tblEntry = new TableLayoutPanel();
      tblFooter = new TableLayoutPanel();

      ((System.ComponentModel.ISupportInitialize)dgvExpenses)
          .BeginInit();

      SuspendLayout();

      // =====================================================
      // EXPENSE FORM
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
              1800,
              1400);

      MinimumSize =
          new Size(
              950,
              700);

      FormBorderStyle =
          FormBorderStyle.None;

      Text =
          "Expenses";

      Load +=
          ExpenseForm_Load;

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
          "EXPENSES";

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
          "Date";

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
      // MAIN LAYOUT
      // =====================================================

      tblMain.Dock =
          DockStyle.Fill;

      tblMain.Padding =
          new Padding(20);

      tblMain.ColumnCount =
          1;

      tblMain.RowCount =
          4;

      tblMain.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              100F));

      tblMain.RowStyles.Add(
          new RowStyle(
              SizeType.Percent,
              35F));

      tblMain.RowStyles.Add(
          new RowStyle(
              SizeType.Percent,
              40F));

      tblMain.RowStyles.Add(
          new RowStyle(
              SizeType.Percent,
              12F));

      tblMain.RowStyles.Add(
          new RowStyle(
              SizeType.Percent,
              13F));

      // =====================================================
      // ENTRY PANEL
      // =====================================================

      pnlEntry.Dock =
          DockStyle.Fill;

      pnlEntry.BackColor =
          Color.FromArgb(
              245,
              247,
              250);

      tblEntry.Dock =
          DockStyle.Fill;

      tblEntry.Padding =
          new Padding(
              5);

      tblEntry.ColumnCount =
          2;

      tblEntry.RowCount =
          2;

      tblEntry.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              50F));

      tblEntry.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              50F));

      tblEntry.RowStyles.Add(
          new RowStyle(
              SizeType.Percent,
              50F));

      tblEntry.RowStyles.Add(
          new RowStyle(
              SizeType.Percent,
              50F));

      // =====================================================
      // AMOUNT
      // =====================================================

      amountExpense.Caption =
          "EXPENSE AMOUNT";

      amountExpense.Dock =
          DockStyle.Fill;

      amountExpense.Margin =
          new Padding(8);

      amountExpense.Value =
          0M;

      amountExpense.AllowNegative =
          false;

      amountExpense.ReadOnly =
          false;

      amountExpense.ValueChanged +=
          amountExpense_ValueChanged;

      // =====================================================
      // COMPANY
      // =====================================================

      ConfigureEntryButton(
          btnCompany,
          "TOUCH TO ENTER COMPANY");

      btnCompany.Click +=
          btnCompany_Click;

      // =====================================================
      // DESCRIPTION
      // =====================================================

      ConfigureEntryButton(
          btnDescription,
          "TOUCH TO ENTER DESCRIPTION");

      btnDescription.Click +=
          btnDescription_Click;

      // =====================================================
      // ADD EXPENSE
      // =====================================================

      btnAdd.Dock =
          DockStyle.Fill;

      btnAdd.Margin =
          new Padding(8);

      btnAdd.Text =
          "ADD EXPENSE";

      btnAdd.Font =
          new Font(
              "Segoe UI",
              17F,
              FontStyle.Bold);

      btnAdd.BackColor =
          Color.FromArgb(
              156,
              163,
              175);

      btnAdd.ForeColor =
          Color.White;

      btnAdd.FlatStyle =
          FlatStyle.Flat;

      btnAdd.FlatAppearance.BorderSize =
          0;

      btnAdd.Cursor =
          Cursors.Hand;

      btnAdd.Enabled =
          false;

      btnAdd.TabStop =
          false;

      btnAdd.Click +=
          btnAdd_Click;

      // -----------------------------------------------------
      // Add Entry Controls
      // -----------------------------------------------------

      tblEntry.Controls.Add(
          amountExpense,
          0,
          0);

      tblEntry.Controls.Add(
          btnCompany,
          1,
          0);

      tblEntry.Controls.Add(
          btnDescription,
          0,
          1);

      tblEntry.Controls.Add(
          btnAdd,
          1,
          1);

      pnlEntry.Controls.Add(
          tblEntry);

      // =====================================================
      // EXPENSE GRID
      // =====================================================

      dgvExpenses.Dock =
          DockStyle.Fill;

      dgvExpenses.Margin =
          new Padding(
              8);

      dgvExpenses.BackgroundColor =
          Color.White;

      dgvExpenses.BorderStyle =
          BorderStyle.FixedSingle;

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
          58;

      dgvExpenses.ColumnHeadersHeight =
          60;

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
              13F,
              FontStyle.Bold);

      dgvExpenses.ColumnHeadersDefaultCellStyle.Alignment =
          DataGridViewContentAlignment.MiddleCenter;

      dgvExpenses.DefaultCellStyle.Font =
          new Font(
              "Segoe UI",
              13F,
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

      dgvExpenses.GridColor =
          Color.FromArgb(
              209,
              213,
              219);

      dgvExpenses.CellClick +=
          dgvExpenses_CellClick;

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
          30F;

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
          50F;

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
          20F;

      colAmount.DefaultCellStyle.Alignment =
          DataGridViewContentAlignment.MiddleRight;

      colAmount.DefaultCellStyle.Format =
          "C2";

      dgvExpenses.Columns.AddRange(
          colCompany,
          colDescription,
          colAmount);

      // =====================================================
      // TOTAL PANEL
      // =====================================================

      pnlTotal.Dock =
          DockStyle.Fill;

      pnlTotal.Margin =
          new Padding(8);

      pnlTotal.BackColor =
          Color.FromArgb(
              219,
              234,
              254);

      // -----------------------------------------------------
      // Total Caption
      // -----------------------------------------------------

      lblTotalCaption.Dock =
          DockStyle.Left;

      lblTotalCaption.Width =
          500;

      lblTotalCaption.Text =
          "TOTAL EXPENSES";

      lblTotalCaption.TextAlign =
          ContentAlignment.MiddleRight;

      lblTotalCaption.Font =
          new Font(
              "Segoe UI",
              20F,
              FontStyle.Bold);

      lblTotalCaption.ForeColor =
          Color.FromArgb(
              30,
              64,
              175);

      // -----------------------------------------------------
      // Total Value
      // -----------------------------------------------------

      lblTotalValue.Dock =
          DockStyle.Fill;

      lblTotalValue.Text =
          "$0.00";

      lblTotalValue.TextAlign =
          ContentAlignment.MiddleLeft;

      lblTotalValue.Padding =
          new Padding(
              30,
              0,
              0,
              0);

      lblTotalValue.Font =
          new Font(
              "Segoe UI",
              28F,
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
      // FOOTER PANEL
      // =====================================================

      pnlFooter.Dock =
          DockStyle.Fill;

      pnlFooter.BackColor =
          Color.FromArgb(
              229,
              231,
              235);

      tblFooter.Dock =
          DockStyle.Fill;

      tblFooter.Padding =
          new Padding(5);

      tblFooter.ColumnCount =
          4;

      tblFooter.RowCount =
          1;

      for (int i = 0; i < 4; i++)
      {
        tblFooter.ColumnStyles.Add(
            new ColumnStyle(
                SizeType.Percent,
                25F));
      }

      // =====================================================
      // NO EXPENSE
      // =====================================================

      ConfigureFooterButton(
          btnNoExpense,
          "NO EXPENSE",
          Color.FromArgb(
              251,
              191,
              36),
          Color.FromArgb(
              31,
              41,
              55));

      btnNoExpense.Click +=
          btnNoExpense_Click;

      // =====================================================
      // DELETE
      // =====================================================

      ConfigureFooterButton(
          btnDelete,
          "DELETE",
          Color.FromArgb(
              239,
              68,
              68),
          Color.White);

      btnDelete.Enabled =
          false;

      btnDelete.Click +=
          btnDelete_Click;

      // =====================================================
      // CANCEL
      // =====================================================

      ConfigureFooterButton(
          btnCancel,
          "CANCEL",
          Color.FromArgb(
              107,
              114,
              128),
          Color.White);

      btnCancel.Click +=
          btnCancel_Click;

      // =====================================================
      // DONE
      // =====================================================

      ConfigureFooterButton(
          btnDone,
          "DONE",
          Color.FromArgb(
              34,
              197,
              94),
          Color.White);

      btnDone.Click +=
          btnDone_Click;

      // -----------------------------------------------------
      // Add Footer Buttons
      // -----------------------------------------------------

      tblFooter.Controls.Add(
          btnNoExpense,
          0,
          0);

      tblFooter.Controls.Add(
          btnDelete,
          1,
          0);

      tblFooter.Controls.Add(
          btnCancel,
          2,
          0);

      tblFooter.Controls.Add(
          btnDone,
          3,
          0);

      pnlFooter.Controls.Add(
          tblFooter);

      // =====================================================
      // BUILD MAIN LAYOUT
      // =====================================================

      tblMain.Controls.Add(
          pnlEntry,
          0,
          0);

      tblMain.Controls.Add(
          dgvExpenses,
          0,
          1);

      tblMain.Controls.Add(
          pnlTotal,
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

      ((System.ComponentModel.ISupportInitialize)dgvExpenses)
          .EndInit();

      ResumeLayout(false);
    }

    // =========================================================
    // ENTRY BUTTON
    // =========================================================

    private static void ConfigureEntryButton(
        Button button,
        string text)
    {
      button.Text =
          text;

      button.Dock =
          DockStyle.Fill;

      button.Margin =
          new Padding(8);

      button.Font =
          new Font(
              "Segoe UI",
              15F,
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
        Color backgroundColor,
        Color foregroundColor)
    {
      button.Text =
          text;

      button.Dock =
          DockStyle.Fill;

      button.Margin =
          new Padding(7);

      button.Font =
          new Font(
              "Segoe UI",
              15F,
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