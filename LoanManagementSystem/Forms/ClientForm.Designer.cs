namespace LoanManagementSystem.Forms
{
    partial class ClientForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtClientCode;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblClientCode;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

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
            this.lblClientCode = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();

            this.txtClientCode = new System.Windows.Forms.TextBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();

            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 40, 50);
            this.lblTitle.Text = "🧾 Client Information";
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Size = new System.Drawing.Size(300, 40);

            // Labels
            this.lblClientCode.Text = "Client Code:";
            this.lblClientCode.Location = new System.Drawing.Point(20, 70);
            this.lblFullName.Text = "Full Name:";
            this.lblFullName.Location = new System.Drawing.Point(20, 110);
            this.lblEmail.Text = "Email:";
            this.lblEmail.Location = new System.Drawing.Point(20, 150);
            this.lblPhone.Text = "Phone:";
            this.lblPhone.Location = new System.Drawing.Point(20, 190);
            this.lblAddress.Text = "Address:";
            this.lblAddress.Location = new System.Drawing.Point(20, 230);

            // Textboxes
            this.txtClientCode.Location = new System.Drawing.Point(130, 67);
            this.txtClientCode.Width = 300;
            this.txtFullName.Location = new System.Drawing.Point(130, 107);
            this.txtFullName.Width = 300;
            this.txtEmail.Location = new System.Drawing.Point(130, 147);
            this.txtEmail.Width = 300;
            this.txtPhone.Location = new System.Drawing.Point(130, 187);
            this.txtPhone.Width = 300;
            this.txtAddress.Location = new System.Drawing.Point(130, 227);
            this.txtAddress.Size = new System.Drawing.Size(300, 70);
            this.txtAddress.Multiline = true;

            // Buttons
            this.btnSave.Text = "💾 Save";
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(230, 320);
            this.btnSave.Size = new System.Drawing.Size(90, 35);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnCancel.Text = "Cancel";
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(340, 320);
            this.btnCancel.Size = new System.Drawing.Size(90, 35);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // Form
            this.ClientSize = new System.Drawing.Size(470, 380);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTitle, this.lblClientCode, this.lblFullName, this.lblEmail,
                this.lblPhone, this.lblAddress, this.txtClientCode, this.txtFullName,
                this.txtEmail, this.txtPhone, this.txtAddress, this.btnSave, this.btnCancel
            });
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
        }
    }
}