namespace LoanManagementSystem.Forms
{
    partial class ClientManagementControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewClients;
        private System.Windows.Forms.Button btnAddClient;
        private System.Windows.Forms.Button btnEditClient;
        private System.Windows.Forms.Button btnDeleteClient;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblTitle;

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
            this.dataGridViewClients = new System.Windows.Forms.DataGridView();
            this.btnAddClient = new System.Windows.Forms.Button();
            this.btnEditClient = new System.Windows.Forms.Button();
            this.btnDeleteClient = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClients)).BeginInit();
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
            this.lblTitle.Text = "👥 Client Management";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridViewClients
            // 
            this.dataGridViewClients.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewClients.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClients.Location = new System.Drawing.Point(20, 120);
            this.dataGridViewClients.Name = "dataGridViewClients";
            this.dataGridViewClients.Size = new System.Drawing.Size(860, 460);
            this.dataGridViewClients.TabIndex = 1;
            // 
            // btnAddClient
            // 
            this.btnAddClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnAddClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddClient.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddClient.ForeColor = System.Drawing.Color.White;
            this.btnAddClient.Location = new System.Drawing.Point(20, 70);
            this.btnAddClient.Name = "btnAddClient";
            this.btnAddClient.Size = new System.Drawing.Size(120, 35);
            this.btnAddClient.TabIndex = 2;
            this.btnAddClient.Text = "➕ Add Client";
            this.btnAddClient.UseVisualStyleBackColor = false;
            this.btnAddClient.Click += new System.EventHandler(this.BtnAddClient_Click);
            // 
            // btnEditClient
            // 
            this.btnEditClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnEditClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditClient.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditClient.ForeColor = System.Drawing.Color.White;
            this.btnEditClient.Location = new System.Drawing.Point(150, 70);
            this.btnEditClient.Name = "btnEditClient";
            this.btnEditClient.Size = new System.Drawing.Size(120, 35);
            this.btnEditClient.TabIndex = 3;
            this.btnEditClient.Text = "✏️ Edit Client";
            this.btnEditClient.UseVisualStyleBackColor = false;
            this.btnEditClient.Click += new System.EventHandler(this.BtnEditClient_Click);
            // 
            // btnDeleteClient
            // 
            this.btnDeleteClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnDeleteClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteClient.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteClient.ForeColor = System.Drawing.Color.White;
            this.btnDeleteClient.Location = new System.Drawing.Point(280, 70);
            this.btnDeleteClient.Name = "btnDeleteClient";
            this.btnDeleteClient.Size = new System.Drawing.Size(120, 35);
            this.btnDeleteClient.TabIndex = 4;
            this.btnDeleteClient.Text = "🗑️ Delete";
            this.btnDeleteClient.UseVisualStyleBackColor = false;
            this.btnDeleteClient.Click += new System.EventHandler(this.BtnDeleteClient_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(430, 73);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(370, 25);
            this.txtSearch.TabIndex = 5;
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged); // ✅ ADDED THIS LINE
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(810, 70);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(70, 35);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "🔍";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click); // ✅ ADDED THIS LINE
            // 
            // ClientManagementControl
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnDeleteClient);
            this.Controls.Add(this.btnEditClient);
            this.Controls.Add(this.btnAddClient);
            this.Controls.Add(this.dataGridViewClients);
            this.Controls.Add(this.lblTitle);
            this.Name = "ClientManagementControl";
            this.Size = new System.Drawing.Size(900, 600);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}