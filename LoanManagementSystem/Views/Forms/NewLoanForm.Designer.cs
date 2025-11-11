using System.Windows.Forms;

namespace LoanManagementSystem.Views.Forms
{
    partial class NewLoanForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel panelHeader;
        private Label lblTitle;
        private Panel panelMain;
        private ComboBox cmbClient;
        private TextBox txtLoanAmount;
        private TextBox txtTerm;
        private TextBox txtNotes;
        private Button btnSubmit;
        private Button btnCancel;
        private Label lblMonthlyPaymentValue;
        private Label lblTotalRepaymentValue;
        private Label lblTotalInterestValue;
        private Label lblInterestRateValue;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Panel panelCalculation;
        private Label label9;
        private TextBox txtInterestRate;

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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelCalculation = new System.Windows.Forms.Panel();
            this.lblInterestRateValue = new System.Windows.Forms.Label();
            this.lblTotalInterestValue = new System.Windows.Forms.Label();
            this.lblTotalRepaymentValue = new System.Windows.Forms.Label();
            this.lblMonthlyPaymentValue = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtInterestRate = new System.Windows.Forms.TextBox();
            this.txtTerm = new System.Windows.Forms.TextBox();
            this.txtLoanAmount = new System.Windows.Forms.TextBox();
            this.cmbClient = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelCalculation.SuspendLayout();
            this.SuspendLayout();

