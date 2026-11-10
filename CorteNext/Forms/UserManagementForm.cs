using CorteNext.Models;
using CorteNext.Services;

namespace CorteNext.Forms
{
  public partial class UserManagementForm : Form
  {
    private readonly IUserService _userService;
    private readonly UserSession _userSession;

    private UserAccount? _selectedUser;

    private string _firstName = string.Empty;
    private string _lastName = string.Empty;
    private string _userName = string.Empty;
    private string _pin = string.Empty;

    private bool _isAdding;

    public event EventHandler? UserManagementCompleted;

    public UserManagementForm(
        IUserService userService,
        UserSession userSession)
    {
      InitializeComponent();

      _userService = userService;
      _userSession = userSession;
    }

    // =========================================================
    // FORM LOAD
    // =========================================================

    private void UserManagementForm_Load(
        object sender,
        EventArgs e)
    {
      ConfigureAccessLevels();
      LoadUsers();
      ClearEditor();
    }

    // =========================================================
    // ACCESS LEVELS
    // =========================================================

    private void ConfigureAccessLevels()
    {
      cboAccessLevel.Items.Clear();

      cboAccessLevel.Items.Add(
          new AccessLevelItem(
              3,
              "Standard User"));

      cboAccessLevel.Items.Add(
          new AccessLevelItem(
              5,
              "Administrator"));

      cboAccessLevel.DisplayMember =
          nameof(AccessLevelItem.DisplayName);

      cboAccessLevel.ValueMember =
          nameof(AccessLevelItem.Value);

      cboAccessLevel.SelectedIndex = 0;
    }

    private int GetSelectedAccessLevel()
    {
      if (cboAccessLevel.SelectedItem
          is AccessLevelItem item)
      {
        return item.Value;
      }

      return 0;
    }

    private void SelectAccessLevel(
        int accessLevel)
    {
      for (int i = 0;
           i < cboAccessLevel.Items.Count;
           i++)
      {
        if (cboAccessLevel.Items[i]
            is not AccessLevelItem item)
        {
          continue;
        }

        if (item.Value != accessLevel)
          continue;

        cboAccessLevel.SelectedIndex = i;

        return;
      }

      cboAccessLevel.SelectedIndex =
          cboAccessLevel.Items.Count > 0
              ? 0
              : -1;
    }

    private void cboAccessLevel_SelectedIndexChanged(
        object sender,
        EventArgs e)
    {
      UpdateSaveState();
    }

    // =========================================================
    // LOAD USERS
    // =========================================================

