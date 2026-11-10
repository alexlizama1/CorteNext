namespace CorteNext.Forms
{
  partial class MainForm
  {
    private System.ComponentModel.IContainer? components = null;

    // =========================================================
    // MAIN LAYOUT
    // =========================================================

    private Panel pnlHeader;

    private TableLayoutPanel tblBody;
    private TableLayoutPanel tblNavigation;

    private Panel pnlNavigation;
    private Panel pnlContent;

    // =========================================================
    // CONTENT PANELS
    // =========================================================

    private Panel pnlHome;
    private Panel pnlFondoSelection;
    private Panel pnlCorteSelection;
    private Panel pnlAdminSelection;

    // =========================================================
    // HEADER LABELS
    // =========================================================

    private Label lblApplicationTitle;
    private Label lblPageTitle;
    private Label lblDateTime;

    // =========================================================
    // SELECTION TITLES
    // =========================================================

    private Label lblFondoSelectionTitle;
    private Label lblCorteSelectionTitle;
    private Label lblAdminSelectionTitle;

    // =========================================================
    // NAVIGATION BUTTONS
    // =========================================================

    private Button btnHome;
    private Button btnFondo;
    private Button btnCorte;
    private Button btnExpenses;
    private Button btnTracker;
    private Button btnAdmin;

    /*
     * Legacy Reports control.
     *
     * This remains declared because MainForm.cs still explicitly
     * keeps the old Reports button hidden and disabled.
     *
     * It is not added to tblNavigation.
     */
    private Button btnReports;

    private Button btnLogout;
    private Button btnExit;

    // =========================================================
    // HOME BUTTONS
    // =========================================================

    private Button btnHomeFondo;
    private Button btnHomeCorte;
    private Button btnHomeExpenses;
    private Button btnHomeTracker;
    private Button btnHomeAdmin;

    /*
     * Legacy Home Reports control.
     *
     * It remains declared for compatibility with ApplyAccess(),
     * but it is not added to tblHome.
     */
    private Button btnHomeReports;

    // =========================================================
    // FONDO BUTTONS
    // =========================================================

    private Button btnFondoAM;
    private Button btnFondoDrive;
    private Button btnFondoPM;
    private Button btnFondoBack;

    // =========================================================
    // CORTE BUTTONS
    // =========================================================

    private Button btnCorteAM;
    private Button btnCortePM;
    private Button btnCorteAMDrive;
    private Button btnCortePMDrive;
    private Button btnCorteBack;

    // =========================================================
    // ADMIN BUTTONS
    // =========================================================

    private Button btnAdminUsers;
    private Button btnAdminPrinter;
    private Button btnAdminReports;
    private Button btnAdminBack;

    // =========================================================
    // CONTENT TABLES
    // =========================================================

    private TableLayoutPanel tblHome;
    private TableLayoutPanel tblFondoSelection;
    private TableLayoutPanel tblCorteSelection;
    private TableLayoutPanel tblAdminSelection;

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
      // =====================================================
      // CREATE LAYOUT CONTROLS
      // =====================================================

      pnlHeader = new Panel();

      tblBody = new TableLayoutPanel();
      tblNavigation = new TableLayoutPanel();

      pnlNavigation = new Panel();
      pnlContent = new Panel();

      pnlHome = new Panel();
      pnlFondoSelection = new Panel();
      pnlCorteSelection = new Panel();
      pnlAdminSelection = new Panel();

      // =====================================================
      // CREATE LABELS
      // =====================================================

      lblApplicationTitle = new Label();
      lblPageTitle = new Label();
      lblDateTime = new Label();

      lblFondoSelectionTitle = new Label();
      lblCorteSelectionTitle = new Label();
      lblAdminSelectionTitle = new Label();

      // =====================================================
      // CREATE NAVIGATION BUTTONS
      // =====================================================

      btnHome = new Button();
      btnFondo = new Button();
      btnCorte = new Button();
      btnExpenses = new Button();
      btnReports = new Button();
      btnTracker = new Button();
      btnAdmin = new Button();

      btnLogout = new Button();
      btnExit = new Button();

      // =====================================================
      // CREATE HOME BUTTONS
      // =====================================================

      btnHomeFondo = new Button();
      btnHomeCorte = new Button();
      btnHomeExpenses = new Button();
      btnHomeReports = new Button();
      btnHomeTracker = new Button();
      btnHomeAdmin = new Button();

      // =====================================================
      // CREATE FONDO BUTTONS
      // =====================================================

      btnFondoAM = new Button();
      btnFondoDrive = new Button();
      btnFondoPM = new Button();
      btnFondoBack = new Button();

      // =====================================================
      // CREATE CORTE BUTTONS
      // =====================================================

      btnCorteAM = new Button();
      btnCortePM = new Button();
      btnCorteAMDrive = new Button();
      btnCortePMDrive = new Button();
      btnCorteBack = new Button();

      // =====================================================
      // CREATE ADMIN BUTTONS
      // =====================================================

      btnAdminUsers = new Button();
      btnAdminPrinter = new Button();
      btnAdminReports = new Button();
      btnAdminBack = new Button();

      // =====================================================
      // CREATE CONTENT TABLES
      // =====================================================

      tblHome = new TableLayoutPanel();
      tblFondoSelection = new TableLayoutPanel();
      tblCorteSelection = new TableLayoutPanel();
      tblAdminSelection = new TableLayoutPanel();

      SuspendLayout();

      // =====================================================
      // MAIN FORM
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
              1280,
              800);

      MinimumSize =
          new Size(
              1024,
              700);

      StartPosition =
          FormStartPosition.CenterScreen;

      WindowState =
          FormWindowState.Maximized;

      ControlBox =
        false;

      Text =
          "CorteNext";

      Load +=
          MainForm_Load;



      // =====================================================
      // HEADER
      // =====================================================

      pnlHeader.Dock =
          DockStyle.Top;

      pnlHeader.Height =
          95;

      pnlHeader.Margin =
          new Padding(0);

      pnlHeader.BackColor =
          Color.FromArgb(
              31,
              41,
              55);

      // -----------------------------------------------------
      // Application title
      // -----------------------------------------------------

      lblApplicationTitle.AutoSize =
          true;

      lblApplicationTitle.Text =
          "CORTE NEXT";

      lblApplicationTitle.ForeColor =
          Color.White;

      lblApplicationTitle.Font =
          new System.Drawing.Font(
              "Segoe UI",
              22F,
              System.Drawing.FontStyle.Bold);

      lblApplicationTitle.Location =
          new Point(
              25,
              10);

      //// -----------------------------------------------------
      //// Page title
      //// -----------------------------------------------------

      //lblPageTitle.AutoSize =
      //    true;

      //lblPageTitle.Text =
      //    "Login Required";

      //lblPageTitle.ForeColor =
      //    Color.FromArgb(
      //        147,
      //        197,
      //        253);

      //lblPageTitle.Font =
      //    new System.Drawing.Font(
      //        "Segoe UI",
      //        13F,
      //        System.Drawing.FontStyle.Regular);

      //lblPageTitle.Location =
      //    new Point(
      //        28,
      //        57);

      // -----------------------------------------------------
      // Date
      // -----------------------------------------------------

      lblDateTime.Dock =
          DockStyle.Right;

      lblDateTime.Width =
          450;

      lblDateTime.Text =
          string.Empty;

      lblDateTime.TextAlign =
          ContentAlignment.MiddleRight;

      lblDateTime.Padding =
          new Padding(
              0,
              0,
              25,
              0);

      lblDateTime.ForeColor =
          Color.WhiteSmoke;

      lblDateTime.Font =
          new System.Drawing.Font(
              "Segoe UI",
              14F,
              System.Drawing.FontStyle.Regular);

      pnlHeader.Controls.Add(
          lblDateTime);

      pnlHeader.Controls.Add(
          lblPageTitle);

      pnlHeader.Controls.Add(
          lblApplicationTitle);

      // =====================================================
      // BODY LAYOUT
      //
      // Navigation: 18%
      // Content:    82%
      // =====================================================

      tblBody.Dock =
          DockStyle.Fill;

      tblBody.Margin =
          new Padding(0);

      tblBody.Padding =
          new Padding(0);

      tblBody.AutoSize =
          false;

      tblBody.GrowStyle =
          TableLayoutPanelGrowStyle.FixedSize;

      tblBody.ColumnCount =
          2;

      tblBody.RowCount =
          1;

      tblBody.ColumnStyles.Clear();

      tblBody.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              18F));

      tblBody.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              82F));

      tblBody.RowStyles.Clear();

      tblBody.RowStyles.Add(
          new RowStyle(
              SizeType.Percent,
              100F));

      // =====================================================
      // NAVIGATION PANEL
      // =====================================================

      pnlNavigation.Dock =
          DockStyle.Fill;

      pnlNavigation.Margin =
          new Padding(0);

      pnlNavigation.Padding =
          new Padding(8);

      pnlNavigation.BackColor =
          Color.FromArgb(
              229,
              231,
              235);

      // =====================================================
      // NAVIGATION TABLE
      //
      // HOME
      // FONDO
      // CORTE
      // EXPENSES
      // TRACKER
      // ADMIN
      // LOGIN/LOGOUT
      // EXIT
      //
      // Reports no longer appears in normal navigation.
      // =====================================================

      tblNavigation.Dock =
          DockStyle.Fill;

      tblNavigation.Margin =
          new Padding(0);

      tblNavigation.Padding =
          new Padding(0);

      tblNavigation.AutoSize =
          false;

      tblNavigation.GrowStyle =
          TableLayoutPanelGrowStyle.FixedSize;

      tblNavigation.ColumnCount =
          1;

      tblNavigation.RowCount =
          8;

      tblNavigation.ColumnStyles.Clear();

      tblNavigation.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              100F));

      tblNavigation.RowStyles.Clear();

      /*
       * Six normal-navigation rows use 78%.
       * Each receives 13%.
       */

      for (int row = 0; row < 6; row++)
      {
        tblNavigation.RowStyles.Add(
            new RowStyle(
                SizeType.Percent,
                13F));
      }

      tblNavigation.RowStyles.Add(
          new RowStyle(
              SizeType.Percent,
              12F));

      tblNavigation.RowStyles.Add(
          new RowStyle(
              SizeType.Percent,
              10F));

      // =====================================================
      // HOME NAVIGATION
      // =====================================================

      ConfigureNavigationButton(
          btnHome,
          "HOME");

      btnHome.Visible =
          false;

      btnHome.Click +=
          btnHome_Click;

      // =====================================================
      // FONDO NAVIGATION
      // =====================================================

      ConfigureNavigationButton(
          btnFondo,
          "FONDO");

      btnFondo.Visible =
          false;

      btnFondo.Click +=
          btnFondo_Click;

      // =====================================================
      // CORTE NAVIGATION
      // =====================================================

      ConfigureNavigationButton(
          btnCorte,
          "CORTE");

      btnCorte.Visible =
          false;

      btnCorte.Click +=
          btnCorte_Click;

      // =====================================================
      // EXPENSES NAVIGATION
      // =====================================================

      ConfigureNavigationButton(
          btnExpenses,
          "EXPENSES");

      btnExpenses.Visible =
          false;

      btnExpenses.Click +=
          btnExpenses_Click;

      // =====================================================
      // TRACKER NAVIGATION
      // =====================================================

      ConfigureNavigationButton(
          btnTracker,
          "TRACKER");

      btnTracker.Visible =
          false;

      btnTracker.Click +=
          btnTracker_Click;

      // =====================================================
      // ADMIN NAVIGATION
      // =====================================================

      ConfigureNavigationButton(
          btnAdmin,
          "ADMIN");

      btnAdmin.Visible =
          false;

      btnAdmin.Click +=
          btnAdmin_Click;

      // =====================================================
      // LEGACY REPORTS BUTTON
      //
      // Not added to navigation.
      // =====================================================

      ConfigureNavigationButton(
          btnReports,
          "REPORTS");

      btnReports.Visible =
          false;

      btnReports.Enabled =
          false;

      btnReports.Click +=
          btnReports_Click;

      // =====================================================
      // LOGIN / LOGOUT
      // =====================================================

      ConfigureSystemButton(
          btnLogout,
          "LOGIN",
          Color.FromArgb(
              59,
              130,
              246));

      btnLogout.Visible =
          true;

      btnLogout.Click +=
          btnLogout_Click;

      // =====================================================
      // EXIT
      // =====================================================

      ConfigureSystemButton(
          btnExit,
          "EXIT",
          Color.FromArgb(
              239,
              68,
              68));

      btnExit.Visible =
          true;

      btnExit.Click +=
          btnExit_Click;

      // -----------------------------------------------------
      // Add navigation buttons
      // -----------------------------------------------------

      tblNavigation.Controls.Add(
          btnHome,
          0,
          0);

      tblNavigation.Controls.Add(
          btnFondo,
          0,
          1);

      tblNavigation.Controls.Add(
          btnCorte,
          0,
          2);

      tblNavigation.Controls.Add(
          btnExpenses,
          0,
          3);

      tblNavigation.Controls.Add(
          btnTracker,
          0,
          4);

      tblNavigation.Controls.Add(
          btnAdmin,
          0,
          5);

      tblNavigation.Controls.Add(
          btnLogout,
          0,
          6);

      tblNavigation.Controls.Add(
          btnExit,
          0,
          7);

      pnlNavigation.Controls.Add(
          tblNavigation);

      // =====================================================
      // CONTENT PANEL
      // =====================================================

      pnlContent.Dock =
          DockStyle.Fill;

      pnlContent.Margin =
          new Padding(0);

      pnlContent.Padding =
          new Padding(12);

      pnlContent.BackColor =
          Color.FromArgb(
              245,
              247,
              250);

      // =====================================================
      // HOME PANEL
      // =====================================================

      pnlHome.Dock =
          DockStyle.Fill;

      pnlHome.Margin =
          new Padding(0);

      pnlHome.Padding =
          new Padding(0);

      pnlHome.Visible =
          false;

      pnlHome.BackColor =
          Color.FromArgb(
              245,
              247,
              250);

      // =====================================================
      // HOME TABLE
      //
      // Five visible choices:
      //
      // FONDO       CORTE
      // EXPENSES    TRACKER
      // ADMIN       empty
      //
      // The Admin tile is shown only to administrators.
      // =====================================================

      tblHome.Dock =
          DockStyle.Fill;

      tblHome.Margin =
          new Padding(0);

      tblHome.Padding =
          new Padding(8);

      tblHome.AutoSize =
          false;

      tblHome.GrowStyle =
          TableLayoutPanelGrowStyle.FixedSize;

      tblHome.ColumnCount =
          2;

      tblHome.RowCount =
          3;

      tblHome.ColumnStyles.Clear();

      tblHome.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              50F));

      tblHome.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              50F));

      tblHome.RowStyles.Clear();

      tblHome.RowStyles.Add(
          new RowStyle(
              SizeType.Percent,
              33.3333F));

      tblHome.RowStyles.Add(
          new RowStyle(
              SizeType.Percent,
              33.3333F));

      tblHome.RowStyles.Add(
          new RowStyle(
              SizeType.Percent,
              33.3334F));

      // =====================================================
      // HOME FONDO
      // =====================================================

      ConfigureHomeButton(
          btnHomeFondo,
          "FONDO",
          Color.FromArgb(
              219,
              234,
              254));

      btnHomeFondo.Visible =
          false;

      btnHomeFondo.Click +=
          btnFondo_Click;

      // =====================================================
      // HOME CORTE
      // =====================================================

      ConfigureHomeButton(
          btnHomeCorte,
          "CORTE",
          Color.FromArgb(
              220,
              252,
              231));

      btnHomeCorte.Visible =
          false;

      btnHomeCorte.Click +=
          btnCorte_Click;

      // =====================================================
      // HOME EXPENSES
      // =====================================================

      ConfigureHomeButton(
          btnHomeExpenses,
          "EXPENSES",
          Color.FromArgb(
              254,
              249,
              195));

      btnHomeExpenses.Visible =
          false;

      btnHomeExpenses.Click +=
          btnExpenses_Click;

      // =====================================================
      // HOME TRACKER
      // =====================================================

      ConfigureHomeButton(
          btnHomeTracker,
          "TRACKER",
          Color.FromArgb(
              207,
              250,
              254));

      btnHomeTracker.Visible =
          false;

      btnHomeTracker.Click +=
          btnTracker_Click;

      // =====================================================
      // HOME ADMIN
      // =====================================================

      ConfigureHomeButton(
          btnHomeAdmin,
          "ADMIN",
          Color.FromArgb(
              254,
              226,
              226));

      btnHomeAdmin.Visible =
          false;

      btnHomeAdmin.Click +=
          btnAdmin_Click;

      // =====================================================
      // LEGACY HOME REPORTS BUTTON
      //
      // Not added to tblHome.
      // =====================================================

      ConfigureHomeButton(
          btnHomeReports,
          "REPORTS",
          Color.FromArgb(
              243,
              232,
              255));

      btnHomeReports.Visible =
          false;

      btnHomeReports.Enabled =
          false;

      btnHomeReports.Click +=
          btnReports_Click;

      // -----------------------------------------------------
      // Add visible Home tiles
      // -----------------------------------------------------

      tblHome.Controls.Add(
          btnHomeFondo,
          0,
          0);

      tblHome.Controls.Add(
          btnHomeCorte,
          1,
          0);

      tblHome.Controls.Add(
          btnHomeExpenses,
          0,
          1);

      tblHome.Controls.Add(
          btnHomeTracker,
          1,
          1);

      tblHome.Controls.Add(
          btnHomeAdmin,
          0,
          2);

      /*
       * Row 2, column 1 remains empty.
       *
       * This preserves the proportional 2 × 3 layout.
       */

      pnlHome.Controls.Add(
          tblHome);

      // =====================================================
      // FONDO SELECTION PANEL
      // =====================================================

      ConfigureSelectionPanel(
          pnlFondoSelection,
          lblFondoSelectionTitle,
          "SELECT FONDO SHIFT");

      tblFondoSelection.Dock =
          DockStyle.Fill;

      tblFondoSelection.Margin =
          new Padding(0);

      tblFondoSelection.Padding =
          new Padding(18);

      tblFondoSelection.AutoSize =
          false;

      tblFondoSelection.GrowStyle =
          TableLayoutPanelGrowStyle.FixedSize;

      tblFondoSelection.ColumnCount =
          3;

      tblFondoSelection.RowCount =
          2;

      tblFondoSelection.ColumnStyles.Clear();

      tblFondoSelection.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              33.3333F));

      tblFondoSelection.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              33.3333F));

      tblFondoSelection.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              33.3334F));

      tblFondoSelection.RowStyles.Clear();

      tblFondoSelection.RowStyles.Add(
          new RowStyle(
              SizeType.Percent,
              78F));

      tblFondoSelection.RowStyles.Add(
          new RowStyle(
              SizeType.Percent,
              22F));

      ConfigureSelectionButton(
          btnFondoAM,
          "AM FONDO",
          Color.FromArgb(
              219,
              234,
              254));

      ConfigureSelectionButton(
          btnFondoDrive,
          "DRIVE FONDO",
          Color.FromArgb(
              254,
              249,
              195));

      ConfigureSelectionButton(
          btnFondoPM,
          "PM FONDO",
          Color.FromArgb(
              220,
              252,
              231));

      ConfigureBackButton(
          btnFondoBack);

      btnFondoAM.Click +=
          btnFondoAM_Click;

      btnFondoDrive.Click +=
          btnFondoDrive_Click;

      btnFondoPM.Click +=
          btnFondoPM_Click;

      btnFondoBack.Click +=
          btnFondoBack_Click;

      tblFondoSelection.Controls.Add(
          btnFondoAM,
          0,
          0);

      tblFondoSelection.Controls.Add(
          btnFondoDrive,
          1,
          0);

      tblFondoSelection.Controls.Add(
          btnFondoPM,
          2,
          0);

      tblFondoSelection.Controls.Add(
          btnFondoBack,
          0,
          1);

      tblFondoSelection.SetColumnSpan(
          btnFondoBack,
          3);

      pnlFondoSelection.Controls.Add(
          tblFondoSelection);

      pnlFondoSelection.Controls.Add(
          lblFondoSelectionTitle);

      // =====================================================
      // CORTE SELECTION PANEL
      // =====================================================

      ConfigureSelectionPanel(
          pnlCorteSelection,
          lblCorteSelectionTitle,
          "SELECT CORTE SHIFT");

      tblCorteSelection.Dock =
          DockStyle.Fill;

      tblCorteSelection.Margin =
          new Padding(0);

      tblCorteSelection.Padding =
          new Padding(18);

      tblCorteSelection.AutoSize =
          false;

      tblCorteSelection.GrowStyle =
          TableLayoutPanelGrowStyle.FixedSize;

      tblCorteSelection.ColumnCount =
          2;

      tblCorteSelection.RowCount =
          3;

      tblCorteSelection.ColumnStyles.Clear();

      tblCorteSelection.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              50F));

      tblCorteSelection.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              50F));

      tblCorteSelection.RowStyles.Clear();

      tblCorteSelection.RowStyles.Add(
          new RowStyle(
              SizeType.Percent,
              40F));

      tblCorteSelection.RowStyles.Add(
          new RowStyle(
              SizeType.Percent,
              40F));

      tblCorteSelection.RowStyles.Add(
          new RowStyle(
              SizeType.Percent,
              20F));

      ConfigureSelectionButton(
          btnCorteAM,
          "AM CORTE",
          Color.FromArgb(
              219,
              234,
              254));

      ConfigureSelectionButton(
          btnCortePM,
          "PM CORTE",
          Color.FromArgb(
              220,
              252,
              231));

      ConfigureSelectionButton(
          btnCorteAMDrive,
          "AM DRIVE CORTE",
          Color.FromArgb(
              254,
              249,
              195));

      ConfigureSelectionButton(
          btnCortePMDrive,
          "PM DRIVE CORTE",
          Color.FromArgb(
              254,
              226,
              226));

      ConfigureBackButton(
          btnCorteBack);

      btnCorteAM.Click +=
          btnCorteAM_Click;

      btnCortePM.Click +=
          btnCortePM_Click;

      btnCorteAMDrive.Click +=
          btnCorteAMDrive_Click;

      btnCortePMDrive.Click +=
          btnCortePMDrive_Click;

      btnCorteBack.Click +=
          btnCorteBack_Click;

      tblCorteSelection.Controls.Add(
          btnCorteAM,
          0,
          0);

      tblCorteSelection.Controls.Add(
          btnCortePM,
          1,
          0);

      tblCorteSelection.Controls.Add(
          btnCorteAMDrive,
          0,
          1);

      tblCorteSelection.Controls.Add(
          btnCortePMDrive,
          1,
          1);

      tblCorteSelection.Controls.Add(
          btnCorteBack,
          0,
          2);

      tblCorteSelection.SetColumnSpan(
          btnCorteBack,
          2);

      pnlCorteSelection.Controls.Add(
          tblCorteSelection);

      pnlCorteSelection.Controls.Add(
          lblCorteSelectionTitle);

      // =====================================================
      // ADMIN SELECTION PANEL
      // =====================================================

      ConfigureSelectionPanel(
          pnlAdminSelection,
          lblAdminSelectionTitle,
          "ADMINISTRATION");

      // -----------------------------------------------------
      // Admin table
      //
      // USER MANAGEMENT | PRINTER SETTINGS
      // REPORTS                         |
      // BACK TO HOME                    |
      // -----------------------------------------------------

      tblAdminSelection.Dock =
          DockStyle.Fill;

      tblAdminSelection.Margin =
          new Padding(0);

      tblAdminSelection.Padding =
          new Padding(18);

      tblAdminSelection.AutoSize =
          false;

      tblAdminSelection.GrowStyle =
          TableLayoutPanelGrowStyle.FixedSize;

      tblAdminSelection.ColumnCount =
          2;

      tblAdminSelection.RowCount =
          3;

      tblAdminSelection.ColumnStyles.Clear();

      tblAdminSelection.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              50F));

      tblAdminSelection.ColumnStyles.Add(
          new ColumnStyle(
              SizeType.Percent,
              50F));

      tblAdminSelection.RowStyles.Clear();

      tblAdminSelection.RowStyles.Add(
          new RowStyle(
              SizeType.Percent,
              40F));

      tblAdminSelection.RowStyles.Add(
          new RowStyle(
              SizeType.Percent,
              40F));

      tblAdminSelection.RowStyles.Add(
          new RowStyle(
              SizeType.Percent,
              20F));

      // =====================================================
      // USER MANAGEMENT
      // =====================================================

      ConfigureSelectionButton(
          btnAdminUsers,
          "USER MANAGEMENT",
          Color.FromArgb(
              219,
              234,
              254));

      btnAdminUsers.Click +=
          btnAdminUsers_Click;

      // =====================================================
      // PRINTER SETTINGS
      // =====================================================

      ConfigureSelectionButton(
          btnAdminPrinter,
          "PRINTER SETTINGS",
          Color.FromArgb(
              220,
              252,
              231));

      btnAdminPrinter.Click +=
          btnAdminPrinter_Click;

      // =====================================================
      // ADMIN REPORTS
      // =====================================================

      ConfigureSelectionButton(
          btnAdminReports,
          "REPORTS",
          Color.FromArgb(
              243,
              232,
              255));

      btnAdminReports.Click +=
          btnAdminReports_Click;

      // =====================================================
      // ADMIN BACK
      // =====================================================

      ConfigureBackButton(
          btnAdminBack);

      btnAdminBack.Click +=
          btnAdminBack_Click;

      // -----------------------------------------------------
      // Add Admin controls
      // -----------------------------------------------------

      tblAdminSelection.Controls.Add(
          btnAdminUsers,
          0,
          0);

      tblAdminSelection.Controls.Add(
          btnAdminPrinter,
          1,
          0);

      tblAdminSelection.Controls.Add(
          btnAdminReports,
          0,
          1);

      tblAdminSelection.SetColumnSpan(
          btnAdminReports,
          2);

      tblAdminSelection.Controls.Add(
          btnAdminBack,
          0,
          2);

      tblAdminSelection.SetColumnSpan(
          btnAdminBack,
          2);

      pnlAdminSelection.Controls.Add(
          tblAdminSelection);

      pnlAdminSelection.Controls.Add(
          lblAdminSelectionTitle);

      // =====================================================
      // ADD CONTENT PANELS
      // =====================================================

      pnlContent.Controls.Add(
          pnlHome);

      pnlContent.Controls.Add(
          pnlFondoSelection);

      pnlContent.Controls.Add(
          pnlCorteSelection);

      pnlContent.Controls.Add(
          pnlAdminSelection);

      // =====================================================
      // BUILD BODY
      // =====================================================

      tblBody.Controls.Add(
          pnlNavigation,
          0,
          0);

      tblBody.Controls.Add(
          pnlContent,
          1,
          0);

      // =====================================================
      // BUILD FORM
      // =====================================================

      Controls.Add(
          tblBody);

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
      button.Dock =
          DockStyle.Fill;

      button.Margin =
          new Padding(4);

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
          new System.Drawing.Font(
              "Segoe UI",
              14F,
              System.Drawing.FontStyle.Bold);

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
              209,
              213,
              219);

      button.FlatAppearance.BorderSize =
          1;

      button.Cursor =
          Cursors.Hand;

      button.TabStop =
          false;
    }

    // =========================================================
    // SYSTEM BUTTON
    // =========================================================

    private static void ConfigureSystemButton(
        Button button,
        string text,
        Color backgroundColor)
    {
      button.Dock =
          DockStyle.Fill;

      button.Margin =
          new Padding(4);

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
          new System.Drawing.Font(
              "Segoe UI",
              15F,
              System.Drawing.FontStyle.Bold);

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

    // =========================================================
    // HOME BUTTON
    // =========================================================

    private static void ConfigureHomeButton(
        Button button,
        string text,
        Color backgroundColor)
    {
      button.Dock =
          DockStyle.Fill;

      button.Margin =
          new Padding(8);

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
          new System.Drawing.Font(
              "Segoe UI",
              19F,
              System.Drawing.FontStyle.Bold);

      button.BackColor =
          backgroundColor;

      button.ForeColor =
          Color.FromArgb(
              31,
              41,
              55);

      button.FlatStyle =
          FlatStyle.Flat;

      button.FlatAppearance.BorderColor =
          Color.FromArgb(
              209,
              213,
              219);

      button.FlatAppearance.BorderSize =
          2;

      button.Cursor =
          Cursors.Hand;

      button.TabStop =
          false;
    }

    // =========================================================
    // SELECTION PANEL
    // =========================================================

    private static void ConfigureSelectionPanel(
        Panel panel,
        Label title,
        string titleText)
    {
      panel.Dock =
          DockStyle.Fill;

      panel.Margin =
          new Padding(0);

      panel.Padding =
          new Padding(0);

      panel.AutoSize =
          false;

      panel.Visible =
          false;

      panel.BackColor =
          Color.FromArgb(
              245,
              247,
              250);

      title.Dock =
          DockStyle.Top;

      title.Height =
          85;

      title.Margin =
          new Padding(0);

      title.Text =
          titleText;

      title.TextAlign =
          ContentAlignment.MiddleCenter;

      title.Font =
          new System.Drawing.Font(
              "Segoe UI",
              22F,
              System.Drawing.FontStyle.Bold);

      title.ForeColor =
          Color.FromArgb(
              31,
              41,
              55);
    }

    // =========================================================
    // SELECTION BUTTON
    // =========================================================

    private static void ConfigureSelectionButton(
        Button button,
        string text,
        Color backgroundColor)
    {
      button.Dock =
          DockStyle.Fill;

      button.Margin =
          new Padding(10);

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
          new System.Drawing.Font(
              "Segoe UI",
              18F,
              System.Drawing.FontStyle.Bold);

      button.BackColor =
          backgroundColor;

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
    // BACK BUTTON
    // =========================================================

    private static void ConfigureBackButton(
        Button button)
    {
      button.Dock =
          DockStyle.Fill;

      button.Margin =
          new Padding(10);

      button.AutoSize =
          false;

      button.MinimumSize =
          Size.Empty;

      button.MaximumSize =
          Size.Empty;

      button.Text =
          "BACK TO HOME";

      button.TextAlign =
          ContentAlignment.MiddleCenter;

      button.Font =
          new System.Drawing.Font(
              "Segoe UI",
              15F,
              System.Drawing.FontStyle.Bold);

      button.BackColor =
          Color.FromArgb(
              107,
              114,
              128);

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