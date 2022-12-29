using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Contact_Mangement_System
{
    public partial class Failed : Form
    {
        public Failed()
        {
            InitializeComponent();
            Timer t = new Timer();
            t.Interval = 500;
            t.Tick += new EventHandler(timer1_Tick); 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
