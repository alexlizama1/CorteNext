using CorteNext.Models;
using CorteNext.Printing;
using CorteNext.Services;

namespace CorteNext.Forms
{
  public partial class MainForm : Form
  {
    // =========================================================
    // SERVICES
    // =========================================================

    private readonly IFondoService _fondoService;
    private readonly ICorteService _corteService;
    private readonly IExpenseService _expenseService;
    private readonly IAuthenticationService _authenticationService;
    private readonly IUserService _userService;
    private readonly IPrinterSettingsService _printerSettingsService;
    private readonly IReceiptPrintService _receiptPrintService;
    private readonly ITrackerService _trackerService;
    private readonly UserSession _userSession;
    private readonly IUpdateService _updateService;
    private bool _updateCheckCompleted;

    protected override async void OnShown(
    EventArgs e)
    {
      base.OnShown(e);

      if (_updateCheckCompleted)
      {
        return;
      }

      _updateCheckCompleted =
          true;

      await CheckForUpdatesAsync();
    }
    // =========================================================
    // CHILD FORM
    // =========================================================

    private Form? _currentChildForm;


    // =========================================================
    // CONSTRUCTOR
    // =========================================================

    public MainForm(
        IFondoService fondoService,
        ICorteService corteService,
        IExpenseService expenseService,
        IAuthenticationService authenticationService,
        IUserService userService,
        IPrinterSettingsService printerSettingsService,
        IReceiptPrintService receiptPrintService,
        ITrackerService trackerService,
        IUpdateService updateService,
        UserSession userSession)
    {
      InitializeComponent();

      _fondoService =
          fondoService;

      _corteService =
          corteService;

      _expenseService =
          expenseService;

      _authenticationService =
          authenticationService;

      _userService =
          userService;

      _printerSettingsService =
          printerSettingsService;

      _receiptPrintService =
          receiptPrintService;

      _trackerService =
          trackerService;

      _updateService =
          updateService;

      _userSession =
          userSession;
    }

    // =========================================================
    // FORM LOAD
    // =========================================================

    private void MainForm_Load(
        object sender,
        EventArgs e)
    {
      lblDateTime.Text =
          DateTime.Now.ToString(
              "dddd, MMMM d, yyyy");

      ApplyAccess();
      ShowHome();
    }

    // =========================================================
    // LOGIN
    // =========================================================

    private void ShowLogin()
    {
      using LoginForm loginForm =
          new(
              _authenticationService,
              _userSession);

      DialogResult result =
          loginForm.ShowDialog(this);

      if (result != DialogResult.OK)
      {
        return;
      }

      ApplyAccess();
      ShowHome();
    }

    private bool RequireLogin()
    {
      if (_userSession.IsLoggedIn)
      {
        return true;
      }

      ShowLogin();

      return _userSession.IsLoggedIn;
    }

    // =========================================================
    // ACCESS CONTROL
    // =========================================================

    private void ApplyAccess()
    {
      bool loggedIn =
          _userSession.IsLoggedIn;

      bool admin =
          loggedIn &&
          _userSession.IsAdmin;

      // =====================================================
      // NORMAL NAVIGATION
      // =====================================================

      btnHome.Visible = loggedIn;
      btnFondo.Visible = loggedIn;
      btnCorte.Visible = loggedIn;
      btnExpenses.Visible = loggedIn;
      btnTracker.Visible = loggedIn;

      btnHome.Enabled = loggedIn;
      btnFondo.Enabled = loggedIn;
      btnCorte.Enabled = loggedIn;
      btnExpenses.Enabled = loggedIn;
      btnTracker.Enabled = loggedIn;

      // =====================================================
      // REPORTS
      //
      // Reports are no longer shown in regular navigation.
      // Reports are available only from Administration.
      // =====================================================

      btnReports.Visible = false;
      btnReports.Enabled = false;

      btnHomeReports.Visible = false;
      btnHomeReports.Enabled = false;

      // =====================================================
      // ADMIN
      // =====================================================

      btnAdmin.Visible = admin;
      btnAdmin.Enabled = admin;

      // =====================================================
      // HOME TOUCH BUTTONS
      // =====================================================

      btnHomeFondo.Visible = loggedIn;
      btnHomeCorte.Visible = loggedIn;
      btnHomeExpenses.Visible = loggedIn;
      btnHomeTracker.Visible = loggedIn;

      btnHomeFondo.Enabled = loggedIn;
      btnHomeCorte.Enabled = loggedIn;
      btnHomeExpenses.Enabled = loggedIn;
      btnHomeTracker.Enabled = loggedIn;

      btnHomeAdmin.Visible = admin;
      btnHomeAdmin.Enabled = admin;

      // =====================================================
      // LOGIN / LOGOUT
      // =====================================================

      btnLogout.Visible = true;
      btnLogout.Enabled = true;

      if (loggedIn)
      {
        btnLogout.Text =
            $"LOGOUT\r\n" +
            $"{_userSession.CurrentUser?.DisplayName}";

        btnLogout.BackColor =
            Color.FromArgb(
                251,
                191,
                36);

        btnLogout.ForeColor =
            Color.FromArgb(
                31,
                41,
                55);
      }
      else
      {
        btnLogout.Text =
            "LOGIN";

        btnLogout.BackColor =
            Color.FromArgb(
                59,
                130,
                246);

        btnLogout.ForeColor =
            Color.White;
      }

      btnExit.Visible = true;
      btnExit.Enabled = true;
    }

