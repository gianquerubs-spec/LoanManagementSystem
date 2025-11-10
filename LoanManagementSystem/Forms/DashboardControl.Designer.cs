namespace LoanManagementSystem.Forms
{
    partial class DashboardControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelStats;
        private System.Windows.Forms.Label lblTotalClients;
        private System.Windows.Forms.Label lblTotalLoans;
        private System.Windows.Forms.Label lblActiveLoans;
        private System.Windows.Forms.Label lblPendingApprovals;

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
            this.panelStats = new System.Windows.Forms.Panel();
            this.lblPendingApprovals = new System.Windows.Forms.Label();
            this.lblActiveLoans = new System.Windows.Forms.Label();
            this.lblTotalLoans = new System.Windows.Forms.Label();
            this.lblTotalClients = new System.Windows.Forms.Label();
            this.panelStats.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(300, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📊 Dashboard Overview";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelStats
            // 
            this.panelStats.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            this.panelStats.Controls.Add(this.lblPendingApprovals);
            this.panelStats.Controls.Add(this.lblActiveLoans);
            this.panelStats.Controls.Add(this.lblTotalLoans);
            this.panelStats.Controls.Add(this.lblTotalClients);
            this.panelStats.Location = new System.Drawing.Point(20, 80);
            this.panelStats.Name = "panelStats";
            this.panelStats.Size = new System.Drawing.Size(860, 120);
            this.panelStats.TabIndex = 1;
            // 
            // lblPendingApprovals
            // 
            this.lblPendingApprovals.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.lblPendingApprovals.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendingApprovals.ForeColor = System.Drawing.Color.White;
            this.lblPendingApprovals.Location = new System.Drawing.Point(650, 20);
            this.lblPendingApprovals.Name = "lblPendingApprovals";
            this.lblPendingApprovals.Size = new System.Drawing.Size(190, 80);
            this.lblPendingApprovals.TabIndex = 3;
            this.lblPendingApprovals.Text = "Pending";
            this.lblPendingApprovals.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblActiveLoans
            // 
            this.lblActiveLoans.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.lblActiveLoans.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActiveLoans.ForeColor = System.Drawing.Color.White;
            this.lblActiveLoans.Location = new System.Drawing.Point(440, 20);
            this.lblActiveLoans.Name = "lblActiveLoans";
            this.lblActiveLoans.Size = new System.Drawing.Size(190, 80);
            this.lblActiveLoans.TabIndex = 2;
            this.lblActiveLoans.Text = "Active Loans";
            this.lblActiveLoans.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalLoans
            // 
            this.lblTotalLoans.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblTotalLoans.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalLoans.ForeColor = System.Drawing.Color.White;
            this.lblTotalLoans.Location = new System.Drawing.Point(230, 20);
            this.lblTotalLoans.Name = "lblTotalLoans";
            this.lblTotalLoans.Size = new System.Drawing.Size(190, 80);
            this.lblTotalLoans.TabIndex = 1;
            this.lblTotalLoans.Text = "Total Loans";
            this.lblTotalLoans.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalClients
            // 
            this.lblTotalClients.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblTotalClients.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalClients.ForeColor = System.Drawing.Color.White;
            this.lblTotalClients.Location = new System.Drawing.Point(20, 20);
            this.lblTotalClients.Name = "lblTotalClients";
            this.lblTotalClients.Size = new System.Drawing.Size(190, 80);
            this.lblTotalClients.TabIndex = 0;
            this.lblTotalClients.Text = "Total Clients";
            this.lblTotalClients.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTotalClients.Click += new System.EventHandler(this.lblTotalClients_Click);
            // 
            // DashboardControl
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelStats);
            this.Controls.Add(this.lblTitle);
            this.Name = "DashboardControl";
            this.Size = new System.Drawing.Size(900, 600);
            this.Load += new System.EventHandler(this.DashboardControl_Load);
            this.panelStats.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}