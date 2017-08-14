using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace myADODemo
{
    public partial class Form1 : Form
    {  
        public Form1()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                // make the form invisiible
                this.Visible = false;

                // Throw New Exception
                throw new Exception("This Form has a problem with InitializeComponent", ex);
            }
            finally
            {             
                try
                {
                    // This is my code to connect to the SQL and ADO Stuff
                    GetDataManual();
                    this.categoriesTableAdapter.Fill(this.nWind.Categories);
                    
                }
                catch (Exception ex)
                {
                  // make the form invisiible
                  this.Visible = false;
                  
                  // Throw New Exception
                  throw new Exception("This Form Has a Data Connection Issue", ex);
                }
                finally
                {
                    
                }
            }
        }

        // This my method for doing some ADO stuff
        public void GetDataManual()
        {
            string connString = ConfigurationManager.ConnectionStrings["myADODemo.Properties.Settings.NWindConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Categories ORDER BY CategoryName";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("{0} {1}",reader["CategoryID"], reader["CategoryName"] );
                        }
                    } // reader
                } // cmd
            } // conn
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.categoriesTableAdapter.Fill(this.nWind.Categories);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Hide the form while things are disposed at the parent caller 
            // "Main" method to the form object
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
