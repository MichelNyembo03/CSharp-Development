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
    public partial class UserLoginError : Form
    {
        public UserLoginError()
        {
            InitializeComponent();
            Timer timer= new Timer();
            timer.Interval= 500;
            timer.Tick += new EventHandler(timer1_Tick);
        }

        private void UserLoginError_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
