using LoanManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoanManagementSystem.Forms
{
    public partial class ClientForm : Form
    {
        public Client Client { get; private set; }
        private readonly bool _isEdit;

        public ClientForm() : this(null) { }

        public ClientForm(Client client)
        {
            InitializeComponent();
            if (client == null)
            {
                _isEdit = false;
                Client = new Client();
                this.Text = "Add Client";
            }
            else
            {
                _isEdit = true;
                Client = client;
                this.Text = "Edit Client";
                PopulateFields();
            }
        }

        private void PopulateFields()
        {
            txtClientCode.Text = Client.ClientCode;
            txtFullName.Text = Client.FullName;
            txtEmail.Text = Client.Email;
            txtPhone.Text = Client.Phone;
            txtAddress.Text = Client.Address;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Full name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Client.ClientCode = txtClientCode.Text.Trim();
            Client.FullName = txtFullName.Text.Trim();
            Client.Email = txtEmail.Text.Trim();
            Client.Phone = txtPhone.Text.Trim();
            Client.Address = txtAddress.Text.Trim();

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        // Helper method to format currency as Philippine Peso
        private string FormatCurrency(decimal amount)
        {
            return $"₱{amount:N2}";
        }
    }
}