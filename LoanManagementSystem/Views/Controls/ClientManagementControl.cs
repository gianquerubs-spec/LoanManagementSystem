using LoanManagementSystem.Models;
using LoanManagementSystem.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LoanManagementSystem.Views.Forms
{
    public partial class ClientManagementControl : UserControl, IClientManagementView
    {
        // IClientManagementView implementation
        public string SearchTerm => txtSearch.Text;

        public event EventHandler LoadClients;
        public event EventHandler AddClientClicked;
        public event EventHandler EditClientClicked;
        public event EventHandler DeleteClientClicked;
        public event EventHandler SearchClicked;
        public event EventHandler SearchTextChanged;

        public ClientManagementControl()
        {
            InitializeComponent();
            WireUpEvents();
        }

        private void WireUpEvents()
        {
            // Wire up UI events to interface events
            this.Load += (s, e) => LoadClients?.Invoke(this, EventArgs.Empty);
            btnAddClient.Click += (s, e) => AddClientClicked?.Invoke(this, EventArgs.Empty);
            btnEditClient.Click += (s, e) => EditClientClicked?.Invoke(this, EventArgs.Empty);
            btnDeleteClient.Click += (s, e) => DeleteClientClicked?.Invoke(this, EventArgs.Empty);
            btnSearch.Click += (s, e) => SearchClicked?.Invoke(this, EventArgs.Empty);
            txtSearch.TextChanged += (s, e) => SearchTextChanged?.Invoke(this, EventArgs.Empty);
        }

        // IClientManagementView method implementations
        public void DisplayClients(List<Client> clients)
        {
            dataGridViewClients.Rows.Clear();

            foreach (var client in clients)
            {
                dataGridViewClients.Rows.Add(
                    client.ClientCode,
                    client.FullName,
                    client.Email,
                    client.Phone,
                    client.Address
                );
            }
        }

        // For adding new client
        public Client ShowClientFormDialog()
        {
            using (var clientForm = new ClientForm())
            {
                var result = clientForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    return clientForm.Client;
                }
            }
            return null;
        }

        // For editing existing client
        public Client ShowClientFormDialog(Client client)
        {
            using (var clientForm = new ClientForm(client))
            {
                var result = clientForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    return clientForm.Client;
                }
            }
            return null;
        }

        public void ShowMessage(string message, string caption, bool isError = false)
        {
            MessageBox.Show(
                message,
                caption,
                MessageBoxButtons.OK,
                isError ? MessageBoxIcon.Error : MessageBoxIcon.Information
            );
        }

        public bool ConfirmAction(string message, string caption)
        {
            var result = MessageBox.Show(
                message,
                caption,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            return result == DialogResult.Yes;
        }

        public void ShowLoading()
        {
            Cursor = Cursors.WaitCursor;
        }

        public void HideLoading()
        {
            Cursor = Cursors.Default;
        }

        public string GetSelectedClientCode()
        {
            if (dataGridViewClients.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewClients.SelectedRows[0];
                var cellValue = selectedRow.Cells["colClientCode"].Value;
                return cellValue?.ToString() ?? string.Empty;
            }

            // Also check if a cell is selected
            if (dataGridViewClients.SelectedCells.Count > 0)
            {
                var selectedCell = dataGridViewClients.SelectedCells[0];
                var row = dataGridViewClients.Rows[selectedCell.RowIndex];
                var cellValue = row.Cells["colClientCode"].Value;
                return cellValue?.ToString() ?? string.Empty;
            }

            return null;
        }

        public void ClearSelection()
        {
            dataGridViewClients.ClearSelection();
        }
    }
}