    // =========================================================
    // HOME
    // =========================================================

    private void ShowHome()
    {
      CloseCurrentChild();
      HideSelectionPanels();

      bool loggedIn =
          _userSession.IsLoggedIn;

      pnlHome.Visible = loggedIn;
      pnlHome.Enabled = loggedIn;

      if (loggedIn)
      {
        pnlHome.BringToFront();

        lblPageTitle.Text =
            "Home";
      }
      else
      {
        lblPageTitle.Text =
            "Login Required";
      }
    }

    private void btnHome_Click(
        object sender,
        EventArgs e)
    {
      if (!_userSession.IsLoggedIn)
      {
        return;
      }

      ShowHome();
    }

    // =========================================================
    // SELECTION PANELS
    // =========================================================

    private void HideSelectionPanels()
    {
      pnlFondoSelection.Visible = false;
      pnlCorteSelection.Visible = false;
      pnlAdminSelection.Visible = false;
    }

    // =========================================================
    // FONDO NAVIGATION
    // =========================================================

    private void btnFondo_Click(
        object sender,
        EventArgs e)
    {
      if (!RequireLogin())
      {
        return;
      }

      ShowFondoSelection();
    }

    private void ShowFondoSelection()
    {
      CloseCurrentChild();

      pnlHome.Visible = false;

      HideSelectionPanels();
      RefreshFondoShiftButtons();

      pnlFondoSelection.Enabled = true;
      pnlFondoSelection.Visible = true;
      pnlFondoSelection.BringToFront();

      lblPageTitle.Text =
          "Fondo";
    }

    private void btnFondoAM_Click(
        object sender,
        EventArgs e)
    {
      OpenFondo(
          ShiftType.FondoAM);
    }

    private void btnFondoDrive_Click(
        object sender,
        EventArgs e)
    {
      OpenFondo(
          ShiftType.FondoDrive);
    }

    private void btnFondoPM_Click(
        object sender,
        EventArgs e)
    {
      OpenFondo(
          ShiftType.FondoPM);
    }

    private void btnFondoBack_Click(
        object sender,
        EventArgs e)
    {
      ShowHome();
    }

