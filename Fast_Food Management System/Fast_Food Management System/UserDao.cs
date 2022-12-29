using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fast_Food_Management_System
{
   
    public class UserDao
    {
        DbConnection conn = new DbConnection();
        public bool LoginAdmin(string user, string pass)
        {
            using(var connection = conn.GetConnection())
            {
                connection.Open();
                using(var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select * from Admin where adminName=@user and adminPassword=@pass";
                    command.Parameters.AddWithValue("@user", user);
                    command.Parameters.AddWithValue("@pass", pass);

                    SqlDataReader reader = command.ExecuteReader();
                    if(reader.HasRows)
                    {
                        return true;
                    }
                    else
                        return false;
                }
            }
        }

        public bool LoginUser(string user, string pass)
        {
            
            using (var connection = conn.GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select * from Users where userName=@user and userpassword=@pass";
                    command.Parameters.AddWithValue("@user", user);
                    command.Parameters.AddWithValue("@pass", pass);
                    

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        return true;
                    }
                    else
                        return false;
                }
            }
        }

        public void AddItem(string name, string type, double price, byte[] image)
        {
            using (var connection = conn.GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try {
                        command.Connection = connection;
                        command.CommandText = "INSERT INTO Product(prodName, typeOfProd, price, image)" +
                            "values(@name, @type, @price, @image)";
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@type", type);
                        command.Parameters.AddWithValue("@price", price);
                        command.Parameters.AddWithValue("@image", image);

                        int RowInserted = command.ExecuteNonQuery();
                        
                        MessageBox.Show("Success, Item inserted");
                            
                        connection.Close();

                    }catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    
                }
            }

        }

        
        public DataTable Display()
        {
            DataTable dt = new DataTable();
            using (var connection = conn.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Select * from Product";

                    try
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(command))
                        {
                            
                            sda.Fill(dt);
                            
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

            return dt;
        }


        public DataTable DisplayFood()
        {
            DataTable dt = new DataTable();
            using (var connection = conn.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Select * from Product where typeOfProd='Food'";

                    try
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(command))
                        {

                            sda.Fill(dt);

                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

            return dt;
        }


        public DataTable DisplayDrink()
        {
            DataTable dt = new DataTable();
            using (var connection = conn.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Select * from Product where typeOfProd='Drink'";

                    try
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(command))
                        {

                            sda.Fill(dt);

                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

            return dt;
        }


        public DataTable DisplaySearch(TextBox word)
        {
            DataTable dt = new DataTable();
            using (var connection = conn.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = $"Select * from Product where prodName like @word";
                    command.Parameters.AddWithValue("word", string.Format("%{0}%", word.Text));
                    try
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(command))
                        {

                            sda.Fill(dt);

                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

            return dt;
        }

        public DataTable DisplaySearchFood(TextBox word)
        {
            DataTable dt = new DataTable();
            using (var connection = conn.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = $"Select * from Product where prodName like @word and typeOfProd='Food'";
                    command.Parameters.AddWithValue("word", string.Format("%{0}%", word.Text));
                    try
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(command))
                        {

                            sda.Fill(dt);

                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

            return dt;
        }


        public DataTable DisplaySearchDrink(TextBox word)
        {
            DataTable dt = new DataTable();
            using (var connection = conn.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = $"Select * from Product where prodName like @word and typeOfProd='Drink'";
                    command.Parameters.AddWithValue("word", string.Format("%{0}%", word.Text));
                    try
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(command))
                        {

                            sda.Fill(dt);

                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

            return dt;
        }

        public void InsertOrder(DataGridView dataGridView1)
        {
            try
            {
                using (SqlConnection con = conn.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Product_Order(ProductName, prodQuantity, totPrice, OrderDate) VALUES (@ProductName, @prodQuantity, @totPrice, @OrderDate)", con))
                    {
                        cmd.Parameters.Add(new SqlParameter("@ProductName", SqlDbType.VarChar));
                        cmd.Parameters.Add(new SqlParameter("@prodQuantity", SqlDbType.Int));
                        cmd.Parameters.Add(new SqlParameter("@totPrice", SqlDbType.Decimal));
                        cmd.Parameters.Add(new SqlParameter("@OrderDate", SqlDbType.DateTime));
                        con.Open();
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                cmd.Parameters["@ProductName"].Value = row.Cells[0].Value;
                                cmd.Parameters["@prodQuantity"].Value = 1;
                                cmd.Parameters["@totPrice"].Value = Convert.ToDecimal(row.Cells[2].Value.ToString().Replace("$",""));
                                cmd.Parameters["@OrderDate"].Value = DateTime.Now;
                                cmd.ExecuteNonQuery();
                            }
                        }
                        MessageBox.Show("Order Saved");
                    }
                    con.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
    }
}
