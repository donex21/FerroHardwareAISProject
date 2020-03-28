using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace LoginPage
{
    public partial class SalesReport : UserControl
    {
        OleDbConnection con = new OleDbConnection(Form1.connectionString);
        private static SalesReport instance;
        public static SalesReport Instance
        {
            get
            {
                if (instance == null)
                    instance = new SalesReport();
                return instance;
            }
        }
        public SalesReport()
        {
            InitializeComponent();
        }

        private void comboBoxSearch_MouseClick(object sender, MouseEventArgs e)
        {
            AddUserIncombo();
        }

        private void AddUserIncombo()
        {
            try
            {
                comboBoxSearch.Items.Clear();
                con.Open();
                OleDbCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM User_tbl Order by username";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    comboBoxSearch.Items.Add(dr["username"].ToString());
                }
                con.Close();
                comboBoxSearch.DroppedDown = true;
            }
            catch
            {
                MessageBox.Show("Pls. Input Fields");
            }
        }

        private void buttonGenerateReport_Click(object sender, EventArgs e)
        {
            int counter = 0;
            double totalsales = 0;
            dataGridViewProductSold.Rows.Clear();
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM SalesReport where receipt_date BETWEEN #" + Convert.ToDateTime(dateTimePickerDateFrom.Text) + "# AND #" + Convert.ToDateTime(dateTimePickerUntilOn.Text) + "# AND username = '" + comboBoxSearch.Text + "' ORDER BY receipt_date";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                counter++;
                totalsales += Convert.ToDouble(dr["totalsales"].ToString());
                dataGridViewProductSold.Rows.Add(dr["receipt_no"].ToString(), dr["username"].ToString(), dr["totalsales"].ToString(), String.Format("{0:MM/dd/yyyy}", dr["receipt_date"]));
            }
            con.Close();
            textBoxRqty.Text = counter.ToString();
            textBoxTSales.Text = totalsales.ToString();
        }

        private void buttonViewItem_Click(object sender, EventArgs e)
        {
            try
            {
                View_Items_Sold view = new View_Items_Sold();
                string id = dataGridViewProductSold.SelectedCells[0].Value.ToString();
                con.Open();
                OleDbCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM SoldProduct sp,Product p where p.prod_code = sp.prod_code and receipt_no = '" + id + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    view.dataGridViewItemSold.Rows.Add(dr["receipt_no"].ToString(), dr["prod_name"].ToString(), dr["qtysold"].ToString(), dr["tpricesold"].ToString());
                }
                con.Close();
                view.ShowDialog();
            }
            catch { MessageBox.Show("Please choose an item"); }
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
            xcelApp.Application.Workbooks.Add(Type.Missing);

            xcelApp.Cells[1, 2] = "Sales Report";
            xcelApp.Cells[3, 1] = "Date As of: ";
            xcelApp.Cells[3, 2] = DateTime.Now.ToShortDateString();
            if (dataGridViewProductSold.Rows.Count > 0)
            {
                for (int i = 1; i < dataGridViewProductSold.Columns.Count + 1; i++)
                {
                    xcelApp.Cells[5, i] = dataGridViewProductSold.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < dataGridViewProductSold.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridViewProductSold.Columns.Count; j++)
                    {
                        xcelApp.Cells[i + 6, j + 1] = dataGridViewProductSold.Rows[i].Cells[j].Value.ToString();
                    }
                }

                int x = dataGridViewProductSold.RowCount + 8;
                xcelApp.Cells[x, 4] = "Total # of Receipt:";
                xcelApp.Cells[x, 5] = textBoxRqty.Text;
                xcelApp.Cells[++x, 4] = "Total Sales:";
                xcelApp.Cells[x, 5] = textBoxTSales.Text;

                xcelApp.Columns.AutoFit();
                xcelApp.Visible = true;
            }
        }
    }
}
