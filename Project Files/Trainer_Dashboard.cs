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
    public partial class Trainer_Dashboard : Form
    {
        string trainerEmail;
        string currently_selected_button;
        public Trainer_Dashboard(string email = "")
        {
            InitializeComponent();
            this.trainerEmail = email;
            this.currently_selected_button = "";

            currently_selected_button = "gym";
            dataGridView1.Visible = false;
            kryptonButton8.Visible = false; // SELECT
            kryptonButton10.Visible = false; // CHANGE
            kryptonButton9.Visible = false; // CREATE
            kryptonTextBox1.Visible = false;
            label1.Visible = false;
        }

        private void Trainer_Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            currently_selected_button = "gym";
            dataGridView1.Visible = false;
            kryptonButton8.Visible = false; // SELECT
            kryptonButton10.Visible = false; // CHANGE
            kryptonButton9.Visible = false; // CREATE
            kryptonTextBox1.Visible = false;
            label1.Visible = false;
            Trainer_Gym trainer = new Trainer_Gym(trainerEmail);
            trainer.Show();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            currently_selected_button = "workout";
            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();
            string query = "SELECT WorkoutPlan.workoutPlanID, WorkoutPlan.goal, WorkoutPlan.schedule, WorkoutPlan.experienceLevel " +
                "FROM WorkoutPlan INNER JOIN Trainer ON WorkoutPlan.trainerEmail = trainer.trainerEmail where trainer.trainerEmail = @trainerEmail;";
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@trainerEmail", trainerEmail);
                using (SqlDataAdapter sqlDA = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    sqlDA.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            kryptonButton8.Visible = false; // SELECT
            kryptonButton9.Visible = true; // CREATE
            kryptonButton10.Visible = true; // Remove
            kryptonTextBox1.Visible = false; // INPUT BOX     
            label1.Visible = false; // LABEL "ENTER"
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            currently_selected_button = "diet";
            kryptonTextBox1.Visible = false;
            label1.Visible = false;
            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();
            string query = "SELECT dietPlan.dietPlanID, dietPlan.purpose, dietPlan.typeOfDiet " +
                "FROM dietPlan Inner JOIN Trainer ON dietPlan.trainerEmail = trainer.trainerEmail where trainer.trainerEmail = @trainerEmail ";
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@trainerEmail", trainerEmail);
                using (SqlDataAdapter sqlDA = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    sqlDA.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            kryptonButton8.Visible = false; // SELECT
            kryptonButton9.Visible = true; // CREATE
            kryptonButton10.Visible = true; // Remove
            kryptonTextBox1.Visible = false; // INPUT BOX     
            label1.Visible = false; // LABEL "ENTER"
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Trainer_Appointments trainer = new Trainer_Appointments(trainerEmail);
            trainer.Show();
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kryptonButton8_Click(object sender, EventArgs e)
        {
            if (currently_selected_button == "workout")
            {
                string workoutid = kryptonTextBox1.Text;
                if (string.IsNullOrEmpty(workoutid))
                {
                    MessageBox.Show("Please enter all compulsory fields!");
                }
                else
                {
                    SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
                    conn.Open();
                    SqlCommand cmd;
                    string query = "select count(*) from WorkoutPlan where workoutPlanID = @workoutid";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.Add("@workoutid", SqlDbType.VarChar).Value = workoutid;
                    int count = (int)cmd.ExecuteScalar();

                    if (count != 0)
                    {
                        query = "";
                        query = "delete from workout_exercises where workoutPlanId=@workoutid;";
                        cmd.CommandText = query;
                        cmd.ExecuteNonQuery();
                        query = "update member set currentlyfollowingworkoutplanid=NULL where currentlyfollowingworkoutplanid=@workoutid";
                        cmd.CommandText = query;
                        cmd.ExecuteNonQuery();
                       
                        query = "delete from workoutPlan where workoutPlanId=@workoutid;";
                        cmd.CommandText = query;
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Workoutplan Removed Successfully!");
                        button3_Click_1(sender, e);
                        kryptonTextBox1.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Invalid Workout ID!");
                    }
                }
            }
            else if (currently_selected_button == "diet")
            {
                string dietplanid = kryptonTextBox1.Text;
                if (string.IsNullOrEmpty(dietplanid))
                {
                    MessageBox.Show("Please enter all compulsory fields!");
                }
                else
                {
                    SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
                    conn.Open();
                    SqlCommand cmd;
                    string query = "select count(*) from DietPlan where dietPlanID = @dietplanid";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.Add("@dietplanid", SqlDbType.VarChar).Value = dietplanid;
                    int count = (int)cmd.ExecuteScalar();

                    if (count != 0)
                    {
                        query = "";
                        query = "delete from diet_meal where dietPlanId=@dietPlanid;";
                        cmd.CommandText = query;
                        cmd.ExecuteNonQuery();
                        query = "update member set dietplanid=NULL where dietplanid=@dietplanid";
                        cmd.CommandText = query;
                        cmd.ExecuteNonQuery();
                        query = "delete from dietPlan where dietPlanId=@dietplanid;";
                        cmd.CommandText = query;
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Dietplan Removed Successfully!");
                        kryptonTextBox1.Text = "";
                        button4_Click_1(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Invalid Diet Plan ID!");
                    }
                }
            }
        }

        private void kryptonButton9_Click(object sender, EventArgs e)
        {
            if (currently_selected_button == "workout")
            {
                this.Close();
                Trainer_WorkoutPlan_Create trainer = new Trainer_WorkoutPlan_Create(trainerEmail);
                trainer.Show();
            }
            else if (currently_selected_button == "diet")
            {
                this.Close();
                Trainer_DietPlan_Create trainer = new Trainer_DietPlan_Create(trainerEmail);
                trainer.Show();
            }
        }

        private void kryptonButton10_Click(object sender, EventArgs e)
        {
            if (currently_selected_button == "workout")
            {
                SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
                conn.Open();
                string query = "SELECT WorkoutPlan.workoutPlanID, WorkoutPlan.goal, WorkoutPlan.schedule, WorkoutPlan.experienceLevel FROM WorkoutPlan inner join Trainer on Trainer.trainerEmail = WorkoutPlan.trainerEmail where trainer.trainerEmail = @trainerEmail ;";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@trainerEmail", trainerEmail);
                    using (SqlDataAdapter sqlDA = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        sqlDA.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
                label1.Text = "Enter WorkoutPlan ID: ";
                label1.Visible = true;
                kryptonButton10.Visible = false;
                kryptonButton9.Visible = false;
                kryptonButton8.Location = kryptonButton9.Location;
                kryptonButton8.Visible = true;
                kryptonTextBox1.Visible = true;
            }
            else if (currently_selected_button == "diet")
            {
                SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
                conn.Open();
                string query = "SELECT dietPlan.dietplanID, dietPlan.trainerEmail, dietPlan.memberEmail, dietPlan.purpose, dietPlan.typeOfDiet FROM DietPlan inner join Trainer on trainer.trainerEmail = dietPlan.trainerEmail where trainer.trainerEmail = @trainerEmail ;";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter sqlDA = new SqlDataAdapter(command))
                    {
                        command.Parameters.AddWithValue("@trainerEmail", trainerEmail);
                        DataTable dt = new DataTable();
                        sqlDA.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
                label1.Text = "Enter DietPlan ID: ";
                label1.Visible = true;
                kryptonButton10.Visible = false;
                kryptonButton9.Visible = false;
                kryptonButton8.Location = kryptonButton9.Location;
                kryptonButton8.Visible = true;
                kryptonTextBox1.Visible = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void kryptonButton6_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            currently_selected_button = "member_feedback";

            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();
            string query = "select * from feedback where trainerEmail = @trainerEmail";
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@trainerEmail", trainerEmail);
                using (SqlDataAdapter sqlDA = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    sqlDA.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            kryptonButton8.Visible = false; // SELECT
            kryptonButton9.Visible = false; // CREATE
            kryptonButton10.Visible = false; // CHANGE
            kryptonTextBox1.Visible = false; // INPUT BOX     
            label1.Visible = false; // LABEL "ENTER"
        }

        private void kryptonButton7_Click(object sender, EventArgs e)
        {
            Trainer_Clients tc = new Trainer_Clients(trainerEmail);
            tc.Show();
        }
    }
}
