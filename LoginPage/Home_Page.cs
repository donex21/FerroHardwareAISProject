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
    public partial class Home_Page : Form
    {

        OleDbConnection con = new OleDbConnection(Form1.connectionString);
        static System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["Form1"];
        string user = ((Form1)f).textBoxusername.Text;
        public Home_Page()
        {
            InitializeComponent();
            labelUser.Text = user.ToString();
        }

        public string username()
        {
            return labelUser.Text;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void buttonDashboard_Click(object sender, EventArgs e)
        {
            panelDropdown.Height = 45;
            buttonDashboard.BackColor = Color.FromArgb(192, 64, 0);
            buttonPOS.BackColor = Color.FromArgb(34, 36, 39);
            buttonPurchase.BackColor = Color.FromArgb(34, 36, 39);
            buttonProduct.BackColor = Color.FromArgb(34, 36, 39);
            buttonSupplier.BackColor = Color.FromArgb(34, 36, 39);
            buttonUser.BackColor = Color.FromArgb(34, 36, 39);
            buttonReport.BackColor = Color.FromArgb(34, 36, 39);
            panelDisplay.Controls.Clear(); 
            if (!panelDisplay.Controls.Contains(Dashboard.Instance))
            {
                panelDisplay.Controls.Add(Dashboard.Instance);
                Dashboard.Instance.Dock = DockStyle.Fill;
                Dashboard.Instance.BringToFront();
            }
            else {
                Dashboard.Instance.BringToFront();
            }
        }

        private void buttonPOS_Click(object sender, EventArgs e)
        {
            panelDropdown.Height = 45;
            buttonDashboard.BackColor = Color.FromArgb(34, 36, 39);
            buttonPOS.BackColor = Color.FromArgb(192, 64, 0);
            buttonPurchase.BackColor = Color.FromArgb(34, 36, 39);
            buttonProduct.BackColor = Color.FromArgb(34, 36, 39);
            buttonSupplier.BackColor = Color.FromArgb(34, 36, 39);
            buttonUser.BackColor = Color.FromArgb(34, 36, 39);
            buttonReport.BackColor = Color.FromArgb(34, 36, 39);
            panelDisplay.Controls.Clear();
            if (!panelDisplay.Controls.Contains(POS.Instance))
            {
                panelDisplay.Controls.Add(POS.Instance);
                POS.Instance.Dock = DockStyle.Fill;
                POS.Instance.BringToFront();
            }
            else
            {
                POS.Instance.BringToFront();
            }
        }

        private void buttonPurchase_Click(object sender, EventArgs e)
        {
            panelDropdown.Height = 45;
            buttonDashboard.BackColor = Color.FromArgb(34, 36, 39);
            buttonPOS.BackColor = Color.FromArgb(34, 36, 39);
            buttonPurchase.BackColor = Color.FromArgb(192, 64, 0);
            buttonProduct.BackColor = Color.FromArgb(34, 36, 39);
            buttonSupplier.BackColor = Color.FromArgb(34, 36, 39);
            buttonUser.BackColor = Color.FromArgb(34, 36, 39);
            buttonReport.BackColor = Color.FromArgb(34, 36, 39);
            panelDisplay.Controls.Clear();
            if (!panelDisplay.Controls.Contains(Purchase.Instance))
            {
                panelDisplay.Controls.Add(Purchase.Instance);
                Purchase.Instance.Dock = DockStyle.Fill;
                Purchase.Instance.BringToFront();
            }
            else
            {
                Purchase.Instance.BringToFront();
            }
        }

        private void buttonProduct_Click(object sender, EventArgs e)
        {
            panelDropdown.Height = 45;
            buttonDashboard.BackColor = Color.FromArgb(34, 36, 39);
            buttonPOS.BackColor = Color.FromArgb(34, 36, 39);
            buttonPurchase.BackColor = Color.FromArgb(34, 36, 39);
            buttonProduct.BackColor = Color.FromArgb(192, 64, 0);
            buttonSupplier.BackColor = Color.FromArgb(34, 36, 39);
            buttonUser.BackColor = Color.FromArgb(34, 36, 39);
            buttonReport.BackColor = Color.FromArgb(34, 36, 39);
            panelDisplay.Controls.Clear();
            if (!panelDisplay.Controls.Contains(Products.Instance))
            {
                panelDisplay.Controls.Add(Products.Instance);
                Products.Instance.Dock = DockStyle.Fill;
                Products.Instance.BringToFront();
            }
            else
            {
                Products.Instance.BringToFront();
            }
        }

        private void buttonSupplier_Click(object sender, EventArgs e)
        {
            panelDropdown.Height = 45;
            buttonDashboard.BackColor = Color.FromArgb(34, 36, 39);
            buttonPOS.BackColor = Color.FromArgb(34, 36, 39);
            buttonPurchase.BackColor = Color.FromArgb(34, 36, 39);
            buttonProduct.BackColor = Color.FromArgb(34, 36, 39);
            buttonSupplier.BackColor = Color.FromArgb(192, 64, 0);
            buttonUser.BackColor = Color.FromArgb(34, 36, 39);
            buttonReport.BackColor = Color.FromArgb(34, 36, 39);
            panelDisplay.Controls.Clear();
            if (!panelDisplay.Controls.Contains(Supplier.Instance))
            {
                panelDisplay.Controls.Add(Supplier.Instance);
                Supplier.Instance.Dock = DockStyle.Fill;
                Supplier.Instance.BringToFront();
            }
            else
            {
                Supplier.Instance.BringToFront();
            }
        }
        
        private void buttonReport_Click(object sender, EventArgs e)
        {
            buttonDashboard.BackColor = Color.FromArgb(34, 36, 39);
            buttonPOS.BackColor = Color.FromArgb(34, 36, 39);
            buttonPurchase.BackColor = Color.FromArgb(34, 36, 39);
            buttonProduct.BackColor = Color.FromArgb(34, 36, 39);
            buttonSupplier.BackColor = Color.FromArgb(34, 36, 39);
            buttonUser.BackColor = Color.FromArgb(34, 36, 39);
            buttonReport.BackColor = Color.FromArgb(192, 64, 0);

            if(panelDropdown.Height == 225)
            {
                panelDropdown.Height = 45;
            }
            else{
                panelDropdown.Height = 225;
            }
        }

        private void buttonUser_Click_1(object sender, EventArgs e)
        {
            panelDropdown.Height = 45;
            buttonDashboard.BackColor = Color.FromArgb(34, 36, 39);
            buttonPOS.BackColor = Color.FromArgb(34, 36, 39);
            buttonPurchase.BackColor = Color.FromArgb(34, 36, 39);
            buttonProduct.BackColor = Color.FromArgb(34, 36, 39);
            buttonSupplier.BackColor = Color.FromArgb(34, 36, 39);
            buttonUser.BackColor = Color.FromArgb(192, 64, 0);
            buttonReport.BackColor = Color.FromArgb(34, 36, 39);
            panelDisplay.Controls.Clear();
            if (!panelDisplay.Controls.Contains(Users.Instance))
            {
                panelDisplay.Controls.Add(Users.Instance);
                Users.Instance.Dock = DockStyle.Fill;
                Users.Instance.BringToFront();
            }
            else
            {
                Users.Instance.BringToFront();
            }
        }

        private void buttonInventory_Click(object sender, EventArgs e)
        {
            panelDisplay.Controls.Clear();
            if (!panelDisplay.Controls.Contains(Inventory.Instance))
            {
                panelDisplay.Controls.Add(Inventory.Instance);
                Inventory.Instance.Dock = DockStyle.Fill;
                Inventory.Instance.BringToFront();
            }
            else
            {
                Inventory.Instance.BringToFront();
            }
        }

        private void buttonMOQItems_Click(object sender, EventArgs e)
        {
            panelDisplay.Controls.Clear();
            if (!panelDisplay.Controls.Contains(MOQItems.Instance))
            {
                panelDisplay.Controls.Add(MOQItems.Instance);
                MOQItems.Instance.Dock = DockStyle.Fill;
                MOQItems.Instance.BringToFront();
            }
            else
            {
                MOQItems.Instance.BringToFront();
            }
        }

        private void buttonSalesReport_Click(object sender, EventArgs e)
        {
            panelDisplay.Controls.Clear();
            if (!panelDisplay.Controls.Contains(SalesReport.Instance))
            {
                panelDisplay.Controls.Add(SalesReport.Instance);
                SalesReport.Instance.Dock = DockStyle.Fill;
                SalesReport.Instance.BringToFront();
            }
            else
            {
                SalesReport.Instance.BringToFront();
            }
        }

        private void buttonRequest_Click(object sender, EventArgs e)
        {
            panelDisplay.Controls.Clear();
            if (!panelDisplay.Controls.Contains(Request.Instance))
            {
                panelDisplay.Controls.Add(Request.Instance);
                Request.Instance.Dock = DockStyle.Fill;
                Request.Instance.BringToFront();
            }
            else
            {
                Request.Instance.BringToFront();
            }
        }

        private void panelGreen_MouseClick(object sender, MouseEventArgs e)
        {
            panelDisplay.BackColor = Color.FromArgb(255, 192, 192);
            Users.Instance.BackColor = Color.FromArgb(255, 192, 192);
            Dashboard.Instance.BackColor = Color.FromArgb(255, 192, 192);                    
        }

        private void panelNormal_MouseClick(object sender, MouseEventArgs e)
        {
            panelDisplay.BackColor = Color.White;           
            Dashboard.Instance.BackColor = Color.White;
            Users.Instance.BackColor = Color.White;
        }

        private void panelBlue_MouseClick(object sender, MouseEventArgs e)
        {
            panelDisplay.BackColor = Color.FromArgb(192, 255, 192);
            Users.Instance.BackColor = Color.FromArgb(192, 255, 192);
            Dashboard.Instance.BackColor = Color.FromArgb(192, 255, 192);

           
        }

        private void Home_Page_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rand = new Random();
            int A = rand.Next(0, 255);
            int R = rand.Next(0, 255);
            int G = rand.Next(0, 255);
            int B = rand.Next(0, 255);
            Promo.ForeColor = Color.FromArgb(A, R, G, B);
        }
    }
}
