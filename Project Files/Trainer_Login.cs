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
    public partial class Trainer_Login : Form
    {
        public Trainer_Login()
        {       
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            Trainer_SignUp trainer_SignUp = new Trainer_SignUp();
            trainer_SignUp.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string email = trainer_login_email.Text;
            string password = trainer_login_pw.Text;
            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();
            SqlCommand cmd;
            string query = "select count(*) from trainer where trainerEmail=@email"; 
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

                    query = "select password from trainer where trainerEmail=@email";
                    cmd.CommandText = query;
                    string returned_Password = cmd.ExecuteScalar().ToString();
                    if (returned_Password == password)
                    {
                        this.Close();
                        Trainer_Dashboard trainer_Dashboard = new Trainer_Dashboard(email);
                        trainer_Dashboard.Show();

                    }
                    else
                    {
                        MessageBox.Show("Incorrect email or passowrd.");
                    }

                }
            }



        }

        private void Trainer_Login_Load(object sender, EventArgs e)
        {

        }

        private void trainer_login_email_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void kryptonButton5_Click(object sender, EventArgs e)
        {
            if (trainer_login_pw.PasswordChar == '\0')
            {
                kryptonButton2.BringToFront();
                trainer_login_pw.PasswordChar = '•';
            }
        }

        private void kryptonButton2_Click_2(object sender, EventArgs e)
        {
            if (trainer_login_pw.PasswordChar == '•')
            {
                kryptonButton5.BringToFront();
                trainer_login_pw.PasswordChar = '\0';
            }
        }
    }
}
