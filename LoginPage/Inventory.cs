﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace LoginPage
{
    public partial class Inventory : UserControl
    {
        OleDbConnection con = new OleDbConnection(Form1.connectionString);
        private static Inventory instance;
        public static Inventory Instance
        {
            get
            {
                if (instance == null)
                    instance = new Inventory();
                return instance;
            }
        }
        public Inventory()
        {
            InitializeComponent();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            SearchItems();
            QTY();
        }

        private void buttonViewAll_Click(object sender, EventArgs e)
        {
            DisplayallItems();
            QTYAll();
        }

        private void AddCategoryIncombo()
        {
            try
            {
                string id = comboBoxSearch.Text;
                con.Open();
                OleDbCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Category where category_name like '%" + id + "%' Order by category_name";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    string name = dr["category_name"].ToString();
                    comboBoxSearch.Items.Add(name);
                }
                con.Close();
                comboBoxSearch.DroppedDown = true;
            }
            catch
            {
                MessageBox.Show("Pls. Input Fields");
            }
        }

        private void DisplayallItems()
        {
            dataGridViewProduct.Rows.Clear();
            int i = 0;
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT prod_code, prod_name, orig_price, srp, qty, moq, category FROM Product Order by prod_name";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                double minqty = Convert.ToDouble(dr["moq"].ToString());
                double qty = Convert.ToDouble(dr["qty"].ToString());
                if (minqty >= qty)
                {
                    dataGridViewProduct.Rows.Add(dr["prod_code"].ToString(), dr["prod_name"].ToString(), dr["orig_price"].ToString(), dr["srp"].ToString(), dr["qty"].ToString(), dr["moq"].ToString(), dr["category"].ToString());
                    dataGridViewProduct.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
                else
                {
                    dataGridViewProduct.Rows.Add(dr["prod_code"].ToString(), dr["prod_name"].ToString(), dr["orig_price"].ToString(), dr["srp"].ToString(), dr["qty"].ToString(), dr["moq"].ToString(), dr["category"].ToString());
                }
                i++;
            }
            con.Close();
        }

        private void SearchItems()
        {
            dataGridViewProduct.Rows.Clear();
            int i = 0;
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT prod_code, prod_name, orig_price, srp, qty, moq, category FROM Product where category like '%" + comboBoxSearch.Text + "%' Order by prod_name";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                double minqty = Convert.ToDouble(dr["moq"].ToString());
                double qty = Convert.ToDouble(dr["qty"].ToString());
                if (minqty >= qty)
                {
                    dataGridViewProduct.Rows.Add(dr["prod_code"].ToString(), dr["prod_name"].ToString(), dr["orig_price"].ToString(), dr["srp"].ToString(), dr["qty"].ToString(), dr["moq"].ToString(), dr["category"].ToString());
                    dataGridViewProduct.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
                else
                {
                    dataGridViewProduct.Rows.Add(dr["prod_code"].ToString(), dr["prod_name"].ToString(), dr["orig_price"].ToString(), dr["srp"].ToString(), dr["qty"].ToString(), dr["moq"].ToString(), dr["category"].ToString());
                }
                i++;
            }
            con.Close();
        }

        private void comboBoxSearch_MouseClick(object sender, MouseEventArgs e)
        {
            comboBoxSearch.Items.Clear();
            AddCategoryIncombo();
        }

        private void QTY()
        {
            con.Open();
            OleDbCommand command = con.CreateCommand();
            command.CommandText = "SELECT SUM(qty) from Product where category like '%" + comboBoxSearch.Text + "%'";
            object total = command.ExecuteScalar();
            con.Close();
            textBoxTqty.Text = Convert.ToString(total);
        }

        private void QTYAll()
        {
            con.Open();
            OleDbCommand command = con.CreateCommand();
            command.CommandText = "SELECT SUM(qty) from Product";
            object total = command.ExecuteScalar();
            con.Close();
            textBoxTqty.Text = Convert.ToString(total);
        }

        private void buttonViewItem_Click(object sender, EventArgs e)
        {
            try
            {
                ViewImage view = new ViewImage();
                string id = dataGridViewProduct.CurrentRow.Cells[0].Value.ToString();
                con.Open();
                OleDbCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT prodimage FROM Product where prod_code = '" + id + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    view.pictureBoxImage.Image = (dr["prodimage"] is DBNull) ? LoginPage.Properties.Resources.noimage : loadphoto((byte[])dr["prodimage"]);
                }
                con.Close();
                view.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Pls Choose a Item");
            }
        }

        private Image loadphoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void buttonStockCards_Click(object sender, EventArgs e)
        {
            try
            {
            StockCard stock = new StockCard();
            string id = dataGridViewProduct.SelectedCells[0].Value.ToString();
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM SoldProduct sp,SalesReport sr where sr.receipt_no = sp.receipt_no and prod_code = '" + id + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                stock.dataGridViewStockCard.Rows.Add(dr["qtysold"].ToString(), dr["tpricesold"].ToString(), dr["receipt_date"].ToString());
            }
            con.Close();
            stock.ShowDialog();
            }
            catch {
              MessageBox.Show("Pls Choose a Item");
            }
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
            xcelApp.Application.Workbooks.Add(Type.Missing);

            xcelApp.Cells[1, 2] = "Inventory Report";
            xcelApp.Cells[3, 1] = "Inventory As of: ";
            xcelApp.Cells[3, 2] = DateTime.Now.ToString();
            if (dataGridViewProduct.Rows.Count > 0)
            {
                for (int i = 1; i < dataGridViewProduct.Columns.Count + 1; i++)
                {
                    xcelApp.Cells[5, i] = dataGridViewProduct.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < dataGridViewProduct.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridViewProduct.Columns.Count; j++)
                    {
                        xcelApp.Cells[i + 6, j + 1] = dataGridViewProduct.Rows[i].Cells[j].Value.ToString();
                    }
                }

                int x = dataGridViewProduct.RowCount + 8;
                xcelApp.Cells[x, 4] = "Total Quantity:";
                xcelApp.Cells[x, 5] = textBoxTqty.Text + " Pcs.";
                
                xcelApp.Columns.AutoFit();
                xcelApp.Visible = true;
            }
        }       
    }
}
