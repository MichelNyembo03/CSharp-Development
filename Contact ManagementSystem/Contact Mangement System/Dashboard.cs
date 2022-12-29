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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            var doc = XDocument.Load(@"C:\\Contact Management System db\\Contact.xml");
            var count = doc.Descendants("Contact").Count();

            ContactTotal.Text = count.ToString();
        }
    }
}
