using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Views.Interfaces
{
    public interface IDashboardView
    {
        // Just the essential methods
        void UpdateStats(int totalClients, int totalLoans, int activeLoans, int pendingApprovals);
        void ShowError(string message);
    }
}