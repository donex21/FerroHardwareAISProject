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
using System.Drawing.Printing;

namespace LoginPage
{
    public partial class POS : UserControl
    {
        OleDbConnection con = new OleDbConnection(Form1.connectionString);
        double Order_tprice = 0;
        private static POS instance;
        public static POS Instance
        {
            get
            {
                if (instance == null)
                    instance = new POS();
                return instance;
            }
        }
        public POS()
        {
            InitializeComponent();
        }

        private void textBoxReceiptno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Boolean exist = false;
                do
                {
                    Random randomcode = new Random();
                    textBoxReceiptno.ForeColor = Color.Black;
                    int Count = randomcode.Next(1, 5000);
                    con.Open();
                    OleDbCommand checkid = new OleDbCommand("SELECT count([receipt_no]) FROM SalesReport WHERE (receipt_no = 'OR-00" + Count.ToString() + "') ", con);
                    int UserExist = (int)checkid.ExecuteScalar();
                    if (UserExist == 1)
                    {
                        exist = true;
                    }
                    else
                        exist = false;
                    con.Close();
                    if (!exist)
                        textBoxReceiptno.Text = "OR-00" + (Count);
                } while (exist);
            }
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

        private void Items()
        {
            con.Open();
            OleDbCommand thisCommand = con.CreateCommand();
            thisCommand.CommandText = "SELECT prod_code AS Code, prod_name AS Name, SRP, qty, category FROM Product where category like '%" + comboBoxSearchItem.Text + "%' Order by prod_code";
            thisCommand.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(thisCommand);
            da.Fill(dt);
            dataGridViewItemList.DataSource = dt;
            con.Close();
        }

