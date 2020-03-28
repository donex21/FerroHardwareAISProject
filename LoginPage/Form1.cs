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

    public partial class Form1 : Form
    {
        public static string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\acer\Desktop\FerroPOSVersion 1\FerroPOSVersion 1\FerroDatabase.mdb";
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void textBoxusername_Click(object sender, EventArgs e)
        {
            textBoxusername.Text = "";
            if (textBoxUserpwd.Text == "")
                MessageBox.Show("Pls. Fill Up Password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void textBoxUserpwd_Click(object sender, EventArgs e)
        {
            textBoxUserpwd.UseSystemPasswordChar = true;
            textBoxUserpwd.Text = "";
            if (textBoxusername.Text == "")
                MessageBox.Show("Pls. Fill Up Username", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void buttonlogin_Click(object sender, EventArgs e)
        {
            login();
        }

        private void buttonclear_Click(object sender, EventArgs e)
        {
            textBoxusername.Text = "Username";
            textBoxUserpwd.Text = "Password";
        }

        private void textBoxUserpwd_TextChanged(object sender, EventArgs e)
        {
            textBoxUserpwd.UseSystemPasswordChar = true;
        }

        private void buttonlogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                login();
            }
        }

        private void login()
        {
            if (textBoxUserpwd.Text == "" || textBoxusername.Text == "")
            {
                MessageBox.Show("Pls. Complete the Details", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                bool check = false;
                OleDbConnection thisConnection = new OleDbConnection(connectionString);
                OleDbConnection con = new OleDbConnection(connectionString);
                con.Open();
                OleDbCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT username,  userpwd FROM User_tbl";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    if (textBoxusername.Text == dr["username"].ToString() && textBoxUserpwd.Text == dr["userpwd"].ToString())
                    {
                        this.Hide();
                        new Splash().Show();
                        return;
                    }
                    else {
                        check = true;
                    }
                }
                
                con.Close();
                if(check)
                    MessageBox.Show("Invalid Id and Password", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);

                /* OleDbConnection thisConnection = new OleDbConnection(connectionString);
                 OleDbDataAdapter sda = new OleDbDataAdapter("SELECT COUNT(*) FROM User_tbl WHERE username='" + textBoxusername.Text + "' AND userpwd='" + textBoxUserpwd.Text + "'", thisConnection);
                 DataTable dt = new DataTable(); //this is creating a virtual table  
                 sda.Fill(dt);
                 if (dt.Rows[0][0].ToString() == "1")
                 {
                     this.Hide();
                     new Home_Page().Show();
                 }*/

            }
        }

        private void textBoxUserpwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                login();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
