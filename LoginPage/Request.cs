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
    public partial class Request : UserControl
    {
        OleDbConnection con = new OleDbConnection(Form1.connectionString);
        private static Request instance;
        public static Request Instance
        {
            get
            {
                if (instance == null)
                    instance = new Request();
                return instance;
            }
        }
        public Request()
        {
            InitializeComponent();            
        }

        private void comboBoxSearchSupplier_MouseClick(object sender, MouseEventArgs e)
        {
            AddSupplierIncombo();
        }

        private void AddSupplierIncombo()
        {
            try
            {
                comboBoxSearchSupplier.Items.Clear();
                con.Open();
                OleDbCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Supplier";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    string lname = dr["lname"].ToString();
                    string fname = dr["fname"].ToString();
                    string mname = dr["mname"].ToString();
                    comboBoxSearchSupplier.Items.Add(lname + ", " + fname + ", " + mname);
                }
                con.Close();
                comboBoxSearchSupplier.DroppedDown = true;
            }
            catch
            {
                MessageBox.Show("Pls. Input Fields");
            }
        }

        private void buttonGenerateReport_Click(object sender, EventArgs e)
        {
            int counter = 0;
            double totalpurchase = 0;
            dataGridViewProductPurchase.Rows.Clear();
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM EntryOrders where supplier_name = '"+comboBoxSearchSupplier.Text+"' ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                counter++;
                totalpurchase += Convert.ToDouble(dr["ordertotalsales"].ToString());
                dataGridViewProductPurchase.Rows.Add(dr["order_no"].ToString(), dr["supplier_name"].ToString(), String.Format("{0:MM/dd/yyyy}", dr["order_date"]), dr["ordertotalsales"].ToString());
            }
            con.Close();
            textBoxNPurchase.Text = counter.ToString();
            textBoxTPurchase.Text = totalpurchase.ToString();
        }

        public string SupplierName
        {
            get;
            set;
        }

        private void buttonViewPurchaseItem_Click(object sender, EventArgs e)
        {
            try
            {              
                View_Purcahse_Items viewPurchase = new View_Purcahse_Items();
                string id = dataGridViewProductPurchase.SelectedCells[0].Value.ToString();
                viewPurchase.suppName = dataGridViewProductPurchase.SelectedCells[1].Value.ToString();
                con.Open();
                OleDbCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM EntryOrderDetail EOD, Product p where p.prod_code = EOD.prod_code and order_no = '" + id + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    viewPurchase.dataGridViewPurchaseItems.Rows.Add(dr["order_no"].ToString(), dr["prod_name"].ToString(), dr["ordertprice"].ToString(), dr["orderqty"].ToString(), dr["status"].ToString());
                }
                con.Close();
                viewPurchase.ShowDialog();
            }
            catch {
               MessageBox.Show("Choose a Column!!");
            }
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
            xcelApp.Application.Workbooks.Add(Type.Missing);

            xcelApp.Cells[1, 2] = "Supplier's Request Report";
            xcelApp.Cells[3, 1] = "Date As of: ";
            xcelApp.Cells[3, 2] = DateTime.Now.ToShortDateString();
            if (dataGridViewProductPurchase.Rows.Count > 0)
            {
                for (int i = 1; i < dataGridViewProductPurchase.Columns.Count + 1; i++)
                {
                    xcelApp.Cells[5, i] = dataGridViewProductPurchase.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < dataGridViewProductPurchase.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridViewProductPurchase.Columns.Count; j++)
                    {
                        xcelApp.Cells[i + 6, j + 1] = dataGridViewProductPurchase.Rows[i].Cells[j].Value.ToString();
                    }
                }

                int x = dataGridViewProductPurchase.RowCount + 8;
                xcelApp.Cells[x, 3] = "Total # of Purchase:";
                xcelApp.Cells[x, 4] = textBoxNPurchase.Text;
                xcelApp.Cells[++x, 3] = "Total Purchase:";
                xcelApp.Cells[x, 4] = textBoxTPurchase.Text;

                xcelApp.Columns.AutoFit();
                xcelApp.Visible = true;
            }
        }

        
    }
}

