namespace CorteNext.Forms
{
  partial class UserManagementForm
  {
    private System.ComponentModel.IContainer? components = null;

    // =========================================================
    // PANELS
    // =========================================================

    private Panel pnlHeader;
    private Panel pnlUsers;
    private Panel pnlEditor;
    private Panel pnlFooter;

    // =========================================================
    // HEADER
    // =========================================================

    private Label lblTitle;

    // =========================================================
    // USER LIST
    // =========================================================

    private Label lblUsers;
    private ListBox lstUsers;

    // =========================================================
    // EDITOR
    // =========================================================

    private Label lblEditorTitle;

    private Label lblFirstName;
    private Label lblLastName;
    private Label lblUserName;
    private Label lblPin;
    private Label lblAccessLevel;

    private Button btnFirstName;
    private Button btnLastName;
    private Button btnUserName;
    private Button btnPin;

    private ComboBox cboAccessLevel;

    // =========================================================
    // FOOTER
    // =========================================================

    private Button btnAddUser;
    private Button btnDelete;
    private Button btnSave;
    private Button btnDone;

    // =========================================================
    // LAYOUT
    // =========================================================

    private TableLayoutPanel tblMain;
    private TableLayoutPanel tblEditor;
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
      pnlUsers = new Panel();
      pnlEditor = new Panel();
      pnlFooter = new Panel();

      lblTitle = new Label();

      lblUsers = new Label();
      lstUsers = new ListBox();

      lblEditorTitle = new Label();

      lblFirstName = new Label();
      lblLastName = new Label();
      lblUserName = new Label();
      lblPin = new Label();
      lblAccessLevel = new Label();

      btnFirstName = new Button();
      btnLastName = new Button();
      btnUserName = new Button();
      btnPin = new Button();

      cboAccessLevel = new ComboBox();

      btnAddUser = new Button();
      btnDelete = new Button();
      btnSave = new Button();
      btnDone = new Button();

      tblMain = new TableLayoutPanel();
      tblEditor = new TableLayoutPanel();
      tblFooter = new TableLayoutPanel();

      SuspendLayout();

      // =====================================================
      // USER MANAGEMENT FORM
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
              800);

      MinimumSize =
          new Size(
              1050,
              700);

      FormBorderStyle =
          FormBorderStyle.None;

      Text =
          "User Management";

      Load +=
          UserManagementForm_Load;

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

      lblTitle.Dock =
          DockStyle.Fill;

      lblTitle.Text =
          "USER MANAGEMENT";

      lblTitle.TextAlign =
          ContentAlignment.MiddleCenter;

      lblTitle.Font =
          new Font(
              "Segoe UI",
              25F,
              FontStyle.Bold);

      lblTitle.ForeColor =
          Color.White;

      pnlHeader.Controls.Add(
          lblTitle);

      // =====================================================
      // MAIN TABLE
      // =====================================================

      tblMain.Dock =
          DockStyle.Fill;

      tblMain.Padding =
          new Padding(
              20);

      tblMain.ColumnCount =
          2;

      tblMain.RowCount =
          2;

