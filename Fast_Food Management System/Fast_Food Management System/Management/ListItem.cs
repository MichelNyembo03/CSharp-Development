using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fast_Food_Management_System.Management
{
    public partial class ListItem : UserControl
    {
        public ListItem()
        {
            InitializeComponent();
        }

        private int _id;
        private string _name;
        private string _type;
        private decimal _price;
        private Image _image;


        [Category("Custom pros")]
        public int Id
        {
            get { return _id; }
            set { _id = value; lblId.Text = value.ToString(); }
        }

        [Category("Custom pros")]
        public string Name
        {
            get { return _name; }
            set { _name = value; lblName.Text = value; }
        }

        [Category("Custom pros")]
        public string Type
        {
            get { return _type; }
            set { _type = value; lblType.Text = value; }
        }

        [Category("Custom pros")]
        public decimal Price
        {
            get { return _price; }
            set { _price = value; lblPrice.Text = value.ToString() +"$"; }
        }

        [Category("Custom pros")]
        public Image Image
        {
            get { return _image; }
            set { _image = value; pictureBox1.Image = value; }
        }

       
        

        private void ListItem_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#2d3436");
            this.ForeColor = Color.White;
        }

        private void ListItem_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Parent.BackColor;
            this.ForeColor = Color.Black;
            
        }

        private void ListItem_Load(object sender, EventArgs e)
        {

        }
    }
}
