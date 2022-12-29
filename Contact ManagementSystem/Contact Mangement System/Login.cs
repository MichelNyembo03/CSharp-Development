using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Contact_Mangement_System
{
    public partial class Login : Form
    {

        public string usr = "";
        public string pss = "";
        Thread th;
        public Login()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void Login_Load(object sender, EventArgs e)
        {
            String root = @"C:\\Contact Management System db";
            if (!File.Exists(root))
            {
                Directory.CreateDirectory(root);

            }

            //Xml file for Conatct
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml("<Contacts>" +
                    "<Contact>" +
                        "<Id>" + "1C" + "</Id>" +
                        "<Name>" + "Michael" + "</Name>" +
                        "<SurName>" + "Nyembo" + "</SurName>" +
                        "<Title>" + "Manager" + "</Title>" +
                        "<Email>" + "MichaelNyembo03@gmail.com" + "</Email>" +
                        "<Phone>" + "+260770397209" + "</Phone>" +
                        "<Address>" + "Zambia, Lusaka" + "</Address>" +
                    "</Contact>" +
                "</Contacts>");

            //save the xml file

            if (!File.Exists(@"C:\\Contact Management System db\\Contact.xml"))
            {
                using (XmlTextWriter write = new XmlTextWriter(@"C:\\Contact Management System db\\Contact.xml", null))
                {
                    write.Formatting = Formatting.Indented;
                    xmldoc.Save(write);
                }
            }



            //Xml file for Admin

            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<Admins>" +
                    "<Admin>" +
                        "<Id>" + "1" + "</Id>" +
                        "<UserName>" + "Admin" + "</UserName>" +
                        "<Password>" + "admin" + "</Password>" +
                    "</Admin>" +
                "</Admins>");

            //save the xml file

            if (!File.Exists(@"C:\\Contact Management System db\\Admin.xml"))
            {
                using (XmlTextWriter write = new XmlTextWriter(@"C:\\Contact Management System db\\Admin.xml", null))
                {
                    write.Formatting = Formatting.Indented;
                    doc.Save(write);
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }

        public void openMain()
        {
            Application.Run(new Main());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string XMLuser = "";
            string XMLpass = "";
            string xUser = "";
            string xPass = "";
            var xdoc = XDocument.Load(@"C:\\Contact Management System db\\Admin.xml");
            var admin = from x in xdoc.Descendants("Admin").Where(x => (string)x.Element("Id") == "1")
                        select new
                        {
                            XMLuser = x.Element("UserName").Value,
                            XMLpass = x.Element("Password").Value
                        };

            foreach (var x in admin)
            {
                xUser = x.XMLuser;
                xPass = x.XMLpass;
            }

            if (textBox1.Text.ToUpper().Equals(xUser.ToUpper()) && textBox2.Text.ToUpper().Equals(xPass.ToUpper()))
            {
                Success s = new Success();
                s.ShowDialog();
                this.Close();
                th = new Thread(openMain);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
                
                
            }
            else
            {
                UserLoginError usE = new UserLoginError();
                usE.ShowDialog();


            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
