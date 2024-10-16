using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Database_Project_GymTrainer
{
    public partial class Member_Dashboard : Form
    {
        string owner_email, member_email;
        string currently_selected_button;
        string current_gym;
        public Member_Dashboard(string email = "", string email2 = "", string current_gym = "")
        {
            InitializeComponent();
            currently_selected_button = "";
            this.current_gym = current_gym;
            owner_email = email;
            member_email = email2;

            dataGridView1.Visible = false;
            kryptonTextBox1.Visible = false;
            kryptonButton7.Visible = false;
            kryptonButton6.Visible = false;
            kryptonButton8.Visible = false;
            kryptonButton12.Visible = false;
            kryptonButton13.Visible = false;
            label1.Visible = false;

            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();
            SqlCommand cmd;
            string query = "select count(*) from Gym_CustomerSatisfaction where memberEmail=@email and gymName=@gymName";
            cmd = new SqlCommand(query, conn);
            string trainer_email;
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = member_email;
            cmd.Parameters.Add("@gymName", SqlDbType.VarChar).Value = current_gym;
            if ((int)cmd.ExecuteScalar() > 0)
                kryptonButton10.Visible = false;
            else
                kryptonButton10.Visible = true;


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Member_Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            currently_selected_button = "gym";
            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();

            string query_member = "Select Gym.gymName, Gym.gymOwner, Gym.adminEmail, Gym.location, Gym.membership_fees from Member join Gym on Member.gymName = Gym.gymName where member.memberEmail= @memberEmail;";
            SqlCommand command = new SqlCommand(query_member, conn);

            command.Parameters.AddWithValue("@memberEmail", member_email);

            // Use SqlDataReader to execute the query
            SqlDataReader reader = command.ExecuteReader();

            // Load data into DataTable
            DataTable dt = new DataTable();
            dt.Load(reader);

            // Bind DataTable to DataGridView

            dataGridView1.DataSource = dt;
            dt.Dispose();

            kryptonButton8.Visible = false;
            kryptonButton7.Visible = true;
            kryptonButton6.Visible = false;
            kryptonTextBox1.Visible = false;
            kryptonButton12.Visible = false;
            kryptonButton13.Visible = false;
            label1.Visible = false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            currently_selected_button = "workout";
            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();
            string query = "SELECT WorkoutPlan.workoutPlanID, WorkoutPlan.goal, WorkoutPlan.schedule, WorkoutPlan.experienceLevel " +
                "FROM WorkoutPlan INNER JOIN Member ON WorkoutPlan.workoutPlanID = Member.currentlyFollowingWorkoutPlanID where member.memberEmail = @memberEmail;";
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@memberEmail", member_email);
                using (SqlDataAdapter sqlDA = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    sqlDA.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            kryptonButton8.Visible = false; // SELECT
            kryptonButton6.Visible = true; // CREATE
            kryptonButton7.Visible = true; // CHANGE
            kryptonTextBox1.Visible = false; // INPUT BOX
            kryptonButton12.Visible = true;// remove button
            kryptonButton13.Visible = false;// remove Select Button button
            label1.Visible = false; // LABEL "ENTER"
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            currently_selected_button = "diet";
            kryptonTextBox1.Visible = false;
            label1.Visible = false;
            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();
            string query = "SELECT dietPlan.dietPlanID, dietPlan.purpose, dietPlan.typeOfDiet " +
                "FROM dietPlan Inner JOIN Member ON dietPlan.dietPlanID = Member.dietPlanID where member.memberEmail = @memberemail ";
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@memberemail", member_email);
                using (SqlDataAdapter sqlDA = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    sqlDA.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            kryptonButton8.Visible = false; // SELECT
            kryptonButton6.Visible = true; // CREATE
            kryptonButton7.Visible = true; // CHANGE
            kryptonTextBox1.Visible = false; // INPUT BOX
            kryptonButton12.Visible = true;
            kryptonButton13.Visible = false;// remove Select Button button

            label1.Visible = false; // LABEL "ENTER"
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            currently_selected_button = "trainer";
            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();

            string query_member = "Select Trainer.trainerEmail, Trainer.name, Trainer.speciality, Trainer.experience from Trainer join Member on Trainer.trainerEmail = Member.trainerEmail where member.memberEmail = @memberEmail;";
            SqlCommand command = new SqlCommand(query_member, conn);

            command.Parameters.AddWithValue("@memberEmail", member_email);

            // Use SqlDataReader to execute the query
            SqlDataReader reader = command.ExecuteReader();

            // Load data into DataTable
            DataTable dt = new DataTable();
            dt.Load(reader);

            // Bind DataTable to DataGridView

            dataGridView1.DataSource = dt;
            dt.Dispose();
            kryptonButton7.Visible = true;
            kryptonButton7.Text = "Change";
            kryptonButton6.Visible = false;
            kryptonButton8.Visible = false;
            kryptonTextBox1.Visible = false;
            label1.Visible = false;
            kryptonButton12.Visible = false;
            kryptonButton13.Visible = false;// remove Select Button button
        }

        private void kryptonButton7_Click(object sender, EventArgs e)
        {
            kryptonButton8.Visible = true; // SELECT
            kryptonButton6.Visible = false; // CREATE
            kryptonButton7.Visible = false; // CHANGE
            kryptonTextBox1.Visible = true; // INPUT BOX     
            label1.Visible = true; // LABEL "ENTER"
            kryptonButton8.Location = kryptonButton7.Location;
            if (currently_selected_button == "gym")
            {
                SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
                conn.Open();
                string query = "Select Gym.gymName, Gym.gymOwner, Gym.adminEmail, Gym.location, Gym.membership_fees from Gym where gymName != @currentgym";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@currentgym", current_gym);
                    using (SqlDataAdapter sqlDA = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        sqlDA.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
                label1.Text = "Enter Gym Name: ";
            }
            else if (currently_selected_button == "trainer")
            {
                SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
                conn.Open();
                string query = "SELECT Trainer.trainerEmail, Trainer.name, Trainer.speciality, Trainer.experience FROM Trainer where trainer.trainerEmail in (select gymtrainers.trainerEmail from  gymtrainers inner join trainer on trainer.trainerEmail=GymTrainers.trainerEmail inner join member on trainer.trainerEmail!=member.trainerEmail or member.trainerEmail is NULL where gymtrainers.gymName=@currentGym and member.memberEmail=@memberEmail);";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@currentgym", current_gym);
                    command.Parameters.AddWithValue("@memberEmail", member_email);
                    using (SqlDataAdapter sqlDA = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        sqlDA.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
                label1.Text = "Enter Trainer Email: ";
                label1.Visible = true;
                kryptonButton7.Visible = false;
                kryptonButton8.Location = kryptonButton7.Location;
                kryptonButton8.Visible = true;
            }
            else if (currently_selected_button == "workout")
            {
                SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
                conn.Open();
                string query = "SELECT WorkoutPlan.workoutPlanID, WorkoutPlan.goal, WorkoutPlan.schedule, WorkoutPlan.experienceLevel FROM WorkoutPlan inner join Member on Member.memberEmail = WorkoutPlan.memberEmail where Member.memberEmail = @memberEmail UNION SELECT WorkoutPlan.workoutPlanID, WorkoutPlan.goal, WorkoutPlan.schedule, WorkoutPlan.experienceLevel FROM WorkoutPlan inner join Trainer on trainer.trainerEmail = WorkoutPlan.trainerEmail inner join Member on Trainer.trainerEmail = Member.trainerEmail where Member.memberEmail = @memberEmail EXCEPT SELECT WorkoutPlan.workoutPlanID, WorkoutPlan.goal, WorkoutPlan.schedule, WorkoutPlan.experienceLevel FROM WorkoutPlan inner join member on Member.currentlyFollowingWorkoutPlanID = WorkoutPlan.workoutPlanID where Member.memberEmail = @memberEmail ;";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@memberEmail", member_email);
                    using (SqlDataAdapter sqlDA = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        sqlDA.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
                label1.Text = "Enter WorkoutPlan ID: ";
                label1.Visible = true;
                kryptonButton7.Visible = false;
                kryptonButton12.Visible = false;
                kryptonButton8.Location = kryptonButton7.Location;
                kryptonButton8.Visible = true;
            }
            else if (currently_selected_button == "diet")
            {
                SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
                conn.Open();
                string query = "SELECT dietPlan.dietplanID, dietPlan.trainerEmail, dietPlan.memberEmail, dietPlan.purpose, dietPlan.typeOfDiet FROM DietPlan inner join Member on Member.memberEmail = dietPlan.memberEmail where Member.memberEmail = @memberEmail " +
                    "UNION SELECT dietPlan.dietplanID, dietPlan.trainerEmail, dietPlan.memberEmail, dietPlan.purpose, dietPlan.typeOfDiet FROM DietPlan inner join Trainer on trainer.trainerEmail = dietPlan.trainerEmail inner join Member on Trainer.trainerEmail = Member.trainerEmail where Member.memberEmail = @memberEmail " +
                    "EXCEPT SELECT dietPlan.dietplanID, dietPlan.trainerEmail, dietPlan.memberEmail, dietPlan.purpose, dietPlan.typeOfDiet FROM DietPlan inner join member on Member.dietPlanID = dietPlan.dietPlanID where Member.memberEmail = @memberEmail ;";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter sqlDA = new SqlDataAdapter(command))
                    {
                        command.Parameters.AddWithValue("@memberEmail", member_email);
                        DataTable dt = new DataTable();
                        sqlDA.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
                label1.Text = "Enter DietPlan ID: ";
                label1.Visible = true;
                kryptonButton12.Visible = false;

                kryptonButton7.Visible = false;
                kryptonButton8.Location = kryptonButton7.Location;
                kryptonButton8.Visible = true;
            }

        }

        private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton8_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void kryptonButton6_Click(object sender, EventArgs e)
        {
            if (currently_selected_button == "workout")
            {
                this.Close();
                Member_WorkoutPlan_Create member = new Member_WorkoutPlan_Create(member_email, owner_email, current_gym);
                member.Show();
            }
            else if (currently_selected_button == "diet")
            {
                this.Close();
                Member_DietPlan_Create member = new Member_DietPlan_Create(member_email, owner_email, current_gym);
                member.Show();
            }
        }

        private void kryptonButton9_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();
            string query = "Select trainerEmail from member where memberEmail = @memberEmail;";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@memberEmail", SqlDbType.VarChar).Value = member_email;
            string trainer_email = cmd.ExecuteScalar().ToString();
            if (trainer_email == "")
            {
                MessageBox.Show("Select a Trainer First !");
                return;
            }

            this.Close();
            Member_BookAppointment member = new Member_BookAppointment(owner_email, member_email, current_gym, trainer_email);
            member.Show();
        }

        private void kryptonButton10_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();
            SqlCommand cmd;
            string query = "select count(*) from Gym_CustomerSatisfaction where memberEmail=@email and gymName=@gymName";
            cmd = new SqlCommand(query, conn);
            string trainer_email;
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = member_email;
            cmd.Parameters.Add("@gymName", SqlDbType.VarChar).Value = current_gym;
            if ((int)cmd.ExecuteScalar() == 0)
            {
                Member_Gym_Feedback_Dashboard feedback = new Member_Gym_Feedback_Dashboard(member_email);
                feedback.Show();
            }
            else
            {
                MessageBox.Show("Feedback already given!");
            }

        }

        private void kryptonButton11_Click(object sender, EventArgs e)
        {
            string query = "", trainer_email;
            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();
            SqlCommand cmd;
            cmd = new SqlCommand(query, conn);
            try
            {
                query = "select trainerEmail from member where memberEmail=@email";
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = member_email;
                cmd.CommandText = query;
                trainer_email = cmd.ExecuteScalar().ToString();
                if (string.IsNullOrEmpty(trainer_email))
                {
                    MessageBox.Show("Please select a trainer first!");
                }
                else
                {

                    cmd.Parameters.Add("@trainerEmail", SqlDbType.VarChar).Value = trainer_email;
                    query = "select count(*) from feedback where memberEmail=@email and trainerEmail=@trainerEmail";

                    cmd.CommandText = query;
                    if ((int)cmd.ExecuteScalar() > 0)
                    {
                        MessageBox.Show("Feedback already given to this trainer!");
                    }
                    else
                    {
                        Member_Trainer_Feedback_Dashboard member_Trainer_Feedback_Dashboard = new Member_Trainer_Feedback_Dashboard(member_email);
                        member_Trainer_Feedback_Dashboard.Show();
                    }
                }
            }


            catch
            {
                MessageBox.Show("An error occurred!");
            }
        }

        private void kryptonButton12_Click(object sender, EventArgs e)
        {
            if (currently_selected_button == "workout")
            {
                SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
                conn.Open();
                string query = "SELECT WorkoutPlan.workoutPlanID, WorkoutPlan.goal, WorkoutPlan.schedule, WorkoutPlan.experienceLevel FROM WorkoutPlan inner join Member on Member.memberEmail = WorkoutPlan.memberEmail where Member.memberEmail = @memberEmail EXCEPT SELECT WorkoutPlan.workoutPlanID, WorkoutPlan.goal, WorkoutPlan.schedule, WorkoutPlan.experienceLevel FROM WorkoutPlan inner join member on Member.currentlyFollowingWorkoutPlanID = WorkoutPlan.workoutPlanID where Member.memberEmail = @memberEmail ;";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@memberEmail", member_email);
                    using (SqlDataAdapter sqlDA = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        sqlDA.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
                label1.Text = "Enter WorkoutPlan ID: ";
                label1.Visible = true;
                kryptonButton7.Visible = false;
                kryptonButton6.Visible = false;
                kryptonButton12.Visible = false;
                kryptonButton13.Location = kryptonButton7.Location;
                kryptonButton13.Visible = true;
                kryptonTextBox1.Visible = true;
            }
            else if (currently_selected_button == "diet")
            {
                SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
                conn.Open();
                string query = "SELECT dietPlan.dietplanID, dietPlan.trainerEmail, dietPlan.memberEmail, dietPlan.purpose, dietPlan.typeOfDiet FROM DietPlan inner join Member on Member.memberEmail = dietPlan.memberEmail where Member.memberEmail = @memberEmail " +
                    "EXCEPT SELECT dietPlan.dietplanID, dietPlan.trainerEmail, dietPlan.memberEmail, dietPlan.purpose, dietPlan.typeOfDiet FROM DietPlan inner join member on Member.dietPlanID = dietPlan.dietPlanID where Member.memberEmail = @memberEmail ;";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter sqlDA = new SqlDataAdapter(command))
                    {
                        command.Parameters.AddWithValue("@memberEmail", member_email);
                        DataTable dt = new DataTable();
                        sqlDA.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
                label1.Text = "Enter DietPlan ID: ";
                label1.Visible = true;
                kryptonButton7.Visible = false;
                kryptonButton6.Visible = false;
                kryptonButton12.Visible = false;
                kryptonButton13.Location = kryptonButton7.Location;
                kryptonButton13.Visible = true;
                kryptonTextBox1.Visible = true;
            }
        }

        private void kryptonButton13_Click(object sender, EventArgs e)
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
                        cmd.Parameters.Add("@memberEmail", SqlDbType.VarChar).Value = member_email;
                        cmd.ExecuteNonQuery();
                        query = "delete from workoutPlan where workoutPlanId=@workoutid;";
                        cmd.CommandText = query;
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Workoutplan Removed Successfully!");
                        button2_Click_1(sender, e);
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
                        cmd.Parameters.Add("@memberEmail", SqlDbType.VarChar).Value = member_email;
                        cmd.ExecuteNonQuery();
                        query = "delete from dietPlan where dietPlanId=@dietplanid;";
                        cmd.CommandText = query;
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Dietplan Removed Successfully!");
                        kryptonTextBox1.Text = "";
                        button1_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Invalid Diet Plan ID!");
                    }
                }
            }

        }

        private void kryptonButton8_Click(object sender, EventArgs e)
        {
            if (currently_selected_button == "gym")
            {
                SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
                conn.Open();
                string query = "Select Gym.gymName, Gym.gymOwner, Gym.adminEmail, Gym.location, Gym.membership_fees from Gym where gymName != @currentgym";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@currentgym", current_gym);
                    using (SqlDataAdapter sqlDA = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        sqlDA.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
                string gymname = kryptonTextBox1.Text;
                if (string.IsNullOrEmpty(gymname))
                {
                    MessageBox.Show("Please enter all compulsory fields!");
                }
                else
                {
                    conn = new SqlConnection(ConnectionString.ServerName);
                    conn.Open();
                    SqlCommand cmd;
                    query = "";
                    query = "select count(*) from Gym where gymName=@gymName";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.Add("@gymName", SqlDbType.VarChar).Value = gymname;
                    int count = (int)cmd.ExecuteScalar();

                    if (count != 0)
                    {
                        query = "";
                        query = "select gymOwner from Gym where gymName = @gymName";
                        owner_email = cmd.ExecuteScalar().ToString();

                        query = "";
                        query = "update Member set addedBy = NULL,currentlyFollowingWorkoutPlanID = NULL , dietPlanID = NULL, gymName = NULL,isApproved = 0,trainerEmail = NULL where memberEmail = @memberEmail";
                        cmd.CommandText = query;
                        cmd.Parameters.Add("@memberEmail", SqlDbType.VarChar).Value = member_email;
                        cmd.ExecuteNonQuery();
                        query = "Insert into member_verification(memberEmail, gymName) VALUES(@memberEmail,@gymName)";
                        cmd.CommandText = query;
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Leaving Current Gym. Approval Request sent to Gym Owner. Kindly Wait for Gym Owner's Approval. Once Aprroved, you will be able to login.");
                        this.Close();
                        kryptonTextBox1.Text = "";
                        current_gym = " ";
                        owner_email = " ";
                    }
                    else
                    {
                        MessageBox.Show("Invalid Gym Name!");
                    }
                }
            }
            else if (currently_selected_button == "trainer")
            {
                string traineremail = kryptonTextBox1.Text;
                if (string.IsNullOrEmpty(traineremail))
                {
                    MessageBox.Show("Please enter all compulsory fields!");
                }
                else
                {
                    SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
                    conn.Open();
                    SqlCommand cmd;
                    string query = "select count(*) from Trainer where trainerEmail=@trainerEmail";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.Add("@trainerEmail", SqlDbType.VarChar).Value = traineremail;
                    int count = (int)cmd.ExecuteScalar();

                    if (count != 0)
                    {


                        query = "";
                        query = "update Member set trainerEmail = @trainerEmail where memberEmail = @memberEmail";
                        cmd.CommandText = query;
                        cmd.Parameters.Add("@memberEmail", SqlDbType.VarChar).Value = member_email;
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Trainer Selected Successfully!");
                        kryptonTextBox1.Text = "";
                        kryptonButton7_Click(sender, e);

                    }
                    else
                    {
                        MessageBox.Show("Invalid Trainer Email!");
                    }
                }
            }
            else if (currently_selected_button == "workout")
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
                        query = "update Member set currentlyFollowingWorkoutPlanID = @workoutid where memberEmail = @memberEmail";
                        cmd.CommandText = query;
                        cmd.Parameters.Add("@memberEmail", SqlDbType.VarChar).Value = member_email;
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Workoutplan Changed Successfully!");
                        button2_Click_1(sender, e);
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
                        query = "update Member set dietPlanID = @dietplanid where memberEmail = @memberEmail";
                        cmd.CommandText = query;
                        cmd.Parameters.Add("@memberEmail", SqlDbType.VarChar).Value = member_email;
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Dietplan Changed Successfully!");
                        kryptonTextBox1.Text = "";
                        button1_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Invalid Diet Plan ID!");
                    }
                }
            }
        }
    }
}
