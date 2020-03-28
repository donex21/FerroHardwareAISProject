namespace LoginPage
{
    partial class StockCard
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
            this.dataGridViewStockCard = new System.Windows.Forms.DataGridView();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStockCard)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewStockCard
            // 
            this.dataGridViewStockCard.AllowUserToAddRows = false;
            this.dataGridViewStockCard.AllowUserToDeleteRows = false;
            this.dataGridViewStockCard.AllowUserToResizeRows = false;
            this.dataGridViewStockCard.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewStockCard.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewStockCard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStockCard.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Quantity,
            this.Amount,
            this.Column1});
            this.dataGridViewStockCard.Location = new System.Drawing.Point(15, 12);
            this.dataGridViewStockCard.MultiSelect = false;
            this.dataGridViewStockCard.Name = "dataGridViewStockCard";
            this.dataGridViewStockCard.ReadOnly = true;
            this.dataGridViewStockCard.RowHeadersVisible = false;
            this.dataGridViewStockCard.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStockCard.Size = new System.Drawing.Size(415, 328);
            this.dataGridViewStockCard.TabIndex = 108;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Date Release";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // StockCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 356);
            this.Controls.Add(this.dataGridViewStockCard);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(471, 395);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(471, 395);
            this.Name = "StockCard";
            this.Text = "StockCard";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStockCard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        public System.Windows.Forms.DataGridView dataGridViewStockCard;
    }
}