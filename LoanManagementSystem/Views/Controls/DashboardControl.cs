using LoanManagementSystem.Presenters;
using LoanManagementSystem.Repositories;
using LoanManagementSystem.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoanManagementSystem.Views.Forms
{
    public partial class DashboardControl : UserControl, IDashboardView
    {
        private DashboardPresenter _presenter;

        public DashboardControl()
        {
            InitializeComponent();
            InitializePresenter();
            WireUpEvents();
        }

        private void InitializePresenter()
        {
            var dashboardRepository = new DashboardRepository();
            _presenter = new DashboardPresenter(this, dashboardRepository);
        }

        private void WireUpEvents()
        {
            this.Load += (s, e) => RefreshDashboard();
            lblTotalClients.Click += (s, e) => RefreshDashboard();
            lblTotalLoans.Click += (s, e) => RefreshDashboard();
            lblActiveLoans.Click += (s, e) => RefreshDashboard();
            lblPendingApprovals.Click += (s, e) => RefreshDashboard();
        }

        private void RefreshDashboard()
        {
            _presenter?.Refresh();
        }

        // Implement IDashboardView methods
        public void UpdateStats(int totalClients, int totalLoans, int activeLoans, int pendingApprovals)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => UpdateStats(totalClients, totalLoans, activeLoans, pendingApprovals)));
                return;
            }

            lblTotalClients.Text = $"Total Clients\n{totalClients}";
            lblTotalLoans.Text = $"Total Loans\n{totalLoans}";
            lblActiveLoans.Text = $"Active Loans\n{activeLoans}";
            lblPendingApprovals.Text = $"Pending\n{pendingApprovals}";
        }

        public void ShowError(string message)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => ShowError(message)));
                return;
            }

            MessageBox.Show(message, "Dashboard Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}