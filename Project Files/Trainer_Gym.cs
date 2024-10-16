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
    public partial class Trainer_Gym : Form
    {
        string trainer_email;
        public Trainer_Gym(string trainer_email)
        {
            InitializeComponent();
            this.trainer_email = trainer_email;

            // Joined Gyms
            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();
            string query = "Select Gym.gymName from Gym join GymTrainers on Gym.gymName = GymTrainers.gymName where trainerEmail = @trainerEmail;";
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@trainerEmail", trainer_email);
                using (SqlDataAdapter sqlDA = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    sqlDA.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            // Available Gyms
            query = "";
            query = "Select Gym.gymName from Gym EXCEPT Select GymTrainers.GymName FROM GymTrainers inner join trainer on gymtrainers.trainerEmail=trainer.trainerEmail where trainer.trainerEmail = @trainerEmail;";
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@trainerEmail", trainer_email);
                using (SqlDataAdapter sqlDA = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    sqlDA.Fill(dt);
                    dataGridView2.DataSource = dt;
                }
            }
        }

        private void Trainer_Gym_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            this.Close();
            Trainer_Dashboard trainer = new Trainer_Dashboard(trainer_email);
            trainer.Show();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            string gymname = kryptonTextBox1.Text;
            if (string.IsNullOrEmpty(gymname)) 
            {
                MessageBox.Show("Please Enter Valid Gym Name!");
            }
            else
            {
                SqlConnection conn =  new SqlConnection(ConnectionString.ServerName);
                conn.Open();
                SqlCommand cmd;
                String query = "";
                query = "select count(*) from Gym where gymName=@gymName";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@gymName", SqlDbType.VarChar).Value = gymname;
                int count = (int)cmd.ExecuteScalar();

                if ( count != 0 )
                {
                    query = "";
                    query = "insert into Trainer_Verification(gymName,trainerEmail) values (@gymName,@trainerEmail);";
                    cmd.CommandText = query;
                    cmd.Parameters.Add("@trainerEmail", SqlDbType.VarChar).Value = trainer_email;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Joining Request Sent to Gym Owner. Please Wait for Gym Owner's Approval.");
                    kryptonTextBox1.Text = "";
                }
                else
                {
                    MessageBox.Show("Please Enter Valid Gym Name!");
                }

                // Joined Gyms
                
                query = "Select Gym.gymName from Gym join GymTrainers on Gym.gymName = GymTrainers.gymName where trainerEmail = @trainerEmail;";
                
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@trainerEmail", trainer_email);
                    using (SqlDataAdapter sqlDA = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        sqlDA.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
                // Available Gyms
                query = "";
                query = "Select Gym.gymName from Gym EXCEPT Select GymTrainers.GymName FROM GymTrainers inner join trainer on gymtrainers.trainerEmail=trainer.trainerEmail where trainer.trainerEmail = @trainerEmail;";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@trainerEmail", trainer_email);
                    using (SqlDataAdapter sqlDA = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        sqlDA.Fill(dt);
                        dataGridView2.DataSource = dt;
                    }
                }
            }
        }
    }
}
