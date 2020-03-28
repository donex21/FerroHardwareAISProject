namespace LoginPage
{
    partial class Request
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Request));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxSearchSupplier = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxTPurchase = new System.Windows.Forms.TextBox();
            this.buttonExport = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxNPurchase = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonViewPurchaseItem = new System.Windows.Forms.Button();
            this.dataGridViewProductPurchase = new System.Windows.Forms.DataGridView();
            this.PO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Supplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PODate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPurchase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonGenerateReport = new System.Windows.Forms.Button();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductPurchase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(39)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1099, 28);
            this.panel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(443, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Supplier\'s Request";
            // 
            // comboBoxSearchSupplier
            // 
            this.comboBoxSearchSupplier.BackColor = System.Drawing.SystemColors.Info;
            this.comboBoxSearchSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSearchSupplier.FormattingEnabled = true;
            this.comboBoxSearchSupplier.Location = new System.Drawing.Point(254, 56);
            this.comboBoxSearchSupplier.Name = "comboBoxSearchSupplier";
            this.comboBoxSearchSupplier.Size = new System.Drawing.Size(168, 21);
            this.comboBoxSearchSupplier.TabIndex = 142;
            this.comboBoxSearchSupplier.MouseClick += new System.Windows.Forms.MouseEventHandler(this.comboBoxSearchSupplier_MouseClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(175, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 20);
            this.label5.TabIndex = 141;
            this.label5.Text = "Supplier: ";
            // 
            // textBoxTPurchase
            // 
            this.textBoxTPurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTPurchase.Location = new System.Drawing.Point(803, 503);
            this.textBoxTPurchase.Name = "textBoxTPurchase";
            this.textBoxTPurchase.ReadOnly = true;
            this.textBoxTPurchase.Size = new System.Drawing.Size(91, 26);
            this.textBoxTPurchase.TabIndex = 139;
            // 
            // buttonExport
            // 
            this.buttonExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.buttonExport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExport.Location = new System.Drawing.Point(972, 34);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(112, 34);
            this.buttonExport.TabIndex = 140;
            this.buttonExport.Text = "     &Export";
            this.buttonExport.UseVisualStyleBackColor = false;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(653, 503);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 24);
            this.label4.TabIndex = 138;
            this.label4.Text = "Total Purchase";
            // 
            // textBoxNPurchase
            // 
            this.textBoxNPurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNPurchase.Location = new System.Drawing.Point(568, 503);
            this.textBoxNPurchase.Name = "textBoxNPurchase";
            this.textBoxNPurchase.ReadOnly = true;
            this.textBoxNPurchase.Size = new System.Drawing.Size(72, 26);
            this.textBoxNPurchase.TabIndex = 137;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(374, 503);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(196, 24);
            this.label6.TabIndex = 136;
            this.label6.Text = "Total # of Purchase:";
            // 
            // buttonViewPurchaseItem
            // 
            this.buttonViewPurchaseItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.buttonViewPurchaseItem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonViewPurchaseItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonViewPurchaseItem.Location = new System.Drawing.Point(171, 503);
            this.buttonViewPurchaseItem.Name = "buttonViewPurchaseItem";
            this.buttonViewPurchaseItem.Size = new System.Drawing.Size(180, 22);
            this.buttonViewPurchaseItem.TabIndex = 135;
            this.buttonViewPurchaseItem.Text = "    View Purchase Items";
            this.buttonViewPurchaseItem.UseVisualStyleBackColor = false;
            this.buttonViewPurchaseItem.Click += new System.EventHandler(this.buttonViewPurchaseItem_Click);
            // 
            // dataGridViewProductPurchase
            // 
            this.dataGridViewProductPurchase.AllowDrop = true;
            this.dataGridViewProductPurchase.AllowUserToAddRows = false;
            this.dataGridViewProductPurchase.AllowUserToDeleteRows = false;
            this.dataGridViewProductPurchase.AllowUserToResizeRows = false;
            this.dataGridViewProductPurchase.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewProductPurchase.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridViewProductPurchase.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridViewProductPurchase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProductPurchase.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PO,
            this.Supplier,
            this.PODate,
            this.TotalPurchase});
            this.dataGridViewProductPurchase.Location = new System.Drawing.Point(171, 124);
            this.dataGridViewProductPurchase.Name = "dataGridViewProductPurchase";
            this.dataGridViewProductPurchase.ReadOnly = true;
            this.dataGridViewProductPurchase.RowHeadersVisible = false;
            this.dataGridViewProductPurchase.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewProductPurchase.Size = new System.Drawing.Size(723, 373);
            this.dataGridViewProductPurchase.TabIndex = 134;
            // 
            // PO
            // 
            this.PO.HeaderText = "PO. No";
            this.PO.Name = "PO";
            this.PO.ReadOnly = true;
            // 
            // Supplier
            // 
            this.Supplier.HeaderText = "Supplier";
            this.Supplier.Name = "Supplier";
            this.Supplier.ReadOnly = true;
            // 
            // PODate
            // 
            this.PODate.HeaderText = "PO. Date";
            this.PODate.Name = "PODate";
            this.PODate.ReadOnly = true;
            // 
            // TotalPurchase
            // 
            this.TotalPurchase.HeaderText = "Total Purchase";
            this.TotalPurchase.Name = "TotalPurchase";
            this.TotalPurchase.ReadOnly = true;
            // 
            // buttonGenerateReport
            // 
            this.buttonGenerateReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.buttonGenerateReport.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGenerateReport.Location = new System.Drawing.Point(171, 83);
            this.buttonGenerateReport.Name = "buttonGenerateReport";
            this.buttonGenerateReport.Size = new System.Drawing.Size(723, 35);
            this.buttonGenerateReport.TabIndex = 133;
            this.buttonGenerateReport.Text = "Generate";
            this.buttonGenerateReport.UseVisualStyleBackColor = false;
            this.buttonGenerateReport.Click += new System.EventHandler(this.buttonGenerateReport_Click);
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(981, 41);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(28, 20);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 144;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(179, 506);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 143;
            this.pictureBox1.TabStop = false;
            // 
            // Request
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.comboBoxSearchSupplier);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxTPurchase);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxNPurchase);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buttonViewPurchaseItem);
            this.Controls.Add(this.dataGridViewProductPurchase);
            this.Controls.Add(this.buttonGenerateReport);
            this.Controls.Add(this.panel1);
            this.Name = "Request";
            this.Size = new System.Drawing.Size(1099, 555);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductPurchase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxSearchSupplier;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxTPurchase;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxNPurchase;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonViewPurchaseItem;
        private System.Windows.Forms.DataGridView dataGridViewProductPurchase;
        private System.Windows.Forms.Button buttonGenerateReport;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PO;
        private System.Windows.Forms.DataGridViewTextBoxColumn Supplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn PODate;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalPurchase;
        private System.Windows.Forms.PictureBox pictureBox7;
    }
}
