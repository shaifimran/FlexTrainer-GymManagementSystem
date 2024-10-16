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
using System.Xml.Linq;

namespace Database_Project_GymTrainer
{
    public partial class Admin_Login : Form
    {
        public Admin_Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            Admin_SignUp admin_SignUp = new Admin_SignUp();
            admin_SignUp.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Admin_Login_Load(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            string email = admin_login_email.Text;
            string password = admin_login_password.Text;
            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();
            SqlCommand cmd;
            string query = "select count(*) from admin where adminEmail=@email";
            cmd = new SqlCommand(query, conn);
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                MessageBox.Show("Please enter email and passowrd!");
            else
            {
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
                cmd.CommandText = query;
                int count = (int)cmd.ExecuteScalar();
                if (count == 0)
                {
                    MessageBox.Show("Email does not exist. Please Sign Up!");
                }
                else
                {
                    query = "select password from admin where adminEmail=@email";
                    cmd.CommandText = query;
                    string returned_Password = cmd.ExecuteScalar().ToString();
                    if (returned_Password == password)
                    {
                        this.Close();
                        Admin_Dashboard admin_Dashboard = new Admin_Dashboard(email);
                        admin_Dashboard.Show();

                    }
                    else
                    {
                        MessageBox.Show("Incorrect email or passowrd.");
                    }
                }
            }
        }

        private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void kryptonButton5_Click(object sender, EventArgs e)
        {
            if (admin_login_password.PasswordChar == '\0')
            {
                kryptonButton2.BringToFront();
                admin_login_password.PasswordChar = '•';
            }
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            if (admin_login_password.PasswordChar == '•')
            {
                kryptonButton5.BringToFront();
                admin_login_password.PasswordChar = '\0';
            }
        }
    }
}
