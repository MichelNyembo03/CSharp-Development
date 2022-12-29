using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Fast_Food_Management_System.POS
{
    public partial class Receipt : Form
    {
        public string cost = "";
        public string[] names;
        public string[] prices;
        public Receipt()
        {
            InitializeComponent();
        }

        public int generateNumbers()
        {
            Random rand = new Random();
            return rand.Next(1000, 9999);
        }
        
        private void Receipt_Load(object sender, EventArgs e)
        {
            orderNum.Text = "R" + generateNumbers().ToString();
            date.Text = DateTime.Now.ToString();
            totalCostValue.Text = cost+"$";
            var Item = new Dictionary<String, string>();
            for(int i=0; i< names.Length; i++)
            {
                Item.Add(names[i], prices[i]);
            }

            
            foreach(string key in Item.Keys)
            {
                richTextBox2.Text = $"{key} \t\t\t\t\t\t\t {Item[key]}";

            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        Bitmap bitmap;
        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void printDocument1_PrintPage_1(object sender, PrintPageEventArgs e)
        {
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