    private void LoadUsers()
    {
      try
      {
        IReadOnlyList<UserAccount> users =
            _userService.GetUsers();

        lstUsers.DataSource = null;

        lstUsers.DataSource =
            users.ToList();

        lstUsers.DisplayMember =
            nameof(UserAccount.DisplayName);

        lstUsers.ValueMember =
            nameof(UserAccount.Id);

        lstUsers.ClearSelected();
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

    private void lstUsers_SelectedIndexChanged(
        object sender,
        EventArgs e)
    {
      if (lstUsers.SelectedItem
          is not UserAccount user)
      {
        return;
      }

      _selectedUser = user;
      _isAdding = false;

      LoadSelectedUser(user);
    }

    private void LoadSelectedUser(
        UserAccount user)
    {
      _firstName =
          user.FirstName;

      _lastName =
          user.LastName;

      _userName =
          user.UserName;

      // Existing PIN is deliberately not loaded.
      _pin = string.Empty;

      btnFirstName.Text =
          GetDisplayText(
              _firstName,
              "TOUCH TO ENTER FIRST NAME");

      btnLastName.Text =
          GetDisplayText(
              _lastName,
              "TOUCH TO ENTER LAST NAME");

      btnUserName.Text =
          GetDisplayText(
              _userName,
              "TOUCH TO ENTER USERNAME");

      btnPin.Text =
          "CHANGE PIN";

      btnPin.BackColor =
          Color.White;

      btnPin.ForeColor =
          Color.FromArgb(
              31,
              41,
              55);

      SelectAccessLevel(
          user.AccessLevel);

      lblEditorTitle.Text =
          "EDIT USER";

      btnDelete.Enabled = true;

      UpdateSaveState();
    }

    // =========================================================
    // ADD USER
    // =========================================================

    private void btnAddUser_Click(
        object sender,
        EventArgs e)
    {
      lstUsers.ClearSelected();

      _selectedUser = null;
      _isAdding = true;

      _firstName = string.Empty;
      _lastName = string.Empty;
      _userName = string.Empty;
      _pin = string.Empty;

      btnFirstName.Text =
          "TOUCH TO ENTER FIRST NAME";

      btnLastName.Text =
          "TOUCH TO ENTER LAST NAME";

      btnUserName.Text =
          "TOUCH TO ENTER USERNAME";

      btnPin.Text =
          "SET PIN";

      btnPin.BackColor =
          Color.White;

      btnPin.ForeColor =
          Color.FromArgb(
              31,
              41,
              55);

      cboAccessLevel.SelectedIndex =
          cboAccessLevel.Items.Count > 0
              ? 0
              : -1;

      lblEditorTitle.Text =
          "ADD USER";

      btnDelete.Enabled = false;

      UpdateSaveState();
    }

    // =========================================================
    // FIRST NAME
    // =========================================================

    private void btnFirstName_Click(
        object sender,
        EventArgs e)
    {
      string? value =
          GetKeyboardValue(
              _firstName);

      if (value == null)
        return;

      _firstName =
          value.Trim();

      btnFirstName.Text =
          GetDisplayText(
              _firstName,
              "TOUCH TO ENTER FIRST NAME");

      BuildSuggestedUserName();

      UpdateSaveState();
    }

    // =========================================================
    // LAST NAME
    // =========================================================

    private void btnLastName_Click(
        object sender,
        EventArgs e)
    {
      string? value =
          GetKeyboardValue(
              _lastName);

      if (value == null)
        return;

      _lastName =
          value.Trim();

      btnLastName.Text =
          GetDisplayText(
              _lastName,
              "TOUCH TO ENTER LAST NAME");

      BuildSuggestedUserName();

      UpdateSaveState();
    }

    // =========================================================
    // USERNAME
    // =========================================================

    private void btnUserName_Click(
        object sender,
        EventArgs e)
    {
      string? value =
          GetKeyboardValue(
              _userName);

      if (value == null)
        return;

      _userName =
          value.Trim();

      btnUserName.Text =
          GetDisplayText(
              _userName,
              "TOUCH TO ENTER USERNAME");

      UpdateSaveState();
    }

    // =========================================================
    // SUGGEST USERNAME
    // =========================================================

    private void BuildSuggestedUserName()
    {
      // Only automatically generate usernames
      // when adding a new user.
      if (!_isAdding)
        return;

      if (string.IsNullOrWhiteSpace(
              _firstName))
      {
        return;
      }

      if (string.IsNullOrWhiteSpace(
              _lastName))
      {
        return;
      }

      _userName =
          $"{_firstName}.{_lastName[0]}"
          .ToLowerInvariant();

      btnUserName.Text =
          _userName;
    }

    // =========================================================
    // PIN
    // =========================================================

    private void btnPin_Click(
        object sender,
        EventArgs e)
    {
      using PinPadForm pinPad =
          new();

      if (pinPad.ShowDialog(this) !=
          DialogResult.OK)
      {
        return;
      }

      _pin =
          pinPad.Pin;

      btnPin.Text =
          _isAdding
              ? "PIN ENTERED"
              : "NEW PIN ENTERED";

      btnPin.BackColor =
          Color.FromArgb(
              220,
              252,
              231);

      btnPin.ForeColor =
          Color.FromArgb(
              22,
              101,
              52);

      UpdateSaveState();
    }

    // =========================================================
    // KEYBOARD
    // =========================================================

    private string? GetKeyboardValue(
        string currentValue)
    {
      using KeyboardForm keyboard =
          new(currentValue);

      if (keyboard.ShowDialog(this) !=
          DialogResult.OK)
      {
        return null;
      }

      return keyboard.Value;
    }

    // =========================================================
    // SAVE STATE
    // =========================================================

    private void UpdateSaveState()
    {
      bool profileCompleted =
          !string.IsNullOrWhiteSpace(
              _firstName) &&
          !string.IsNullOrWhiteSpace(
              _lastName) &&
          !string.IsNullOrWhiteSpace(
              _userName) &&
          GetSelectedAccessLevel() > 0;

      /*
       * A new user requires a PIN.
       *
       * An existing user does not require a new PIN because
       * UserRepository.Update() leaves the existing password
       * column unchanged.
       */
      bool pinCompleted =
          !_isAdding ||
          !string.IsNullOrWhiteSpace(
              _pin);

      bool hasUserToEdit =
          _isAdding ||
          _selectedUser != null;

      btnSave.Enabled =
          profileCompleted &&
          pinCompleted &&
          hasUserToEdit;

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
      if (!btnSave.Enabled)
        return;

      try
      {
        if (_isAdding)
        {
          AddUser();
        }
        else
        {
          UpdateUser();
        }

        MessageBox.Show(
            "User saved successfully.",
            "User Management",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);

        LoadUsers();
        ClearEditor();
      }
      catch (Exception ex)
      {
        MessageBox.Show(
            ex.Message,
            "Unable to Save User",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
      }
    }

    // =========================================================
    // ADD USER
    // =========================================================

    private void AddUser()
    {
      UserAccount user = new()
      {
        FirstName =
              _firstName,

        LastName =
              _lastName,

        UserName =
              _userName,

        Password =
              _pin,

        AccessLevel =
              GetSelectedAccessLevel()
      };

      _userService.AddUser(
          user);
    }

    // =========================================================
    // UPDATE USER
    // =========================================================

    private void UpdateUser()
    {
      if (_selectedUser == null)
      {
        throw new InvalidOperationException(
            "Select a user to update.");
      }

      UserAccount user = new()
      {
        Id =
              _selectedUser.Id,

        FirstName =
              _firstName,

        LastName =
              _lastName,

        UserName =
              _userName,

        AccessLevel =
              GetSelectedAccessLevel()
      };

      // -----------------------------------------------------
      // Update profile only.
      // Existing PIN remains unchanged.
      // -----------------------------------------------------

      _userService.UpdateUser(
          user);

      // -----------------------------------------------------
      // Change PIN only if a new one was explicitly entered.
      // -----------------------------------------------------

      if (!string.IsNullOrWhiteSpace(
              _pin))
      {
        _userService.UpdatePin(
            user.Id,
            _pin);
      }
    }

    // =========================================================
    // DELETE USER
    // =========================================================

    private void btnDelete_Click(
        object sender,
        EventArgs e)
    {
      if (_selectedUser == null)
        return;

      // Prevent the logged-in administrator
      // from deleting their own account.
      if (_userSession.CurrentUser?.Id ==
          _selectedUser.Id)
      {
        MessageBox.Show(
            "You cannot delete the account currently logged in.",
            "Delete User",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning);

        return;
      }

      DialogResult result =
          MessageBox.Show(
              $"Delete {_selectedUser.DisplayName}?",
              "Delete User",
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Question);

      if (result != DialogResult.Yes)
        return;

      try
      {
        _userService.DeleteUser(
            _selectedUser.Id);

        MessageBox.Show(
            "User deleted successfully.",
            "User Management",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);

        LoadUsers();
        ClearEditor();
      }
      catch (Exception ex)
      {
        MessageBox.Show(
            ex.Message,
            "Unable to Delete User",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
      }
    }

    // =========================================================
    // CLEAR EDITOR
    // =========================================================

    private void ClearEditor()
    {
      _selectedUser = null;
      _isAdding = false;

      _firstName = string.Empty;
      _lastName = string.Empty;
      _userName = string.Empty;
      _pin = string.Empty;

      btnFirstName.Text =
          "TOUCH TO ENTER FIRST NAME";

      btnLastName.Text =
          "TOUCH TO ENTER LAST NAME";

      btnUserName.Text =
          "TOUCH TO ENTER USERNAME";

      btnPin.Text =
          "SET PIN";

      btnPin.BackColor =
          Color.White;

      btnPin.ForeColor =
          Color.FromArgb(
              31,
              41,
              55);

      cboAccessLevel.SelectedIndex =
          cboAccessLevel.Items.Count > 0
              ? 0
              : -1;

      lblEditorTitle.Text =
          "SELECT OR ADD USER";

      btnDelete.Enabled =
          false;

      btnSave.Enabled =
          false;

      btnSave.BackColor =
          Color.FromArgb(
              156,
              163,
              175);
    }

    // =========================================================
    // DONE
    // =========================================================

    private void btnDone_Click(
        object sender,
        EventArgs e)
    {
      UserManagementCompleted?.Invoke(
          this,
          EventArgs.Empty);

      Close();
    }

    // =========================================================
    // DISPLAY TEXT
    // =========================================================

    private static string GetDisplayText(
        string value,
        string placeholder)
    {
      return string.IsNullOrWhiteSpace(
          value)
              ? placeholder
              : value;
    }

    // =========================================================
    // ACCESS LEVEL ITEM
    // =========================================================

    private sealed class AccessLevelItem
    {
      public int Value { get; }

      public string DisplayName { get; }

      public AccessLevelItem(
          int value,
          string displayName)
      {
        Value =
            value;

        DisplayName =
            displayName;
      }

      public override string ToString()
      {
        return DisplayName;
      }
    }
  }
}