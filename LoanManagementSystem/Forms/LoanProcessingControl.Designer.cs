namespace LoanManagementSystem.Forms
{
    partial class LoanProcessingControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dataGridViewLoans;
        private System.Windows.Forms.Button btnNewLoan;
        private System.Windows.Forms.Button btnApproveLoan;
        private System.Windows.Forms.Button btnRejectLoan;
        private System.Windows.Forms.Button btnViewDetails;
        private System.Windows.Forms.ComboBox cmbFilterStatus;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Panel panelLoanDetails;
        private System.Windows.Forms.Label lblLoanDetails;
        private System.Windows.Forms.Label lblClientName;
        private System.Windows.Forms.Label lblLoanAmount;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblApplicationDate;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.dataGridViewLoans = new System.Windows.Forms.DataGridView();
            this.btnNewLoan = new System.Windows.Forms.Button();
            this.btnApproveLoan = new System.Windows.Forms.Button();
            this.btnRejectLoan = new System.Windows.Forms.Button();
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.cmbFilterStatus = new System.Windows.Forms.ComboBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.panelLoanDetails = new System.Windows.Forms.Panel();
            this.lblApplicationDate = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblLoanAmount = new System.Windows.Forms.Label();
            this.lblClientName = new System.Windows.Forms.Label();
            this.lblLoanDetails = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLoans)).BeginInit();
            this.panelLoanDetails.SuspendLayout();
            this.SuspendLayout();

            // LoanProcessingControl
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelLoanDetails);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.cmbFilterStatus);
            this.Controls.Add(this.btnViewDetails);
            this.Controls.Add(this.btnRejectLoan);
            this.Controls.Add(this.btnApproveLoan);
            this.Controls.Add(this.btnNewLoan);
            this.Controls.Add(this.dataGridViewLoans);
            this.Controls.Add(this.lblTitle);
            this.Name = "LoanProcessingControl";
            this.Size = new System.Drawing.Size(900, 600);

            // lblTitle
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 40, 50);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(300, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "💰 Loan Processing";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // dataGridViewLoans
            this.dataGridViewLoans.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewLoans.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewLoans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLoans.Location = new System.Drawing.Point(20, 120);
            this.dataGridViewLoans.Name = "dataGridViewLoans";
            this.dataGridViewLoans.Size = new System.Drawing.Size(860, 250);
            this.dataGridViewLoans.TabIndex = 1;
            this.dataGridViewLoans.SelectionChanged += new System.EventHandler(this.DataGridViewLoans_SelectionChanged);

            // btnNewLoan
            this.btnNewLoan.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnNewLoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewLoan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewLoan.ForeColor = System.Drawing.Color.White;
            this.btnNewLoan.Location = new System.Drawing.Point(20, 70);
            this.btnNewLoan.Name = "btnNewLoan";
            this.btnNewLoan.Size = new System.Drawing.Size(120, 35);
            this.btnNewLoan.TabIndex = 2;
            this.btnNewLoan.Text = "➕ New Loan";
            this.btnNewLoan.UseVisualStyleBackColor = false;
            this.btnNewLoan.Click += new System.EventHandler(this.BtnNewLoan_Click);

            // btnApproveLoan
            this.btnApproveLoan.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnApproveLoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApproveLoan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApproveLoan.ForeColor = System.Drawing.Color.White;
            this.btnApproveLoan.Location = new System.Drawing.Point(150, 70);
            this.btnApproveLoan.Name = "btnApproveLoan";
            this.btnApproveLoan.Size = new System.Drawing.Size(120, 35);
            this.btnApproveLoan.TabIndex = 3;
            this.btnApproveLoan.Text = "✅ Approve";
            this.btnApproveLoan.UseVisualStyleBackColor = false;
            this.btnApproveLoan.Click += new System.EventHandler(this.BtnApproveLoan_Click);

            // btnRejectLoan
            this.btnRejectLoan.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnRejectLoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRejectLoan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRejectLoan.ForeColor = System.Drawing.Color.White;
            this.btnRejectLoan.Location = new System.Drawing.Point(280, 70);
            this.btnRejectLoan.Name = "btnRejectLoan";
            this.btnRejectLoan.Size = new System.Drawing.Size(120, 35);
            this.btnRejectLoan.TabIndex = 4;
            this.btnRejectLoan.Text = "❌ Reject";
            this.btnRejectLoan.UseVisualStyleBackColor = false;
            this.btnRejectLoan.Click += new System.EventHandler(this.BtnRejectLoan_Click);

            // btnViewDetails
            this.btnViewDetails.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.btnViewDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewDetails.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewDetails.ForeColor = System.Drawing.Color.White;
            this.btnViewDetails.Location = new System.Drawing.Point(410, 70);
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Size = new System.Drawing.Size(120, 35);
            this.btnViewDetails.TabIndex = 5;
            this.btnViewDetails.Text = "👁️ View Details";
            this.btnViewDetails.UseVisualStyleBackColor = false;
            this.btnViewDetails.Click += new System.EventHandler(this.BtnViewDetails_Click);

            // cmbFilterStatus
            this.cmbFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFilterStatus.FormattingEnabled = true;
            this.cmbFilterStatus.Items.AddRange(new object[] {
            "All",
            "Pending",
            "Approved",
            "Rejected",
            "Active",
            "Completed"});
            this.cmbFilterStatus.Location = new System.Drawing.Point(680, 73);
            this.cmbFilterStatus.Name = "cmbFilterStatus";
            this.cmbFilterStatus.Size = new System.Drawing.Size(150, 25);
            this.cmbFilterStatus.TabIndex = 6;
            this.cmbFilterStatus.SelectedIndexChanged += new System.EventHandler(this.CmbFilterStatus_SelectedIndexChanged);

            // lblFilter
            this.lblFilter.AutoSize = true;
            this.lblFilter.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilter.Location = new System.Drawing.Point(600, 76);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(74, 19);
            this.lblFilter.TabIndex = 7;
            this.lblFilter.Text = "Filter by:";

            // panelLoanDetails
            this.panelLoanDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelLoanDetails.BackColor = System.Drawing.Color.FromArgb(240, 244, 247);
            this.panelLoanDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLoanDetails.Controls.Add(this.lblApplicationDate);
            this.panelLoanDetails.Controls.Add(this.lblStatus);
            this.panelLoanDetails.Controls.Add(this.lblLoanAmount);
            this.panelLoanDetails.Controls.Add(this.lblClientName);
            this.panelLoanDetails.Controls.Add(this.lblLoanDetails);
            this.panelLoanDetails.Location = new System.Drawing.Point(20, 390);
            this.panelLoanDetails.Name = "panelLoanDetails";
            this.panelLoanDetails.Size = new System.Drawing.Size(860, 190);
            this.panelLoanDetails.TabIndex = 8;

            // lblLoanDetails
            this.lblLoanDetails.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoanDetails.ForeColor = System.Drawing.Color.FromArgb(30, 40, 50);
            this.lblLoanDetails.Location = new System.Drawing.Point(20, 15);
            this.lblLoanDetails.Name = "lblLoanDetails";
            this.lblLoanDetails.Size = new System.Drawing.Size(200, 25);
            this.lblLoanDetails.TabIndex = 0;
            this.lblLoanDetails.Text = "Loan Details";
            this.lblLoanDetails.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // lblClientName
            this.lblClientName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientName.Location = new System.Drawing.Point(20, 50);
            this.lblClientName.Name = "lblClientName";
            this.lblClientName.Size = new System.Drawing.Size(400, 25);
            this.lblClientName.TabIndex = 1;
            this.lblClientName.Text = "Client: ";
            this.lblClientName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // lblLoanAmount
            this.lblLoanAmount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoanAmount.Location = new System.Drawing.Point(20, 80);
            this.lblLoanAmount.Name = "lblLoanAmount";
            this.lblLoanAmount.Size = new System.Drawing.Size(400, 25);
            this.lblLoanAmount.TabIndex = 2;
            this.lblLoanAmount.Text = "Loan Amount: ";
            this.lblLoanAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // lblStatus
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(20, 110);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(400, 25);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Status: ";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // lblApplicationDate
            this.lblApplicationDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationDate.Location = new System.Drawing.Point(20, 140);
            this.lblApplicationDate.Name = "lblApplicationDate";
            this.lblApplicationDate.Size = new System.Drawing.Size(400, 25);
            this.lblApplicationDate.TabIndex = 4;
            this.lblApplicationDate.Text = "Application Date: ";
            this.lblApplicationDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLoans)).EndInit();
            this.panelLoanDetails.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}