    private void OpenFondo(
        ShiftType shift)
    {
      try
      {
        FondoForm fondoForm =
            new(
                _fondoService,
                shift);

        fondoForm.FondoCompleted +=
            FondoForm_FondoCompleted;

        OpenChildForm(
            fondoForm,
            GetFondoTitle(shift));
      }
      catch (Exception ex)
      {
        MessageBox.Show(
            ex.ToString(),
            "Unable to Open Fondo",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
      }
    }

    private void FondoForm_FondoCompleted(
        object? sender,
        EventArgs e)
    {
      ShowFondoSelection();
    }

    private static string GetFondoTitle(
        ShiftType shift)
    {
      return shift switch
      {
        ShiftType.FondoAM =>
            "AM Fondo",

        ShiftType.FondoDrive =>
            "Drive Fondo",

        ShiftType.FondoPM =>
            "PM Fondo",

        _ =>
            "Fondo"
      };
    }

    // =========================================================
    // FONDO BUTTON STATUS
    // =========================================================

    private void RefreshFondoShiftButtons()
    {
      try
      {
        DateTime today =
            DateTime.Today;

        bool amCompleted =
            _fondoService.FondoExists(
                today,
                "am");

        bool driveCompleted =
            _fondoService.FondoExists(
                today,
                "drive");

        bool pmCompleted =
            _fondoService.FondoExists(
                today,
                "pm");

        SetFondoShiftButtonState(
            btnFondoAM,
            amCompleted,
            "AM FONDO",
            Color.FromArgb(
                219,
                234,
                254));

        SetFondoShiftButtonState(
            btnFondoDrive,
            driveCompleted,
            "DRIVE FONDO",
            Color.FromArgb(
                254,
                249,
                195));

        SetFondoShiftButtonState(
            btnFondoPM,
            pmCompleted,
            "PM FONDO",
            Color.FromArgb(
                220,
                252,
                231));
      }
      catch (Exception ex)
      {
        MessageBox.Show(
            ex.Message,
            "Unable to Check Fondo Status",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
      }
    }

    private static void SetFondoShiftButtonState(
        Button button,
        bool completed,
        string normalText,
        Color availableColor)
    {
      if (completed)
      {
        button.Enabled = false;

        button.Text =
            $"{normalText}\r\nCOMPLETED";

        SetDisabledShiftAppearance(
            button);

        return;
      }

      button.Enabled = true;
      button.Text = normalText;
      button.BackColor = availableColor;

      button.ForeColor =
          Color.FromArgb(
              31,
              41,
              55);

      button.FlatAppearance.BorderColor =
          Color.FromArgb(
              156,
              163,
              175);

      button.FlatAppearance.BorderSize = 2;
      button.Cursor = Cursors.Hand;
    }

    // =========================================================
    // CORTE NAVIGATION
    // =========================================================

    private void btnCorte_Click(
        object sender,
        EventArgs e)
    {
      if (!RequireLogin())
      {
        return;
      }

      ShowCorteSelection();
    }

    private void ShowCorteSelection()
    {
      CloseCurrentChild();

      pnlHome.Visible = false;

      HideSelectionPanels();

      pnlCorteSelection.Enabled = true;
      tblCorteSelection.Enabled = true;

      RefreshCorteShiftButtons();

      pnlCorteSelection.Visible = true;
      pnlCorteSelection.BringToFront();

      lblPageTitle.Text =
          "Corte";
    }

    private void btnCorteAM_Click(
        object sender,
        EventArgs e)
    {
      OpenCorte(
          ShiftType.CorteAM);
    }

    private void btnCortePM_Click(
        object sender,
        EventArgs e)
    {
      OpenCorte(
          ShiftType.CortePM);
    }

    private void btnCorteAMDrive_Click(
        object sender,
        EventArgs e)
    {
      OpenCorte(
          ShiftType.CorteAMDrive);
    }

    private void btnCortePMDrive_Click(
        object sender,
        EventArgs e)
    {
      OpenCorte(
          ShiftType.CortePMDrive);
    }

    private void btnCorteBack_Click(
        object sender,
        EventArgs e)
    {
      ShowHome();
    }

    private void OpenCorte(
        ShiftType shift)
    {
      try
      {
        CorteForm corteForm =
            new(
                _corteService,
                _fondoService,
                _expenseService,
                shift);

        corteForm.CorteCompleted +=
            CorteForm_CorteCompleted;

        OpenChildForm(
            corteForm,
            GetCorteTitle(shift));
      }
      catch (Exception ex)
      {
        MessageBox.Show(
            ex.ToString(),
            "Unable to Open Corte",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
      }
    }

    private void CorteForm_CorteCompleted(
        object? sender,
        EventArgs e)
    {
      ShowCorteSelection();
    }

    private static string GetCorteTitle(
        ShiftType shift)
    {
      return shift switch
      {
        ShiftType.CorteAM =>
            "AM Corte",

        ShiftType.CortePM =>
            "PM Corte",

        ShiftType.CorteAMDrive =>
            "AM Drive Corte",

        ShiftType.CortePMDrive =>
            "PM Drive Corte",

        _ =>
            "Corte"
      };
    }

    // =========================================================
    // CORTE BUTTON STATUS
    // =========================================================

    private void RefreshCorteShiftButtons()
    {
      try
      {
        DateTime today =
            DateTime.Today;

        bool amFondoCompleted =
            _fondoService.FondoExists(
                today,
                "am");

        bool driveFondoCompleted =
            _fondoService.FondoExists(
                today,
                "drive");

        bool pmFondoCompleted =
            _fondoService.FondoExists(
                today,
                "pm");

        bool amCorteCompleted =
            _corteService.CorteExists(
                today,
                "am");

        bool pmCorteCompleted =
            _corteService.CorteExists(
                today,
                "pm");

        bool amDriveCorteCompleted =
            _corteService.CorteExists(
                today,
                "amDrive");

        bool pmDriveCorteCompleted =
            _corteService.CorteExists(
                today,
                "pmDrive");

        SetCorteShiftButtonState(
            btnCorteAM,
            fondoCompleted:
                amFondoCompleted,
            corteCompleted:
                amCorteCompleted,
            normalText:
                "AM CORTE",
            requiredText:
                "AM FONDO REQUIRED",
            availableColor:
                Color.FromArgb(
                    219,
                    234,
                    254));

        SetCorteShiftButtonState(
            btnCortePM,
            fondoCompleted:
                pmFondoCompleted,
            corteCompleted:
                pmCorteCompleted,
            normalText:
                "PM CORTE",
            requiredText:
                "PM FONDO REQUIRED",
            availableColor:
                Color.FromArgb(
                    220,
                    252,
                    231));

        SetCorteShiftButtonState(
            btnCorteAMDrive,
            fondoCompleted:
                driveFondoCompleted,
            corteCompleted:
                amDriveCorteCompleted,
            normalText:
                "AM DRIVE CORTE",
            requiredText:
                "DRIVE FONDO REQUIRED",
            availableColor:
                Color.FromArgb(
                    254,
                    249,
                    195));

        SetCorteShiftButtonState(
            btnCortePMDrive,
            fondoCompleted:
                driveFondoCompleted,
            corteCompleted:
                pmDriveCorteCompleted,
            normalText:
                "PM DRIVE CORTE",
            requiredText:
                "DRIVE FONDO REQUIRED",
            availableColor:
                Color.FromArgb(
                    254,
                    226,
                    226));
      }
      catch (Exception ex)
      {
        MessageBox.Show(
            ex.ToString(),
            "Unable to Check Corte Status",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
      }
    }

    private static void SetCorteShiftButtonState(
        Button button,
        bool fondoCompleted,
        bool corteCompleted,
        string normalText,
        string requiredText,
        Color availableColor)
    {
      if (corteCompleted)
      {
        button.Enabled = false;

        button.Text =
            $"{normalText}\r\nCOMPLETED";

        SetDisabledShiftAppearance(
            button);

        return;
      }

      if (!fondoCompleted)
      {
        button.Enabled = false;

        button.Text =
            $"{normalText}\r\n{requiredText}";

        SetDisabledShiftAppearance(
            button);

        return;
      }

      button.Enabled = true;
      button.Text = normalText;
      button.BackColor = availableColor;

      button.ForeColor =
          Color.FromArgb(
              31,
              41,
              55);

      button.FlatAppearance.BorderColor =
          Color.FromArgb(
              156,
              163,
              175);

      button.FlatAppearance.BorderSize = 2;
      button.Cursor = Cursors.Hand;
    }

    private static void SetDisabledShiftAppearance(
        Button button)
    {
      button.BackColor =
          Color.FromArgb(
              209,
              213,
              219);

      button.ForeColor =
          Color.FromArgb(
              107,
              114,
              128);

      button.FlatAppearance.BorderColor =
          Color.FromArgb(
              156,
              163,
              175);

      button.FlatAppearance.BorderSize = 2;
      button.Cursor = Cursors.Default;
    }

    // =========================================================
    // EXPENSE HISTORY
    // =========================================================

    private void btnExpenses_Click(
        object sender,
        EventArgs e)
    {
      if (!RequireLogin())
      {
        return;
      }

      OpenExpenseReport();
    }

    private void OpenExpenseReport()
    {
      try
      {
        ExpenseReportForm expenseReportForm =
            new(
                _expenseService,
                _corteService);

        expenseReportForm.ExpenseReportCompleted +=
            ExpenseReportForm_ExpenseReportCompleted;

        OpenChildForm(
            expenseReportForm,
            "Expense History");
      }
      catch (Exception ex)
      {
        MessageBox.Show(
            ex.ToString(),
            "Unable to Open Expense History",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
      }
    }

    private void ExpenseReportForm_ExpenseReportCompleted(
        object? sender,
        EventArgs e)
    {
      ShowHome();
    }

    // =========================================================
    // LEGACY REPORT HANDLER
    //
    // Kept because the existing Designer may still have the
    // old Reports button wired to this method.
    // The regular Reports button remains hidden.
    // =========================================================

    private void btnReports_Click(
        object sender,
        EventArgs e)
    {
      if (!RequireAdmin())
      {
        return;
      }

      OpenCorteReport();
    }

    // =========================================================
    // TRACKER
    // =========================================================

    private void btnTracker_Click(
        object sender,
        EventArgs e)
    {
      if (!RequireLogin())
      {
        return;
      }

      OpenTracker();
    }

    private void OpenTracker()
    {
      try
      {
        TrackerForm trackerForm =
            new(
                _trackerService);

        trackerForm.TrackerCompleted +=
            TrackerForm_TrackerCompleted;

        OpenChildForm(
            trackerForm,
            "Daily Tracker");
      }
      catch (Exception ex)
      {
        MessageBox.Show(
            ex.ToString(),
            "Unable to Open Tracker",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
      }
    }

    private void TrackerForm_TrackerCompleted(
        object? sender,
        EventArgs e)
    {
      ShowHome();
    }

    // =========================================================
    // ADMINISTRATION
    // =========================================================

    private void btnAdmin_Click(
        object sender,
        EventArgs e)
    {
      if (!RequireAdmin())
      {
        return;
      }

      ShowAdminSelection();
    }

    private bool RequireAdmin()
    {
      if (!RequireLogin())
      {
        return false;
      }

      if (_userSession.IsAdmin)
      {
        return true;
      }

      MessageBox.Show(
          "Administrator access is required.",
          "Access Denied",
          MessageBoxButtons.OK,
          MessageBoxIcon.Warning);

      return false;
    }

    private void ShowAdminSelection()
    {
      if (!_userSession.IsAdmin)
      {
        ShowHome();
        return;
      }

      CloseCurrentChild();

      pnlHome.Visible = false;

      HideSelectionPanels();

      pnlAdminSelection.Enabled = true;
      pnlAdminSelection.Visible = true;
      pnlAdminSelection.BringToFront();

      lblPageTitle.Text =
          "Administration";
    }

    // =========================================================
    // ADMIN REPORTS
    // =========================================================

    private void btnAdminReports_Click(
        object sender,
        EventArgs e)
    {
      if (!RequireAdmin())
      {
        return;
      }

      OpenCorteReport();
    }

    private void OpenCorteReport()
    {
      try
      {
        CorteReportForm reportForm =
            new(
                _corteService,
                _receiptPrintService);

        reportForm.CorteReportCompleted +=
            CorteReportForm_CorteReportCompleted;

        OpenChildForm(
            reportForm,
            "Corte Report");
      }
      catch (Exception ex)
      {
        MessageBox.Show(
            ex.ToString(),
            "Unable to Open Corte Report",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
      }
    }

    private void CorteReportForm_CorteReportCompleted(
        object? sender,
        EventArgs e)
    {
      ShowAdminSelection();
    }

    // =========================================================
    // USER MANAGEMENT
    // =========================================================

    private void btnAdminUsers_Click(
        object sender,
        EventArgs e)
    {
      if (!RequireAdmin())
      {
        return;
      }

      OpenUserManagement();
    }

    private void OpenUserManagement()
    {
      try
      {
        UserManagementForm userManagementForm =
            new(
                _userService,
                _userSession);

        userManagementForm.UserManagementCompleted +=
            UserManagementForm_UserManagementCompleted;

        OpenChildForm(
            userManagementForm,
            "User Management");
      }
      catch (Exception ex)
      {
        MessageBox.Show(
            ex.ToString(),
            "Unable to Open User Management",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
      }
    }

    private void UserManagementForm_UserManagementCompleted(
        object? sender,
        EventArgs e)
    {
      ApplyAccess();
      ShowAdminSelection();
    }

    // =========================================================
    // PRINTER SETTINGS
    // =========================================================

    private void btnAdminPrinter_Click(
        object sender,
        EventArgs e)
    {
      if (!RequireAdmin())
      {
        return;
      }

      OpenPrinterSettings();
    }

    private void OpenPrinterSettings()
    {
      try
      {
        PrinterSettingsForm printerSettingsForm =
            new(
                _printerSettingsService);

        printerSettingsForm.PrinterSettingsCompleted +=
            PrinterSettingsForm_PrinterSettingsCompleted;

        OpenChildForm(
            printerSettingsForm,
            "Printer Settings");
      }
      catch (Exception ex)
      {
        MessageBox.Show(
            ex.ToString(),
            "Unable to Open Printer Settings",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
      }
    }

    private void PrinterSettingsForm_PrinterSettingsCompleted(
        object? sender,
        EventArgs e)
    {
      ShowAdminSelection();
    }

    private void btnAdminBack_Click(
        object sender,
        EventArgs e)
    {
      ShowHome();
    }

    // =========================================================
    // CHILD FORM NAVIGATION
    // =========================================================

    private void OpenChildForm(
        Form childForm,
        string title)
    {
      CloseCurrentChild();

      pnlHome.Visible = false;

      HideSelectionPanels();

      _currentChildForm =
          childForm;

      childForm.TopLevel = false;

      childForm.FormBorderStyle =
          FormBorderStyle.None;

      childForm.Dock =
          DockStyle.Fill;

      pnlContent.Controls.Add(
          childForm);

      lblPageTitle.Text =
          title;

      childForm.Show();
      childForm.BringToFront();
    }

    private void CloseCurrentChild()
    {
      if (_currentChildForm == null)
      {
        return;
      }

      Form childForm =
          _currentChildForm;

      _currentChildForm =
          null;

      pnlContent.Controls.Remove(
          childForm);

      if (!childForm.IsDisposed)
      {
        childForm.Close();
        childForm.Dispose();
      }
    }

    // =========================================================
    // LOGIN / LOGOUT
    // =========================================================

    private void btnLogout_Click(
        object sender,
        EventArgs e)
    {
      if (!_userSession.IsLoggedIn)
      {
        ShowLogin();
        return;
      }

      _userSession.Logout();

      CloseCurrentChild();

      ApplyAccess();
      ShowHome();
    }

    // =========================================================
    // EXIT
    // =========================================================

    private void btnExit_Click(
        object sender,
        EventArgs e)
    {
      Close();
    }

    // =========================================================
    // UPDATE CHECK
    // =========================================================

    private async Task CheckForUpdatesAsync()
    {
      try
      {
        UpdateInfo? update =
            await _updateService
                .CheckForUpdateAsync();

        if (update == null)
        {
          return;
        }

        ShowUpdateAvailable(
            update);
      }
      catch
      {
        /*
         * CorteNext should continue operating normally
         * when update checking cannot be completed.
         */
      }
    }

    private void ShowUpdateAvailable(
    UpdateInfo update)
    {
      Version currentVersion =
          _updateService.GetCurrentVersion();

      DialogResult result =
          MessageBox.Show(
              $"A new CorteNext update is available.\r\n\r\n" +
              $"Installed: {currentVersion}\r\n" +
              $"Available: {update.Version}\r\n\r\n" +
              $"{update.ReleaseNotes}\r\n\r\n" +
              "Download and install this update now?",
              "CorteNext Update Available",
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Information);

      if (result !=
          DialogResult.Yes)
      {
        return;
      }

      _ =
          DownloadAndInstallUpdateAsync(
              update);
    }

    private async Task DownloadAndInstallUpdateAsync(
    UpdateInfo update)
    {
      try
      {
        UseWaitCursor =
            true;

        Cursor =
            Cursors.WaitCursor;

        string installerPath =
            await _updateService
                .DownloadInstallerAsync(
                    update);

        UseWaitCursor =
            false;

        Cursor =
            Cursors.Default;

        DialogResult result =
            MessageBox.Show(
                "The CorteNext update has finished downloading.\r\n\r\n" +
                "CorteNext must close to install the update.\r\n\r\n" +
                "Continue?",
                "Install Update",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);

        if (result !=
            DialogResult.Yes)
        {
          return;
        }

        _updateService.LaunchInstaller(
            installerPath);

        Application.Exit();
      }
      catch (Exception ex)
      {
        UseWaitCursor =
            false;

        Cursor =
            Cursors.Default;

        MessageBox.Show(
            "CorteNext could not download or start the update.\r\n\r\n" +
            ex.Message,
            "Update Failed",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
      }
    }

  }
}