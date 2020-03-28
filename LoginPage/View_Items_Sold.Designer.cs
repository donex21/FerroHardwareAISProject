namespace LoginPage
{
    partial class View_Items_Sold
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
            this.dataGridViewItemSold = new System.Windows.Forms.DataGridView();
            this.ReceiptNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoldQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItemSold)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewItemSold
            // 
            this.dataGridViewItemSold.AllowUserToAddRows = false;
            this.dataGridViewItemSold.AllowUserToDeleteRows = false;
            this.dataGridViewItemSold.AllowUserToResizeRows = false;
            this.dataGridViewItemSold.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewItemSold.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewItemSold.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewItemSold.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ReceiptNo,
            this.Product,
            this.SoldQuantity,
            this.Amount});
            this.dataGridViewItemSold.Location = new System.Drawing.Point(20, 21);
            this.dataGridViewItemSold.MultiSelect = false;
            this.dataGridViewItemSold.Name = "dataGridViewItemSold";
            this.dataGridViewItemSold.ReadOnly = true;
            this.dataGridViewItemSold.RowHeadersVisible = false;
            this.dataGridViewItemSold.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewItemSold.Size = new System.Drawing.Size(470, 328);
            this.dataGridViewItemSold.TabIndex = 109;
            // 
            // ReceiptNo
            // 
            this.ReceiptNo.HeaderText = "Receipt No";
            this.ReceiptNo.Name = "ReceiptNo";
            this.ReceiptNo.ReadOnly = true;
            // 
            // Product
            // 
            this.Product.HeaderText = "Product";
            this.Product.Name = "Product";
            this.Product.ReadOnly = true;
            // 
            // SoldQuantity
            // 
            this.SoldQuantity.HeaderText = "Sold Quantity";
            this.SoldQuantity.Name = "SoldQuantity";
            this.SoldQuantity.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // View_Items_Sold
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 370);
            this.Controls.Add(this.dataGridViewItemSold);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(534, 409);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(534, 409);
            this.Name = "View_Items_Sold";
            this.Text = "View_Items_Sold";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItemSold)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridViewItemSold;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiptNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoldQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
    }
}