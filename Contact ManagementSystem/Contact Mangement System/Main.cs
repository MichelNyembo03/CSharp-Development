using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Contact_Mangement_System
{
    public partial class Main : Form
    {
        bool isCollapse =true;
        UserLoginError ulError;
     

        public Form propForm1 { get; set; }

        public Panel panel {
            get { return mainPanel; }
            set { mainPanel.Controls.Add(value); }
        
        }

        public Main()
        {
            InitializeComponent();
        }

        public void openLogin()
        {
            Application.Run(new Login());
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread th = new Thread(openLogin);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            panelb1.Visible = false;
            panelb2.Visible = true;

            Contact c = new Contact();
            c.TopLevel = false;
            c.FormBorderStyle = FormBorderStyle.None;
            mainPanel.Controls.Add(c);
            c.Dock = DockStyle.Fill;
            c.Visible = true;

            

        }
        private void timer_bar_Tick(object sender, EventArgs e)
        {
            timer_bar.Interval = 10;
            if (isCollapse)
            {
                menuBar.Width -= 240;

                if (menuBar.Width == menuBar.MinimumSize.Width)
                {
                    isCollapse = false;
                    timer_bar.Stop();
                }
            }
            else
            {
                menuBar.Width += 240;

                if (menuBar.Width == menuBar.MaximumSize.Width)
                {
                    isCollapse = true;
                    timer_bar.Stop();
                }
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            timer_bar.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            panelb1.Visible = true;
            panelb2.Visible = false;

            Dashboard d = new Dashboard();
            d.TopLevel = false;
            d.FormBorderStyle = FormBorderStyle.None;
            mainPanel.Controls.Add(d);
            d.Dock = DockStyle.Fill;
            d.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            panelb1.Visible = true;
            panelb2.Visible = false;

            Dashboard d = new Dashboard();
            d.TopLevel = false;
            d.FormBorderStyle = FormBorderStyle.None;
            mainPanel.Controls.Add(d);
            d.Dock = DockStyle.Fill;
            d.Visible = true;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            panelb1.Visible = true;
            panelb2.Visible = false;

            About about = new About();
            about.TopLevel = false;
            about.FormBorderStyle = FormBorderStyle.None;
            mainPanel.Controls.Add(about);
            about.Dock = DockStyle.Fill;
            about.Visible = true;
        }

        public void Admin()
        {
            
                mainPanel.Controls.Clear();
                panelb1.Visible = true;
                panelb2.Visible = false;

                About a = new About();
                a.TopLevel = false;
                a.FormBorderStyle = FormBorderStyle.None;
                mainPanel.Controls.Add(a);
                a.Dock = DockStyle.Fill;
                a.Visible = true;
          
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}