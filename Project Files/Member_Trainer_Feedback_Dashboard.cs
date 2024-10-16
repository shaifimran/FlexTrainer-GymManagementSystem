using ComponentFactory.Krypton.Toolkit;
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
    public partial class Member_Trainer_Feedback_Dashboard : Form
    {
        string current_email;
        public Member_Trainer_Feedback_Dashboard(string email = "")
        {
            current_email = email;
            InitializeComponent();
        }

        private void kryptonButton10_Click(object sender, EventArgs e)
        {
            string feedback = kryptonRichTextBox1.Text;

            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();
            SqlCommand cmd;
            string trainer_email = "", query = "select trainerEmail from member where memberEmail=@email";
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = current_email;
            try
            {
                trainer_email = cmd.ExecuteScalar().ToString();
            }
            catch
            {
                MessageBox.Show("An error occurred!");
                Close();
                return;
            }
            cmd.Parameters.Add("@feedback", SqlDbType.VarChar).Value = feedback;
            cmd.Parameters.Add("@trainerEmail", SqlDbType.VarChar).Value = trainer_email;

            query = "insert into Feedback(trainerEmail, memberEmail, feedbackContent) values (@trainerEmail, @email, @feedback)";
            cmd.CommandText = query;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("An error occurred!");
                Close();
                return;
            }
            MessageBox.Show("Feedback sent successfully!");
            Close();
        }

        private void kryptonRichTextBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