      tblMain.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              35F));

      tblMain.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              65F));

      tblMain.RowStyles.Add(
          new RowStyle(
              SizeType.Percent,
              84F));

      tblMain.RowStyles.Add(
          new RowStyle(
              SizeType.Percent,
              16F));

      // =====================================================
      // USER LIST PANEL
      // =====================================================

      pnlUsers.Dock =
          DockStyle.Fill;

      pnlUsers.Margin =
          new Padding(
              8);

      pnlUsers.Padding =
          new Padding(
              12);

      pnlUsers.BackColor =
          Color.White;

      // -----------------------------------------------------
      // Users Heading
      // -----------------------------------------------------

      lblUsers.Dock =
          DockStyle.Top;

      lblUsers.Height =
          65;

      lblUsers.Text =
          "USERS";

      lblUsers.TextAlign =
          ContentAlignment.MiddleCenter;

      lblUsers.Font =
          new Font(
              "Segoe UI",
              18F,
              FontStyle.Bold);

      lblUsers.ForeColor =
          Color.FromArgb(
              31,
              41,
              55);

      lblUsers.BackColor =
          Color.FromArgb(
              229,
              231,
              235);

      // -----------------------------------------------------
      // User List
      // -----------------------------------------------------

      lstUsers.Dock =
          DockStyle.Fill;

      lstUsers.BorderStyle =
          BorderStyle.None;

      lstUsers.Font =
          new Font(
              "Segoe UI",
              17F,
              FontStyle.Regular);

      lstUsers.ItemHeight =
          50;

      lstUsers.IntegralHeight =
          false;

      lstUsers.BackColor =
          Color.White;

      lstUsers.ForeColor =
          Color.FromArgb(
              31,
              41,
              55);

      lstUsers.SelectedIndexChanged +=
          lstUsers_SelectedIndexChanged;

      pnlUsers.Controls.Add(
          lstUsers);

      pnlUsers.Controls.Add(
          lblUsers);

      // =====================================================
      // EDITOR PANEL
      // =====================================================

      pnlEditor.Dock =
          DockStyle.Fill;

      pnlEditor.Margin =
          new Padding(
              8);

      pnlEditor.Padding =
          new Padding(
              15);

      pnlEditor.BackColor =
          Color.White;

      // -----------------------------------------------------
      // Editor title
      // -----------------------------------------------------

      lblEditorTitle.Dock =
          DockStyle.Top;

      lblEditorTitle.Height =
          60;

      lblEditorTitle.Text =
          "SELECT OR ADD USER";

      lblEditorTitle.TextAlign =
          ContentAlignment.MiddleCenter;

      lblEditorTitle.Font =
          new Font(
              "Segoe UI",
              18F,
              FontStyle.Bold);

      lblEditorTitle.ForeColor =
          Color.FromArgb(
              30,
              64,
              175);

      // =====================================================
      // EDITOR TABLE
      // =====================================================

      tblEditor.Dock =
          DockStyle.Fill;

      tblEditor.Padding =
          new Padding(
              20,
              10,
              20,
              10);

      tblEditor.ColumnCount =
          2;

      tblEditor.RowCount =
          5;

      tblEditor.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              30F));

      tblEditor.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              70F));

      for (int row = 0; row < 5; row++)
      {
        tblEditor.RowStyles.Add(
            new RowStyle(
                SizeType.Percent,
                20F));
      }

      // =====================================================
      // FIRST NAME
      // =====================================================

      ConfigureEditorLabel(
          lblFirstName,
          "FIRST NAME");

      ConfigureEditorButton(
          btnFirstName,
          "TOUCH TO ENTER FIRST NAME");

      btnFirstName.Click +=
          btnFirstName_Click;

      tblEditor.Controls.Add(
          lblFirstName,
          0,
          0);

      tblEditor.Controls.Add(
          btnFirstName,
          1,
          0);

      // =====================================================
      // LAST NAME
      // =====================================================

      ConfigureEditorLabel(
          lblLastName,
          "LAST NAME");

      ConfigureEditorButton(
          btnLastName,
          "TOUCH TO ENTER LAST NAME");

      btnLastName.Click +=
          btnLastName_Click;

      tblEditor.Controls.Add(
          lblLastName,
          0,
          1);

      tblEditor.Controls.Add(
          btnLastName,
          1,
          1);

      // =====================================================
      // USERNAME
      // =====================================================

      ConfigureEditorLabel(
          lblUserName,
          "USERNAME");

      ConfigureEditorButton(
          btnUserName,
          "TOUCH TO ENTER USERNAME");

      btnUserName.Click +=
          btnUserName_Click;

      tblEditor.Controls.Add(
          lblUserName,
          0,
          2);

      tblEditor.Controls.Add(
          btnUserName,
          1,
          2);

      // =====================================================
      // PIN
      // =====================================================

      ConfigureEditorLabel(
          lblPin,
          "PIN");

      ConfigureEditorButton(
          btnPin,
          "SET PIN");

      btnPin.Click +=
          btnPin_Click;

      tblEditor.Controls.Add(
          lblPin,
          0,
          3);

      tblEditor.Controls.Add(
          btnPin,
          1,
          3);

      // =====================================================
      // ACCESS LEVEL
      // =====================================================

      ConfigureEditorLabel(
          lblAccessLevel,
          "ACCESS LEVEL");

      cboAccessLevel.Dock =
          DockStyle.Fill;

      cboAccessLevel.Margin =
          new Padding(
              8,
              12,
              8,
              12);

      cboAccessLevel.DropDownStyle =
          ComboBoxStyle.DropDownList;

      cboAccessLevel.Font =
          new Font(
              "Segoe UI",
              17F,
              FontStyle.Regular);

      cboAccessLevel.BackColor =
          Color.White;

      cboAccessLevel.ForeColor =
          Color.FromArgb(
              31,
              41,
              55);

      cboAccessLevel.IntegralHeight =
          false;

      cboAccessLevel.DropDownHeight =
          220;

      cboAccessLevel.SelectedIndexChanged +=
          cboAccessLevel_SelectedIndexChanged;

      tblEditor.Controls.Add(
          lblAccessLevel,
          0,
          4);

      tblEditor.Controls.Add(
          cboAccessLevel,
          1,
          4);

      pnlEditor.Controls.Add(
          tblEditor);

      pnlEditor.Controls.Add(
          lblEditorTitle);

      // =====================================================
      // FOOTER
      // =====================================================

      pnlFooter.Dock =
          DockStyle.Fill;

      pnlFooter.Margin =
          new Padding(
              8);

      pnlFooter.BackColor =
          Color.FromArgb(
              229,
              231,
              235);

      tblFooter.Dock =
          DockStyle.Fill;

      tblFooter.Padding =
          new Padding(
              5);

      tblFooter.ColumnCount =
          4;

      tblFooter.RowCount =
          1;

      for (int column = 0;
           column < 4;
           column++)
      {
        tblFooter.ColumnStyles.Add(
            new ColumnStyle(
                SizeType.Percent,
                25F));
      }

      // =====================================================
      // ADD USER
      // =====================================================

      ConfigureFooterButton(
          btnAddUser,
          "ADD USER",
          Color.FromArgb(
              59,
              130,
              246),
          Color.White);

      btnAddUser.Click +=
          btnAddUser_Click;

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
      // SAVE
      // =====================================================

      ConfigureFooterButton(
          btnSave,
          "SAVE",
          Color.FromArgb(
              156,
              163,
              175),
          Color.White);

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
              94),
          Color.White);

      btnDone.Click +=
          btnDone_Click;

      // -----------------------------------------------------
      // Add footer buttons
      // -----------------------------------------------------

      tblFooter.Controls.Add(
          btnAddUser,
          0,
          0);

      tblFooter.Controls.Add(
          btnDelete,
          1,
          0);

      tblFooter.Controls.Add(
          btnSave,
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
          pnlUsers,
          0,
          0);

      tblMain.Controls.Add(
          pnlEditor,
          1,
          0);

      tblMain.Controls.Add(
          pnlFooter,
          0,
          1);

      tblMain.SetColumnSpan(
          pnlFooter,
          2);

      // =====================================================
      // ADD FORM CONTROLS
      // =====================================================

      Controls.Add(
          tblMain);

      Controls.Add(
          pnlHeader);

      ResumeLayout(false);
    }

    // =========================================================
    // EDITOR LABEL
    // =========================================================

    private static void ConfigureEditorLabel(
        Label label,
        string text)
    {
      label.Dock =
          DockStyle.Fill;

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
              14F,
              FontStyle.Bold);

      label.ForeColor =
          Color.FromArgb(
              75,
              85,
              99);
    }

    // =========================================================
    // EDITOR TOUCH BUTTON
    // =========================================================

    private static void ConfigureEditorButton(
        Button button,
        string text)
    {
      button.Dock =
          DockStyle.Fill;

      button.Margin =
          new Padding(
              8,
              10,
              8,
              10);

      button.Text =
          text;

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
    // FOOTER TOUCH BUTTON
    // =========================================================

    private static void ConfigureFooterButton(
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

      button.FlatAppearance.BorderSize =
          0;

      button.Cursor =
          Cursors.Hand;

      button.TabStop =
          false;
    }
  }
}