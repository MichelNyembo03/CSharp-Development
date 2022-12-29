using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fast_Food_Management_System.POS
{
    public partial class Quantity : Form
    {
        PointeOfSale pt;
        public Quantity()
        {
            InitializeComponent();
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            pt = new PointeOfSale();
            if (e.KeyCode == Keys.Enter)
            {
                pt.quantity = Convert.ToDecimal(textBox1.Text);
                this.Close();
            }
        }
    }
}
