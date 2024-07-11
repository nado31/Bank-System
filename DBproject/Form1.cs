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
    public partial class Form1 : Form
    {
         static string strConnString = "Data Source=DESKTOP-IJ4CQTR; Initial Catalog=BankDb;Integrated Security=True";
        SqlConnection con=new SqlConnection(strConnString);
        public Form1()
        {
            InitializeComponent();
            HideBankUIElements();
            HideBranchUIElements();
            HideCustomerUIElements();
            comboBox1.Width = 150; 
            comboBox1.Height = 100;
            comboBox2.Width = 150; 
            comboBox2.Height = 100;
            comboBox3.Width = 150; 
            comboBox3.Height = 100;
            
            comboBox2.Items.AddRange(new object[] { "Show Customers", "Show Loans", "Show loan with Min Amount" });
            comboBox3.Items.AddRange(new object[] { "Delete Customer", "Delete Loan" });
          
    }
       


        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
        //show list of customers who availed loans
        public DataTable LoadCustomerTable()
        {
            DataTable dt = new DataTable();
            string query = @"
    SELECT 
    c.CUSTOMER_SSN AS CustomerSSN,
    c.BRANCH_ID AS BranchID,
    c.BIRTH_DATE AS BirthDate,
    c.GENDER,
    c.FNAME AS FirstName,
    c.MIDNAME AS MiddleName,
    c.LNAME AS LastName,
    c.ZIPCODE AS ZipCode,
    c.CITY,
    c.STREET,
    c.PHONENUMBER AS PhoneNumber
FROM 
    CUSTOMER c
INNER JOIN 
    AVAIL a ON c.CUSTOMER_SSN = a.CUSTOMER_SSN
";

            try
            {
                using (SqlConnection con = new SqlConnection(strConnString)) // Use the connection string defined in strConnString
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions here (e.g., log the error, display a message to the user)
                MessageBox.Show("An error occurred: " + ex.Message);
            }

            return dt;
        }
        public DataTable LoadCustomerwithoutLoansTable()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM CUSTOMER "
  ;

            try
            {
                using (SqlConnection con = new SqlConnection(strConnString)) // Use the connection string defined in strConnString
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions here (e.g., log the error, display a message to the user)
                MessageBox.Show("An error occurred: " + ex.Message);
            }

            return dt;
        }

        //show list of loans
        private DataTable LoadLoanData()
        {
            DataTable loanData = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(strConnString))
                {
                    con.Open();
                    string query = @"SELECT 
                                        LOAN_NUMBER AS LoanNumber,
                                        LOAN_TYPE AS LoanType,
                                        BRANCH_ID AS BranchID,
                                        AMOUNT AS LoanAmount,
                                        INTEREST_RATE AS InterestRate
                                    FROM 
                                        LOAN";



                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(loanData);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading loan data: " + ex.Message);
            }

            return loanData;
        }
        private DataTable LoadBankData()
        {
            DataTable BankData = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(strConnString))
                {
                    con.Open();
                    string query = "SELECT * FROM BANK";



                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(BankData);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading loan data: " + ex.Message);
            }

            return BankData;
        }
        private DataTable LoadBranchData()
        {
            DataTable BranchData = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(strConnString))
                {
                    con.Open();
                    string query = "SELECT * FROM BRANCH";



                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(BranchData);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading loan data: " + ex.Message);
            }

            return BranchData;
        }
        private void ShowBranchUIElements()
        {
            textBox15.Visible = true;
            textBox16.Visible = true;
            textBox17.Visible = true;

            textBox18.Visible = true;
            textBox19.Visible = true;
            textBox20.Visible = true;
            textBox21.Visible = true;
            label16.Visible = true;
            label17.Visible = true;
            label18.Visible = true;
            label19.Visible = true;
            label20.Visible = true;
            label21.Visible = true;
            label22.Visible = true;

        }
        private void HideBranchUIElements()
        {
            textBox15.Visible = false;
            textBox16.Visible = false;
            textBox17.Visible = false;

            textBox18.Visible = false;
            textBox19.Visible = false;
            textBox20.Visible = false;
            textBox21.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
            label18.Visible = false;
            label19.Visible = false;
            label20.Visible = false;
            label21.Visible = false;
            label22.Visible = false;

        }


        //BankUI
        private void ShowBankUIElements()
        {
           
            textBox1.Visible = true; 
            textBox5.Visible = true; 
            textBox6.Visible = true; 

            label5.Visible = true;   
            label6.Visible = true;   
            label7.Visible = true;  
        }
        private void HideBankUIElements()
        {
           
            textBox1.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;

            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
        }
        private void ShowCustomerUIElements()
        {

            textBox9.Visible = true;
            textBox4.Visible = true;
            textBox7.Visible = true;

            textBox8.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox10.Visible = true;
            textBox11.Visible = true;
            textBox12.Visible = true;
            textBox13.Visible = true;
            textBox14.Visible = true;
            label1.Visible = true;
            label4.Visible = true;
            label9.Visible = true;
            label8.Visible = true;
            label10.Visible = true;
            label11.Visible = true;
            label12.Visible = true;
            label13.Visible = true;
            label14.Visible = true;
            label15.Visible = true;
            label3.Visible = true;



        }
        private void HideCustomerUIElements()
        {

            textBox9.Visible = false;
            textBox4.Visible = false;
            textBox7.Visible = false;

            textBox8.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox10.Visible = false;
            textBox11.Visible = false;
            textBox12.Visible = false;
            textBox13.Visible = false;
            textBox14.Visible = false;
            label1.Visible = false;
            label4.Visible = false;
            label9.Visible = false;
            label8.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            label3.Visible = false;

        }





        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       
        //ADD bank or customer or branch
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            string selectedOption = comboBox1.SelectedItem.ToString();
            MessageBox.Show($"Selected option: {selectedOption}");
            if (selectedOption == "Add Bank")
            {
                ShowBankUIElements();
             
                AddBank();
            }
            else if (selectedOption == "Add Customer")
            {
            ShowCustomerUIElements();
                AddCustomer();
            }
            else if (selectedOption == "Add Branch")
            {
               ShowBranchUIElements();
                AddBranch();
            }
        }
        private void AddBranch()
        {
            // Check if all required fields are filled
            if (string.IsNullOrWhiteSpace(textBox15.Text) || string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox16.Text))
            {
                MessageBox.Show("Please fill in all the fields.");
                return;
            }

            try
            {
                con.Open();
                string branchquery = "INSERT INTO BRANCH (BRANCH_ID, CODE, BRANCH_NAME, BRANCH_ZIPCODE, BRANCH_CITY, BRANCH_STREET, MGR_STARTDATE) VALUES (@BRANCH_ID, @CODE, @BRANCH_NAME, @BRANCH_ZIPCODE, @BRANCH_CITY, @BRANCH_STREET, @MGR_STARTDATE)";
                SqlCommand cmd = new SqlCommand(branchquery, con);
                cmd.Parameters.AddWithValue("@BRANCH_ID", textBox15.Text);
                cmd.Parameters.AddWithValue("@CODE", textBox16.Text);
                cmd.Parameters.AddWithValue("@BRANCH_NAME", textBox17.Text);
                cmd.Parameters.AddWithValue("@BRANCH_ZIPCODE", textBox18.Text);
                cmd.Parameters.AddWithValue("@BRANCH_CITY", textBox19.Text);
                cmd.Parameters.AddWithValue("@BRANCH_STREET", textBox20.Text);
                cmd.Parameters.AddWithValue("@MGR_STARTDATE", textBox21.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Branch Saved");
                dataGridView1.DataSource = LoadBranchData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding the branch: " + ex.Message);
                con.Close();
            }
        }

        private void AddBank()
        {
            if (string.IsNullOrWhiteSpace(textBox5.Text) || string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox6.Text))
            {
                MessageBox.Show("Please fill in all the fields.");
                return; // Exit the method if any text box is empty
            }
            con.Open();
            string bankquery = "INSERT INTO BANK (CODE,NAME,HEADQUARTERS)VALUES(@CODE,@NAME,@HEADQUARTERS)";
            SqlCommand cmd = new SqlCommand(bankquery,con);
            cmd.Parameters.AddWithValue("@CODE",textBox5.Text);
            cmd.Parameters.AddWithValue("@NAME", textBox1.Text);
            cmd.Parameters.AddWithValue("@HEADQUARTERS", textBox6.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Bank Saved");
            dataGridView1.DataSource= LoadBankData();

        }
        private void AddCustomer()
        {
            if (string.IsNullOrWhiteSpace(textBox5.Text) || string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox6.Text))
            {
                MessageBox.Show("Please fill in all the fields.");
                return; // Exit the method if any text box is empty
            }

            try
            {
                con.Open();
                string custquery = "INSERT INTO CUSTOMER (CUSTOMER_SSN, BRANCH_ID, BIRTH_DATE, GENDER, FNAME, MIDNAME, LNAME, ZIPCODE, CITY, STREET, PHONENUMBER) VALUES (@CUSTOMER_SSN, @BRANCH_ID, @BIRTH_DATE, @GENDER, @FNAME, @MIDNAME, @LNAME, @ZIPCODE, @CITY, @STREET, @PHONENUMBER)";
                SqlCommand cmd = new SqlCommand(custquery, con);
                cmd.Parameters.AddWithValue("@CUSTOMER_SSN", textBox9.Text);
                cmd.Parameters.AddWithValue("@BRANCH_ID", textBox4.Text);
                cmd.Parameters.AddWithValue("@BIRTH_DATE", textBox7.Text);
                cmd.Parameters.AddWithValue("@GENDER", textBox8.Text);
                cmd.Parameters.AddWithValue("@FNAME", textBox2.Text);
                cmd.Parameters.AddWithValue("@MIDNAME", textBox3.Text);
                cmd.Parameters.AddWithValue("@LNAME", textBox10.Text);
                cmd.Parameters.AddWithValue("@ZIPCODE", textBox11.Text);
                cmd.Parameters.AddWithValue("@CITY", textBox12.Text);
                cmd.Parameters.AddWithValue("@STREET", textBox13.Text);
                cmd.Parameters.AddWithValue("@PHONENUMBER", textBox14.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Customer Saved");
                dataGridView1.DataSource = LoadCustomerwithoutLoansTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding the customer: " + ex.Message);
            }
        }


        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        public double GetMinLoanAmount()
        {
            double minLoanAmount = 0.0;

            try
            {
                using (SqlConnection con = new SqlConnection(strConnString))
                {
                    con.Open();
                    string query = "SELECT MIN(AMOUNT) FROM LOAN";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            minLoanAmount = Convert.ToDouble(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while retrieving the minimum loan amount: " + ex.Message);
            }

            return minLoanAmount;
        }




        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string selectedOption = comboBox2.SelectedItem.ToString();
            MessageBox.Show($"Selected option: {selectedOption}");
            if (selectedOption == "Show Customers")
            {
                DataTable customerData = LoadCustomerTable();

                dataGridView1.DataSource = customerData;

            }
            else if (selectedOption == "Show Loans")
            {

                DataTable loanData = LoadLoanData();
                dataGridView1.DataSource = loanData;
            }
            else if(selectedOption =="Show loan with Min Amount")
            {
                double minLoanAmount = GetMinLoanAmount();
                MessageBox.Show($"Minimum Loan Amount: {minLoanAmount}"+"LE");

            }
        }
        //DELETE
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedOption3 = comboBox3.SelectedItem.ToString();
            MessageBox.Show($"Selected option: {selectedOption3}");
            if (selectedOption3 == "Delete Customer")
            {
                DelCustomer();
               

            }
            else if (selectedOption3 == "Delete Loan")
            {
                DelLoan();
               
            }
        }
        private void DelCustomer()
        {
            con.Open();
            string q = "DELETE FROM CUSTOMER WHERE CUSTOMER_SSN=" + dataGridView1.CurrentRow.Cells[0].Value + "";
            SqlCommand cmd = new SqlCommand(q, con);

            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Customer deleted successfully.");
            dataGridView1.DataSource = LoadCustomerTable();
        }

        private void DelLoan()
        {
            con.Open();
            string q = "DELETE FROM LOAN WHERE LOAN_NUMBER=" + dataGridView1.CurrentRow.Cells[0].Value + "";
            SqlCommand cmd = new SqlCommand(q, con);

            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("LOAN deleted successfully.");
            dataGridView1.DataSource = LoadLoanData();
        }
       
    
       

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.FormClosed += Form2_FormClosed;
            form.Show();
            this.Hide();
           

        }
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            form.FormClosed += Form3_FormClosed;
            form.Show();
            this.Hide();
        }
        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
    }


}

