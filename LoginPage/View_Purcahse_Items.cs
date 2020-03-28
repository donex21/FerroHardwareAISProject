using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace LoginPage
{
    public partial class View_Purcahse_Items : Form
    {
        OleDbConnection con = new OleDbConnection(Form1.connectionString);
        public string suppName = "";
        public View_Purcahse_Items()
        {
            InitializeComponent();
        }
      
        private void buttonExport_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
            xcelApp.Application.Workbooks.Add(Type.Missing);

            xcelApp.Cells[1, 2] = "Supplier's Purchase Items Report";
            xcelApp.Cells[3, 1] = "Date As of: ";
            xcelApp.Cells[3, 2] = DateTime.Now.ToShortDateString();
            xcelApp.Cells[4, 1] = "Supplier: ";
            xcelApp.Cells[4, 2] = suppName;
            if (dataGridViewPurchaseItems.Rows.Count > 0)
            {
                for (int i = 1; i < dataGridViewPurchaseItems.Columns.Count + 1; i++)
                {
                    xcelApp.Cells[5, i] = dataGridViewPurchaseItems.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < dataGridViewPurchaseItems.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridViewPurchaseItems.Columns.Count; j++)
                    {
                        xcelApp.Cells[i + 6, j + 1] = dataGridViewPurchaseItems.Rows[i].Cells[j].Value.ToString();
                    }
                }

                xcelApp.Columns.AutoFit();
                xcelApp.Visible = true;
            }
        }

        private void View_Purcahse_Items_Load(object sender, EventArgs e)
        {

        }

        private void buttonUpdatePurchase_Click(object sender, EventArgs e)
        {            
            try
            {                
                string[] prodcode = new string[100];
                int i = 0;
                if (dataGridViewPurchaseItems.Rows[0].Cells[0].Value != null)
                {                       
                    con.Open();
                    OleDbCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM EntryOrderDetail";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        if( dr["order_no"].ToString().Equals(dataGridViewPurchaseItems.Rows[0].Cells[0].Value.ToString()))
                        {
                            prodcode[i] = dr["prod_code"].ToString();
                            i++;
                        }
                    }
                    con.Close();
                    
                    int x = 0;
                    foreach (DataGridViewRow row in dataGridViewPurchaseItems.Rows)
                    {                        
                        OleDbCommand cmd1 = con.CreateCommand();
                        cmd1 = new OleDbCommand("UPDATE EntryOrderDetail set status =@status where prod_code=@prodcode AND order_no=@order_no", con);
                        con.Open();
                        cmd1.Parameters.AddWithValue("@status", row.Cells[4].Value);
                        cmd1.Parameters.AddWithValue("@prodcode", prodcode[x]);                       
                        cmd1.Parameters.AddWithValue("@order_no", row.Cells[0].Value);
                        cmd1.ExecuteNonQuery();                        
                        con.Close();
                        x++;
                    }
                }
                MessageBox.Show("Records Updated");
           }
           catch {
               MessageBox.Show("Object Reference is not an Instance");
           }
        }
    }
}
