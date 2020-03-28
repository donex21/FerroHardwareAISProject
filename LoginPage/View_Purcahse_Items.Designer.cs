namespace LoginPage
{
    partial class View_Purcahse_Items
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(View_Purcahse_Items));
            this.dataGridViewPurchaseItems = new System.Windows.Forms.DataGridView();
            this.PONo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TPurchase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.buttonUpdatePurchase = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.buttonExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPurchaseItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewPurchaseItems
            // 
            this.dataGridViewPurchaseItems.AllowUserToAddRows = false;
            this.dataGridViewPurchaseItems.AllowUserToDeleteRows = false;
            this.dataGridViewPurchaseItems.AllowUserToResizeRows = false;
            this.dataGridViewPurchaseItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPurchaseItems.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewPurchaseItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPurchaseItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PONo,
            this.Product,
            this.TPurchase,
            this.QTY,
            this.Status});
            this.dataGridViewPurchaseItems.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewPurchaseItems.MultiSelect = false;
            this.dataGridViewPurchaseItems.Name = "dataGridViewPurchaseItems";
            this.dataGridViewPurchaseItems.RowHeadersVisible = false;
            this.dataGridViewPurchaseItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPurchaseItems.Size = new System.Drawing.Size(582, 328);
            this.dataGridViewPurchaseItems.TabIndex = 109;
            // 
            // PONo
            // 
            this.PONo.HeaderText = "PO. No.";
            this.PONo.Name = "PONo";
            this.PONo.ReadOnly = true;
            // 
            // Product
            // 
            this.Product.HeaderText = "Product";
            this.Product.Name = "Product";
            this.Product.ReadOnly = true;
            // 
            // TPurchase
            // 
            this.TPurchase.HeaderText = "Total Purchase";
            this.TPurchase.Name = "TPurchase";
            this.TPurchase.ReadOnly = true;
            // 
            // QTY
            // 
            this.QTY.HeaderText = "Quantity";
            this.QTY.Name = "QTY";
            this.QTY.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Items.AddRange(new object[] {
            "Paid",
            "Unpaid"});
            this.Status.Name = "Status";
            // 
            // buttonUpdatePurchase
            // 
            this.buttonUpdatePurchase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.buttonUpdatePurchase.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonUpdatePurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUpdatePurchase.Location = new System.Drawing.Point(12, 350);
            this.buttonUpdatePurchase.Name = "buttonUpdatePurchase";
            this.buttonUpdatePurchase.Size = new System.Drawing.Size(98, 22);
            this.buttonUpdatePurchase.TabIndex = 111;
            this.buttonUpdatePurchase.Text = "    Update";
            this.buttonUpdatePurchase.UseVisualStyleBackColor = false;
            this.buttonUpdatePurchase.Click += new System.EventHandler(this.buttonUpdatePurchase_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(18, 353);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 112;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(491, 353);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(28, 20);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 146;
            this.pictureBox7.TabStop = false;
            // 
            // buttonExport
            // 
            this.buttonExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.buttonExport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExport.Location = new System.Drawing.Point(482, 346);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(112, 34);
            this.buttonExport.TabIndex = 145;
            this.buttonExport.Text = "     &Export";
            this.buttonExport.UseVisualStyleBackColor = false;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // View_Purcahse_Items
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 387);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonUpdatePurchase);
            this.Controls.Add(this.dataGridViewPurchaseItems);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "View_Purcahse_Items";
            this.Text = "View_Purcahse_Items";
            this.Load += new System.EventHandler(this.View_Purcahse_Items_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPurchaseItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridViewPurchaseItems;
        private System.Windows.Forms.Button buttonUpdatePurchase;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.DataGridViewTextBoxColumn PONo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product;
        private System.Windows.Forms.DataGridViewTextBoxColumn TPurchase;
        private System.Windows.Forms.DataGridViewTextBoxColumn QTY;
        private System.Windows.Forms.DataGridViewComboBoxColumn Status;
    }
}