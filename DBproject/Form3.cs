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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DBproject
{
    public partial class Form3 : Form
    {
        static string strConnString = "Data Source=DESKTOP-IJ4CQTR; Initial Catalog=BankDb;Integrated Security=True";
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            string code = textBox2.Text;
            string name= textBox3.Text;
            string zipcode = textBox4.Text;
            string city = textBox7.Text;
            string street = textBox5.Text;
            string startdate  = textBox6.Text;
            



            if (IsBranchValid(id))
            {
                UpdateBranchDetails(id,code, name,zipcode,city,street,startdate) ;
            }
            else
            {
                MessageBox.Show("Invalid Branch id.");
            }
        }
        private bool IsBranchValid(string BranchId)
        {
            using (SqlConnection connection = new SqlConnection(strConnString))
            {
                string query = "SELECT COUNT(*) FROM BRANCH WHERE BRANCH_ID = @Bid";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Bid", BranchId);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }
        private void UpdateBranchDetails(string branchid,string branchcode, string branchname, string branchzipcode,string branchcity, string branchstreet,string branchstart)
        {
            using (SqlConnection connection = new SqlConnection(strConnString))
            {
                string query = "UPDATE BRANCH SET BRANCH_ID = @Id, CODE= @Code, BRANCH_NAME = @Name, BRANCH_ZIPCODE = @Zipcode,BRANCH_CITY= @City, BRANCH_STREET = @Street,MGR_STARTDATE=@Startdate WHERE BRANCH_ID = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", branchid);
                command.Parameters.AddWithValue("@Code", branchcode);
                command.Parameters.AddWithValue("@Name", branchname);
                command.Parameters.AddWithValue("@Zipcode", branchzipcode);
                command.Parameters.AddWithValue("@City",branchcity);
                command.Parameters.AddWithValue("@Street", branchstreet);
                command.Parameters.AddWithValue("@Startdate", branchstart);




                connection.Open();
                int rowsAffected1 = command.ExecuteNonQuery();
                if (rowsAffected1 > 0)
                {
                    MessageBox.Show("Branch details updated successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to update Branch details.");
                }
            }
        }
    }
}
