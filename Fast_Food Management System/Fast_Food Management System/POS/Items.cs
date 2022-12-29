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
    public partial class Items : UserControl
    {
        public Items()
        {
            InitializeComponent();
        }

        private Image _image;
        private string _name;
        private decimal _price;

        [Category("Custom props")]
        public Image Image
        {
            get { return _image; }
            set { _image = value; picture.Image = value; }
        }

        [Category("Custom props")]
        public string Name
        {
            get { return _name; }
            set { _name = value; txtName.Text = value; }
        }

        [Category("Custom props")]
        public decimal Price
        {
            get { return _price; }
            set { _price = value; txtPrice.Text = value.ToString(); }
        }
        private void Items_Load(object sender, EventArgs e)
        {

        }


    }
}
