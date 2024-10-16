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
    public partial class GymOwner_ViewMembersTrainers : Form
    {
        string current_email;
        public GymOwner_ViewMembersTrainers(string current_email = "")
        {
            InitializeComponent();
            this.current_email = current_email;

            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();
            string query = "Select * from Member where gymName = (Select gymName from Gym where gymOwner = @owner) AND isApproved = 1;";
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@owner", current_email);
                using (SqlDataAdapter sqlDA = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    sqlDA.Fill(dt);
                    kryptonDataGridView1.DataSource = dt;
                }
            }

            query = "Select Trainer.trainerEmail, Trainer.name, Trainer.speciality, Trainer.experience, Trainer.qualification, " +
                    "Trainer_Verification.gymName FROM Trainer " +
                    "JOIN Trainer_Verification on Trainer.trainerEmail = Trainer_Verification.trainerEmail " +
                    "where Trainer_Verification.gymName = (Select gymName from Gym where gymOwner = @owner) AND Trainer_Verification.isVerified = 1;";
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@owner", current_email);
                using (SqlDataAdapter sqlDA = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    sqlDA.Fill(dt);
                    kryptonDataGridView2.DataSource = dt;
                }
            }
        }

        private void GymOwner_ViewMembersTrainers_Load(object sender, EventArgs e)
        {

        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kryptonButton8_Click(object sender, EventArgs e)
        {
            string memberEmail = member_signup_gym.Text;

            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();

            string query = "SELECT count(memberEmail) FROM Member WHERE memberEmail = @member;";
            SqlCommand cmd;
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("member", memberEmail);
            int count = (int)cmd.ExecuteScalar();

            if ( count == 0 )
            {
                MessageBox.Show("Invalid Member Email !");
            }
            else
            {
                query = "Delete FROM Workout_Exercises where workoutPlanID IN (SELECT workoutPlanID FROM workoutPlan where memberEmail= @member)";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                query = "Delete FROM WorkoutPlan where memberEmail = @member";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                query = "Delete FROM Diet_Meal where dietPlanID IN (SELECT dietPlanID FROM dietPlan where memberEmail = @member)";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                query = "Delete FROM dietPlan where memberEmail = @member";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                query = "DELETE FROM TrainerRating where memberEmail = @member";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                query = "DELETE FROM Member_Verification where memberEmail = @member";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                query = "DELETE FROM Appointment where memberEmail = @member";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                query = "DELETE FROM Gym_Membership where memberEmail = @member";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                query = "DELETE FROM Gym_CustomerSatisfaction where memberEmail = @member";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                query = "DELETE FROM Member where memberEmail = @member";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                MessageBox.Show("Member deleted successfully !");

                query = "Select * from Member where gymName = (Select gymName from Gym where gymOwner = @owner) AND isApproved = 1;";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@owner", current_email);
                    using (SqlDataAdapter sqlDA = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        sqlDA.Fill(dt);
                        kryptonDataGridView1.DataSource = dt;
                    }
                }
            }
        }

        private void member_signup_gym_DropDown(object sender, EventArgs e)

        {
            member_signup_gym.Items.Clear();
           SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();
            string query = "Select memberEmail from Member where gymName = (Select gymName from Gym where gymOwner = @owner) AND isApproved = 1;";
            SqlCommand cmd;
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@owner", current_email);

            string target_muscle = member_signup_gym.Text;
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string exerciseName = reader.GetString(0);
                member_signup_gym.Items.Add(exerciseName);
            }
        }

        private void kryptonComboBox2_DropDown(object sender, EventArgs e)
        {
            kryptonComboBox2.Items.Clear();
            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();
            string query = "Select Trainer.trainerEmail, Trainer.name, Trainer.password, Trainer.speciality, Trainer.experience, Trainer.qualification, " +
                    "Trainer_Verification.gymName FROM Trainer " +
                    "JOIN Trainer_Verification on Trainer.trainerEmail = Trainer_Verification.trainerEmail " +
                    "where Trainer_Verification.gymName = (Select gymName from Gym where gymOwner = @owner) AND Trainer_Verification.isVerified = 1;";
            SqlCommand cmd;
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@owner", current_email);

            string target_muscle = kryptonComboBox2.Text;
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string exerciseName = reader.GetString(0);
                kryptonComboBox2.Items.Add(exerciseName);
            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            string trainerEmail = kryptonComboBox2.Text;

            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();

            string query = "SELECT count(trainerEmail) FROM Trainer WHERE trainerEmail = @trainer;";
            SqlCommand cmd;
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("trainer", trainerEmail);
            int count = (int)cmd.ExecuteScalar();

            if (count == 0)
            {
                MessageBox.Show("Invalid Trainer Email !");
            }
            else
            {
                query = "Delete FROM Workout_Exercises where workoutPlanID IN (SELECT workoutPlanID FROM workoutPlan where trainerEmail= @trainer)";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                query = "Delete FROM WorkoutPlan where trainerEmail = @trainer";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                query = "Delete FROM Diet_Meal where dietPlanID IN (SELECT dietPlanID FROM dietPlan where trainerEmail = @trainer)";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                query = "Delete FROM dietPlan where trainerEmail = @trainer";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                query = "Update MEMBER set trainerEmail = NULL where trainerEmail = @trainer";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                query = "DELETE FROM TrainerRating where trainerEmail = @trainer";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                query = "DELETE FROM Trainer_Verification where trainerEmail = @trainer";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                query = "DELETE FROM GymTrainers where trainerEmail = @trainer";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                query = "DELETE FROM Feedback where trainerEmail = @trainer";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                query = "DELETE FROM Appointment where trainerEmail = @trainer";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                query = "DELETE FROM Trainer where trainerEmail = @trainer";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                MessageBox.Show("Trainer deleted successfully !");

                query = "Select Trainer.trainerEmail, Trainer.name, Trainer.password, Trainer.speciality, Trainer.experience, Trainer.qualification, " +
                    "Trainer_Verification.gymName FROM Trainer " +
                    "JOIN Trainer_Verification on Trainer.trainerEmail = Trainer_Verification.trainerEmail " +
                    "where Trainer_Verification.gymName = (Select gymName from Gym where gymOwner = @owner) AND Trainer_Verification.isVerified = 1;";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@owner", current_email);
                    using (SqlDataAdapter sqlDA = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        sqlDA.Fill(dt);
                        kryptonDataGridView2.DataSource = dt;
                    }
                }
            }
        }
    }
}
