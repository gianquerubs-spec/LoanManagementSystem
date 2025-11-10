using LoanManagementSystem.Models;
using LoanManagementSystem.Services;
using LoanManagementSystem.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoanManagementSystem.Forms
{
    public partial class ClientManagementControl : UserControl
    {
        private ClientService _clientService;
        private Timer searchTimer;

        public ClientManagementControl()
        {
            InitializeComponent();
            _clientService = new ClientService();

           
            searchTimer = new Timer();
            searchTimer.Interval = 500; 
            searchTimer.Tick += SearchTimer_Tick;

           
            SetupDataGridView();
            LoadClients();
        }

        // datagrid design
        private void SetupDataGridView()
        {
            dataGridViewClients.AutoGenerateColumns = false;
            dataGridViewClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewClients.MultiSelect = false;
            dataGridViewClients.AllowUserToAddRows = false;
            dataGridViewClients.ReadOnly = true;
            dataGridViewClients.RowHeadersVisible = false;

            dataGridViewClients.Columns.Clear();
            dataGridViewClients.Columns.Add("ClientCode", "Client Code");
            dataGridViewClients.Columns.Add("FullName", "Full Name");
            dataGridViewClients.Columns.Add("Email", "Email");
            dataGridViewClients.Columns.Add("Phone", "Phone");
            dataGridViewClients.Columns.Add("Address", "Address");

            // auto-size columns
            foreach (DataGridViewColumn col in dataGridViewClients.Columns)
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        //load all clients
        private void LoadClients()
        {
            dataGridViewClients.Rows.Clear();
            var clients = _clientService.GetAllClients();

            foreach (var c in clients)
            {
                dataGridViewClients.Rows.Add(
                    c.ClientCode,
                    c.FullName,
                    c.Email,
                    c.Phone,
                    c.Address
                );
            }
        }

        // add Client Button
        private void BtnAddClient_Click(object sender, EventArgs e)
        {
            using (var clientForm = new ClientForm())
            {
                if (clientForm.ShowDialog() == DialogResult.OK)
                {
                    var newClient = clientForm.Client;
                    newClient.ClientCode = _clientService.GenerateClientCode();
                    newClient.CreatedAt = DateTime.Now;
                    newClient.CreatedBy = 1;

                    bool added = _clientService.AddClient(newClient, 1);
                    if (added)
                    {
                        MessageBox.Show($"Client added successfully! Client Code: {newClient.ClientCode}", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadClients();
                    }
                    else
                    {
                        MessageBox.Show("Failed to add client.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // edit Client Button
        private void BtnEditClient_Click(object sender, EventArgs e)
        {
            if (dataGridViewClients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a client to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string clientCode = dataGridViewClients.SelectedRows[0].Cells["ClientCode"].Value.ToString();
            var client = _clientService.GetClientByCode(clientCode);

            if (client == null)
            {
                MessageBox.Show("Client not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var clientForm = new ClientForm(client))
            {
                if (clientForm.ShowDialog() == DialogResult.OK)
                {
                    bool updated = _clientService.UpdateClient(clientForm.Client);
                    if (updated)
                    {
                        MessageBox.Show("Client updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadClients();
                    }
                    else
                    {
                        MessageBox.Show("Failed to update client.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // delete Client Button
        private void BtnDeleteClient_Click(object sender, EventArgs e)
        {
            if (dataGridViewClients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a client to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string clientCode = dataGridViewClients.SelectedRows[0].Cells["ClientCode"].Value.ToString();
            var confirm = MessageBox.Show("Are you sure you want to delete this client?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                bool deleted = _clientService.DeleteClientByCode(clientCode);
                if (deleted)
                {
                    MessageBox.Show("Client deleted successfully!", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadClients();
                }
                else
                {
                    MessageBox.Show("Failed to delete client. Client may have existing loans.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // live search
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            searchTimer.Stop();
            searchTimer.Start();
        }

        // for delayed search
        private void SearchTimer_Tick(object sender, EventArgs e)
        {
            searchTimer.Stop();
            PerformSearch();
        }

        private void PerformSearch()
        {
            string term = txtSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(term))
            {
                LoadClients();
                return;
            }

            var clients = _clientService.SearchClients(term);

            dataGridViewClients.Rows.Clear();
            foreach (var c in clients)
            {
                dataGridViewClients.Rows.Add(
                    c.ClientCode,
                    c.FullName,
                    c.Email,
                    c.Phone,
                    c.Address
                );
            }
        }

        // search Button
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            PerformSearch();
        }
    }
}