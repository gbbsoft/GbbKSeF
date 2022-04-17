namespace TestKSeF
{
    partial class ConfigurationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            this.components = new System.ComponentModel.Container();
            this.okButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new GbbLibWin.OurDataGridView();
            this.URL_BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PublicKey_BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.configurationLineBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nIPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tokenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uRLDataGridViewTextBoxColumn = new GbbLibWin.OurDataGridViewComboBoxColumn2();
            this.publicKeyDataGridViewTextBoxColumn = new GbbLibWin.OurDataGridViewComboBoxColumn2();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.URL_BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PublicKey_BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.configurationLineBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okButton.Location = new System.Drawing.Point(821, 206);
            this.okButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(88, 27);
            this.okButton.TabIndex = 24;
            this.okButton.Text = "&OK";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 15);
            this.label1.TabIndex = 25;
            this.label1.Text = "Konfiguracje:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.nIPDataGridViewTextBoxColumn,
            this.tokenDataGridViewTextBoxColumn,
            this.uRLDataGridViewTextBoxColumn,
            this.publicKeyDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.configurationLineBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(13, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(897, 172);
            this.dataGridView1.TabIndex = 26;
            // 
            // URL_BindingSource
            // 
            this.URL_BindingSource.DataSource = typeof(TestKSeF.DropDownString);
            // 
            // PublicKey_BindingSource
            // 
            this.PublicKey_BindingSource.DataSource = typeof(TestKSeF.DropDownString);
            // 
            // configurationLineBindingSource
            // 
            this.configurationLineBindingSource.DataSource = typeof(TestKSeF.ConfigurationLine);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Nazwa";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // nIPDataGridViewTextBoxColumn
            // 
            this.nIPDataGridViewTextBoxColumn.DataPropertyName = "NIP";
            this.nIPDataGridViewTextBoxColumn.HeaderText = "NIP";
            this.nIPDataGridViewTextBoxColumn.Name = "nIPDataGridViewTextBoxColumn";
            // 
            // tokenDataGridViewTextBoxColumn
            // 
            this.tokenDataGridViewTextBoxColumn.DataPropertyName = "Token";
            this.tokenDataGridViewTextBoxColumn.HeaderText = "Token";
            this.tokenDataGridViewTextBoxColumn.Name = "tokenDataGridViewTextBoxColumn";
            this.tokenDataGridViewTextBoxColumn.Width = 200;
            // 
            // uRLDataGridViewTextBoxColumn
            // 
            this.uRLDataGridViewTextBoxColumn.DataPropertyName = "URL";
            this.uRLDataGridViewTextBoxColumn.DataSource = this.URL_BindingSource;
            this.uRLDataGridViewTextBoxColumn.DisplayMember = "Name";
            this.uRLDataGridViewTextBoxColumn.HeaderText = "URL";
            this.uRLDataGridViewTextBoxColumn.Name = "uRLDataGridViewTextBoxColumn";
            this.uRLDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.uRLDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.uRLDataGridViewTextBoxColumn.ValueMember = "Value";
            this.uRLDataGridViewTextBoxColumn.Width = 200;
            // 
            // publicKeyDataGridViewTextBoxColumn
            // 
            this.publicKeyDataGridViewTextBoxColumn.DataPropertyName = "PublicKey";
            this.publicKeyDataGridViewTextBoxColumn.DataSource = this.PublicKey_BindingSource;
            this.publicKeyDataGridViewTextBoxColumn.DisplayMember = "Name";
            this.publicKeyDataGridViewTextBoxColumn.HeaderText = "PublicKey";
            this.publicKeyDataGridViewTextBoxColumn.Name = "publicKeyDataGridViewTextBoxColumn";
            this.publicKeyDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.publicKeyDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.publicKeyDataGridViewTextBoxColumn.ValueMember = "Value";
            this.publicKeyDataGridViewTextBoxColumn.Width = 200;
            // 
            // ConfigurationForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 246);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigurationForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ConfigurationForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfigurationForm_FormClosing);
            this.Load += new System.EventHandler(this.ConfigurationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.URL_BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PublicKey_BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.configurationLineBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button okButton;
        private Label label1;
        private GbbLibWin.OurDataGridView dataGridView1;
        private BindingSource configurationLineBindingSource;
        private BindingSource URL_BindingSource;
        private BindingSource PublicKey_BindingSource;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nIPDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn tokenDataGridViewTextBoxColumn;
        private GbbLibWin.OurDataGridViewComboBoxColumn2 uRLDataGridViewTextBoxColumn;
        private GbbLibWin.OurDataGridViewComboBoxColumn2 publicKeyDataGridViewTextBoxColumn;
    }
}
