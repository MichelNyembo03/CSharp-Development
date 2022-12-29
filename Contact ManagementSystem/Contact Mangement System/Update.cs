using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Contact_Mangement_System
{
    public partial class Update : Form
    {
        public Update()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var doc = XDocument.Load(@"C:\\Contact Management System db\\Contact.xml");
            string updateNo = Uid.Text;

            if (File.Exists(@"C:\\Contact Management System db\\Contact.xml"))
            {
                var items = from item in doc.Descendants("Contact")
                            where item.Element("Id").Value == updateNo
                            select item;

                foreach (XElement selectedElement in items)
                {
                    if(Uname.Text.Length !=0 && Usurname.Text.Length != 0 && Utitle.Text.Length != 0 &&
                        Uemail.Text.Length != 0 && Uphone.Text.Length != 0 && Uaddress.Text.Length != 0)
                    {
                        selectedElement.SetElementValue("Name", Uname.Text);
                        selectedElement.SetElementValue("SurName", Usurname.Text);
                        selectedElement.SetElementValue("Title", Utitle.Text);
                        selectedElement.SetElementValue("Email", Uemail.Text);
                        selectedElement.SetElementValue("Phone", Uphone.Text);
                        selectedElement.SetElementValue("Address", Uaddress.Text);

                        Success s = new Success();
                        s.ShowDialog();

                    }
                    else
                    {
                        Failed f = new Failed();
                        f.ShowDialog();
                    }
                    
                }

                doc.Save(@"C:\\Contact Management System db\\Contact.xml");

            }
            
        }
    }
}
