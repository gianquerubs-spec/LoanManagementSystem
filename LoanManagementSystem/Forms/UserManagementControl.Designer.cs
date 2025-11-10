using System;
using System.Drawing;
using System.Windows.Forms;

namespace LoanManagementSystem.Forms
{
    partial class UserManagementControl
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dataGridViewUsers;
        private Button btnAddUser;
        private Button btnEditUser;
        private Button btnDeleteUser;
        private Button btnRefresh;
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
            this.dataGridViewUsers = new DataGridView();
            this.btnAddUser = new Button();
            this.btnEditUser = new Button();
            this.btnDeleteUser = new Button();
            this.btnRefresh = new Button();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).BeginInit();
            this.SuspendLayout();

            // panelHeader
            this.panelHeader.BackColor = Color.SteelBlue;
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = DockStyle.Top;
            this.panelHeader.Location = new Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new Size(800, 60);
            this.panelHeader.TabIndex = 0;

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location = new Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(197, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "User Management";

            // dataGridViewUsers
            this.dataGridViewUsers.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            this.dataGridViewUsers.Location = new Point(20, 80);
            this.dataGridViewUsers.Name = "dataGridViewUsers";
            this.dataGridViewUsers.Size = new Size(760, 350);
            this.dataGridViewUsers.TabIndex = 1;

            // btnAddUser
            this.btnAddUser.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Left)));
            this.btnAddUser.BackColor = Color.SteelBlue;
            this.btnAddUser.FlatStyle = FlatStyle.Flat;
            this.btnAddUser.Font = new Font("Segoe UI", 9F);
            this.btnAddUser.ForeColor = Color.White;
            this.btnAddUser.Location = new Point(20, 450);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new Size(90, 35);
            this.btnAddUser.TabIndex = 2;
            this.btnAddUser.Text = "Add User";
            this.btnAddUser.UseVisualStyleBackColor = false;
            this.btnAddUser.Click += new EventHandler(this.btnAddUser_Click);

            // btnEditUser
            this.btnEditUser.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Left)));
            this.btnEditUser.BackColor = Color.Green;
            this.btnEditUser.FlatStyle = FlatStyle.Flat;
            this.btnEditUser.Font = new Font("Segoe UI", 9F);
            this.btnEditUser.ForeColor = Color.White;
            this.btnEditUser.Location = new Point(120, 450);
            this.btnEditUser.Name = "btnEditUser";
            this.btnEditUser.Size = new Size(90, 35);
            this.btnEditUser.TabIndex = 3;
            this.btnEditUser.Text = "Edit User";
            this.btnEditUser.UseVisualStyleBackColor = false;
            this.btnEditUser.Click += new EventHandler(this.btnEditUser_Click);

            // btnDeleteUser
            this.btnDeleteUser.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Left)));
            this.btnDeleteUser.BackColor = Color.Red;
            this.btnDeleteUser.FlatStyle = FlatStyle.Flat;
            this.btnDeleteUser.Font = new Font("Segoe UI", 9F);
            this.btnDeleteUser.ForeColor = Color.White;
            this.btnDeleteUser.Location = new Point(220, 450);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new Size(90, 35);
            this.btnDeleteUser.TabIndex = 4;
            this.btnDeleteUser.Text = "Delete User";
            this.btnDeleteUser.UseVisualStyleBackColor = false;
            this.btnDeleteUser.Click += new EventHandler(this.btnDeleteUser_Click);

            // btnRefresh
            this.btnRefresh.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            this.btnRefresh.BackColor = Color.Gray;
            this.btnRefresh.FlatStyle = FlatStyle.Flat;
            this.btnRefresh.Font = new Font("Segoe UI", 9F);
            this.btnRefresh.ForeColor = Color.White;
            this.btnRefresh.Location = new Point(690, 450);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new Size(90, 35);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);

            // UserManagementControl
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnDeleteUser);
            this.Controls.Add(this.btnEditUser);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.dataGridViewUsers);
            this.Controls.Add(this.panelHeader);
            this.Name = "UserManagementControl";
            this.Size = new Size(800, 500);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).EndInit();
            this.ResumeLayout(false);
        }
    }
}