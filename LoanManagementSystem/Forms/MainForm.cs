using LoanManagementSystem.Models;
using LoanManagementSystem.Repositories;
using LoanManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoanManagementSystem.Forms
{
    public partial class MainForm : Form
    {
        private IAuthService _authService;
        private User _currentUser;

        public MainForm(IAuthService authService)
        {
            _authService = authService;
            _currentUser = _authService.CurrentUser;
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Welcome, {_currentUser.FullName} ({_currentUser.Role})";
            SetupRoleBasedAccess();
            HighlightNavButton(btnDashboard);
            ShowDashboard();
        }

        private void SetupRoleBasedAccess()
        {
            if (_currentUser.Role == "Staff")
            {
                btnUsers.Enabled = false;
                btnUsers.BackColor = System.Drawing.Color.FromArgb(60, 70, 80);
                btnUsers.ForeColor = System.Drawing.Color.FromArgb(120, 120, 120);
                btnUsers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(60, 70, 80);
            }
        }

        private void BtnDashboard_Click(object sender, EventArgs e)
        {
            HighlightNavButton((Button)sender);
            ShowDashboard();
        }

        private void BtnClients_Click(object sender, EventArgs e)
        {
            HighlightNavButton((Button)sender);
            ShowClientManagement();
        }

        private void BtnLoans_Click(object sender, EventArgs e)
        {
            HighlightNavButton((Button)sender);
            ShowLoanProcessing();
        }

        private void BtnUsers_Click(object sender, EventArgs e)
        {
            HighlightNavButton((Button)sender);
            ShowUserManagement();
        }

        private void BtnProfile_Click(object sender, EventArgs e)
        {
            HighlightNavButton((Button)sender);
            ShowProfile();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            Logout();
        }

        private void TimerDateTime_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy | hh:mm tt");
        }

        private void HighlightNavButton(Button button)
        {
            if (!button.Enabled)
                return;

            ResetNavButtons();
            button.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            button.ForeColor = System.Drawing.Color.White;
        }

        private void ResetNavButtons()
        {
            btnDashboard.BackColor = System.Drawing.Color.FromArgb(30, 40, 50);
            btnDashboard.ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
            btnClients.BackColor = System.Drawing.Color.FromArgb(30, 40, 50);
            btnClients.ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
            btnLoans.BackColor = System.Drawing.Color.FromArgb(30, 40, 50);
            btnLoans.ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);

            if (btnUsers.Enabled)
            {
                btnUsers.BackColor = System.Drawing.Color.FromArgb(30, 40, 50);
                btnUsers.ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
            }
            else
            {
                btnUsers.BackColor = System.Drawing.Color.FromArgb(60, 70, 80);
                btnUsers.ForeColor = System.Drawing.Color.FromArgb(120, 120, 120);
            }

            btnProfile.BackColor = System.Drawing.Color.FromArgb(30, 40, 50);
            btnProfile.ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        }

        private void ShowDashboard()
        {
            contentPanel.Controls.Clear();
            var dashboardControl = new DashboardControl();
            dashboardControl.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(dashboardControl);
        }

        private void ShowClientManagement()
        {
            contentPanel.Controls.Clear();
            var clientControl = new ClientManagementControl();
            clientControl.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(clientControl);
        }

        private void ShowLoanProcessing()
        {
            contentPanel.Controls.Clear();
            var loanControl = new LoanProcessingControl();
            loanControl.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(loanControl);
        }

        private void ShowUserManagement()
        {
            contentPanel.Controls.Clear();
            Label lbl = new Label();
            lbl.Text = "User Management - Manage staff accounts (Admin Only)";
            lbl.Dock = DockStyle.Fill;
            lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lbl.Font = new System.Drawing.Font("Segoe UI", 16, System.Drawing.FontStyle.Bold);
            lbl.ForeColor = System.Drawing.Color.Gray;
            contentPanel.Controls.Add(lbl);
        }

        private void ShowProfile()
        {
            contentPanel.Controls.Clear();
            Label lbl = new Label();
            lbl.Text = $"User Profile: {_currentUser.FullName}\nRole: {_currentUser.Role}";
            lbl.Dock = DockStyle.Fill;
            lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lbl.Font = new System.Drawing.Font("Segoe UI", 16, System.Drawing.FontStyle.Bold);
            lbl.ForeColor = System.Drawing.Color.Gray;
            contentPanel.Controls.Add(lbl);
        }

        private void Logout()
        {
            var result = MessageBox.Show("Are you sure you want to logout?", "Logout",
                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                _authService.Logout();
                this.Hide();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ContentPanel_Paint(object sender, PaintEventArgs e)
        {
          
        }
    }
}