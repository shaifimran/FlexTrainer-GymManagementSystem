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
    public partial class Member_Gym_Feedback_Dashboard : Form
    {
        string current_email;
        public Member_Gym_Feedback_Dashboard(string email = "")
        {
            current_email = email;
            InitializeComponent();
        }

        private void Member_Gym_Feedback_Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void kryptonButton10_Click(object sender, EventArgs e)
        {
            string rating = kryptonNumericUpDown1.Text;

            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();
            SqlCommand cmd;
            string query = "select gymName from member where memberEmail=@email";
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = current_email;
            string gymName = cmd.ExecuteScalar().ToString();
            cmd.Parameters.Add("@rating", SqlDbType.Int).Value = Int32.Parse(rating);
            cmd.Parameters.Add("@gymName", SqlDbType.VarChar).Value = gymName;
            query = "insert into Gym_CustomerSatisfaction(gymName, memberEmail, customerSatisfaction) values (@gymName, @email, @rating)";
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Rating sent successfully!");
            Close();
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void kryptonNumericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
