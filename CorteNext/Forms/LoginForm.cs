using CorteNext.Models;
using CorteNext.Services;
using System.ComponentModel;

namespace CorteNext.Forms
{
  public partial class LoginForm : Form
  {
    private readonly IAuthenticationService _authenticationService;
    private readonly UserSession _userSession;

    private UserAccount? _selectedUser;
    private string _pin = string.Empty;

    [Browsable(false)]
    [DesignerSerializationVisibility(
        DesignerSerializationVisibility.Hidden)]
    public UserAccount? LoggedInUser =>
        _userSession.CurrentUser;

    public LoginForm(
        IAuthenticationService authenticationService,
        UserSession userSession)
    {
      InitializeComponent();

      _authenticationService =
          authenticationService;

      _userSession =
          userSession;
    }

    // =========================================================
    // LOAD
    // =========================================================

    private void LoginForm_Load(
        object sender,
        EventArgs e)
    {
      LoadUsers();

      ClearLogin();
    }

    // =========================================================
    // LOAD USERS
    // =========================================================

    private void LoadUsers()
    {
      try
      {
        IReadOnlyList<UserAccount> users =
            _authenticationService.GetUsers();

        cboUsers.DataSource =
            users.ToList();

        cboUsers.DisplayMember =
            nameof(UserAccount.DisplayName);

        cboUsers.ValueMember =
            nameof(UserAccount.Id);

        cboUsers.SelectedIndex =
            -1;

        cboUsers.Text =
            string.Empty;
      }
      catch (Exception ex)
      {
        MessageBox.Show(
            ex.Message,
            "Unable to Load Users",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
      }
    }

    // =========================================================
    // USER SELECTED
    // =========================================================

    private void cboUsers_SelectedIndexChanged(
        object sender,
        EventArgs e)
    {
      _selectedUser =
          cboUsers.SelectedItem
              as UserAccount;

      _pin =
          string.Empty;

      UpdatePinDisplay();
      UpdateLoginButton();
    }

    // =========================================================
    // ENTER PIN
    // =========================================================

    private void btnEnterPin_Click(
        object sender,
        EventArgs e)
    {
      if (_selectedUser == null)
      {
        MessageBox.Show(
            "Select a user first.",
            "Select User",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);

        return;
      }

      using PinPadForm pinPad =
          new();

      if (pinPad.ShowDialog(this) !=
          DialogResult.OK)
      {
        return;
      }

      _pin =
          pinPad.Pin;

      UpdatePinDisplay();
      UpdateLoginButton();
    }

    // =========================================================
    // PIN DISPLAY
    // =========================================================

    private void UpdatePinDisplay()
    {
      if (string.IsNullOrEmpty(_pin))
      {
        lblPinStatus.Text =
            "PIN NOT ENTERED";

        lblPinStatus.ForeColor =
            Color.FromArgb(
                107,
                114,
                128);

        return;
      }

      lblPinStatus.Text =
          "PIN ENTERED";

      lblPinStatus.ForeColor =
          Color.FromArgb(
              22,
              101,
              52);
    }

    // =========================================================
    // LOGIN BUTTON STATE
    // =========================================================

    private void UpdateLoginButton()
    {
      btnLogin.Enabled =
          _selectedUser != null &&
          !string.IsNullOrWhiteSpace(
              _pin);

      btnLogin.BackColor =
          btnLogin.Enabled
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
    // LOGIN
    // =========================================================

    private void btnLogin_Click(
        object sender,
        EventArgs e)
    {
      if (_selectedUser == null)
        return;

      if (string.IsNullOrWhiteSpace(_pin))
        return;

      try
      {
        UserAccount? user =
            _authenticationService.Authenticate(
                _selectedUser.UserName,
                _pin);

        if (user == null)
        {
          MessageBox.Show(
              "Invalid PIN.",
              "Login Failed",
              MessageBoxButtons.OK,
              MessageBoxIcon.Warning);

          _pin =
              string.Empty;

          UpdatePinDisplay();
          UpdateLoginButton();

          return;
        }

        _userSession.Login(
            user);

        DialogResult =
            DialogResult.OK;

        Close();
      }
      catch (Exception ex)
      {
        MessageBox.Show(
            ex.Message,
            "Login Error",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
      }
    }

    // =========================================================
    // CLEAR
    // =========================================================

    private void ClearLogin()
    {
      _selectedUser =
          null;

      _pin =
          string.Empty;

      cboUsers.SelectedIndex =
          -1;

      UpdatePinDisplay();
      UpdateLoginButton();
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