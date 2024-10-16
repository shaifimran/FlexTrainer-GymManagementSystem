using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_Project_GymTrainer
{
    public partial class Trainer_SignUp : Form
    {

        string owner_email;
        public Trainer_SignUp(string owner_email = "")
        {
            InitializeComponent();
            this.owner_email = owner_email;
        }

        private void Trainer_SignUp_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Trainer_Login trainer_Login = new Trainer_Login();
            trainer_Login.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string name = trainer_signup_name.Text;
            string email = trainer_signup_email.Text;
            string password = trainer_signup_pw.Text;
            string speciality = trainer_signup_speciality.Text;
            string qualification = trainer_signup_qualification.Text;
            string experience = trainer_signup_exp.Text;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter all compulsory fields!");
            }
            else
            {
                SqlConnection conn = new SqlConnection(ConnectionString.ServerName);

                conn.Open();
                SqlCommand cmd;
                string query = "select count(*) from Trainer where trainerEmail=@email";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
                cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
                cmd.Parameters.Add("@speciality", SqlDbType.VarChar).Value = speciality;
                cmd.Parameters.Add("@qualification", SqlDbType.VarChar).Value = qualification;
                cmd.Parameters.Add("@experience", SqlDbType.VarChar).Value = experience;

                int count = (int)cmd.ExecuteScalar();
                if (count > 0)
                {
                    MessageBox.Show("Email already exists!");
                }
                else
                {
                    query = "";
                    query = "Insert into Trainer(trainerEmail, name,password, speciality, experience, qualification) values(@email, @name, @password, @speciality, @experience, @qualification)";
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    
                    conn.Close();
                    MessageBox.Show("Sign Up Successfull!");

                    this.Close();
                    Trainer_Login trainer = new Trainer_Login();
                    trainer.Show();
                }

            }
        }

        private void kryptonTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void kryptonComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
