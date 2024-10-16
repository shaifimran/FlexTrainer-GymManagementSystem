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
    public partial class Admin_ApprovedGyms : Form
    {

        string admin_email;
        public Admin_ApprovedGyms(string admin_email = "")
        {
            InitializeComponent();
            this.admin_email = admin_email;

            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();
            string query = "Select * from Gym where adminEmail = @adminEmail AND isApproved = 1;";
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@adminEmail", admin_email);
                using (SqlDataAdapter sqlDA = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    sqlDA.Fill(dt);
                    kryptonDataGridView1.DataSource = dt;
                }
            }
        }

        private void GymOwner_ApprovedGyms_Load(object sender, EventArgs e)
        {

        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void member_signup_gym_DropDown(object sender, EventArgs e)
        {
            member_signup_gym.Items.Clear();
            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();
            string query = "SELECT gymName FROM Gym WHERE isApproved = 1 and adminEmail = @admin;";
            SqlCommand cmd;
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@admin", admin_email);

            string target_muscle = member_signup_gym.Text;
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string exerciseName = reader.GetString(0);
                member_signup_gym.Items.Add(exerciseName);
            }
        }

        private void kryptonButton8_Click(object sender, EventArgs e)
        {
            string gymName = member_signup_gym.Text;

            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();

            string query = "SELECT count(gymName) FROM Gym WHERE gymName = @gym;";
            SqlCommand cmd;
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("gym", gymName);
            int count = (int)cmd.ExecuteScalar();

            if ( count == 0 )
            {
                MessageBox.Show("Invalid Gym Name !");
                return;
            }
            else
            {
                query = "DELETE FROM Trainer_Verification where gymName = @gym";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                query = "DELETE FROM Member_Verification where gymName = @gym";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

               
                query = "Delete FROM Workout_Exercises where workoutPlanID IN (SELECT workoutPlanID FROM workoutPlan where memberEmail IN (SELECT MEMBEREmail FROM member where gymName = @gym))";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                query = "Delete FROM WorkoutPlan where memberEmail IN (SELECT MEMBEREmail FROM member where gymName = @gym)";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                query = "Delete FROM Diet_Meal where dietPlanID IN (SELECT dietPlanID FROM dietPlan where memberEmail IN (SELECT MEMBEREmail FROM member where gymName = @gym))";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                query = "Delete FROM dietPlan where memberEmail IN (SELECT MEMBEREmail FROM member where gymName = @gym)";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                query = "DELETE FROM Member where gymName = @gym";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                query = "DELETE FROM GymTrainers where gymName = @gym";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                query = "DELETE FROM Gym_Membership where gymName = @gym";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                query = "DELETE FROM Gym_Machines where gymName = @gym";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                query = "DELETE FROM Gym_CustomerSatisfaction where gymName = @gym";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                query = "DELETE FROM Approval where gymName = @gym";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                query = "DELETE FROM Gym where gymName = @gym";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                MessageBox.Show("Gym Removed from the Portal Successfully !");

                conn = new SqlConnection(ConnectionString.ServerName);
                conn.Open();
                query = "Select * from Gym where adminEmail = @adminEmail AND isApproved = 1;";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@adminEmail", admin_email);
                    using (SqlDataAdapter sqlDA = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        sqlDA.Fill(dt);
                        kryptonDataGridView1.DataSource = dt;
                    }
                }
            }
        }
    }
}
