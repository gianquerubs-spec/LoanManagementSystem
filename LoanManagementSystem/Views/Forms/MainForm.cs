using LoanManagementSystem.Interfaces.Services; 
using LoanManagementSystem.Models;
using LoanManagementSystem.Presenters;
using LoanManagementSystem.Repositories;
using LoanManagementSystem.Services;
using LoanManagementSystem.Utilities;
using LoanManagementSystem.Views.Interfaces;
using System;
using System.Windows.Forms;


namespace LoanManagementSystem.Views.Forms
{
    public partial class MainForm : Form, IMainView
    {
        public User CurrentUser { get; set; }
        private IAuthService  _authService;

        // IMainView events
        public event EventHandler DashboardClicked;
        public event EventHandler ClientsClicked;
        public event EventHandler LoansClicked;
        public event EventHandler UsersClicked;
        public event EventHandler ProfileClicked;
        public event EventHandler LogoutClicked;

        public MainForm(IAuthService authService)
        {
            _authService = authService;
            CurrentUser = authService.CurrentUser;
            InitializeComponent();
            WireUpEvents();

            // Disable user management if not admin
            if (!CurrentUser.IsAdmin())
            {
                DisableUserManagement();
            }
        }

        private void WireUpEvents()
        {
            btnDashboard.Click += (s, e) => DashboardClicked?.Invoke(this, EventArgs.Empty);
            btnClients.Click += (s, e) => ClientsClicked?.Invoke(this, EventArgs.Empty);
            btnLoans.Click += (s, e) => LoansClicked?.Invoke(this, EventArgs.Empty);
            btnUsers.Click += (s, e) => UsersClicked?.Invoke(this, EventArgs.Empty);
            btnProfile.Click += (s, e) => ProfileClicked?.Invoke(this, EventArgs.Empty);
            btnLogout.Click += (s, e) => LogoutClicked?.Invoke(this, EventArgs.Empty);

            this.Load += MainForm_Load;
            this.FormClosed += MainForm_FormClosed;
            timerDateTime.Tick += TimerDateTime_Tick;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (CurrentUser != null)
            {
                lblWelcome.Text = $"Welcome, {CurrentUser.FullName} ({CurrentUser.Role})";
                HighlightNavigation("Dashboard");
                ShowDashboard();
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void TimerDateTime_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy | hh:mm tt");
        }

        // Implement IMainView methods
        public void ShowDashboard()
        {
            contentPanel.Controls.Clear();
            var dashboardControl = new DashboardControl();
            dashboardControl.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(dashboardControl);
        }
        public void ShowClientManagement()
        {
            contentPanel.Controls.Clear();
            var clientControl = new ClientManagementControl();

            // Create presenter with dependencies
            var clientService = DependencyConfig.CreateClientService();
            var clientPresenter = new ClientManagementPresenter(clientControl, clientService);

            clientControl.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(clientControl);
        }

        public void ShowLoanProcessing()
        {
            contentPanel.Controls.Clear();
            var loanControl = new LoanProcessingControl();

            // Create presenter with dependencies
            var loanService = DependencyConfig.CreateLoanService();
            var loanPresenter = new LoanProcessingPresenter(loanControl, loanService);

            loanControl.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(loanControl);
        }

        public void ShowUserManagement()
        {
            contentPanel.Controls.Clear();
            var userControl = new UserManagementControl(_authService);

            // Create presenter with dependencies
            var userService = DependencyConfig.CreateUserService();
            var userPresenter = new UserManagementPresenter(userControl, userService, _authService);

            userControl.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(userControl);
        }

        public void ShowProfile()
        {
            contentPanel.Controls.Clear();
            Label lbl = new Label();
            lbl.Text = $"User Profile: {CurrentUser.FullName}\nRole: {CurrentUser.Role}";
            lbl.Dock = DockStyle.Fill;
            lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lbl.Font = new System.Drawing.Font("Segoe UI", 16, System.Drawing.FontStyle.Bold);
            lbl.ForeColor = System.Drawing.Color.Gray;
            contentPanel.Controls.Add(lbl);
        }

        public void NavigateToLogin()
        {
            this.Hide();
        }

        // NEW: Implement the missing interface methods
        public void HighlightNavigation(string section)
        {
            Button buttonToHighlight;

            switch (section)
            {
                case "Dashboard":
                    buttonToHighlight = btnDashboard;
                    break;
                case "Clients":
                    buttonToHighlight = btnClients;
                    break;
                case "Loans":
                    buttonToHighlight = btnLoans;
                    break;
                case "Users":
                    buttonToHighlight = btnUsers;
                    break;
                case "Profile":
                    buttonToHighlight = btnProfile;
                    break;
                default:
                    buttonToHighlight = btnDashboard;
                    break;
            }

            HighlightNavButton(buttonToHighlight);
        }

      

        public void DisableUserManagement()
        {
            btnUsers.Enabled = false;
            btnUsers.BackColor = System.Drawing.Color.FromArgb(60, 70, 80);
            btnUsers.ForeColor = System.Drawing.Color.FromArgb(120, 120, 120);
            btnUsers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(60, 70, 80);
        }

        // Helper method for button highlighting
        private void HighlightNavButton(Button button)
        {
            if (!button.Enabled)
                return;

            ResetNavButtons();
            button.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            button.ForeColor = System.Drawing.Color.White;
        }

        // Helper method to reset all buttons
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
    }
}