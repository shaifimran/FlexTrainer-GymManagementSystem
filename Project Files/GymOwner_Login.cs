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

namespace Database_Project_GymTrainer
{
    public partial class GymOwner_Login : Form
    {
        public GymOwner_Login()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            GymOwner_SignUp gymOwner_SignUp = new GymOwner_SignUp();
            gymOwner_SignUp.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void GymOwner_Login_Load(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            string email = gymowner_login_email.Text;
            string password = gymowner_login_pw.Text;
            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();
            SqlCommand cmd;
            string query = "select count(*) from gymOwner where ownerEmail=@email";
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
                    query = "select count(*) from gymOwner where ownerEmail=@email AND addedBy is NULL;";
                    cmd.CommandText = query;
                    count = (int)cmd.ExecuteScalar();
                    if ( count == 1)
                    {
                        MessageBox.Show("Email not Approved!");
                    }
                    else
                    {
                        query = "select password from gymOwner where ownerEmail=@email";
                        cmd.CommandText = query;
                        string returned_Password = cmd.ExecuteScalar().ToString();
                        if (returned_Password == password)
                        {
                            this.Close();
                            GymOwner_Dashboard gymowner_dashboard = new GymOwner_Dashboard(email);
                            gymowner_dashboard.Show();
                        }
                        else
                        {
                            MessageBox.Show("Incorrect email or passowrd.");
                        }
                    }
                }
            }


        }

        private void kryptonButton5_Click(object sender, EventArgs e)
        {
            if (gymowner_login_pw.PasswordChar == '\0')
            {
                kryptonButton2.BringToFront();
                gymowner_login_pw.PasswordChar = '•';
            }
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            if (gymowner_login_pw.PasswordChar == '•')
            {
                kryptonButton5.BringToFront();
                gymowner_login_pw.PasswordChar = '\0';
            }
        }
    }
}