        private void comboBoxSearchItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Items();
            }
        }

        private Image loadphoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
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
            catch
            {
                MessageBox.Show("Pls Choose a Item");
            }
        }

        private void textBoxSalesqty_KeyPress(object sender, KeyPressEventArgs e)
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
                if (textBoxSalesqty.Text == "")
                    MessageBox.Show("Pls. Complete the details");
                else if (!unique(dataGridViewItemList.SelectedCells[0].Value.ToString()))
                {
                    MessageBox.Show("The Item is already in the List");
                    textBoxSalesqty.Text = "";
                }
                else if (!prod.validnumberInt(textBoxSalesqty.Text))
                {
                    MessageBox.Show("Pls. Input Valid Number !!");
                    textBoxSalesqty.Text = "";
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
                        double price = Convert.ToDouble(dr["srp"].ToString());
                        double dtbsqty = Convert.ToDouble(dr["qty"].ToString());

                        double qty = Convert.ToDouble(textBoxSalesqty.Text);
                        if (dtbsqty >= qty)
                        {
                            double tprice = price * qty;
                            Order_tprice += tprice;
                            dataGridViewSales.Rows.Add(dr["prod_code"].ToString(), dr["prod_name"].ToString(), textBoxSalesqty.Text, dr["srp"].ToString(), tprice.ToString());
                            labelTotalSales.Text = Order_tprice.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Cannot acquire the Order");
                            textBoxSalesqty.Text = "";
                            con.Close();
                            return;
                        }
                    }
                    con.Close();

                    textBoxSalesqty.Text = "";
                }
            }
            catch
            {
                MessageBox.Show("Impractical Error");
            }
        }

        private bool unique(string value)
        {
            for (int i = 0; i < dataGridViewSales.RowCount; i++)
                if (value.Equals(dataGridViewSales.Rows[i].Cells[0].Value.ToString()))
                    return false;
            return true;
        }

        private void buttonDeleteItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewSales.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show(@"Do you want to Delete the Item?", "Confirmation", MessageBoxButtons.YesNoCancel);
                switch (result)
                {
                    case DialogResult.Yes:
                        Order_tprice -= Convert.ToDouble(dataGridViewSales.SelectedCells[4].Value.ToString());
                        dataGridViewSales.Rows.RemoveAt(dataGridViewSales.CurrentRow.Index);
                        labelTotalSales.Text = Order_tprice.ToString();
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

        double cashChange = 0;
        private void textBoxTendered_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!prod.validnumberFloat(textBoxTendered.Text))
                {
                    MessageBox.Show("Pls input Valid Number");
                    textBoxTendered.Text = "";
                }
                else if (Order_tprice < Convert.ToDouble(textBoxTendered.Text))
                {
                    cashChange = Convert.ToDouble(textBoxTendered.Text) - Order_tprice;
                    textBoxChange.Text = cashChange.ToString();
                    textBoxChange.Focus();
                }
                else {
                    MessageBox.Show("The amount you tendered is ineffecient");
                    textBoxTendered.Text = "";
                }
            }
        }

        private void textBoxTendered_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxChange.Text = "";
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            SaveAndPrint();
        }

        private void textBoxChange_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SaveAndPrint();
            }
        }

        private void SaveAndPrint()
        {
            if (textBoxReceiptno.Text == "Receipt No." || dataGridViewSales.RowCount <= 0 || textBoxTendered.Text == "")
            {
                MessageBox.Show("Pls. Complete all Details");
            }
            else {
                print();
                SaveSalesReport();
                SaveSoldProduct();
                MinusItemQTY();
                textBoxReceiptno.Text = "Receipt No.";
                textBoxReceiptno.ForeColor = Color.Silver;
                dataGridViewSales.Rows.Clear();
                textBoxTendered.Text = "";
                labelTotalSales.Text = "";
                textBoxChange.Text = "";
                Order_tprice = 0;
            }
        }
        private void print()
        {
            PrintDialog printDialog = new PrintDialog();
            PrintDocument printDocument = new PrintDocument();

            printDialog.Document = printDocument;
            printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(CreateReceipt);

            DialogResult result = printDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        Home_Page home = new Home_Page();
        private void SaveSalesReport()
        {
            string sql = "Select * From SalesReport";
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sql, con);
            OleDbCommandBuilder cmdbuilder = new OleDbCommandBuilder(dataAdapter);
            DataSet dataset = new DataSet();
            dataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            dataAdapter.Fill(dataset, "SalesReport");

            DataRow findrow = dataset.Tables["SalesReport"].Rows.Find(textBoxReceiptno.Text);
            if (findrow == null)
            {
                DataRow datarow = dataset.Tables["SalesReport"].NewRow();
                datarow[0] = textBoxReceiptno.Text;
                datarow[1] = home.username();
                datarow[2] = Convert.ToDouble(labelTotalSales.Text);
                datarow[3] = DateTime.Now.ToShortDateString();

                dataset.Tables["SalesReport"].Rows.Add(datarow);
                dataAdapter.Update(dataset, "SalesReport");

            }
            else
            {
                MessageBox.Show("Duplicate Purchase Number");
            }
        }

        private void SaveSoldProduct()
        {
            foreach (DataGridViewRow row in dataGridViewSales.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    string sql = "Select * From SoldProduct";
                    OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sql, con);
                    OleDbCommandBuilder cmdbuilder = new OleDbCommandBuilder(dataAdapter);
                    DataSet dataset = new DataSet();
                    dataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                    dataAdapter.Fill(dataset, "SoldProduct");
                    object[] colpk = new object[2];
                    colpk[0] = textBoxReceiptno.Text;
                    colpk[1] = row.Cells[0].Value;
                    DataRow findrow = dataset.Tables["SoldProduct"].Rows.Find(colpk);
                    if (findrow == null)
                    {
                        DataRow datarow = dataset.Tables["SoldProduct"].NewRow();
                        datarow[0] = textBoxReceiptno.Text;
                        datarow[1] = row.Cells[0].Value;
                        datarow[2] = row.Cells[2].Value;
                        datarow[3] = row.Cells[4].Value;
                       // datarow[4] = row.Cells[5].Value;
                        dataset.Tables["SoldProduct"].Rows.Add(datarow);
                        dataAdapter.Update(dataset, "SoldProduct");
                    }
                }
            }
        }

        private void MinusItemQTY()
        {
            double previewsqty = 0;
            foreach (DataGridViewRow row in dataGridViewSales.Rows)
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

                        findrow[1] = previewsqty - (Convert.ToDouble(row.Cells[2].Value));
                        //dataset.Tables["Item"].Rows.Add(datarow);
                        dataAdapter.Update(dataset, "Product");
                    }
                }
            }
        }

        public void CreateReceipt(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics graphic = e.Graphics;

            Font font = new Font("Courier New", 12); //must use a mono spaced font as the spaces need to line up

            float fontHeight = font.GetHeight();

            int startX = 10;
            int startY = 10;
            int offset = 40;

            graphic.DrawString(" FERRO HARDWARE", new Font("Courier New", 18), new SolidBrush(Color.Black), startX, startY);
            string top = "CUENCO AVE, BANILAD , CEBU CITY \n TIN: 447-590-226-000 \n OR No: " + textBoxReceiptno.Text + "\nDate: " + DateTime.Now.ToString();
            graphic.DrawString(top, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight + 50; //make the spacing consistent
            graphic.DrawString("----------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight + 5; //make the spacing consistent

            string nexttop = "Item Name".PadRight(15) + "QTY.".PadRight(5) + "Price".PadRight(10)+ "Amount";
            graphic.DrawString(nexttop, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight; //make the spacing consistent
            graphic.DrawString("----------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight + 5; //make the spacing consistent


            foreach (DataGridViewRow row in dataGridViewSales.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    string productLine = row.Cells[1].Value.ToString().PadRight(15) + row.Cells[2].Value.ToString().PadRight(5) + row.Cells[3].Value.ToString().PadRight(10) + row.Cells[4].Value.ToString();
                    graphic.DrawString(productLine, new Font("Courier New", 12, FontStyle.Italic), new SolidBrush(Color.Black), startX, startY + offset);
                    offset = offset + (int)fontHeight + 5; //make the spacing consistent
                }
            }

            offset = offset + 20; //make some room so that the total stands out.
            double vat = Convert.ToDouble(labelTotalSales.Text) * .12;
            graphic.DrawString("Total to pay ".PadRight(30) + String.Format("{0:c}", labelTotalSales.Text), new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);

            offset = offset + 20; //make some room so that the total stands out.
            graphic.DrawString("Vat Amount ".PadRight(30) + String.Format("\u20B1{0}", vat), font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 15;
            graphic.DrawString("CASH ".PadRight(30) + String.Format("{0:c}", textBoxTendered.Text), font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 15;
            graphic.DrawString("CHANGE ".PadRight(30) + String.Format("{0:c}", textBoxChange.Text), font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 30; //make some room so that the total stands out.
            graphic.DrawString("     Thank you for shopping,", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 15;
            graphic.DrawString("       Please Come Back Soon!", font, new SolidBrush(Color.Black), startX, startY + offset);

        }

    }
}
