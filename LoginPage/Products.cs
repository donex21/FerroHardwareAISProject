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
    public partial class Products : UserControl
    {
        Boolean Search = false;
        OleDbConnection con = new OleDbConnection(Form1.connectionString);
        private static Products instance;
        public static Products Instance
        {
            get
            {
                if (instance == null)
                    instance = new Products();
                return instance;
            }
        }
        public Products()
        {
            InitializeComponent();
            CategoryItems();
        }

        private void Products_Load(object sender, EventArgs e)
        {
            CategoryItems();
            if (!Search)
                UserDisplay();
            else
            {
                Searchfirstname();
                Search = false;
            }
        }

        private void CategoryItems()
        {
            comboBoxcategory.Items.Clear();
            comboBoxSearch.Items.Clear();
            con.Open();
            OleDbCommand thisCommand = con.CreateCommand();
            thisCommand.CommandText = "SELECT * FROM Category";
            OleDbDataReader thisreader = thisCommand.ExecuteReader();
            while (thisreader.Read())
            {
                comboBoxcategory.Items.Add(thisreader["category_name"].ToString());
                comboBoxSearch.Items.Add(thisreader["category_name"].ToString());
            }
            thisreader.Close();
            con.Close();
        }

        private void UserDisplay()
        {
            con.Open();
            OleDbCommand thisCommand = con.CreateCommand();
            thisCommand.CommandText = "SELECT prod_code, prod_name, orig_price, srp, qty, moq, category FROM Product Order by prod_code";
            thisCommand.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(thisCommand);
            da.Fill(dt);
            dataGridViewProduct.DataSource = dt;
            con.Close();
        }

        private void Searchfirstname()
        {
            con.Open();
            OleDbCommand thisCommand = con.CreateCommand();
            thisCommand.CommandText = "SELECT prod_code, prod_name, orig_price, srp, qty, moq, category FROM Product where category like '%" + comboBoxSearch.Text + "%' Order by prod_code";
            thisCommand.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(thisCommand);
            da.Fill(dt);
            dataGridViewProduct.DataSource = dt;
            con.Close();
        }

        private void comboBoxcategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            textBoxProductCode.ForeColor = Color.Silver;
            textBoxProductCode.Text = "Product Code";
            textBoxProdName.ForeColor = Color.Silver;
            textBoxProdName.Text = "Product Name";
            textBoxSupplierPrice.ForeColor = Color.Silver;
            textBoxSupplierPrice.Text = "Supplier Price";
            textBoxSRP.ForeColor = Color.Silver;
            textBoxSRP.Text = "SRP";
            textBoxqty.ForeColor = Color.Silver;
            textBoxqty.Text = "Quantity";
            TextBoxmoq.ForeColor = Color.Silver;
            TextBoxmoq.Text = "MOQ";
            pictureBoxproduct.Image = LoginPage.Properties.Resources.noimage;
        }

        private void textBoxProductCode_Click(object sender, EventArgs e)
        {
            textBoxProductCode.Text = "";
            textBoxProductCode.ForeColor = Color.Black; 
        }

        private void textBoxProdName_Click(object sender, EventArgs e)
        {
            textBoxProdName.Text = "";
            textBoxProdName.ForeColor = Color.Black; 
        }

        private void textBoxSupplierPrice_Click(object sender, EventArgs e)
        {
            textBoxSupplierPrice.Text = "";
            textBoxSupplierPrice.ForeColor = Color.Black; 
        }

        private void textBoxSRP_Click(object sender, EventArgs e)
        {
            textBoxSRP.Text = "";
            textBoxSRP.ForeColor = Color.Black; 
        }

        private void textBoxqty_Click(object sender, EventArgs e)
        {
            textBoxqty.Text = "";
            textBoxqty.ForeColor = Color.Black; 
        }

        private void textBoxmoq_Click(object sender, EventArgs e)
        {
            TextBoxmoq.Text = "";
            TextBoxmoq.ForeColor = Color.Black; 
        }

        private void textBoxCategory_Click(object sender, EventArgs e)
        {
            textBoxCategory.Text = "";
            textBoxCategory.ForeColor = Color.Black; 
        }

        private void pictureBoxproduct_Click(object sender, EventArgs e)
        {
            //int Count = 0;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select an Item Image";
            ofd.Filter = "Image File (*.png;*.jpg;*.bmp;*.gif)|*.png;*.jpg;*.bmp;*.gif";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBoxproduct.Image = new Bitmap(ofd.FileName);
            }
        }

        private Image loadphoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Search = true;
            Searchfirstname(); 
            comboBoxSearch.Text = "";
        }

        private void buttonViewAll_Click(object sender, EventArgs e)
        {
            Search = false;
            UserDisplay();  
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxCategory.Text != "")
            {
                string sql = "Select * From Category";
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sql, con);
                OleDbCommandBuilder cmdbuilder = new OleDbCommandBuilder(dataAdapter);
                DataSet dataset = new DataSet();
                dataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                dataAdapter.Fill(dataset, "Category");

                DataRow findrow = dataset.Tables["Category"].Rows.Find(textBoxCategory.Text);
                if (findrow == null)
                {
                    DataRow datarow = dataset.Tables["Category"].NewRow();
                    datarow[0] = textBoxCategory.Text;

                    dataset.Tables["Category"].Rows.Add(datarow);
                    dataAdapter.Update(dataset, "Category");
                    MessageBox.Show("Successfully Saved");
                    textBoxCategory.ForeColor = Color.Silver;
                    textBoxCategory.Text = "Product Code";
                    UserDisplay();
                }
                else
                {
                    MessageBox.Show("Category already Exist");
                }
            }
            else {
                MessageBox.Show("Pls. Input Category");
                textBoxCategory.ForeColor = Color.Silver;
                textBoxCategory.Text = "Product Code";
            }
        }

        private bool TextEmpty()
        {
            if (TextBoxmoq.Text =="" || textBoxProdName.Text == "" || textBoxProductCode.Text == "" || 
                textBoxqty.Text == ""|| textBoxSRP.Text == ""|| textBoxSupplierPrice.Text == ""||
                comboBoxcategory.Text == "" || TextBoxmoq.ForeColor == Color.Silver || textBoxProdName.ForeColor == Color.Silver || textBoxProductCode.ForeColor == Color.Silver ||
                textBoxqty.ForeColor == Color.Silver || textBoxSRP.ForeColor == Color.Silver || textBoxSupplierPrice.ForeColor == Color.Silver ||
                comboBoxcategory.ForeColor == Color.Silver)
            {
                return true;
            }
            else
                return false;
        }

        private void buttonaddproduct_Click(object sender, EventArgs e)
        {
            if (!TextEmpty())
            {
                if (validnumberFloat(textBoxSupplierPrice.Text) && validnumberFloat(textBoxSRP.Text) && validnumberInt(textBoxqty.Text) && validnumberInt(TextBoxmoq.Text))
                {
                    string sql = "Select * From Product";
                    OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sql, con);
                    OleDbCommandBuilder cmdbuilder = new OleDbCommandBuilder(dataAdapter);
                    DataSet dataset = new DataSet();
                    dataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                    dataAdapter.Fill(dataset, "Product");

                    DataRow findrow = dataset.Tables["Product"].Rows.Find(textBoxProductCode.Text);
                    if (findrow == null)
                    {
                        DataRow datarow = dataset.Tables["Product"].NewRow();
                        datarow[0] = textBoxProductCode.Text;
                        datarow[1] = textBoxProdName.Text;
                        datarow[2] = textBoxSupplierPrice.Text;
                        datarow[3] = textBoxSRP.Text;
                        datarow[4] = textBoxqty.Text;
                        datarow[5] = TextBoxmoq.Text;
                        datarow[6] = comboBoxcategory.Text;
                        datarow[7] = Savephoto();
                        
                        dataset.Tables["Product"].Rows.Add(datarow);
                        dataAdapter.Update(dataset, "Product");
                        MessageBox.Show("Successfully Saved");
                        Clear();
                        comboBoxcategory.Text = "";
                        UserDisplay();
                    }
                    else
                    {
                        MessageBox.Show("Duplicate ID");
                    }
                }
                else
                {
                    MessageBox.Show("Pls. Provide Correct Input!!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Pls. Complete All Details");
            }
        }

        //Binary that equal to byte
        private byte[] Savephoto()
        {
            MemoryStream ms = new MemoryStream();
            pictureBoxproduct.Image.Save(ms, pictureBoxproduct.Image.RawFormat);
            return ms.GetBuffer();
        }

        public bool validnumberFloat(string value)
        {
            try
            {
                double val = Convert.ToDouble(value);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool validnumberInt(string value)
        {
            try
            {
                double val = Convert.ToInt32(value);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void comboBoxcategory_Click(object sender, EventArgs e)
        {
            CategoryItems();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (!TextEmpty())
            {
                if (validnumberFloat(textBoxSupplierPrice.Text) && validnumberFloat(textBoxSRP.Text) && validnumberInt(textBoxqty.Text) && validnumberInt(TextBoxmoq.Text))
                {

                    OleDbCommand cmd1 = con.CreateCommand();
                    cmd1 = new OleDbCommand("UPDATE Product set prod_code=@prodcode, prod_name=@prodname, orig_price=@origprice, srp=@srp, qty=@qty, moq=@moq, category=@category, prodimage=@prodimage where prod_code=@prodcode", con);
                    con.Open();
                    cmd1.Parameters.AddWithValue("@prodcode", textBoxProductCode.Text);
                    cmd1.Parameters.AddWithValue("@prodname", textBoxProdName.Text);
                    cmd1.Parameters.AddWithValue("@origprice", textBoxSupplierPrice.Text);
                    cmd1.Parameters.AddWithValue("@srp", textBoxSRP.Text);
                    cmd1.Parameters.AddWithValue("@qty", textBoxqty.Text);
                    cmd1.Parameters.AddWithValue("@moq", TextBoxmoq.Text);
                    cmd1.Parameters.AddWithValue("@category", comboBoxcategory.Text);
                    cmd1.Parameters.AddWithValue("@prodimage", Savephoto());

                    cmd1.ExecuteNonQuery();
                    con.Close();
                    /*string sql = "Select * From Product";
                    OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sql, con);
                    OleDbCommandBuilder cmdbuilder = new OleDbCommandBuilder(dataAdapter);
                    DataSet dataset = new DataSet();
                    dataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                    dataAdapter.Fill(dataset, "Product");

                    DataRow findrow = dataset.Tables["Product"].Rows.Find(textBoxProductCode.Text);
                    if (findrow != null)
                    {
                        //DataRow datarow = dataset.Tables["Product"].NewRow();
                        findrow[0] = textBoxProductCode.Text;
                        findrow[1] = textBoxProdName.Text;
                        findrow[2] = textBoxSupplierPrice.Text;
                        findrow[3] = textBoxSRP.Text;
                        findrow[4] = textBoxqty.Text;
                        findrow[5] = TextBoxmoq.Text;
                        findrow[6] = comboBoxcategory.Text;
                        findrow[7] = Savephoto();

                        //dataset.Tables["Product"].Rows.Add(datarow);
                        dataAdapter.Update(dataset, "Product");*/
                    MessageBox.Show("Successfully Saved");
                    Clear();
                        comboBoxcategory.Text = "";
                        UserDisplay();
                    
                    /*else
                    {
                        MessageBox.Show("That Id is Unique!!!");
                    }*/
                }
                else
                {
                    MessageBox.Show("Pls. Provide Correct Input!!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Pls. Complete All Details");
            }
        }

        private void comboBoxSearch_Click(object sender, EventArgs e)
        {
            CategoryItems();
        }

        private void dataGridViewProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dataGridViewProduct.SelectedCells[0].Value.ToString();
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
                textBoxProductCode.Text = dr["prod_code"].ToString();
                textBoxProdName.Text = dr["prod_name"].ToString();
                textBoxSupplierPrice.Text = dr["orig_price"].ToString();
                textBoxSRP.Text = dr["srp"].ToString();
                textBoxqty.Text = dr["qty"].ToString();
                TextBoxmoq.Text = dr["moq"].ToString();
                comboBoxcategory.Text = dr["category"].ToString();
                pictureBoxproduct.Image = (dr["prodimage"] is DBNull) ? LoginPage.Properties.Resources.noimage : loadphoto((byte[])dr["prodimage"]);

            }
            con.Close();
            blackcolor();
        }

        private void blackcolor()
        {
            textBoxProductCode.ForeColor = Color.Black;
            textBoxProdName.ForeColor = Color.Black;
            textBoxSupplierPrice.ForeColor = Color.Black;
            textBoxSRP.ForeColor = Color.Black;
            textBoxqty.ForeColor = Color.Black;
            TextBoxmoq.ForeColor = Color.Black;

        }

        private void buttonDelte_Click(object sender, EventArgs e)
        {
            string id;
            if (textBoxProductCode.Text == "" || textBoxProductCode.Text == "Product Code")
            {
                MessageBox.Show("Pls. Chooose a User You Want to Delete");
            }
            else
            {
                id = textBoxProductCode.Text;
                con.Open();
                OleDbCommand thisCommand2 = con.CreateCommand();
                thisCommand2.CommandType = CommandType.Text;
                thisCommand2.CommandText = "DELETE FROM Product where prod_code = '" + id + "'";
                thisCommand2.ExecuteNonQuery();
                con.Close();
                Clear();
                UserDisplay();
                MessageBox.Show("User Succesfully Deleted");
            }
        }

        private void textBoxProductCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Boolean exist = false;
                do
                {
                    Random randomcode = new Random();
                    textBoxProductCode.ForeColor = Color.Black;
                    int Count = randomcode.Next(1, 5000);
                    con.Open();
                    OleDbCommand checkid = new OleDbCommand("SELECT count([prod_code]) FROM Product WHERE (prod_code = 'AN-00" + Count.ToString() + "') ", con);
                    int UserExist = (int)checkid.ExecuteScalar();
                    if (UserExist == 1)
                    {
                        exist = true;
                    }
                    else
                        exist = false;
                    con.Close();
                    if (!exist)
                        textBoxProductCode.Text = "AN-00" + (Count);
                } while (exist);
            }
        }

        private void textBoxProdName_TextChanged(object sender, EventArgs e)
        {
            textBoxProdName.ForeColor = Color.Black;
        }

        private void textBoxSupplierPrice_TextChanged(object sender, EventArgs e)
        {
            textBoxSupplierPrice.ForeColor = Color.Black;
        }

        private void textBoxSRP_TextChanged(object sender, EventArgs e)
        {
            textBoxSRP.ForeColor = Color.Black;
        }

        private void textBoxqty_TextChanged(object sender, EventArgs e)
        {
            textBoxqty.ForeColor = Color.Black;
        }

        private void TextBoxmoq_TextChanged(object sender, EventArgs e)
        {
            TextBoxmoq.ForeColor = Color.Black;
        }
    }
}
