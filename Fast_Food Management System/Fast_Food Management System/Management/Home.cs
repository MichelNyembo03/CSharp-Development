using Fast_Food_Management_System.Properties;
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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }


        private void Home_Load(object sender, EventArgs e)
        {
            
            mainPanel.Controls.Clear();

            HomeForm hf = new HomeForm();
            hf.TopLevel = false;
            hf.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(hf);
            hf.Visible = true;
        }

        

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btmAdd_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            
            AddItem add = new AddItem();
            add.TopLevel = false;
            add.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(add);
            add.Visible= true;



        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listItem1_Load_1(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();

            HomeForm hf = new HomeForm();
            hf.TopLevel = false;
            hf.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(hf);
            hf.Visible = true;
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
            WindowState = FormWindowState.Minimized;
        }

        private bool mouseDown;
        private Point lastLocation;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point((this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
                this.Update();
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();

            HomeForm hf = new HomeForm();
            hf.TopLevel = false;
            hf.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(hf);
            hf.Visible = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void openLogin()
        {
            System.Windows.Forms.Application.Run(new LoginForm());
        }
 
    }
}
