using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Contact_Mangement_System
{
    public partial class InsertContact : Form
    {
        XmlDocument xmldoc = new XmlDocument();
        Success s;
        Failed f;
        Contact c = new Contact();
        public InsertContact()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = 1;

            if (File.Exists(@"C:\\Contact Management System db\\Contact.xml"))
            {
                var doc = XDocument.Load(@"C:\\Contact Management System db\\Contact.xml");
                if (name.Text.Length != 0 && surname.Text.Length != 0 && title.Text.Length != 0 &&
                        email.Text.Length != 0 && phone.Text.Length != 0 && address.Text.Length != 0)
                {
                    var Element = new XElement("Contact",
                        new XElement("Id", IdGenerated()),
                        new XElement("Name", name.Text),
                        new XElement("SurName", surname.Text),
                        new XElement("Title", title.Text),
                        new XElement("Email", email.Text),
                        new XElement("Phone", phone.Text),
                        new XElement("Address", address.Text));

                    doc.Element("Contacts").Add(Element);

                    doc.Save(@"C:\\Contact Management System db\\Contact.xml");

                    s = new Success();
                    s.ShowDialog();
                }
                else
                {
                    f = new Failed();
                    f.ShowDialog();
                }
                    
            }
            else
            {
               
            }
        }

        public string IdGenerated()
        {
            Random rand = new Random();
            int num = rand.Next(99);
            int indice = rand.Next(26);
            char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            return num.ToString() + alpha[indice];
        }

        private void InsertContact_Load(object sender, EventArgs e)
        {
            
        }
    }
}
