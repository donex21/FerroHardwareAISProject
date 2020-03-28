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
    public partial class Users : UserControl
    {
        Boolean Search = false;
        OleDbConnection con = new OleDbConnection(Form1.connectionString);
        private static Users instance;
        public static Users Instance
        {
            get
            {
                if (instance == null)
                    instance = new Users();
                return instance;
            }
        }
        public Users()
        {
            InitializeComponent();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void textBoxUsername_Click(object sender, EventArgs e)
        {
            textBoxUsername.Text = "";
            textBoxUsername.ForeColor = Color.Black;        
        }

        private void Clear()
        {
            textBoxUsername.ForeColor = Color.Silver;
            textBoxUsername.Text = "Username";
            textBoxpwd.ForeColor = Color.Silver;
            textBoxpwd.Text = "Password";
            textBoxfname.ForeColor = Color.Silver;
            textBoxfname.Text = "First Name";
            textBoxmname.ForeColor = Color.Silver;
            textBoxmname.Text = "Middle Name";
            textBoxlname.ForeColor = Color.Silver;
            textBoxlname.Text = "Last Name";
            comboBoxgender.Text = "";
           //textBoxgender.ForeColor = Color.Silver;
            //textBoxgender.Text = "Gender";

        }

        private void textBoxpwd_Click(object sender, EventArgs e)
        {
            textBoxpwd.Text = "";
            textBoxpwd.ForeColor = Color.Black;  
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

       /* private void textBoxgender_Click(object sender, EventArgs e)
        {
            textBoxgender.Text = "";
            textBoxgender.ForeColor = Color.Black;  
        }*/

        private void textBoxSearch_Click(object sender, EventArgs e)
        {
            textBoxSearch.Text = "";
            textBoxSearch.ForeColor = Color.Black;  
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Search = true;
            Searchfirstname();
            textBoxSearch.Text = "Search";
            textBoxSearch.ForeColor = Color.Silver;     
        }

        private void Users_Load(object sender, EventArgs e)
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
            thisCommand.CommandText = "SELECT username,fname,mname,lname,gender FROM User_tbl Order by username";
            thisCommand.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(thisCommand);
            da.Fill(dt);
            dataGridViewEmployee.DataSource = dt;
            con.Close();
        }

        private void Searchfirstname()
        {
            con.Open();
            OleDbCommand thisCommand = con.CreateCommand();
            thisCommand.CommandText = "SELECT * FROM User_tbl where lname like '%" + textBoxSearch.Text + "%' Order by username";
            thisCommand.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(thisCommand);
            da.Fill(dt);
            dataGridViewEmployee.DataSource = dt;
            con.Close();
        }

        private void buttonViewAll_Click(object sender, EventArgs e)
        {
            Search = false;
            UserDisplay();   
        }

        private void dataGridViewEmployee_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dataGridViewEmployee.SelectedCells[0].Value.ToString();
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM User_tbl where username = '" + id + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                textBoxUsername.Text = dr["username"].ToString();
                textBoxpwd.Text = dr["userpwd"].ToString();
                textBoxfname.Text = dr["fname"].ToString();
                textBoxmname.Text = dr["mname"].ToString();
                textBoxlname.Text = dr["lname"].ToString();
                comboBoxgender.Text = dr["gender"].ToString();             
            }
            con.Close();
            blackcolor();
        }

        private void blackcolor()
        {
            textBoxUsername.ForeColor = Color.Black;
            textBoxpwd.ForeColor = Color.Black;
            textBoxfname.ForeColor = Color.Black;
            textBoxmname.ForeColor = Color.Black;
            textBoxlname.ForeColor = Color.Black;
            comboBoxgender.ForeColor = Color.Black;
            
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (!TextEmpty())
            {
                string sql = "Select * From User_tbl";
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sql, con);
                OleDbCommandBuilder cmdbuilder = new OleDbCommandBuilder(dataAdapter);
                DataSet dataset = new DataSet();
                dataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                dataAdapter.Fill(dataset, "User_tbl");

                DataRow findrow = dataset.Tables["User_tbl"].Rows.Find(textBoxUsername.Text);
                if (findrow == null)
                {
                    DataRow datarow = dataset.Tables["User_tbl"].NewRow();
                    datarow[0] = textBoxUsername.Text;
                    datarow[1] = textBoxpwd.Text;
                    datarow[2] = textBoxfname.Text;
                    datarow[3] = textBoxmname.Text;
                    datarow[4] = textBoxlname.Text;
                    datarow[5] = comboBoxgender.Text;
                    
                    dataset.Tables["User_tbl"].Rows.Add(datarow);
                    dataAdapter.Update(dataset, "User_tbl");
                    MessageBox.Show("Successfully Saved");
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
            if (textBoxUsername.Text == "" || textBoxfname.Text == ""|| comboBoxgender.Text == "" ||
                textBoxlname.Text == "" || textBoxmname.Text == "" || textBoxpwd.Text == "" ||
                textBoxUsername.ForeColor == Color.Silver || textBoxfname.ForeColor == Color.Silver || comboBoxgender.ForeColor == Color.Silver ||
                textBoxlname.ForeColor == Color.Silver || textBoxmname.ForeColor == Color.Silver || textBoxpwd.ForeColor == Color.Silver)
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
                string sql = "Select * From User_tbl";
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sql, con);
                OleDbCommandBuilder cmdbuilder = new OleDbCommandBuilder(dataAdapter);
                DataSet dataset = new DataSet();
                dataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                dataAdapter.Fill(dataset, "User_tbl");

                DataRow findrow = dataset.Tables["User_tbl"].Rows.Find(textBoxUsername.Text);
                if (findrow != null)
                {
                    // DataRow datarow = dataset.Tables["Employee"].NewRow();
                    findrow[0] = textBoxUsername.Text;
                    findrow[1] = textBoxpwd.Text;
                    findrow[2] = textBoxfname.Text;
                    findrow[3] = textBoxmname.Text;
                    findrow[4] = textBoxlname.Text;
                    findrow[5] = comboBoxgender.Text;
                    
                    //dataset.Tables["Employee"].Rows.Add(datarow);
                    dataAdapter.Update(dataset, "User_tbl");
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

        private void buttonDelte_Click(object sender, EventArgs e)
        {
            string id;
            if (textBoxUsername.Text == "" || textBoxUsername.Text == "Username")
            {
                MessageBox.Show("Pls. Chooose a User You Want to Delete");
            }
            else
            {
                id = textBoxUsername.Text;
                con.Open();
                OleDbCommand thisCommand2 = con.CreateCommand();
                thisCommand2.CommandType = CommandType.Text;
                thisCommand2.CommandText = "DELETE FROM User_tbl where username = '" + id + "'";
                thisCommand2.ExecuteNonQuery();
                con.Close();
                Clear();
                UserDisplay();
                MessageBox.Show("User Succesfully Deleted");
            }
        }

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {
            textBoxUsername.ForeColor = Color.Black;
        }

        private void textBoxpwd_TextChanged(object sender, EventArgs e)
        {
            textBoxpwd.ForeColor = Color.Black;
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
    }
}
