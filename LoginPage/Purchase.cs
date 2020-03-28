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
using System.IO;

namespace LoginPage
{
    public partial class Purchase : UserControl
    {        
        OleDbConnection con = new OleDbConnection(Form1.connectionString);
        double Order_tprice = 0; 
        private static Purchase instance;
        public static Purchase Instance
        {
            get
            {
                if (instance == null)
                    instance = new Purchase();
                return instance;
            }
        }
       
        public Purchase()
        {
            InitializeComponent();
        }

        private void textBoxPurchaseCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Boolean exist = false;
                do
                {
                    Random randomcode = new Random();
                    textBoxPurchaseCode.ForeColor = Color.Black;
                    int Count = randomcode.Next(1, 5000);
                    con.Open();
                    OleDbCommand checkid = new OleDbCommand("SELECT count([order_no]) FROM EntryOrders WHERE (order_no = 'PU-00" + Count.ToString() + "') ", con);
                    int UserExist = (int)checkid.ExecuteScalar();
                    if (UserExist == 1)
                    {
                        exist = true;
                    }
                    else
                        exist = false;
                    con.Close();
                    if (!exist)
                        textBoxPurchaseCode.Text = "PU-00" + (Count);
                } while (exist);
            }
        }

        private void AddSupplierIncombo()
        {
            try
            {
                string id = comboBoxSupplier.Text;
                con.Open();
                OleDbCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Supplier where lname like '%" + id + "%' Order by lname";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    string lname = dr["lname"].ToString();
                    string fname = dr["fname"].ToString();
                    string mname = dr["mname"].ToString();
                    comboBoxSupplier.Items.Add(lname + ", " + fname + ", " + mname);
                }
                con.Close();
                comboBoxSupplier.DroppedDown = true;
            }
            catch
            {
                MessageBox.Show("Pls. Input Fields");
            }
        }

        private void buttonFindSupplier_Click(object sender, EventArgs e)
        {
            comboBoxSupplier.Items.Clear();
            AddSupplierIncombo();
        }

        private void AddCategoryIncombo()
        {
            try
            {
                string id = comboBoxSearchItem.Text;
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
                    comboBoxSearchItem.Items.Add(name);
                }
                con.Close();
                comboBoxSearchItem.DroppedDown = true;
            }
            catch
            {
                MessageBox.Show("Pls. Input Fields");
            }
        }

        private void buttonFindItem_Click(object sender, EventArgs e)
        {
            comboBoxSearchItem.Items.Clear();
            AddCategoryIncombo();
        }

        private void Searchfirstname()
        {
            con.Open();
            OleDbCommand thisCommand = con.CreateCommand();
            thisCommand.CommandText = "SELECT prod_code AS Code, prod_name AS Name, orig_price AS Supplier_Price, SRP, qty, category FROM Product where category like '%" + comboBoxSearchItem.Text + "%' Order by prod_code";
            thisCommand.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(thisCommand);
            da.Fill(dt);
            dataGridViewItemList.DataSource = dt;
            con.Close();
        }

        private void buttonViewItem_Click(object sender, EventArgs e)
        {
            try
            {
                ViewImage view = new ViewImage();
                string id = dataGridViewItemList.CurrentRow.Cells[0].Value.ToString();
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
            catch {
                MessageBox.Show("Pls Choose a Item");
            }
        }

        private Image loadphoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void comboBoxSearchItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Searchfirstname();
            }
        }

        private void textBoxpurchaseqty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                comboBoxStatus.Focus();
            }
        }

        private void comboBoxStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                AddItem();
            }
        }

        private void buttonAddItem_Click(object sender, EventArgs e)
        {
            AddItem();
        }
        Products prod = new Products();

        private void AddItem()
        {
            try
            {
                if (textBoxpurchaseqty.Text == "" || comboBoxStatus.Text == "")
                    MessageBox.Show("Pls. Complete the details");
                else if (!unique(dataGridViewItemList.SelectedCells[0].Value.ToString()))
                {
                    MessageBox.Show("The Item is already in the List");
                    textBoxpurchaseqty.Text = "";
                }
                else if (!prod.validnumberInt(textBoxpurchaseqty.Text))
                {
                    MessageBox.Show("Pls. Input Valid Number !!");
                    textBoxpurchaseqty.Text = "";
                }
                else
                {
                    string id = dataGridViewItemList.SelectedCells[0].Value.ToString();
                    con.Open();
                    OleDbCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM Product where prod_code = '" + id + "'";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        double price = Convert.ToDouble(dr["orig_price"].ToString());
                       // double dtbsqty = Convert.ToDouble(dr["qty"].ToString());

                        double qty = Convert.ToDouble(textBoxpurchaseqty.Text);
                        //if (dtbsqty >= qty)
                        //{
                            double tprice = price * qty;
                            Order_tprice += tprice;
                            dataGridViewPurchase.Rows.Add(dr["prod_code"].ToString(), dr["prod_name"].ToString(), textBoxpurchaseqty.Text, dr["orig_price"].ToString(), tprice.ToString(), comboBoxStatus.Text);
                            labelTotalPurchase.Text = Order_tprice.ToString();
                        //}
                       // else
                        //{
                        //   MessageBox.Show("Cannot acquire the Order");
                         //  textBoxpurchaseqty.Text = "";
                         //   con.Close();
                            //return;
                        //}
                    }
                    con.Close();
            
                    textBoxpurchaseqty.Text = "";
                }
            }
            catch
            {
                MessageBox.Show("Impractical Error");
            }
        }

        private bool unique(string value)
        {
            for (int i = 0; i < dataGridViewPurchase.RowCount; i++)
                if (value.Equals(dataGridViewPurchase.Rows[i].Cells[0].Value.ToString()))
                    return false;
            return true;
        }

        private void buttonDeleteItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewPurchase.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show(@"Do you want to Delete the Item?", "Confirmation", MessageBoxButtons.YesNoCancel);
                switch (result)
                {
                    case DialogResult.Yes:
                        Order_tprice -= Convert.ToDouble(dataGridViewPurchase.SelectedCells[4].Value.ToString());
                        dataGridViewPurchase.Rows.RemoveAt(dataGridViewPurchase.CurrentRow.Index);
                        labelTotalPurchase.Text = Order_tprice.ToString();
                        break;
                    case DialogResult.No:
                        break;
                    default:
                        break;
                }

            }
            else
            {
                MessageBox.Show("Choose an Item You want to delete");
            }

        }

        private void buttonApprove_Click(object sender, EventArgs e)
        {
            if (textBoxPurchaseCode.Text != "" && comboBoxSupplier.Text != "" && dataGridViewPurchase.RowCount > 0 )
            {
                DialogResult result = MessageBox.Show(@"Do you want to Approve the Transaction?", "Confirmation", MessageBoxButtons.YesNoCancel);
                switch (result)
                {
                    case DialogResult.Yes:
                        SaveTransaOrder();
                        SaveOrderDetails();
                        PlusItemQTY();
                        Export();
                        MessageBox.Show("Succesfully Approved");
                        break;
                    case DialogResult.No:
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Pls. Input Purchase Code, Supplier and Orders");
            }
        }

        private void SaveTransaOrder()
        {

            string sql = "Select * From EntryOrders";
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sql, con);
            OleDbCommandBuilder cmdbuilder = new OleDbCommandBuilder(dataAdapter);
            DataSet dataset = new DataSet();
            dataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            dataAdapter.Fill(dataset, "EntryOrders");

            DataRow findrow = dataset.Tables["EntryOrders"].Rows.Find(textBoxPurchaseCode.Text);
            if (findrow == null)
            {
                DataRow datarow = dataset.Tables["EntryOrders"].NewRow();
                datarow[0] = textBoxPurchaseCode.Text;
                datarow[1] = comboBoxSupplier.SelectedItem.ToString();
                datarow[2] = DateTime.Now.ToShortDateString();
                datarow[3] = Convert.ToDecimal(labelTotalPurchase.Text);
         
                dataset.Tables["EntryOrders"].Rows.Add(datarow);
                dataAdapter.Update(dataset, "EntryOrders");
                
            }
            else
            {
                MessageBox.Show("Duplicate Purchase Number");
            }
        }

        private void SaveOrderDetails()
        {
            foreach (DataGridViewRow row in dataGridViewPurchase.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    string sql = "Select * From EntryOrderDetail";
                    OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sql, con);
                    OleDbCommandBuilder cmdbuilder = new OleDbCommandBuilder(dataAdapter);
                    DataSet dataset = new DataSet();
                    dataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                    dataAdapter.Fill(dataset, "EntryOrderDetail");
                    object[] colpk = new object[2];
                    colpk[0] = textBoxPurchaseCode.Text;
                    colpk[1] = row.Cells[0].Value;
                    DataRow findrow = dataset.Tables["EntryOrderDetail"].Rows.Find(colpk);
                    if (findrow == null)
                    {
                        DataRow datarow = dataset.Tables["EntryOrderDetail"].NewRow();
                        datarow[0] = textBoxPurchaseCode.Text;
                        datarow[1] = row.Cells[0].Value;
                        datarow[2] = row.Cells[4].Value;
                        datarow[3] = row.Cells[2].Value;
                        datarow[4] = row.Cells[5].Value;
                        dataset.Tables["EntryOrderDetail"].Rows.Add(datarow);
                        dataAdapter.Update(dataset, "EntryOrderDetail");
                    }
                }
            }
        }

        private void PlusItemQTY()
        {
            double previewsqty = 0;
            foreach (DataGridViewRow row in dataGridViewPurchase.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    con.Open();
                    OleDbCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT qty FROM Product where prod_code = '" + row.Cells[0].Value.ToString() + "'";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        previewsqty = Convert.ToDouble(dr["qty"].ToString());
                    }
                    con.Close();

                    string sql = "Select prod_code, qty From Product";
                    OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sql, con);
                    OleDbCommandBuilder cmdbuilder = new OleDbCommandBuilder(dataAdapter);
                    DataSet dataset = new DataSet();
                    dataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                    dataAdapter.Fill(dataset, "Product");

                    DataRow findrow = dataset.Tables["Product"].Rows.Find(row.Cells[0].Value.ToString());
                    if (findrow != null)
                    {
                        // DataRow datarow = dataset.Tables["Item"].NewRow();

                        findrow[1] = previewsqty + (Convert.ToDouble(row.Cells[2].Value));
                        //dataset.Tables["Item"].Rows.Add(datarow);
                        dataAdapter.Update(dataset, "Product");
                    }
                }
            }
        }

        private void Export()
        {
            Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
            xcelApp.Application.Workbooks.Add(Type.Missing);

            xcelApp.Cells[1, 2] = "Purchase Order";
            xcelApp.Cells[1, 5] = DateTime.Now.ToString();
            xcelApp.Cells[4, 1] = "Supplier:";
            xcelApp.Cells[4, 2] = comboBoxSupplier.Text;
            xcelApp.Cells[5, 1] = "Purchase #:";
            xcelApp.Cells[5, 2] = textBoxPurchaseCode.Text;

            if (dataGridViewPurchase.Rows.Count > 0)
            {
                for (int i = 1; i < dataGridViewPurchase.Columns.Count + 1; i++)
                {
                    xcelApp.Cells[7, i] = dataGridViewPurchase.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < dataGridViewPurchase.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridViewPurchase.Columns.Count; j++)
                    {
                        xcelApp.Cells[i + 8, j + 1] = dataGridViewPurchase.Rows[i].Cells[j].Value.ToString();
                    }
                }

                int x = dataGridViewPurchase.RowCount + 10;
                xcelApp.Cells[++x, 4] = "Total Sales:";
                xcelApp.Cells[x, 5] = labelTotalPurchase.Text;
                xcelApp.Columns.AutoFit();
                xcelApp.Visible = true;
            }
            textBoxPurchaseCode.ForeColor = Color.Silver;
            textBoxPurchaseCode.Text = "Purchase Code";
            dataGridViewPurchase.Rows.Clear();
            comboBoxSupplier.Items.Clear();
            comboBoxSupplier.ResetText();
            labelTotalPurchase.Text = "------";
            Order_tprice = 0;
        }
    }
}
