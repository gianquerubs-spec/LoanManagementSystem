using LoanManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoanManagementSystem.Views.Interfaces
{
    public interface IClientManagementView
    {
        string SearchTerm { get; }

        event EventHandler LoadClients;
        event EventHandler AddClientClicked;
        event EventHandler EditClientClicked;
        event EventHandler DeleteClientClicked;
        event EventHandler SearchClicked;
        event EventHandler SearchTextChanged;

        void DisplayClients(List<Client> clients);
        Client ShowClientFormDialog(); // For adding - returns Client
        Client ShowClientFormDialog(Client client); // For editing - returns Client
        void ShowMessage(string message, string caption, bool isError = false);
        bool ConfirmAction(string message, string caption);
        void ShowLoading();
        void HideLoading();
        string GetSelectedClientCode();
        void ClearSelection();
    }
}