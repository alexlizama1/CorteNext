namespace CorteNext.Forms
{
  partial class LoginForm
  {
    private System.ComponentModel.IContainer? components = null;

    private Panel pnlHeader;
    private Panel pnlBody;
    private Panel pnlFooter;

    private Label lblTitle;
    private Label lblUser;
    private Label lblPinStatus;

    private ComboBox cboUsers;

    private Button btnEnterPin;
    private Button btnLogin;
    private Button btnCancel;

    protected override void Dispose(
        bool disposing)
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
      lblTitle = new Label();
      pnlBody = new Panel();
      lblPinStatus = new Label();
      btnEnterPin = new Button();
      cboUsers = new ComboBox();
      lblUser = new Label();
      pnlFooter = new Panel();
      btnCancel = new Button();
      btnLogin = new Button();
      pnlHeader.SuspendLayout();
      pnlBody.SuspendLayout();
      pnlFooter.SuspendLayout();
      SuspendLayout();
      // 
      // pnlHeader
      // 
      pnlHeader.BackColor = Color.FromArgb(31, 41, 55);
      pnlHeader.Controls.Add(lblTitle);
      pnlHeader.Dock = DockStyle.Top;
      pnlHeader.Location = new Point(0, 0);
      pnlHeader.Name = "pnlHeader";
      pnlHeader.Size = new Size(1138, 110);
      pnlHeader.TabIndex = 2;
      // 
      // lblTitle
      // 
      lblTitle.Dock = DockStyle.Fill;
      lblTitle.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
      lblTitle.ForeColor = Color.White;
      lblTitle.Location = new Point(0, 0);
      lblTitle.Name = "lblTitle";
      lblTitle.Size = new Size(1138, 110);
      lblTitle.TabIndex = 0;
      lblTitle.Text = "CORTE NEXT LOGIN";
      lblTitle.TextAlign = ContentAlignment.MiddleCenter;
      // 
      // pnlBody
      // 
      pnlBody.Controls.Add(lblPinStatus);
      pnlBody.Controls.Add(btnEnterPin);
      pnlBody.Controls.Add(cboUsers);
      pnlBody.Controls.Add(lblUser);
      pnlBody.Dock = DockStyle.Fill;
      pnlBody.Location = new Point(0, 110);
      pnlBody.Name = "pnlBody";
      pnlBody.Padding = new Padding(60, 30, 60, 30);
      pnlBody.Size = new Size(1138, 545);
      pnlBody.TabIndex = 0;
      // 
      // lblPinStatus
      // 
      lblPinStatus.Dock = DockStyle.Top;
      lblPinStatus.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
      lblPinStatus.ForeColor = Color.FromArgb(107, 114, 128);
      lblPinStatus.Location = new Point(60, 400);
      lblPinStatus.Name = "lblPinStatus";
      lblPinStatus.Size = new Size(1018, 60);
      lblPinStatus.TabIndex = 0;
      lblPinStatus.Text = "PIN NOT ENTERED";
      lblPinStatus.TextAlign = ContentAlignment.MiddleCenter;
      // 
      // btnEnterPin
      // 
      btnEnterPin.BackColor = Color.FromArgb(219, 234, 254);
      btnEnterPin.Cursor = Cursors.Hand;
      btnEnterPin.Dock = DockStyle.Top;
      btnEnterPin.FlatAppearance.BorderSize = 2;
      btnEnterPin.FlatStyle = FlatStyle.Flat;
      btnEnterPin.Font = new Font("Segoe UI", 40F, FontStyle.Bold);
      btnEnterPin.ForeColor = Color.FromArgb(30, 64, 175);
      btnEnterPin.Location = new Point(60, 233);
      btnEnterPin.Margin = new Padding(0, 25, 0, 0);
      btnEnterPin.Name = "btnEnterPin";
      btnEnterPin.Size = new Size(1018, 167);
      btnEnterPin.TabIndex = 1;
      btnEnterPin.Text = "ENTER PIN";
      btnEnterPin.UseVisualStyleBackColor = false;
      btnEnterPin.Click += btnEnterPin_Click;
      // 
      // cboUsers
      // 
      cboUsers.Dock = DockStyle.Top;
      //cboUsers.DropDownHeight = 860;
      cboUsers.DropDownStyle = ComboBoxStyle.DropDownList;
      cboUsers.Font = new Font("Segoe UI", 45F);
      cboUsers.IntegralHeight = false;
      cboUsers.Location = new Point(60, 85);
      cboUsers.Name = "cboUsers";
      cboUsers.Size = new Size(1018, 148);
      cboUsers.TabIndex = 2;
      cboUsers.SelectedIndexChanged += cboUsers_SelectedIndexChanged;
      // 
      // lblUser
      // 
      lblUser.Dock = DockStyle.Top;
      lblUser.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
      lblUser.Location = new Point(60, 30);
      lblUser.Name = "lblUser";
      lblUser.Size = new Size(1018, 55);
      lblUser.TabIndex = 3;
      lblUser.Text = "SELECT USER";
      lblUser.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // pnlFooter
      // 
      pnlFooter.BackColor = Color.FromArgb(229, 231, 235);
      pnlFooter.Controls.Add(btnCancel);
      pnlFooter.Controls.Add(btnLogin);
      pnlFooter.Dock = DockStyle.Bottom;
      pnlFooter.Location = new Point(0, 655);
      pnlFooter.Name = "pnlFooter";
      pnlFooter.Padding = new Padding(30, 18, 30, 18);
      pnlFooter.Size = new Size(1138, 263);
      pnlFooter.TabIndex = 1;
      // 
      // btnCancel
      // 
      btnCancel.BackColor = Color.FromArgb(239, 68, 68);
      btnCancel.Cursor = Cursors.Hand;
      btnCancel.Dock = DockStyle.Left;
      btnCancel.FlatAppearance.BorderSize = 0;
      btnCancel.FlatStyle = FlatStyle.Flat;
      btnCancel.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
      btnCancel.ForeColor = Color.White;
      btnCancel.Location = new Point(30, 18);
      btnCancel.Name = "btnCancel";
      btnCancel.Size = new Size(260, 227);
      btnCancel.TabIndex = 0;
      btnCancel.Text = "CANCEL";
      btnCancel.UseVisualStyleBackColor = false;
      btnCancel.Click += btnCancel_Click;
      // 
      // btnLogin
      // 
      btnLogin.BackColor = Color.FromArgb(156, 163, 175);
      btnLogin.Cursor = Cursors.Hand;
      btnLogin.Dock = DockStyle.Right;
      btnLogin.Enabled = false;
      btnLogin.FlatAppearance.BorderSize = 0;
      btnLogin.FlatStyle = FlatStyle.Flat;
      btnLogin.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
      btnLogin.ForeColor = Color.White;
      btnLogin.Location = new Point(808, 18);
      btnLogin.Name = "btnLogin";
      btnLogin.Size = new Size(300, 227);
      btnLogin.TabIndex = 1;
      btnLogin.Text = "LOGIN";
      btnLogin.UseVisualStyleBackColor = false;
      btnLogin.Click += btnLogin_Click;
      // 
      // LoginForm
      // 
      AutoScaleDimensions = new SizeF(168F, 168F);
      AutoScaleMode = AutoScaleMode.Dpi;
      BackColor = Color.FromArgb(245, 247, 250);
      ClientSize = new Size(1138, 918);
      Controls.Add(pnlBody);
      Controls.Add(pnlFooter);
      Controls.Add(pnlHeader);
      FormBorderStyle = FormBorderStyle.FixedDialog;
      MaximizeBox = false;
      MinimizeBox = false;
      Name = "LoginForm";
      StartPosition = FormStartPosition.CenterParent;
      Text = "CorteNext Login";
      Load += LoginForm_Load;
      pnlHeader.ResumeLayout(false);
      pnlBody.ResumeLayout(false);
      pnlFooter.ResumeLayout(false);
      ResumeLayout(false);
    }
  }
}