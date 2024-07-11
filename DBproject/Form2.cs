using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DBproject
{
    public partial class Form2 : Form
    {
        static string strConnString = "Data Source=DESKTOP-IJ4CQTR; Initial Catalog=BankDb;Integrated Security=True";
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       private void button2_Click(object sender, EventArgs e)
        {
            string code = textBox3.Text;
            string name = textBox2.Text;
            string head = textBox1.Text;
         

            if (IsBankValid(code))
            {
                UpdateBankDetails(code,name , head);
            }
            else
            {
                MessageBox.Show("Invalid Bank Code.");
            }

        }
        private bool IsBankValid(string BankId)
        {
            using (SqlConnection connection = new SqlConnection(strConnString))
            {
                string query = "SELECT COUNT(*) FROM BANK WHERE CODE = @Code";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Code", BankId);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }
       private void  UpdateBankDetails( string bankcode,string bankname,string bankhead)
        {
            using (SqlConnection connection = new SqlConnection(strConnString))
            {
                string query = "UPDATE BANK SET CODE = @Code, NAME = @Name, HEADQUARTERS = @Head WHERE CODE = @Code";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Code", bankcode);
                command.Parameters.AddWithValue("@Name",bankname);
                command.Parameters.AddWithValue("@Head",bankhead);
               
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Bank details updated successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to update Bank details.");
                }
            }
        }

    }
}
