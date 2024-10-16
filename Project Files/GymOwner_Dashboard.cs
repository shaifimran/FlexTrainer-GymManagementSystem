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
    public partial class GymOwner_Dashboard : Form
    {
        string current_email;

        public GymOwner_Dashboard(string current_email = "")
        {
            InitializeComponent();
            label5.Visible = false;
            this.current_email = current_email;
            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();
            string query = $"select count(*) from gym where gymOwner='{current_email}' AND isApproved = 1;";
            SqlCommand cmd = new SqlCommand(query, conn); ;

            if ((int)cmd.ExecuteScalar() == 0)
            {
                kryptonButton5.Visible = false;
                kryptonButton3.Visible = false;
                kryptonButton1.Visible = false;

            }   
          
            string query_member = "SELECT * FROM Member_Verification WHERE gymName = (SELECT gymName FROM GYM WHERE gymOwner = @current_email);";
            string query_trainer = "SELECT * FROM Trainer_Verification WHERE gymName = (SELECT gymName FROM GYM WHERE gymOwner = @current_email) AND isVerified = 0;";
            string query_approval = "SELECT count(*) FROM Approval where gymOwnerEmail=@current_email;";
            string check_approved = "SELECT count(*) FROM GYM where gymOwner=@current_email AND isApproved = 1;";
            SqlCommand command = new SqlCommand(query_member, conn);

            command.Parameters.AddWithValue("@current_email", current_email);

            // Use SqlDataReader to execute the query
            SqlDataReader reader = command.ExecuteReader();

            // Load data into DataTable
            DataTable dt = new DataTable();
            dt.Load(reader);

            // Bind DataTable to DataGridView
            kryptonDataGridView1.DataSource = dt;

            dt.Dispose();

            command.CommandText = query_trainer;
            reader = command.ExecuteReader();
            dt = new DataTable();
            dt.Load(reader);    
            kryptonDataGridView2.DataSource = dt;

            dt.Dispose();
            command.CommandText = query_approval;
            if ((int)command.ExecuteScalar() == 1)
            {
                kryptonButton6.Hide();
                
            }

            command.CommandText = check_approved;

            if ((int)command.ExecuteScalar() == 1)
            {
                label5.Location = kryptonButton6.Location;
                label5.Visible = true;   
                kryptonButton6.Hide();

            }

            command.Dispose();
            conn.Close();
        }

        private void GymOwner_Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void kryptonButton5_Click(object sender, EventArgs e)
        {
            Close();
            GymOwner_AddMachine gymOwner_AddMachine = new GymOwner_AddMachine(current_email);
            gymOwner_AddMachine.Show();
        }

        private void kryptonButton6_Click(object sender, EventArgs e)
        {
            Close();
            GymOwner_Approval gymOwner_Approval = new GymOwner_Approval(current_email);
            gymOwner_Approval.Show();
        }

        private void kryptonButton7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            string query = "Update Member set addedBy = @ownerEmail, isApproved = 1, gymName= (Select gymName from Gym where gymOwner=@ownerEmail) where memberEmail IN (SELECT memberEmail FROM Member_Verification WHERE gymName = (Select gymName from Gym where gymOwner=@ownerEmail));";
            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();
            SqlCommand cmd;
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add("@ownerEmail", SqlDbType.VarChar).Value = current_email;
            cmd.ExecuteNonQuery();

            query = "Delete from Member_Verification where gymName = (Select gymName from Gym where gymOwner=@ownerEmail);";
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();

            MessageBox.Show("All Members Verified Successfully!");

            cmd.Dispose();

            string query_member = "SELECT * FROM Member_Verification WHERE gymName = (SELECT gymName FROM GYM WHERE gymOwner = @current_email)";
            SqlCommand command = new SqlCommand(query_member, conn);

            command.Parameters.AddWithValue("@current_email", current_email);

            // Use SqlDataReader to execute the query
            SqlDataReader reader = command.ExecuteReader();

            // Load data into DataTable
            DataTable dt = new DataTable();
            dt.Load(reader);

            // Bind DataTable to DataGridView
            kryptonDataGridView1.DataSource = dt;

            dt.Dispose();
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            int member_ver_id = Int32.Parse(kryptonNumericUpDown1.Text);
            if (member_ver_id > 0)
            {
                SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
                conn.Open();
                SqlCommand cmd;
                string query = "SELECT count(*) FROM Member_Verification WHERE verificationID = @verID AND gymName = (Select gymName from Gym where gymOwner=@ownerEmail);";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@verID", SqlDbType.Int).Value = member_ver_id;
                cmd.Parameters.Add("@ownerEmail", SqlDbType.VarChar).Value = current_email;
                int count = (int)cmd.ExecuteScalar();
                if (count == 1)
                {
                    query = "Select memberEmail FROM Member_Verification where VerificationID = @verID;";
                    cmd.CommandText = query;
                    string returned_string = cmd.ExecuteScalar().ToString();

                    query = "Update Member set addedBy = @ownerEmail, isApproved = 1, gymName = (SELECT gymName FROM GYM WHERE gymOwner = @ownerEmail)  where memberEmail = @memberEmail;";
                    cmd.CommandText = query;
                    cmd.Parameters.Add("@memberEmail", SqlDbType.VarChar).Value = returned_string;
                    cmd.ExecuteNonQuery();

                    query = "Delete from Member_Verification where VerificationID = @verID";
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Verification ID " + member_ver_id + " Verified Successfully!");

                    string query_member = "SELECT * FROM Member_Verification WHERE gymName = (SELECT gymName FROM GYM WHERE gymOwner = @current_email)";
                    SqlCommand command = new SqlCommand(query_member, conn);

                    command.Parameters.AddWithValue("@current_email", current_email);

                    // Use SqlDataReader to execute the query
                    SqlDataReader reader = command.ExecuteReader();

                    // Load data into DataTable
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    // Bind DataTable to DataGridView
                    kryptonDataGridView1.DataSource = dt;

                    dt.Dispose();
                }
                else
                {
                    MessageBox.Show("Invalid Member Verification ID!");
                }
            }
            else
            {
                MessageBox.Show("Member Verification ID must be entered!");
            }
        }

        private void kryptonButton9_Click(object sender, EventArgs e)
        {
            int trainer_ver_id = Int32.Parse(kryptonNumericUpDown2.Text);
            if (trainer_ver_id > 0)
            {
                SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
                conn.Open();
                SqlCommand cmd;
                string query = "Select count(*) FROM Trainer_Verification where VerificationID = @verID  AND gymName = (Select gymName from Gym where gymOwner=@ownerEmail);";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@verID", SqlDbType.Int).Value = trainer_ver_id;
                    cmd.Parameters.Add("@ownerEmail", SqlDbType.VarChar).Value = current_email;
                int count = (int)cmd.ExecuteScalar();
                if (count == 1)
                {
                    query = "Select trainerEmail FROM Trainer_Verification where VerificationID = @verID;";
                    cmd.CommandText = query;
                    string returned_string = cmd.ExecuteScalar().ToString();

                    query = "Update Trainer_verification set isVerified = 1 where verificationID = @verID;";
                    cmd.CommandText = query;
                    cmd.Parameters.Add("@trainerEmail", SqlDbType.VarChar).Value = returned_string;
                    cmd.ExecuteNonQuery();
                    query = "INSERT INTO GYMTRAINERS (gymName, trainerEmail) " +
               "SELECT GYM.gymName,trainer_VErification.trainerEmail FROM  GYM INNER JOIN  trainer_VErification " +
               "ON GYM.gymName = trainer_VErification.gymName WHERE GYM.gymOwner = @ownerEmail AND trainer_verification.verificationID = @verID;";
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                    

                    MessageBox.Show("Verification ID " + trainer_ver_id + " Verified Successfully!");

                    string query_trainer = "SELECT * FROM Trainer_Verification WHERE gymName = (SELECT gymName FROM GYM WHERE gymOwner = @ownerEmail) AND isVerified = 0;";


                    cmd.CommandText = query_trainer;
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    kryptonDataGridView2.DataSource = dt;
                   
                    dt.Dispose();

                    cmd.Dispose();
                    conn.Close();
                }
                else
                {
                    MessageBox.Show("Invalid Trainer Verification ID!");
                }
            }
            else
            {
                MessageBox.Show("Trainer Verification ID must be entered!");
            }
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            GymOwner_Report gr = new GymOwner_Report(current_email);
            gr.Show();
            this.Close();
        }

        private void kryptonDataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void kryptonTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void kryptonButton8_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();
            SqlCommand cmd;

            string query = "Update Trainer_verification set isVerified = 1 where gymName =  (SELECT gymName FROM GYM WHERE gymOwner = @ownerEmail);";
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add("@ownerEmail", SqlDbType.VarChar).Value = current_email;
            cmd.ExecuteNonQuery();
            query = "INSERT INTO GYMTRAINERS (gymName, trainerEmail) " +
                "SELECT GYM.gymName,trainer_VErification.trainerEmail FROM  GYM INNER JOIN  trainer_VErification " +
                "ON GYM.gymName = trainer_VErification.gymName WHERE GYM.gymOwner = @ownerEmail;";
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();

            MessageBox.Show("All Trainers Verified Successfully!");

            string query_trainer = "SELECT * FROM Trainer_Verification WHERE gymName = (SELECT gymName FROM GYM WHERE gymOwner = @ownerEmail) AND isVerified = 0;";


            cmd.CommandText = query_trainer;
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            kryptonDataGridView2.DataSource = dt;

            dt.Dispose();

            cmd.Dispose();
            conn.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void kryptonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            GymOwner_ViewMembersTrainers gmt = new GymOwner_ViewMembersTrainers(current_email);
            gmt.Show();
        }
    }
}
