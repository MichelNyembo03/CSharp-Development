using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace Fast_Food_Management_System.Management
{
    public partial class UpdateItem : Form
    {
        public UpdateItem()
        {
            InitializeComponent();
        }

        public void OpenForm()
        {
            System.Windows.Forms.Application.Run(new Home());
        }


        public void Update()
        {
            string type = cbType.SelectedItem.ToString();
            DbConnection conn = new DbConnection();
            using (var connection = conn.GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {
                        
                        command.Connection = connection;
                        if (Picture.ImageLocation == null)
                        {
                            command.CommandText = "UPDATE Product SET prodName=@name, typeOfProd=@type, price=@price WHERE id=@id";
                            command.Parameters.AddWithValue("@id", Convert.ToInt16(txtId.Text));
                            command.Parameters.AddWithValue("@name", txtName.Text);
                            command.Parameters.AddWithValue("@type", type);
                            command.Parameters.AddWithValue("@price", Convert.ToDouble(txtPrice.Text));

                        }
                        else
                        {

                            imageLocation = Picture.ImageLocation;

                            byte[] image = null;
                            FileStream stream = new FileStream(Picture.Name, FileMode.Open, FileAccess.Read);
                            BinaryReader brs = new BinaryReader(stream);
                            image = brs.ReadBytes((int)stream.Length);

                            command.CommandText = "UPDATE Product SET prodName=@name, typeOfProd=@type, price=@price, image=@image WHERE id=@id";
                            command.Parameters.AddWithValue("@id", Convert.ToInt16(txtId.Text));
                            command.Parameters.AddWithValue("@name", txtName.Text);
                            command.Parameters.AddWithValue("@type", type);
                            command.Parameters.AddWithValue("@price", Convert.ToDouble(txtPrice.Text));
                            command.Parameters.AddWithValue("@image", image);
                        }
                       

                        command.ExecuteNonQuery();
                        MessageBox.Show("Item Updated!");

                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        public void Delete()
        {
           
            DbConnection conn = new DbConnection();
            using (var connection = conn.GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "DELETE FROM Product WHERE id=@id";
                        command.Parameters.AddWithValue("@id", Convert.ToInt16(txtId.Text));
                        

                        var execute = command.ExecuteNonQuery();
                        MessageBox.Show("Item Deleted!");
                        this.Close();

                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           
            if(txtName.Text != "" && txtPrice.Text != "" && Picture.Image != null)
            {
                Update();
            }
            else
            {
                MessageBox.Show("Please, Fll All the field");
            }
        }

        string imageLocation = "";
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "png Files (*.png)|*.png|jpg Files (*.jpg)|*.jpg|All Files(*.*)|*.*";

            if(of.ShowDialog() == DialogResult.OK )
            {
                imageLocation = of.FileName.ToString();
                Picture.ImageLocation= imageLocation;
            }
            else
            {
                imageLocation = Picture.ImageLocation;
                Picture.ImageLocation = imageLocation;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

            Thread th = new Thread(OpenForm);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                txtId.ReadOnly = false;
                txtName.ReadOnly = false;
                txtPrice.ReadOnly = false;
                cbType.DropDownStyle= ComboBoxStyle.DropDown;
                button2.Enabled = true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Delete();
        }

        private void UpdateItem_Load(object sender, EventArgs e)
        {
            
            txtName.ReadOnly = true;
            txtPrice.ReadOnly = true;
            cbType.DropDownStyle = ComboBoxStyle.DropDownList;
            button2.Enabled = false;
        }

        private void UpdateItem_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && !char.IsControl(e.KeyChar);

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
 
        }

        private void cbType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled= true;
        }
    }
}
