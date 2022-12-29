using Fast_Food_Management_System.Management;
using Fast_Food_Management_System.POS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fast_Food_Management_System
{
    public partial class LoginForm : Form
    {
        string type = string.Empty;
        UserDao userD;
        Thread th;
        PointeOfSale pt;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            admin.Checked = true;
            user.Checked = false;
        }

        public void openLogin()
        {
            Application.Run(new Home());
        }public void openPointOfSale()
        {
            Application.Run(new PointeOfSale());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            userD = new UserDao();

            

            if(admin.Checked && user.Checked)
            {
                MessageBox.Show("Sory, Select admin or user only");

            }else if(!admin.Checked && !user.Checked)
            {
                MessageBox.Show("Sorry, Select user or admin!");
            }
            else
            {
                if((username.Text == "") || (password.Text == ""))
                {
                    MessageBox.Show("Please fill all the fiedl");
                }
                else
                {
                    if (admin.Checked)
                    {
                        if (userD.LoginAdmin(username.Text, password.Text))
                        {
                                this.Close();

                                th = new Thread(openLogin);
                                th.SetApartmentState(ApartmentState.STA);
                                th.Start();
                            MessageBox.Show("Logged in as admin");
                        }
                        else
                        {

                            MessageBox.Show("Login failed!");

                        }
                    }
                    else
                    {
                        if (user.Checked)
                        {
                            if (userD.LoginUser(username.Text, password.Text))
                            {
                                this.Close();

                                th = new Thread(openPointOfSale);
                                th.SetApartmentState(ApartmentState.STA);
                                th.Start();
                                MessageBox.Show("Logged in as user");
                            }
                            else
                            {

                                MessageBox.Show("Login failed!");

                            }
                        }
                    }  
                }
            }
            
        }

        private void LoginForm_Load_1(object sender, EventArgs e)
        {
            admin.Checked = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void admin_CheckedChanged(object sender, EventArgs e)
        {
            if(admin.Checked == true)
            {
                user.Checked = false;
               
            }
            else
            {
                user.Checked = true;
                
            }
                
                
        }

        private void user_CheckedChanged(object sender, EventArgs e)
        {
            if (user.Checked == true)
            {
                admin.Checked = false;
               
            }
            else
            {
                admin.Checked = true;
               
            }
        }
    }
}
