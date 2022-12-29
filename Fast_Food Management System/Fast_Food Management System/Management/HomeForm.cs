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
    public partial class HomeForm : Form
    {
        Home home = new Home();
        public HomeForm()
        {
            InitializeComponent();
            
        }


        private void HomeForm_Load(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            UserDao display = new UserDao();

            DataTable dt = display.Display();

            if (dt != null)
            {
                ListItem[] item = new ListItem[dt.Rows.Count];
                for (int i = 0; i < 1; i++)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        MemoryStream memoryStream = new MemoryStream((byte[])row["image"]);

                        item[i] = new ListItem();

                        item[i].Id = (int)row["id"];
                        item[i].Name = (string)row["prodName"];
                        item[i].Type = (string)row["typeOfProd"];
                        item[i].Price = (decimal)row["price"];
                        item[i].Image = new Bitmap(memoryStream);

                        flowLayoutPanel1.Controls.Add(item[i]);

                        item[i].Click += new System.EventHandler(this.listItem1_UpdateEvent);
                        //item[i].Click += new System.EventHandler(this.btnDelete_Click);
                    }
                }

            }


        }
        void Relaod()
        {
            this.Relaod();
        }

        private void listItem1_UpdateEvent(object sender, EventArgs e)
        {
            home = new Home();
            ListItem obj = (ListItem)sender;

            home.mainPanel.Controls.Clear();

            UpdateItem update = new UpdateItem();

            update.txtId.Text = Convert.ToString(obj.Id);
            update.txtName.Text = obj.Name;
            update.cbType.SelectedIndex = update.cbType.FindStringExact(obj.Type);
            update.txtPrice.Text = Convert.ToString(obj.Price);
            update.Picture.Image = obj.Image;

            update.ShowDialog();


            
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