            // panelHeader
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(500, 60);
            this.panelHeader.TabIndex = 0;

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(205, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "New Loan Application";

            // panelMain
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.panelCalculation);
            this.panelMain.Controls.Add(this.label5);
            this.panelMain.Controls.Add(this.txtNotes);
            this.panelMain.Controls.Add(this.label4);
            this.panelMain.Controls.Add(this.txtInterestRate);
            this.panelMain.Controls.Add(this.txtTerm);
            this.panelMain.Controls.Add(this.txtLoanAmount);
            this.panelMain.Controls.Add(this.cmbClient);
            this.panelMain.Controls.Add(this.label3);
            this.panelMain.Controls.Add(this.label2);
            this.panelMain.Controls.Add(this.label1);
            this.panelMain.Controls.Add(this.btnCancel);
            this.panelMain.Controls.Add(this.btnSubmit);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 60);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(20);
            this.panelMain.Size = new System.Drawing.Size(500, 540);
            this.panelMain.TabIndex = 1;

            // panelCalculation
            this.panelCalculation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            this.panelCalculation.Controls.Add(this.lblInterestRateValue);
            this.panelCalculation.Controls.Add(this.lblTotalInterestValue);
            this.panelCalculation.Controls.Add(this.lblTotalRepaymentValue);
            this.panelCalculation.Controls.Add(this.lblMonthlyPaymentValue);
            this.panelCalculation.Controls.Add(this.label9);
            this.panelCalculation.Controls.Add(this.label8);
            this.panelCalculation.Controls.Add(this.label7);
            this.panelCalculation.Controls.Add(this.label6);
            this.panelCalculation.Location = new System.Drawing.Point(23, 230);
            this.panelCalculation.Name = "panelCalculation";
            this.panelCalculation.Size = new System.Drawing.Size(454, 120);
            this.panelCalculation.TabIndex = 12;

            // lblInterestRateValue
            this.lblInterestRateValue.AutoSize = true;
            this.lblInterestRateValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblInterestRateValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblInterestRateValue.Location = new System.Drawing.Point(280, 20);
            this.lblInterestRateValue.Name = "lblInterestRateValue";
            this.lblInterestRateValue.Size = new System.Drawing.Size(47, 19);
            this.lblInterestRateValue.TabIndex = 7;
            this.lblInterestRateValue.Text = "0.00%";

            // lblTotalInterestValue
            this.lblTotalInterestValue.AutoSize = true;
            this.lblTotalInterestValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalInterestValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblTotalInterestValue.Location = new System.Drawing.Point(280, 90);
            this.lblTotalInterestValue.Name = "lblTotalInterestValue";
            this.lblTotalInterestValue.Size = new System.Drawing.Size(42, 19);
            this.lblTotalInterestValue.TabIndex = 6;
            this.lblTotalInterestValue.Text = "$0.00";

            // lblTotalRepaymentValue
            this.lblTotalRepaymentValue.AutoSize = true;
            this.lblTotalRepaymentValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalRepaymentValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblTotalRepaymentValue.Location = new System.Drawing.Point(280, 65);
            this.lblTotalRepaymentValue.Name = "lblTotalRepaymentValue";
            this.lblTotalRepaymentValue.Size = new System.Drawing.Size(42, 19);
            this.lblTotalRepaymentValue.TabIndex = 5;
            this.lblTotalRepaymentValue.Text = "$0.00";

            // lblMonthlyPaymentValue
            this.lblMonthlyPaymentValue.AutoSize = true;
            this.lblMonthlyPaymentValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMonthlyPaymentValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblMonthlyPaymentValue.Location = new System.Drawing.Point(280, 40);
            this.lblMonthlyPaymentValue.Name = "lblMonthlyPaymentValue";
            this.lblMonthlyPaymentValue.Size = new System.Drawing.Size(42, 19);
            this.lblMonthlyPaymentValue.TabIndex = 4;
            this.lblMonthlyPaymentValue.Text = "$0.00";

            // label9
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label9.Location = new System.Drawing.Point(20, 90);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 15);
            this.label9.TabIndex = 3;
            this.label9.Text = "Total Interest:";

            // label8
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label8.Location = new System.Drawing.Point(20, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 15);
            this.label8.TabIndex = 2;
            this.label8.Text = "Total Repayment:";

            // label7
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label7.Location = new System.Drawing.Point(20, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 15);
            this.label7.TabIndex = 1;
            this.label7.Text = "Monthly Payment:";

            // label6
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label6.Location = new System.Drawing.Point(20, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Interest Rate:";

            // label5
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(20, 370);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Notes:";

            // txtNotes
            this.txtNotes.Location = new System.Drawing.Point(23, 390);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.Size = new System.Drawing.Size(454, 80);
            this.txtNotes.TabIndex = 4;

            // label4
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(20, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Term (Months):";

            // txtInterestRate
            this.txtInterestRate.Location = new System.Drawing.Point(280, 120);
            this.txtInterestRate.Name = "txtInterestRate";
            this.txtInterestRate.ReadOnly = true;
            this.txtInterestRate.Size = new System.Drawing.Size(197, 23);
            this.txtInterestRate.TabIndex = 8;
            this.txtInterestRate.TabStop = false;

            // txtTerm
            this.txtTerm.Location = new System.Drawing.Point(23, 180);
            this.txtTerm.Name = "txtTerm";
            this.txtTerm.Size = new System.Drawing.Size(197, 23);
            this.txtTerm.TabIndex = 2;
            this.txtTerm.TextChanged += new System.EventHandler(this.TxtTerm_TextChanged);
            this.txtTerm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtTerm_KeyPress);

            // txtLoanAmount
            this.txtLoanAmount.Location = new System.Drawing.Point(23, 120);
            this.txtLoanAmount.Name = "txtLoanAmount";
            this.txtLoanAmount.Size = new System.Drawing.Size(197, 23);
            this.txtLoanAmount.TabIndex = 1;
            this.txtLoanAmount.TextChanged += new System.EventHandler(this.TxtLoanAmount_TextChanged);
            this.txtLoanAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtLoanAmount_KeyPress);

            // cmbClient
            this.cmbClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClient.FormattingEnabled = true;
            this.cmbClient.Location = new System.Drawing.Point(23, 60);
            this.cmbClient.Name = "cmbClient";
            this.cmbClient.Size = new System.Drawing.Size(454, 23);
            this.cmbClient.TabIndex = 0;

            // label3
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(280, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Interest Rate:";

            // label2
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(20, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Loan Amount:";

            // label1
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(20, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Client:";

            // btnCancel
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(263, 490);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);

            // btnSubmit
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(377, 490);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(100, 35);
            this.btnSubmit.TabIndex = 5;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.BtnSubmit_Click);

            // NewLoanForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 600);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewLoanForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Loan Application";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelCalculation.ResumeLayout(false);
            this.panelCalculation.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}