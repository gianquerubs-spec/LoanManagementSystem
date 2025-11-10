using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoanManagementSystem.Repositories;

namespace LoanManagementSystem.Forms
{
    public partial class DashboardControl : UserControl
    {
        private readonly DashboardRepository _dashboardRepo;

        public DashboardControl()
        {
            InitializeComponent();
            _dashboardRepo = new DashboardRepository();
        }

        private void DashboardControl_Load(object sender, EventArgs e)
        {
            // Load data once when control is shown
            RefreshStats();
        }

        // refresh stats (after changes)
        public void RefreshStats()
        {
            // Get counts from repository
            int totalClients = _dashboardRepo.GetTotalClients();
            int totalLoans = _dashboardRepo.GetTotalLoans();
            int activeLoans = _dashboardRepo.GetActiveLoans();
            int pendingApprovals = _dashboardRepo.GetPendingApprovals();

           
            lblTotalClients.Text = $"Total Clients\n{totalClients}";
            lblTotalLoans.Text = $"Total Loans\n{totalLoans}";
            lblActiveLoans.Text = $"Active Loans\n{activeLoans}";
            lblPendingApprovals.Text = $"Pending\n{pendingApprovals}";
        }

        private void lblTotalClients_Click(object sender, EventArgs e)
        {
           // clicking can refresh
            RefreshStats();
        }
    }
}