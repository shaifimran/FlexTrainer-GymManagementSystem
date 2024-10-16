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
    public partial class GymOwner_SignUp : Form
    {
        public GymOwner_SignUp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = gym_owner_signup_name.Text;
            string email = gym_owner_signup_email.Text;
            string password = gym_owner_signup_pw.Text;
            if (name == "" || email == "" || password == "")
            {
                MessageBox.Show("Please enter all compulsory fields!");
            }
            else
            {

                SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
                conn.Open();
                SqlCommand cmd;
                string query = "select count(*) from gymOwner where ownerEmail=@email";
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
                    query = "Insert into GymOwner(ownerEmail, name, password) values(@email, @name, @password)";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                    cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
                    cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
                    cmd.ExecuteNonQuery();

                    query = "";
                    query = "Insert into Approval(gymOwnerEmail) values (@email);";
                    cmd.CommandText = query;

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    conn.Close();

                    MessageBox.Show("Sign Up Successful. Kindly wait for Admin's Approval.!");

                    this.Close();
                    GymOwner_Login gymOwner_Login = new GymOwner_Login();
                    gymOwner_Login.Show();

                }

            }



        }

        private void GymOwner_SignUp_Load(object sender, EventArgs e)
        {

        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            this.Close();
            GymOwner_Login gymOwner_Login = new GymOwner_Login();
            gymOwner_Login.Show();
        }
    }
}
