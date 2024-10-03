namespace DatabaseSync.View.Window
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblSyncInterval;
        private System.Windows.Forms.Button btnManualSync;
        private System.Windows.Forms.DataGridView dataGridCustomers;
        private System.Windows.Forms.Label lblSyncLog;
        private System.Windows.Forms.ListBox lstSyncLog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.NumericUpDown inputSyncInterval;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            lblSyncInterval = new Label();
            btnManualSync = new Button();
            dataGridCustomers = new DataGridView();
            lblSyncLog = new Label();
            lstSyncLog = new ListBox();
            tableLayoutPanel = new TableLayoutPanel();
            inputSyncInterval = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)dataGridCustomers).BeginInit();
            tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)inputSyncInterval).BeginInit();
            SuspendLayout();
            // 
            // lblSyncInterval
            // 
            lblSyncInterval.Anchor = AnchorStyles.Right;
            lblSyncInterval.AutoSize = true;
            lblSyncInterval.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSyncInterval.ForeColor = Color.Black;
            lblSyncInterval.Location = new Point(94, 16);
            lblSyncInterval.Name = "lblSyncInterval";
            lblSyncInterval.Size = new Size(206, 18);
            lblSyncInterval.TabIndex = 0;
            lblSyncInterval.Text = "Insert Sync Interval (in Min):";
            // 
            // btnManualSync
            // 
            btnManualSync.Anchor = AnchorStyles.None;
            btnManualSync.BackColor = SystemColors.Desktop;
            btnManualSync.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnManualSync.ForeColor = SystemColors.Info;
            btnManualSync.Location = new Point(787, 6);
            btnManualSync.Name = "btnManualSync";
            btnManualSync.Size = new Size(146, 37);
            btnManualSync.TabIndex = 2;
            btnManualSync.Text = "Manual Sync";
            btnManualSync.UseVisualStyleBackColor = false;
            btnManualSync.Click += btnManualSync_Click;
            // 
            // dataGridCustomers
            // 
            dataGridCustomers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.Info;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridCustomers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tableLayoutPanel.SetColumnSpan(dataGridCustomers, 3);
            dataGridCustomers.Location = new Point(3, 53);
            dataGridCustomers.Name = "dataGridCustomers";
            dataGridCustomers.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.ActiveCaptionText;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.Info;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridCustomers.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridCustomers.RowHeadersWidth = 51;
            dataGridCustomers.Size = new Size(1007, 371);
            dataGridCustomers.TabIndex = 3;
            // 
            // lblSyncLog
            // 
            lblSyncLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lblSyncLog.AutoSize = true;
            lblSyncLog.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSyncLog.Location = new Point(3, 678);
            lblSyncLog.Name = "lblSyncLog";
            lblSyncLog.Size = new Size(73, 21);
            lblSyncLog.TabIndex = 4;
            lblSyncLog.Text = "Sync Log";
            // 
            // lstSyncLog
            // 
            lstSyncLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstSyncLog.BackColor = Color.Black;
            tableLayoutPanel.SetColumnSpan(lstSyncLog, 3);
            lstSyncLog.Font = new Font("Bahnschrift", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lstSyncLog.ForeColor = Color.DarkSeaGreen;
            lstSyncLog.FormattingEnabled = true;
            lstSyncLog.ItemHeight = 18;
            lstSyncLog.Items.AddRange(new object[] { "2000-01-01 12:30:54 : Example Log" });
            lstSyncLog.Location = new Point(3, 430);
            lstSyncLog.Name = "lstSyncLog";
            lstSyncLog.SelectionMode = SelectionMode.None;
            lstSyncLog.Size = new Size(1007, 238);
            lstSyncLog.TabIndex = 5;
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.BackColor = Color.Lavender;
            tableLayoutPanel.ColumnCount = 3;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel.Controls.Add(lblSyncInterval, 0, 0);
            tableLayoutPanel.Controls.Add(inputSyncInterval, 1, 0);
            tableLayoutPanel.Controls.Add(btnManualSync, 2, 0);
            tableLayoutPanel.Controls.Add(dataGridCustomers, 0, 1);
            tableLayoutPanel.Controls.Add(lblSyncLog, 0, 2);
            tableLayoutPanel.Controls.Add(lstSyncLog, 0, 2);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 4;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel.Size = new Size(1013, 699);
            tableLayoutPanel.TabIndex = 0;
            // 
            // inputSyncInterval
            // 
            inputSyncInterval.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            inputSyncInterval.Location = new Point(306, 11);
            inputSyncInterval.Maximum = new decimal(new int[] { 1440, 0, 0, 0 });
            inputSyncInterval.Name = "inputSyncInterval";
            inputSyncInterval.Size = new Size(399, 27);
            inputSyncInterval.TabIndex = 1;
            inputSyncInterval.ValueChanged += inputSyncInterval_ValueChanged;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1013, 699);
            Controls.Add(tableLayoutPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Home";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Database-Sync";
            Load += Home_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridCustomers).EndInit();
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)inputSyncInterval).EndInit();
            ResumeLayout(false);
        }

        #endregion
    }
}
