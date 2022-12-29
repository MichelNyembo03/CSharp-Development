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
using System.Xml.Serialization;

namespace Contact_Mangement_System
{
    public partial class Contact : Form
    {
        Main m;
        InsertContact insert;
        ViewContact view;
        Update update;


        public Contact()
        {
            InitializeComponent();
        }

        private void Contact_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(@"C:\\Contact Management System db\\Contact.xml");
            dataGridView1.DataSource = ds.Tables[0];

            textBox1.Focus();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            insert = new InsertContact();
            insert.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            view = new ViewContact();
            if(dataGridView1.SelectedRows.Count > 0)
            {
                for(int i=0; i< selectedRowCount; i++)
                {
                    view.Vname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    view.Vsurname.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    view.Vtitle.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    view.Vemail.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    view.Vphone.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    view.Vaddress.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                }
                view.ShowDialog();
            }
            else
            {
                MessageBox.Show("Select the row you want to view first!");
            }

            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);

            update = new Update();

            if (dataGridView1.SelectedRows.Count > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {
                    update.Uid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    update.Uname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    update.Usurname.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    update.Utitle.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    update.Uemail.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    update.Uphone.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    update.Uaddress.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                }
                update.ShowDialog();
            }
            else
            {
                MessageBox.Show("Select the row you want to view first!");
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);

            var doc = XDocument.Load(@"C:\\Contact Management System db\\Contact.xml");

            string deleteId = "";

            if(dataGridView1.SelectedRows.Count> 0)
            {
                for(int i=0; i<selectedRowCount;i++)
                {
                    deleteId = dataGridView1.CurrentRow.Cells[i].Value.ToString();
                }
            }
            doc.Descendants("Contact")
                .Where(x => (string)x.Element("Id") == deleteId)
                .Remove();

            doc.Save(@"C:\\Contact Management System db\\Contact.xml");

            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Name = '{0}'", textBox1.Text);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //(dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Name = '{0}'", textBox1.Text);

        }

        private void button12_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(@"C:\\Contact Management System db\\Contact.xml");
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            //(dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Name = '{0}'", textBox1.Text);
        }
    }
}
