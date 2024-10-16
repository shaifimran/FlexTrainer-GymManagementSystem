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
    public partial class Member_Login : Form
    {
        string owneremail;
        string gym;
        public Member_Login(string owner_email = "", string gym = "")
        {
            InitializeComponent();
            this.owneremail = owner_email;
            this.gym = gym;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            Member_SignUp memberSignUp = new Member_SignUp();
            memberSignUp.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string email = member_login_email.Text;
            string password = member_login_password.Text;
            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();
            SqlCommand cmd;
            string query = "select count(*) from member where memberEmail=@email";
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
                    query = "select count(*) from Member where memberEmail=@email AND isApproved = 0 AND addedBy is NULL ;";
                    cmd.CommandText = query;
                    count = (int)cmd.ExecuteScalar();
                    if (count == 1)
                    {
                        MessageBox.Show("Email not Approved!");
                    }
                    else
                    {
                        query = "select password from member where memberEmail=@email";
                        cmd.CommandText = query;
                        string returned_Password = cmd.ExecuteScalar().ToString();
                        if (returned_Password == password)
                        {
                            query = "select addedBy from member where memberEmail = @email;";
                            cmd.CommandText = query;
                            owneremail = cmd.ExecuteScalar().ToString();

                            query = "select gymName from member where memberEmail = @email;";
                            cmd.CommandText = query;
                            gym = cmd.ExecuteScalar().ToString();

                            Member_Dashboard member = new Member_Dashboard(owneremail, email, gym);
                            this.Close();
                            member.Show();

                        }
                        else
                        {
                            MessageBox.Show("Incorrect email or passowrd.");
                        }
                    }                   
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Member_Login_Load(object sender, EventArgs e)
        {

        }

        private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void kryptonTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void kryptonButton5_Click(object sender, EventArgs e)
        {
            if (member_login_password.PasswordChar == '\0')
            {
                kryptonButton2.BringToFront();
                member_login_password.PasswordChar = '•';
            }
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            if (member_login_password.PasswordChar == '•')
            {
                kryptonButton5.BringToFront();
                member_login_password.PasswordChar = '\0';
            }
        }
    }
}
