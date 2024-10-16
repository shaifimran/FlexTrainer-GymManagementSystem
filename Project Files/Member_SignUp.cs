using ComponentFactory.Krypton.Toolkit;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Database_Project_GymTrainer
{
    public partial class Member_SignUp : Form
    {
        string owner_email;
        public Member_SignUp(string Owner_Email = "")
        {
            InitializeComponent();
            this.owner_email = Owner_Email;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Member_Login memberLogin = new Member_Login();
            this.Hide();
            memberLogin.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            string name = member_signup_name.Text;
            string email = member_signup_email.Text;
            string password = member_signup_pw.Text;
            string gym = member_signup_gym.Text;
            DateTime date = member_signup_date.Value;
            string objective = member_signup_obj.Text;
            string duration = member_signup_duration.Text;
            string type = member_signup_type.Text;
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) ||
            string.IsNullOrEmpty(gym) || string.IsNullOrEmpty(duration) || string.IsNullOrEmpty(type))
            {
                MessageBox.Show("Please enter all compulsory fields!");
            }
            else
            {
                SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
                conn.Open();
                SqlCommand cmd;
                string query = "select count(*) from Member where memberEmail=@email";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
                cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
                cmd.Parameters.Add("@gym", SqlDbType.VarChar).Value = gym;
                cmd.Parameters.Add("@objective", SqlDbType.VarChar).Value = objective;

                try
                {
                    cmd.Parameters.Add("@duration", SqlDbType.Int).Value = Int32.Parse(duration);
                    if (Int32.Parse(duration) > 12 || Int32.Parse(duration) < 1)
                    {
                        MessageBox.Show("Please enter a valid integer in duration.");
                        return;
                    }
                }

                catch (FormatException)
                {
                    MessageBox.Show("Please enter a valid integer in duration.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                cmd.Parameters.Add("@selectedDate", SqlDbType.DateTime).Value = date;
                cmd.Parameters.Add("@type", SqlDbType.VarChar).Value = type;
                cmd.Parameters.Add("@owneremail", SqlDbType.VarChar).Value = owner_email;
                DateTime currentDate = DateTime.Now;
                int count = (int)cmd.ExecuteScalar();
                if (count > 0)
                {
                    MessageBox.Show("Email already exists!");
                }

                else
                {

                    if (DateTime.Compare(currentDate, date) < 0)
                    {
                        MessageBox.Show("Enter valid date.");
                    }
                    else
                    {
                        query = "";
                        query = "Insert into Member(memberEmail, memberName, password, gymName, objectives, membershipDuration, signup_date) values(@email, @name, @password, NULL, @objective, @duration, @selectedDate)";
                        cmd.CommandText = query;
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        query = "";
                        query = "insert into Member_Verification(memberEmail,gymName) values (@email,@gym);";
                        cmd.CommandText = query;
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        MessageBox.Show("Sign Up Successfull!");

                        this.Close();
                        Member_Login member = new Member_Login(owner_email, gym);
                        member.Show();

                    }
                }

            }
        }

        private void Member_SignUp_Load(object sender, EventArgs e)
        {

        }

        private void member_signup_gym_SelectedIndexChanged(object sender, EventArgs e)
        {
            member_signup_gym.Items.Clear();
            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();
            string query = "SELECT gymName FROM Gym WHERE isApproved = 1;";
            SqlCommand cmd;
            cmd = new SqlCommand(query, conn);
            string target_muscle = member_signup_gym.Text;
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string exerciseName = reader.GetString(0);
                member_signup_gym.Items.Add(exerciseName);
            }
        }

        private void member_signup_date_ValueChanged(object sender, EventArgs e)
        {

        }

        private void member_signup_type_DropDown(object sender, EventArgs e)
        {
            member_signup_type.Items.Clear();
            member_signup_type.Items.Add("Platinum");
            member_signup_type.Items.Add("Gold");
            member_signup_type.Items.Add("Silver");

           
        }
    }
}
