using System;
using System.Drawing;
using System.Windows.Forms;

namespace LoanManagementSystem.Forms
{
    partial class UserForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtUsername;
        private TextBox txtFullName;
        private ComboBox cmbRole;
        private CheckBox chkActive;
        private Button btnSave;
        private Button btnCancel;
        private Label lblUsername;
        private Label lblFullName;
        private Label lblRole;
        private Panel panelHeader;
        private Label lblTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelHeader = new Panel();
            this.lblTitle = new Label();
            this.lblUsername = new Label();
            this.txtUsername = new TextBox();
            this.lblFullName = new Label();
            this.txtFullName = new TextBox();
            this.lblRole = new Label();
            this.cmbRole = new ComboBox();
            this.chkActive = new CheckBox();
            this.btnSave = new Button();
            this.btnCancel = new Button();

            this.panelHeader.SuspendLayout();
            this.SuspendLayout();

            // panelHeader
            this.panelHeader.BackColor = Color.SteelBlue;
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = DockStyle.Top;
            this.panelHeader.Location = new Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new Size(400, 60);
            this.panelHeader.TabIndex = 0;

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location = new Point(20, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(97, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "User Form";

            // lblUsername
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new Point(50, 80);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new Size(63, 15);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Username:";

            // txtUsername
            this.txtUsername.Location = new Point(120, 77);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new Size(200, 23);
            this.txtUsername.TabIndex = 1;

            // lblFullName
            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new Point(50, 120);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new Size(64, 15);
            this.lblFullName.TabIndex = 3;
            this.lblFullName.Text = "Full Name:";

            // txtFullName
            this.txtFullName.Location = new Point(120, 117);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new Size(200, 23);
            this.txtFullName.TabIndex = 2;

            // lblRole
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new Point(50, 160);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new Size(33, 15);
            this.lblRole.TabIndex = 5;
            this.lblRole.Text = "Role:";

            // cmbRole
            this.cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.Items.AddRange(new object[] { "Admin", "Staff" });
            this.cmbRole.Location = new Point(120, 157);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new Size(200, 23);
            this.cmbRole.TabIndex = 3;

            // chkActive
            this.chkActive.AutoSize = true;
            this.chkActive.Location = new Point(120, 200);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new Size(59, 19);
            this.chkActive.TabIndex = 4;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = true;

            // btnSave
            this.btnSave.BackColor = Color.SteelBlue;
            this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.ForeColor = Color.White;
            this.btnSave.Location = new Point(120, 240);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(90, 35);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.BackColor = Color.Gray;
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.ForeColor = Color.White;
            this.btnCancel.Location = new Point(230, 240);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(90, 35);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);

            // UserForm
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(400, 300);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.cmbRole);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}