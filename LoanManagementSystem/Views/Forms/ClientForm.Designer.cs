using System.Windows.Forms;

namespace LoanManagementSystem.Views.Forms
{
    partial class ClientForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel panelHeader;
        private Label lblTitle;
        private Panel panelMain;
        private TabControl tabControl1;
        private TabPage tabPersonalInfo;
        private TabPage tabEmploymentCredit;
        private TextBox txtClientCode;
        private TextBox txtFullName;
        private TextBox txtEmail;
        private TextBox txtPhone;
        private TextBox txtAddress;
        private Button btnSave;
        private Button btnCancel;
        private Label lblClientCode;
        private Label lblFullName;
        private Label lblEmail;
        private Label lblPhone;
        private Label lblAddress;

        // New controls for personal info
        private DateTimePicker dtpDateOfBirth;
        private ComboBox cmbGender;
        private ComboBox cmbCivilStatus;
        private Label lblDateOfBirth;
        private Label lblGender;
        private Label lblCivilStatus;

        // New controls for employment & credit
        private TextBox txtOccupation;
        private TextBox txtEmployer;
        private TextBox txtMonthlyIncome;
        private ComboBox cmbEmploymentStatus;
        private ComboBox cmbGovernmentIdType;
        private TextBox txtGovernmentIdNumber;
        private TextBox txtCreditScore;
        private ComboBox cmbCreditRating;
        private Label lblOccupation;
        private Label lblEmployer;
        private Label lblMonthlyIncome;
        private Label lblEmploymentStatus;
        private Label lblGovernmentIdType;
        private Label lblGovernmentIdNumber;
        private Label lblCreditScore;
        private Label lblCreditRating;

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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPersonalInfo = new System.Windows.Forms.TabPage();
            this.lblCivilStatus = new System.Windows.Forms.Label();
            this.cmbCivilStatus = new System.Windows.Forms.ComboBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.lblDateOfBirth = new System.Windows.Forms.Label();
            this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblClientCode = new System.Windows.Forms.Label();
            this.txtClientCode = new System.Windows.Forms.TextBox();
            this.tabEmploymentCredit = new System.Windows.Forms.TabPage();
            this.lblCreditRating = new System.Windows.Forms.Label();
            this.cmbCreditRating = new System.Windows.Forms.ComboBox();
            this.lblCreditScore = new System.Windows.Forms.Label();
            this.txtCreditScore = new System.Windows.Forms.TextBox();
            this.lblGovernmentIdNumber = new System.Windows.Forms.Label();
            this.txtGovernmentIdNumber = new System.Windows.Forms.TextBox();
            this.lblGovernmentIdType = new System.Windows.Forms.Label();
            this.cmbGovernmentIdType = new System.Windows.Forms.ComboBox();
            this.lblEmploymentStatus = new System.Windows.Forms.Label();
            this.cmbEmploymentStatus = new System.Windows.Forms.ComboBox();
            this.lblMonthlyIncome = new System.Windows.Forms.Label();
            this.txtMonthlyIncome = new System.Windows.Forms.TextBox();
            this.lblEmployer = new System.Windows.Forms.Label();
            this.txtEmployer = new System.Windows.Forms.TextBox();
            this.lblOccupation = new System.Windows.Forms.Label();
            this.txtOccupation = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();

            this.panelHeader.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPersonalInfo.SuspendLayout();
            this.tabEmploymentCredit.SuspendLayout();
            this.SuspendLayout();

