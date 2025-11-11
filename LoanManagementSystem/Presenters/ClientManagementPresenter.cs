using LoanManagementSystem.Interfaces.Services;
using LoanManagementSystem.Models;
using LoanManagementSystem.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Presenters
{
    public class ClientManagementPresenter
    {
        private readonly IClientManagementView _view;
        private readonly IClientService _clientService;

        public ClientManagementPresenter(IClientManagementView view, IClientService clientService)
        {
            _view = view;
            _clientService = clientService;

            _view.LoadClients += OnLoadClients;
            _view.AddClientClicked += OnAddClientClicked;
            _view.EditClientClicked += OnEditClientClicked;
            _view.DeleteClientClicked += OnDeleteClientClicked;
            _view.SearchClicked += OnSearchClicked;
            _view.SearchTextChanged += OnSearchTextChanged;
        }

        private void OnLoadClients(object sender, EventArgs e)
        {
            LoadClients();
        }

        private void OnAddClientClicked(object sender, EventArgs e)
        {
            AddClient();
        }

        private void OnEditClientClicked(object sender, EventArgs e)
        {
            EditClient();
        }

        private void OnDeleteClientClicked(object sender, EventArgs e)
        {
            DeleteClient();
        }

        private void OnSearchClicked(object sender, EventArgs e)
        {
            SearchClients();
        }

        private void OnSearchTextChanged(object sender, EventArgs e)
        {
            SearchClients();
        }

        private void LoadClients()
        {
            _view.ShowLoading();

            var clients = _clientService.GetAllClients();

            if (clients != null && clients.Any())
            {
                _view.DisplayClients(clients);
            }
            else
            {
                _view.ShowMessage("No clients found.", "Information", false);
            }

            _view.HideLoading();
        }

        private void AddClient()
        {
            var client = _view.ShowClientFormDialog();

            if (client != null)
            {
                _view.ShowLoading();

                bool isAdded = _clientService.AddClient(client, 1); // Default user ID

                _view.HideLoading();

                if (isAdded)
                {
                    _view.ShowMessage("Client added successfully!", "Success", false);
                    LoadClients();
                }
                else
                {
                    _view.ShowMessage("Failed to add client. Client code might already exist.", "Error", true);
                }
            }
        }

        private void EditClient()
        {
            string clientCode = _view.GetSelectedClientCode();

            if (string.IsNullOrEmpty(clientCode))
            {
                _view.ShowMessage("Please select a client to edit.", "No Selection", false);
                return;
            }

            _view.ShowLoading();

            var existingClient = _clientService.GetClientByCode(clientCode);

            _view.HideLoading();

            if (existingClient == null)
            {
                _view.ShowMessage("Client not found.", "Error", true);
                return;
            }

            var updatedClient = _view.ShowClientFormDialog(existingClient);

            if (updatedClient != null)
            {
                _view.ShowLoading();

                // Ensure the ID is set for update
                updatedClient.Id = existingClient.Id;

                bool isUpdated = _clientService.UpdateClient(updatedClient);

                _view.HideLoading();

                if (isUpdated)
                {
                    _view.ShowMessage("Client updated successfully!", "Success", false);
                    LoadClients();
                }
                else
                {
                    _view.ShowMessage("Failed to update client.", "Error", true);
                }
            }
        }

        private void DeleteClient()
        {
            string clientCode = _view.GetSelectedClientCode();

            if (string.IsNullOrEmpty(clientCode))
            {
                _view.ShowMessage("Please select a client to delete.", "No Selection", false);
                return;
            }

            var confirm = _view.ConfirmAction("Are you sure you want to delete this client?", "Confirm Delete");

            if (!confirm)
            {
                return;
            }

            _view.ShowLoading();

            bool isDeleted = _clientService.DeleteClientByCode(clientCode);

            _view.HideLoading();

            if (isDeleted)
            {
                _view.ShowMessage("Client deleted successfully!", "Success", false);
                LoadClients();
            }
            else
            {
                _view.ShowMessage("Failed to delete client. The client may have existing loans.", "Error", true);
            }
        }

        private void SearchClients()
        {
            string term = _view.SearchTerm?.Trim();

            if (string.IsNullOrWhiteSpace(term))
            {
                LoadClients();
                return;
            }

            _view.ShowLoading();

            var clients = _clientService.SearchClients(term);

            _view.DisplayClients(clients);
            _view.HideLoading();
        }
    }
}