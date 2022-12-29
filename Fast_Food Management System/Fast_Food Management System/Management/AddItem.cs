using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fast_Food_Management_System.Management
{
    public partial class AddItem : Form
    {
        UserDao insert;
        public AddItem()
        {
            InitializeComponent();
        }
        public string GenerateId()
        {
            Random randNum = new Random();
            int num = randNum.Next(100, 999);

            return "IT" + num.ToString();

        }

        string imageLocation = "";
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "png Files (*.png)|*.png|jpg Files (*.jpg)|*.jpg|All Files(*.*)|*.*";

            if (of.ShowDialog() == DialogResult.OK)
            {
                imageLocation = of.FileName.ToString();
                Picture.ImageLocation = imageLocation;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            byte[] image = null;
            FileStream stream = new FileStream(imageLocation, FileMode.Open, FileAccess.Read);
            BinaryReader brs = new BinaryReader(stream);
            image = brs.ReadBytes((int)stream.Length);

            string type = cbType.SelectedItem.ToString();
            insert = new UserDao();
            if(txtName.Text != "" &&  txtPrice.Text != ""&& Picture.Image != null)
            {
                insert.AddItem(txtName.Text, type, Convert.ToDouble(txtPrice.Text),image);
                txtName.PlaceholderText = "Product Name";
                txtPrice.PlaceholderText = "0.00";
                cbType.SelectedIndex= 0;
                Picture.Image = null;
            }
        }

        private void AddItem_Load(object sender, EventArgs e)
        {
            cbType.SelectedIndex = 0;
        }

        public void OpenFom()
        {
            Application.Run(new Home());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

            Thread th = new Thread(OpenFom);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.';

            if(e.KeyChar !='.' && (sender as TextBox).Text.IndexOf(".") == -1)
            {
                e.Handled = true;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Picture_Click(object sender, EventArgs e)
        {

        }

        private void txtPrice_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && !char.IsControl(e.KeyChar);

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
           {
            e.Handled = true;
           }

        }

        private void cbType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
