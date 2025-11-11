using LoanManagementSystem.Repositories;
using LoanManagementSystem.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Presenters
{
    public class DashboardPresenter
    {
        private readonly IDashboardView _view;
        private readonly DashboardRepository _dashboardRepository;

        public DashboardPresenter(IDashboardView view, DashboardRepository dashboardRepository)
        {
            _view = view;
            _dashboardRepository = dashboardRepository;
            LoadDashboardData();
        }

        private void LoadDashboardData()
        {
            var totalClients = _dashboardRepository.GetTotalClients();
            var totalLoans = _dashboardRepository.GetTotalLoans();
            var activeLoans = _dashboardRepository.GetActiveLoans();
            var pendingApprovals = _dashboardRepository.GetPendingApprovals();

            if (totalClients >= 0 && totalLoans >= 0 && activeLoans >= 0 && pendingApprovals >= 0)
            {
                _view.UpdateStats(totalClients, totalLoans, activeLoans, pendingApprovals);
            }
            else
            {
                _view.ShowError("Unable to load dashboard data.");
            }
        }

        public void Refresh()
        {
            LoadDashboardData();
        }
    }
}