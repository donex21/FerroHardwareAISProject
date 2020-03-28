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
    public partial class Dashboard : UserControl
    {
        OleDbConnection con = new OleDbConnection(Form1.connectionString);
        private static Dashboard instance;
        public static Dashboard Instance
        {
            get {
                if (instance == null)
                    instance = new Dashboard();
                return instance;
            }
        }
        
        public Dashboard()
        {
            InitializeComponent();
            Users();
            Suppliers();
            Products();
            SalesToday();
            MonthSales();
            MonthPurchase();
        }

        private void Users()
        {
            con.Open();
            OleDbCommand command = con.CreateCommand();
            command.CommandText = "SELECT COUNT(*) FROM User_tbl";
            int userCount = (int)command.ExecuteScalar();
            con.Close();
            labelusers.Text = userCount.ToString();
        }

        private void Suppliers()
        {
            con.Open();
            OleDbCommand command = con.CreateCommand();
            command.CommandText = "SELECT COUNT(*) FROM Supplier";
            int supCount = (int)command.ExecuteScalar();
            con.Close();
            labelSupplier.Text = supCount.ToString();
        }

        private void Products()
        {
            con.Open();
            OleDbCommand command = con.CreateCommand();
            command.CommandText = "SELECT COUNT(*) FROM Product";
            int prodCount = (int)command.ExecuteScalar();
            con.Close();
            labelProduct.Text = prodCount.ToString();
        }

        private void pictureBox5_MouseClick(object sender, MouseEventArgs e)
        {
            Users();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Suppliers();
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            Products();
        }

        private void pictureBox3_MouseClick(object sender, MouseEventArgs e)
        {
            SalesToday();
        }

        private void SalesToday()
        {
            try
            {
                double todaysales = 0;
                con.Open();
                OleDbCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM SalesReport where receipt_date = #"+ Convert.ToDateTime(DateTime.Now.ToShortDateString()) +"#";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    todaysales += Convert.ToDouble(dr["totalsales"].ToString());                   
                }
                con.Close();
                labelTodaySales.Text = "P"+ todaysales.ToString();
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void MonthSales()
        {
            DateTime dtn = DateTime.Now;
            labelMonthS.Text = dtn.ToString("MMMM");
            
            double monthsales = 0;
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM SalesReport where YEAR(receipt_date) = '" + Convert.ToInt32(DateTime.Now.Year.ToString()) + "' AND MONTH(receipt_date) = '" + Convert.ToInt32(DateTime.Now.Month.ToString()) + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                monthsales += Convert.ToDouble(dr["totalsales"].ToString());
            }
            con.Close();
            labelMonthSales.Text = "P" + monthsales.ToString();
        }       

        private void MonthPurchase()
        {
            DateTime dtn = DateTime.Now;
            labelMonthP.Text = dtn.ToString("MMMM");

            double monthpurchase = 0;
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM EntryOrders where YEAR(order_date) = '" + Convert.ToInt32(DateTime.Now.Year.ToString()) + "' AND MONTH(order_date) = '" + Convert.ToInt32(DateTime.Now.Month.ToString()) + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                monthpurchase += Convert.ToDouble(dr["ordertotalsales"].ToString());
            }
            con.Close();
            labelMonthPurchase.Text = "P" + monthpurchase.ToString();
        }

        private void pictureBox4_MouseClick(object sender, MouseEventArgs e)
        {
            MonthSales();
        }

        private void pictureBox6_MouseClick(object sender, MouseEventArgs e)
        {
            MonthPurchase();
        }
    }
}
