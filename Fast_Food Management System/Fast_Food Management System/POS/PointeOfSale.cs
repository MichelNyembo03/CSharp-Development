using Fast_Food_Management_System.Management;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Fast_Food_Management_System.POS
{
    public partial class PointeOfSale : Form
    {
        decimal tot = 0;
        string name;
        public decimal quantity = 0;
        public PointeOfSale()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();

            Thread th = new Thread(openLogin);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            WindowState= FormWindowState.Minimized;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PointeOfSale_Load(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            UserDao display = new UserDao();
            DataTable dt = display.Display();

            if(dt != null)
            {
                Items[] item = new Items[dt.Rows.Count];

                for(int i=0; i<1; i++)
                {
                    foreach(DataRow row in dt.Rows)
                    {
                        MemoryStream ms = new MemoryStream((byte[])row["image"]);

                        item[i] = new Items();

                        item[i].Image = new Bitmap(ms);
                        item[i].Name = (string)row["prodName"];
                        item[i].Price = (decimal)row["price"];

                        flowLayoutPanel1.Controls.Add(item[i]);

                        item[i].Click += new EventHandler(this.Order_Event);
                    }

                }
            }
        }

        public void Order_Event(object sender, EventArgs e)
        {
            bool isDuplicate = false;

            Items obj = sender as Items;

            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToString(row.Cells["Hname"].Value) == obj.Name.ToString())
                {
                    isDuplicate = true;
                    MessageBox.Show("Item added already in the order list");
                    return;
                }
            }

            Quantity qty = new Quantity();
            qty.ShowDialog();

            quantity = Convert.ToDecimal(qty.textBox1.Text);

            if (!isDuplicate)
            {
                //string quantity = Interaction.InputBox($"ENTER THE {obj.Name} QUANTITY");
                dataGridView1.Rows.Add(obj.Name.ToString(), quantity, decimal.Round(obj.Price* quantity,2).ToString()+"$");
                tot = tot + (decimal)obj.Price * Convert.ToDecimal(quantity);
                TotalPrice.Text = tot.ToString()+"$";
                name = obj.Name.ToString();
                
            }

            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("There is no order");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Are You Sure?", "Some Title", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    dataGridView1.Rows.Clear();
                    TotalPrice.Text = "0";
                }
            }
            
            
        }
        int count = 0;

        public string[] ItemsName = { };
        public string[] ItemsPrice = { };

        private void button5_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count != 0)
            {
                dataGridView1.AllowUserToAddRows = false;
                count = dataGridView1.Rows.Cast<DataGridViewRow>()
                   .Select(row => row.Cells["Hname"].Value.ToString() == name).Count();

                UserDao insert = new UserDao();
                insert.InsertOrder(dataGridView1);


                ItemsName = new string[this.dataGridView1.Rows.Count];

                ItemsPrice = new string[this.dataGridView1.Rows.Count];

                if (dataGridView1.Rows.Count != 0)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        ItemsName[row.Index] = row.Cells[0].Value.ToString().Trim();
                    }

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        ItemsPrice[row.Index] = row.Cells[2].Value.ToString().Trim();
                    }
                }



                Receipt receipt = new Receipt();
                receipt.names = new string[ItemsName.Length];
                receipt.prices = new string[ItemsPrice.Length];
                if (ItemsName.Length != 0)
                {
                    for (int i = 0; i < ItemsName.Length; i++)
                    {
                        receipt.names[i] = ItemsName[i];
                    }

                    for (int i = 0; i < ItemsPrice.Length; i++)
                    {
                        receipt.prices[i] = ItemsPrice[i];
                    }
                }



                receipt.cost = (decimal.Round(decimal.Parse(this.TotalPrice.Text.Replace("$","")) - (decimal.Parse(this.TotalPrice.Text.Replace("$", "")) * (decimal)0.2), 2)).ToString();
                dataGridView1.Rows.Clear();
                TotalPrice.Text = "0";
                receipt.ShowDialog();

                dataGridView1.AllowUserToAddRows = true;

            }
            else
            {
                MessageBox.Show("There is no order");
            }

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    dataGridView1.Rows.RemoveAt(row.Index);
                }
            }catch(Exception ex)
            {
               
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            all.BackColor = ColorTranslator.FromHtml("#ffffff");
            food.BackColor = ColorTranslator.FromHtml("#ececec");
            drink.BackColor = ColorTranslator.FromHtml("#ffffff");

            flowLayoutPanel1.Controls.Clear();
            UserDao display = new UserDao();
            DataTable dt = display.DisplayFood();

            if (dt != null)
            {
                Items[] item = new Items[dt.Rows.Count];

                for (int i = 0; i < 1; i++)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        MemoryStream ms = new MemoryStream((byte[])row["image"]);

                        item[i] = new Items();

                        item[i].Image = new Bitmap(ms);
                        item[i].Name = (string)row["prodName"];
                        item[i].Price = (decimal)row["price"];

                        flowLayoutPanel1.Controls.Add(item[i]);

                        item[i].Click += new EventHandler(this.Order_Event);
                    }

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            all.BackColor = ColorTranslator.FromHtml("#ffffff");
            food.BackColor = ColorTranslator.FromHtml("#ffffff");
            drink.BackColor = ColorTranslator.FromHtml("#ececec");

            flowLayoutPanel1.Controls.Clear();
            UserDao display = new UserDao();
            DataTable dt = display.DisplayDrink();

            if (dt != null)
            {
                Items[] item = new Items[dt.Rows.Count];

                for (int i = 0; i < 1; i++)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        MemoryStream ms = new MemoryStream((byte[])row["image"]);

                        item[i] = new Items();

                        item[i].Image = new Bitmap(ms);
                        item[i].Name = (string)row["prodName"];
                        item[i].Price = (decimal)row["price"];

                        flowLayoutPanel1.Controls.Add(item[i]);

                        item[i].Click += new EventHandler(this.Order_Event);
                    }

                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            all.BackColor = ColorTranslator.FromHtml("#ececec");
            food.BackColor = ColorTranslator.FromHtml("#ffffff");
            drink.BackColor = ColorTranslator.FromHtml("#ffffff");
            
            flowLayoutPanel1.Controls.Clear();
            UserDao display = new UserDao();
            DataTable dt = display.Display();

            if (dt != null)
            {
                Items[] item = new Items[dt.Rows.Count];

                for (int i = 0; i < 1; i++)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        MemoryStream ms = new MemoryStream((byte[])row["image"]);

                        item[i] = new Items();

                        item[i].Image = new Bitmap(ms);
                        item[i].Name = (string)row["prodName"];
                        item[i].Price = (decimal)row["price"];

                        flowLayoutPanel1.Controls.Add(item[i]);

                        item[i].Click += new EventHandler(this.Order_Event);
                    }

                }
            }
        }

        DataTable dt;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            

            flowLayoutPanel1.Controls.Clear();
            UserDao display = new UserDao();
            
            if(all.BackColor == ColorTranslator.FromHtml("#ececec"))
            {
                dt = display.DisplaySearch(textBox1);
            }
            if(food.BackColor == ColorTranslator.FromHtml("#ececec"))
            {
                dt = display.DisplaySearchFood(textBox1);

            }
            if (drink.BackColor == ColorTranslator.FromHtml("#ececec"))
            {
                dt = display.DisplaySearchDrink(textBox1);

            }


            if (dt != null)
            {
                Items[] item = new Items[dt.Rows.Count];

                for (int i = 0; i < 1; i++)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        MemoryStream ms = new MemoryStream((byte[])row["image"]);

                        item[i] = new Items();

                        item[i].Image = new Bitmap(ms);
                        item[i].Name = (string)row["prodName"];
                        item[i].Price = (decimal)row["price"];

                        flowLayoutPanel1.Controls.Add(item[i]);

                        item[i].Click += new EventHandler(this.Order_Event);
                    }

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            UserDao display = new UserDao();

            if (all.BackColor == ColorTranslator.FromHtml("#ececec"))
            {
                dt = display.DisplaySearch(textBox1);
            }
            if (food.BackColor == ColorTranslator.FromHtml("#ececec"))
            {
                dt = display.DisplaySearchFood(textBox1);

            }
            if (drink.BackColor == ColorTranslator.FromHtml("#ececec"))
            {
                dt = display.DisplaySearchDrink(textBox1);

            }


            if (dt != null)
            {
                Items[] item = new Items[dt.Rows.Count];

                for (int i = 0; i < 1; i++)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        MemoryStream ms = new MemoryStream((byte[])row["image"]);

                        item[i] = new Items();

                        item[i].Image = new Bitmap(ms);
                        item[i].Name = (string)row["prodName"];
                        item[i].Price = (decimal)row["price"];

                        flowLayoutPanel1.Controls.Add(item[i]);

                        item[i].Click += new EventHandler(this.Order_Event);
                    }

                }
            }
        }

        private bool mouseDown;
        private Point lastLocation;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point((this.Location.X - this.lastLocation.X) + e.X, (this.Location.Y - this.lastLocation.Y) + e.Y);
            }
        }

        public void openLogin()
        {
            System.Windows.Forms.Application.Run(new LoginForm());
        }

        private void textqt_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //dataGridView1.Rows.Cell[2].Value = (decimal)dataGridView1.Rows.Cells[1].Value * (decimal)(decimal)dataGridView1.Rows.Cells[2];
        }
    }
}
