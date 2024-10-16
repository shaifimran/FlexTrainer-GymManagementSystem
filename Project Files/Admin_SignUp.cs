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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Database_Project_GymTrainer
{
    public partial class Admin_SignUp : Form
    {
        public Admin_SignUp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Admin_Login admin_Login = new Admin_Login();
            admin_Login.Show();
        }

        private void Admin_SignUp_Load(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            string name = admin_signup_name.Text;
            string email = admin_signup_email.Text;
            string password = admin_signup_pw.Text;
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter all compulsory fields!");
            }
            else
            {

                SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
                conn.Open();
                SqlCommand cmd;
                string query = "select count(*) from admin where adminEmail=@email";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
                cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password;


                int count = (int)cmd.ExecuteScalar();
                if (count > 0)
                {
                    MessageBox.Show("Email already exists!");
                }
                else
                {
                    query = "";
                    query = "Insert into Admin(adminEmail, name, password) values(@email, @name, @password)";
                    cmd.CommandText = query;


                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    conn.Close();

                    MessageBox.Show("Sign Up Successfull!");

                    this.Close();
                    Admin_Login admin_Login = new Admin_Login();
                    admin_Login.Show();

                }

            }
        }

        private void kryptonTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            this.Close();
            Admin_Login admin_Login = new Admin_Login();
            admin_Login.Show();
        }
    }
}
