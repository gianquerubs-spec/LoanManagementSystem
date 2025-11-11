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

namespace LoanManagementSystem.Views.Forms
{
   public partial class ClientForm : Form
    {
        public Client Client { get; private set; }

        // Constructor for adding new client
        public ClientForm()
        {
            InitializeComponent();
            SetupForm();
        }

        // Constructor for editing existing client
        public ClientForm(Client client) : this()
        {
            Client = client;
            LoadClientData();
        }

        private void SetupForm()
        {
            // Wire up events
            btnSave.Click += btnSave_Click;
            btnCancel.Click += BtnCancel_Click;

            // Set default values
            dtpDateOfBirth.Value = DateTime.Now.AddYears(-25);
            cmbGender.SelectedIndex = 0;
            cmbCivilStatus.SelectedIndex = 0;
            cmbEmploymentStatus.SelectedIndex = 0;
            cmbGovernmentIdType.SelectedIndex = 0;
            cmbCreditRating.SelectedIndex = 2; // Fair
        }

        private void LoadClientData()
        {
            if (Client != null)
            {
                // Original fields
                txtClientCode.Text = Client.ClientCode;
                txtFullName.Text = Client.FullName;
                txtEmail.Text = Client.Email ?? "";
                txtPhone.Text = Client.Phone ?? "";
                txtAddress.Text = Client.Address ?? "";

                // New personal fields
                dtpDateOfBirth.Value = Client.DateOfBirth;
                cmbGender.Text = Client.Gender ?? "";
                cmbCivilStatus.Text = Client.CivilStatus ?? "";

                // New employment and credit fields
                txtOccupation.Text = Client.Occupation ?? "";
                txtEmployer.Text = Client.Employer ?? "";
                txtMonthlyIncome.Text = Client.MonthlyIncome.ToString("0.00");
                cmbEmploymentStatus.Text = Client.EmploymentStatus ?? "";
                cmbGovernmentIdType.Text = Client.GovernmentIdType ?? "";
                txtGovernmentIdNumber.Text = Client.GovernmentIdNumber ?? "";
                txtCreditScore.Text = Client.CreditScore.ToString("0.00");
                cmbCreditRating.Text = Client.CreditRating ?? "";

                // Make ClientCode read-only when editing
                txtClientCode.ReadOnly = true;
                txtClientCode.BackColor = System.Drawing.Color.LightGray;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                SaveClient();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool ValidateForm()
        {
            // Validate Client Code (required for new clients)
            if (Client == null && string.IsNullOrWhiteSpace(txtClientCode.Text))
            {
                MessageBox.Show("Client code is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClientCode.Focus();
                return false;
            }

            // Validate Full Name
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Full name is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return false;
            }

            // Validate Monthly Income
            if (!decimal.TryParse(txtMonthlyIncome.Text, out decimal income) || income < 0)
            {
                MessageBox.Show("Please enter a valid monthly income.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMonthlyIncome.Focus();
                return false;
            }

            // Validate Credit Score
            if (!decimal.TryParse(txtCreditScore.Text, out decimal creditScore) || creditScore < 0 || creditScore > 100)
            {
                MessageBox.Show("Credit score must be between 0 and 100.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCreditScore.Focus();
                return false;
            }

            return true;
        }

        private void SaveClient()
        {
            if (Client == null) // New client
            {
                Client = new Client
                {
                    ClientCode = txtClientCode.Text.Trim(),
                    FullName = txtFullName.Text.Trim(),
                    Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim(),
                    Phone = string.IsNullOrWhiteSpace(txtPhone.Text) ? null : txtPhone.Text.Trim(),
                    Address = string.IsNullOrWhiteSpace(txtAddress.Text) ? null : txtAddress.Text.Trim(),
                    CreatedBy = 1, // Default user ID

                    // New personal fields
                    DateOfBirth = dtpDateOfBirth.Value,
                    Gender = cmbGender.Text,
                    CivilStatus = cmbCivilStatus.Text,

                    // New employment and credit fields
                    Occupation = string.IsNullOrWhiteSpace(txtOccupation.Text) ? null : txtOccupation.Text.Trim(),
                    Employer = string.IsNullOrWhiteSpace(txtEmployer.Text) ? null : txtEmployer.Text.Trim(),
                    MonthlyIncome = decimal.Parse(txtMonthlyIncome.Text),
                    EmploymentStatus = cmbEmploymentStatus.Text,
                    GovernmentIdType = cmbGovernmentIdType.Text,
                    GovernmentIdNumber = string.IsNullOrWhiteSpace(txtGovernmentIdNumber.Text) ? null : txtGovernmentIdNumber.Text.Trim(),
                    CreditScore = decimal.Parse(txtCreditScore.Text),
                    CreditRating = cmbCreditRating.Text
                };
            }
            else // Editing existing client
            {
                // Note: ClientCode should not be changed when editing
                Client.FullName = txtFullName.Text.Trim();
                Client.Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim();
                Client.Phone = string.IsNullOrWhiteSpace(txtPhone.Text) ? null : txtPhone.Text.Trim();
                Client.Address = string.IsNullOrWhiteSpace(txtAddress.Text) ? null : txtAddress.Text.Trim();

                // New personal fields
                Client.DateOfBirth = dtpDateOfBirth.Value;
                Client.Gender = cmbGender.Text;
                Client.CivilStatus = cmbCivilStatus.Text;

                // New employment and credit fields
                Client.Occupation = string.IsNullOrWhiteSpace(txtOccupation.Text) ? null : txtOccupation.Text.Trim();
                Client.Employer = string.IsNullOrWhiteSpace(txtEmployer.Text) ? null : txtEmployer.Text.Trim();
                Client.MonthlyIncome = decimal.Parse(txtMonthlyIncome.Text);
                Client.EmploymentStatus = cmbEmploymentStatus.Text;
                Client.GovernmentIdType = cmbGovernmentIdType.Text;
                Client.GovernmentIdNumber = string.IsNullOrWhiteSpace(txtGovernmentIdNumber.Text) ? null : txtGovernmentIdNumber.Text.Trim();
                Client.CreditScore = decimal.Parse(txtCreditScore.Text);
                Client.CreditRating = cmbCreditRating.Text;
            }
        }
    }
}