            // ClientForm
            this.ClientSize = new System.Drawing.Size(500, 600);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Client Information";

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
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(175, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Client Information";

            // panelMain
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.tabControl1);
            this.panelMain.Controls.Add(this.btnCancel);
            this.panelMain.Controls.Add(this.btnSave);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 60);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(20);
            this.panelMain.Size = new System.Drawing.Size(500, 540);
            this.panelMain.TabIndex = 1;

            // tabControl1
            this.tabControl1.Controls.Add(this.tabPersonalInfo);
            this.tabControl1.Controls.Add(this.tabEmploymentCredit);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(20, 20);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(460, 420);
            this.tabControl1.TabIndex = 2;

            // tabPersonalInfo
            this.tabPersonalInfo.Controls.Add(this.lblCivilStatus);
            this.tabPersonalInfo.Controls.Add(this.cmbCivilStatus);
            this.tabPersonalInfo.Controls.Add(this.lblGender);
            this.tabPersonalInfo.Controls.Add(this.cmbGender);
            this.tabPersonalInfo.Controls.Add(this.lblDateOfBirth);
            this.tabPersonalInfo.Controls.Add(this.dtpDateOfBirth);
            this.tabPersonalInfo.Controls.Add(this.lblAddress);
            this.tabPersonalInfo.Controls.Add(this.txtAddress);
            this.tabPersonalInfo.Controls.Add(this.lblPhone);
            this.tabPersonalInfo.Controls.Add(this.txtPhone);
            this.tabPersonalInfo.Controls.Add(this.lblEmail);
            this.tabPersonalInfo.Controls.Add(this.txtEmail);
            this.tabPersonalInfo.Controls.Add(this.lblFullName);
            this.tabPersonalInfo.Controls.Add(this.txtFullName);
            this.tabPersonalInfo.Controls.Add(this.lblClientCode);
            this.tabPersonalInfo.Controls.Add(this.txtClientCode);
            this.tabPersonalInfo.Location = new System.Drawing.Point(4, 24);
            this.tabPersonalInfo.Name = "tabPersonalInfo";
            this.tabPersonalInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPersonalInfo.Size = new System.Drawing.Size(452, 392);
            this.tabPersonalInfo.TabIndex = 0;
            this.tabPersonalInfo.Text = "Personal Information";
            this.tabPersonalInfo.UseVisualStyleBackColor = true;

            // Personal Info Controls (positioning similar to your original layout)
            this.lblClientCode.Location = new System.Drawing.Point(20, 20);
            this.lblClientCode.Size = new System.Drawing.Size(100, 20);
            this.lblClientCode.Text = "Client Code:";

            this.txtClientCode.Location = new System.Drawing.Point(130, 17);
            this.txtClientCode.Size = new System.Drawing.Size(300, 23);

            // ... (similar positioning for all personal info controls)

            // tabEmploymentCredit
            this.tabEmploymentCredit.Controls.Add(this.lblCreditRating);
            this.tabEmploymentCredit.Controls.Add(this.cmbCreditRating);
            this.tabEmploymentCredit.Controls.Add(this.lblCreditScore);
            this.tabEmploymentCredit.Controls.Add(this.txtCreditScore);
            this.tabEmploymentCredit.Controls.Add(this.lblGovernmentIdNumber);
            this.tabEmploymentCredit.Controls.Add(this.txtGovernmentIdNumber);
            this.tabEmploymentCredit.Controls.Add(this.lblGovernmentIdType);
            this.tabEmploymentCredit.Controls.Add(this.cmbGovernmentIdType);
            this.tabEmploymentCredit.Controls.Add(this.lblEmploymentStatus);
            this.tabEmploymentCredit.Controls.Add(this.cmbEmploymentStatus);
            this.tabEmploymentCredit.Controls.Add(this.lblMonthlyIncome);
            this.tabEmploymentCredit.Controls.Add(this.txtMonthlyIncome);
            this.tabEmploymentCredit.Controls.Add(this.lblEmployer);
            this.tabEmploymentCredit.Controls.Add(this.txtEmployer);
            this.tabEmploymentCredit.Controls.Add(this.lblOccupation);
            this.tabEmploymentCredit.Controls.Add(this.txtOccupation);
            this.tabEmploymentCredit.Location = new System.Drawing.Point(4, 24);
            this.tabEmploymentCredit.Name = "tabEmploymentCredit";
            this.tabEmploymentCredit.Padding = new System.Windows.Forms.Padding(3);
            this.tabEmploymentCredit.Size = new System.Drawing.Size(452, 392);
            this.tabEmploymentCredit.TabIndex = 1;
            this.tabEmploymentCredit.Text = "Employment & Credit";
            this.tabEmploymentCredit.UseVisualStyleBackColor = true;

            // Employment & Credit Controls
            this.lblOccupation.Location = new System.Drawing.Point(20, 20);
            this.lblOccupation.Size = new System.Drawing.Size(100, 20);
            this.lblOccupation.Text = "Occupation:";

            this.txtOccupation.Location = new System.Drawing.Point(130, 17);
            this.txtOccupation.Size = new System.Drawing.Size(300, 23);

            // ... (similar positioning for all employment/credit controls)

            // ComboBox items
            this.cmbGender.Items.AddRange(new object[] { "Male", "Female", "Other" });
            this.cmbCivilStatus.Items.AddRange(new object[] { "Single", "Married", "Divorced", "Widowed" });
            this.cmbEmploymentStatus.Items.AddRange(new object[] { "Employed", "Self-Employed", "Unemployed", "Retired" });
            this.cmbGovernmentIdType.Items.AddRange(new object[] { "SSS", "TIN", "Driver's License", "Passport", "UMID" });
            this.cmbCreditRating.Items.AddRange(new object[] { "Excellent", "Good", "Fair", "Poor" });

            // Buttons
            this.btnSave.Location = new System.Drawing.Point(300, 460);
            this.btnSave.Size = new System.Drawing.Size(90, 35);
            this.btnSave.Text = "💾 Save";
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnSave.ForeColor = System.Drawing.Color.White;

            this.btnCancel.Location = new System.Drawing.Point(390, 460);
            this.btnCancel.Size = new System.Drawing.Size(90, 35);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnCancel.ForeColor = System.Drawing.Color.White;

            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPersonalInfo.ResumeLayout(false);
            this.tabPersonalInfo.PerformLayout();
            this.tabEmploymentCredit.ResumeLayout(false);
            this.tabEmploymentCredit.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}