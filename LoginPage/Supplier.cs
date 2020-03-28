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
    public partial class Supplier : UserControl
    {
        Boolean Search = false;
        OleDbConnection con = new OleDbConnection(Form1.connectionString);
        private static Supplier instance;
        public static Supplier Instance
        {
            get
            {
                if (instance == null)
                    instance = new Supplier();
                return instance;
            }
        }
        public Supplier()
        {
            InitializeComponent();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            textBoxSupplierID.ForeColor = Color.Silver;
            textBoxSupplierID.Text = "Supplier ID";
            textBoxfname.ForeColor = Color.Silver;
            textBoxfname.Text = "First Name";
            textBoxmname.ForeColor = Color.Silver;
            textBoxmname.Text = "Middle Name";
            textBoxlname.ForeColor = Color.Silver;
            textBoxlname.Text = "Last Name";
            textBoxaddress.ForeColor = Color.Silver;
            textBoxaddress.Text = "Address";
            textBoxcntctno.ForeColor = Color.Silver;
            textBoxcntctno.Text = "Contact No";
            textBoxemail.ForeColor = Color.Silver;
            textBoxemail.Text = "Email";
            textBoxcompany.ForeColor = Color.Silver;
            textBoxcompany.Text = "Company";           
        }

        private void textBoxfname_Click(object sender, EventArgs e)
        {
            textBoxfname.Text = "";
            textBoxfname.ForeColor = Color.Black; 
        }

        private void textBoxmname_Click(object sender, EventArgs e)
        {

            textBoxmname.Text = "";
            textBoxmname.ForeColor = Color.Black; 
        }

        private void textBoxlname_Click(object sender, EventArgs e)
        {
            textBoxlname.Text = "";
            textBoxlname.ForeColor = Color.Black; 
        }

        private void textBoxaddress_Click(object sender, EventArgs e)
        {

            textBoxaddress.Text = "";
            textBoxaddress.ForeColor = Color.Black; 
        }

        private void textBoxcntctno_Click(object sender, EventArgs e)
        {
            textBoxcntctno.Text = "";
            textBoxcntctno.ForeColor = Color.Black; 
        }

        private void textBoxemail_Click(object sender, EventArgs e)
        {
            textBoxemail.Text = "";
            textBoxemail.ForeColor = Color.Black; 
        }

        private void textBoxcompany_Click(object sender, EventArgs e)
        {
            textBoxcompany.Text = "";
            textBoxcompany.ForeColor = Color.Black; 
        }

        private void textBoxSearch_Click(object sender, EventArgs e)
        {
            textBoxSearch.Text = "";
            textBoxSearch.ForeColor = Color.Black; 
        }

        private void Supplier_Load(object sender, EventArgs e)
        {
            if (!Search)
                UserDisplay();
            else
            {
                Searchfirstname();
                Search = false;
            }
        }

        private void UserDisplay()
        {
            con.Open();
            OleDbCommand thisCommand = con.CreateCommand();
            thisCommand.CommandText = "SELECT * FROM Supplier Order by Supplier_id";
            thisCommand.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(thisCommand);
            da.Fill(dt);
            dataGridViewSupplier.DataSource = dt;
            con.Close();
        }

        private void Searchfirstname()
        {
            con.Open();
            OleDbCommand thisCommand = con.CreateCommand();
            thisCommand.CommandText = "SELECT * FROM Supplier where lname like '%" + textBoxSearch.Text + "%' Order by Supplier_id";
            thisCommand.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(thisCommand);
            da.Fill(dt);
            dataGridViewSupplier.DataSource = dt;
            con.Close();
        }

        private void buttonViewAll_Click(object sender, EventArgs e)
        {
            Search = false;
            UserDisplay();   
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Search = true;
            Searchfirstname();
            textBoxSearch.Text = "Search";
            textBoxSearch.ForeColor = Color.Silver;     
        }

        private void dataGridViewSupplier_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dataGridViewSupplier.SelectedCells[0].Value.ToString();
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Supplier where Supplier_id = '" + id + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                textBoxSupplierID.Text = dr["Supplier_id"].ToString();               
                textBoxfname.Text = dr["fname"].ToString();
                textBoxmname.Text = dr["mname"].ToString();
                textBoxlname.Text = dr["lname"].ToString();
                textBoxaddress.Text = dr["address"].ToString();
                textBoxcntctno.Text = dr["cntctno"].ToString();
                textBoxemail.Text = dr["email"].ToString();
                textBoxcompany.Text = dr["company"].ToString();
            }
            con.Close();
            blackcolor();
        }

        private void blackcolor()
        {
            textBoxSupplierID.ForeColor = Color.Black;
            textBoxfname.ForeColor = Color.Black;
            textBoxmname.ForeColor = Color.Black;
            textBoxlname.ForeColor = Color.Black;
            textBoxaddress.ForeColor = Color.Black;
            textBoxcntctno.ForeColor = Color.Black;
            textBoxemail.ForeColor = Color.Black;
            textBoxcompany.ForeColor = Color.Black;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (!TextEmpty())
            {
                string sql = "Select * From Supplier";
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sql, con);
                OleDbCommandBuilder cmdbuilder = new OleDbCommandBuilder(dataAdapter);
                DataSet dataset = new DataSet();
                dataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                dataAdapter.Fill(dataset, "Supplier");

                DataRow findrow = dataset.Tables["Supplier"].Rows.Find(textBoxSupplierID.Text);
                if (findrow == null)
                {
                    DataRow datarow = dataset.Tables["Supplier"].NewRow();
                    datarow[0] = textBoxSupplierID.Text;                   
                    datarow[1] = textBoxfname.Text;
                    datarow[2] = textBoxmname.Text;
                    datarow[3] = textBoxlname.Text;
                    datarow[4] = textBoxaddress.Text;
                    datarow[5] = textBoxcntctno.Text;
                    datarow[6] = textBoxemail.Text;
                    datarow[7] = textBoxcompany.Text;
                    dataset.Tables["Supplier"].Rows.Add(datarow);
                    dataAdapter.Update(dataset, "Supplier");
                    MessageBox.Show("Supplier Successfully Saved");
                    Clear();
                    UserDisplay();
                }
                else
                {
                    MessageBox.Show("Duplicate ID");
                }
            }
            else
            {
                MessageBox.Show("Pls. Complete All Details");
            }
        }

        private bool TextEmpty()
        {
            if (textBoxaddress.Text == ""|| textBoxcntctno.Text == ""|| textBoxcompany.Text == "" ||
                textBoxemail.Text == "" || textBoxfname.Text == "" || textBoxlname.Text == "" ||
                textBoxmname.Text == "" || textBoxSupplierID.Text == "" || textBoxaddress.ForeColor == Color.Silver || textBoxcntctno.ForeColor == Color.Silver || textBoxcompany.ForeColor == Color.Silver ||
                textBoxemail.ForeColor == Color.Silver || textBoxfname.ForeColor == Color.Silver || textBoxlname.ForeColor == Color.Silver ||
                textBoxmname.ForeColor == Color.Silver || textBoxSupplierID.ForeColor == Color.Silver)
            {
                return true;
            }
            else
                return false;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (!TextEmpty())
            {
                string sql = "Select * From Supplier";
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sql, con);
                OleDbCommandBuilder cmdbuilder = new OleDbCommandBuilder(dataAdapter);
                DataSet dataset = new DataSet();
                dataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                dataAdapter.Fill(dataset, "Supplier");

                DataRow findrow = dataset.Tables["Supplier"].Rows.Find(textBoxSupplierID.Text);
                if (findrow != null)
                {
                    // DataRow datarow = dataset.Tables["Employee"].NewRow();
                    findrow[0] = textBoxSupplierID.Text;
                    findrow[1] = textBoxfname.Text;
                    findrow[2] = textBoxmname.Text;
                    findrow[3] = textBoxlname.Text;
                    findrow[4] = textBoxaddress.Text;
                    findrow[5] = textBoxcntctno.Text;
                    findrow[6] = textBoxemail.Text;
                    findrow[7] = textBoxcompany.Text;
                    
                    //dataset.Tables["Employee"].Rows.Add(datarow);
                    dataAdapter.Update(dataset, "Supplier");
                    MessageBox.Show("User Successfully Updated");
                    Clear();
                    UserDisplay();
                }
                else
                {
                    MessageBox.Show("That Id is Unique!!!");
                }
            }
            else
            {
                MessageBox.Show("Pls. Complete All Details");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void buttonDelte_Click(object sender, EventArgs e)
        {
            string id;
            if (textBoxSupplierID.Text == "" || textBoxSupplierID.Text == "Supplier ID")
            {
                MessageBox.Show("Pls. Chooose a User You Want to Delete");
            }
            else
            {
                id = textBoxSupplierID.Text;
                con.Open();
                OleDbCommand thisCommand2 = con.CreateCommand();
                thisCommand2.CommandType = CommandType.Text;
                thisCommand2.CommandText = "DELETE FROM Supplier where Supplier_id = '" + id + "'";
                thisCommand2.ExecuteNonQuery();
                con.Close();
                Clear();
                UserDisplay();
                MessageBox.Show("User Succesfully Deleted");
            }
        }

       
        private void textBoxSupplierID_KeyPress(object sender, KeyPressEventArgs e)
        {          
            if (e.KeyChar == (char)Keys.Enter)
            {
                Boolean exist = false;
                do{
                    Random randomcode = new Random();
                    textBoxSupplierID.ForeColor = Color.Black;
                    int Count = randomcode.Next(1,5000);
                    con.Open();
                    OleDbCommand checkid = new OleDbCommand("SELECT count([Supplier_id]) FROM Supplier WHERE (Supplier_id = 'SU-00" + Count.ToString() + "') ", con);
                    int UserExist = (int)checkid.ExecuteScalar();
                    if (UserExist == 1)
                    {
                        exist = true;
                    }
                    else
                        exist = false;
                    con.Close();
                    if(!exist)
                        textBoxSupplierID.Text = "SU-00" + (Count);
                }while(exist);
            }
        }

        private void textBoxSupplierID_Click(object sender, EventArgs e)
        {
            textBoxSupplierID.Text = "";
            textBoxSupplierID.ForeColor = Color.Black;
        }

        private void textBoxfname_TextChanged(object sender, EventArgs e)
        {           
            textBoxfname.ForeColor = Color.Black;
        }

        private void textBoxmname_TextChanged(object sender, EventArgs e)
        {           
            textBoxmname.ForeColor = Color.Black;
        }

        private void textBoxlname_TextChanged(object sender, EventArgs e)
        {
            textBoxlname.ForeColor = Color.Black;
        }

        private void textBoxaddress_TextChanged(object sender, EventArgs e)
        {
            textBoxaddress.ForeColor = Color.Black;
        }

        private void textBoxcntctno_TextChanged(object sender, EventArgs e)
        {
            textBoxcntctno.ForeColor = Color.Black;
        }

        private void textBoxemail_TextChanged(object sender, EventArgs e)
        {
            textBoxemail.ForeColor = Color.Black;
        }

        private void textBoxcompany_TextChanged(object sender, EventArgs e)
        {
            textBoxcompany.ForeColor = Color.Black;
        }
    }
}
