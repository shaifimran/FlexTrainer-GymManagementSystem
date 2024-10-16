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
    public partial class Trainer_WorkoutPlan_Create : Form
    {
        string trainerEmail;
        int current_workoutPlanID;
        bool isWorkoutPlanCreated = false;
        int current_day;
        public Trainer_WorkoutPlan_Create(string trainerEmail = "")
        {
            InitializeComponent();
            this.trainerEmail = trainerEmail;
            int.TryParse(label2.Text.Substring(4), out current_day);
        }

       

        private void Trainer_WorkoutPlan_Create_Load(object sender, EventArgs e)
        {

        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            this.Close();
            Trainer_Dashboard trainer_Dashboard = new Trainer_Dashboard(trainerEmail);
            trainer_Dashboard.Show();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (kryptonDataGridView1.RowCount == 0)
            {
                // DataGridView is empty
                MessageBox.Show("No exercises added. Please add exercises.", "No Exercises", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // You can add code here to prompt the user to add exercises
                return;
            }

            if (current_day == 1)
            {
                string goal = kryptonTextBox1.Text;
                string experience_level = kryptonTextBox2.Text;
                if (string.IsNullOrEmpty(experience_level))
                {
                    MessageBox.Show("Please enter an experience level.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Exit the method to prevent further execution
                }
                if (string.IsNullOrEmpty(goal))
                {
                    MessageBox.Show("Please enter a goal.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Exit the method to prevent further execution
                }

                string add_goal_and_experience_level = "UPDATE WorkoutPlan SET goal = @goal, experienceLevel = @experienceLevel where workoutplanID = @workoutPlanID;";
                SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
                conn.Open();
                SqlCommand cmd;
                cmd = new SqlCommand(add_goal_and_experience_level, conn);
                cmd.Parameters.Add("@goal", SqlDbType.VarChar).Value = goal;
                cmd.Parameters.Add("@experienceLevel", SqlDbType.VarChar).Value = experience_level;
                cmd.Parameters.Add("@workoutPlanID", SqlDbType.Int).Value = current_workoutPlanID;

                cmd.ExecuteNonQuery();
                current_day++;
                label2.Text = "Day " + current_day.ToString();
                this.Controls.Remove(label1);
                this.Controls.Remove(label3);
                this.Controls.Remove(kryptonTextBox1);
                this.Controls.Remove(kryptonTextBox2);
                this.Controls.Remove(kryptonButton2);
                kryptonDataGridView1.DataSource = null;
                kryptonDataGridView1.Rows.Clear();
                int moveAmount = 30;
                label2.Location = new Point(label2.Location.X, label2.Location.Y - moveAmount);
                label4.Location = new Point(label4.Location.X, label4.Location.Y - moveAmount);
                label5.Location = new Point(label5.Location.X, label5.Location.Y - moveAmount);
                label6.Location = new Point(label6.Location.X, label6.Location.Y - moveAmount);
                label7.Location = new Point(label7.Location.X, label7.Location.Y - moveAmount);
                kryptonComboBox3.Location = new Point(kryptonComboBox3.Location.X, kryptonComboBox3.Location.Y - moveAmount);
                kryptonComboBox2.Location = new Point(kryptonComboBox2.Location.X, kryptonComboBox2.Location.Y - moveAmount);
                kryptonNumericUpDown1.Location = new Point(kryptonNumericUpDown1.Location.X, kryptonNumericUpDown1.Location.Y - moveAmount);
                kryptonNumericUpDown2.Location = new Point(kryptonNumericUpDown2.Location.X, kryptonNumericUpDown2.Location.Y - moveAmount);
                kryptonButton3.Location = new Point(kryptonButton3.Location.X, kryptonButton3.Location.Y - moveAmount);
                cmd.Dispose();
                conn.Close();

            }

            else
            {
                current_day++;
                if (current_day <= 6)
                {
                    label2.Text = "Day " + current_day.ToString();
                    kryptonDataGridView1.DataSource = null;
                    kryptonDataGridView1.Rows.Clear();
                }
            }

            if (current_day == 6)
            {
                kryptonButton1.Text = "Create Workout Plan";
            }

            if (current_day == 7)
            {
                MessageBox.Show($"Workout plan created successfully with ID: {current_workoutPlanID}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                Trainer_Dashboard trainer = new Trainer_Dashboard(trainerEmail);
                trainer.Show();
            }
        }

        private void kryptonComboBox3_DropDown(object sender, EventArgs e)
        {
            kryptonComboBox3.Items.Clear();
            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();
            SqlCommand cmd;
            string display_targetMuscle = "SELECT distinct(targetMuscle) From exercise ;";
            cmd = new SqlCommand(display_targetMuscle, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string targetMuscle = reader.GetString(0);
                kryptonComboBox3.Items.Add(targetMuscle);
            }


            cmd.Dispose();
            conn.Close();
        }

        private void kryptonComboBox2_DropDown(object sender, EventArgs e)
        {
            kryptonComboBox2.Items.Clear();
            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();
            SqlCommand cmd;
            string display_exerciseNames_specific = "SELECT exerciseName From exercise where targetMuscle = @target_muscle;";
            string display_exerciseNames = "SELECT exerciseName From exercise ;";
            if (kryptonComboBox3.SelectedIndex == -1 || string.IsNullOrEmpty(kryptonComboBox3.Text))
            {
                cmd = new SqlCommand(display_exerciseNames, conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string exerciseName = reader.GetString(0);
                        kryptonComboBox2.Items.Add(exerciseName);
                    }
                }

            }

            else
            {
                cmd = new SqlCommand(display_exerciseNames_specific, conn);
                string target_muscle = kryptonComboBox3.Text;
                cmd.Parameters.Add("@target_muscle", SqlDbType.VarChar).Value = target_muscle;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string exerciseName = reader.GetString(0);
                        kryptonComboBox2.Items.Add(exerciseName);
                    }
                }
            }

            cmd.Dispose();
            conn.Close();
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();
            SqlCommand cmd;
            string get_workoutPlanId = "SELECT MAX(workoutPlanId) From WorkoutPlan ;";
            string check_workoutPlan_empty = "SELECT count(*) FROM workoutPlan;";


            string exerciseName = kryptonComboBox2.Text;
            int sets = Int32.Parse(kryptonNumericUpDown1.Text);
            int reps = Int32.Parse(kryptonNumericUpDown2.Text);

            // Validate selection for exercise name
            if (string.IsNullOrWhiteSpace(exerciseName))
            {
                MessageBox.Show("Please select an exercise name.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Exit the method to prevent further execution
            }

            if (current_day == 1 && !isWorkoutPlanCreated)
            {

                cmd = new SqlCommand(check_workoutPlan_empty, conn);
                int rowCount = (int)cmd.ExecuteScalar();
                current_workoutPlanID = 1;

                string create_workoutplan_record = "INSERT INTO workoutPlan (trainerEmail) VALUES(@trainerEmail);";
                cmd.CommandText = create_workoutplan_record;
                cmd.Parameters.Add("@trainerEmail", SqlDbType.VarChar).Value = trainerEmail;
                cmd.ExecuteNonQuery();

                isWorkoutPlanCreated = true;
                if (rowCount > 0)
                {
                    cmd.CommandText = get_workoutPlanId;
                    current_workoutPlanID = (int)cmd.ExecuteScalar() ;
                }

            }

            string add_exercise_for_workout = "INSERT INTO Workout_Exercises (day, workoutPlanID, exerciseName, sets, reps) VALUES (@day,@workoutPlanID,@exerciseName,@sets,@reps);";
            string check_exerciseName_exists = "SELECT count(*) FROM Workout_Exercises where workoutPlanId = @workoutPlanID AND exerciseName=@exerciseName AND day=@day;";
            cmd = new SqlCommand(check_exerciseName_exists, conn);
            cmd.Parameters.Add("@day", SqlDbType.Int).Value = current_day;
            cmd.Parameters.Add("@sets", SqlDbType.Int).Value = sets;
            cmd.Parameters.Add("@reps", SqlDbType.Int).Value = reps;
            cmd.Parameters.Add("@workoutPlanID", SqlDbType.Int).Value = current_workoutPlanID;
            cmd.Parameters.Add("@exerciseName", SqlDbType.VarChar).Value = exerciseName;
            int count = (int)cmd.ExecuteScalar();

            // If count is greater than 0, the exercise name already exists
            if (count > 0)
            {
                MessageBox.Show("Exercise with the same name already exists for the specified workout plan and day.", "Duplicate Exercise", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Exit the method or perform necessary action
            }

            cmd.CommandText = add_exercise_for_workout;
            cmd.ExecuteNonQuery();

            string selectExercisesQuery = "SELECT day,exerciseName, sets, reps FROM Workout_Exercises WHERE workoutPlanID = @workoutPlanID and day=@day";

            cmd.CommandText = selectExercisesQuery;


            // Create a DataTable to hold the retrieved exercise data
            DataTable exerciseTable = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            // Fill the DataTable with the retrieved data
            adapter.Fill(exerciseTable);


            // Bind the DataTable to 
            kryptonDataGridView1.DataSource = exerciseTable;
            kryptonDataGridView1.ReadOnly = true;
            cmd.Dispose();
            conn.Close();
        }
    }
}
