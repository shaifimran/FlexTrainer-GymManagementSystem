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
    public partial class Trainer_Appointments : Form
    {
        string current_email;
        public Trainer_Appointments(string current_email = "")
        {
            InitializeComponent();
            this.current_email = current_email;

            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();
            string query = "Select * from Appointment where trainerEmail = @trainerEmail";
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@trainerEmail", current_email);
                using (SqlDataAdapter sqlDA = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    sqlDA.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            int AppointmentID = Int32.Parse(kryptonNumericUpDown1.Text);
            if (AppointmentID == 0)
            {
                MessageBox.Show("Select Valid Appointment ID!");
            }
            else
            {
                SqlConnection conn1 = new SqlConnection(ConnectionString.ServerName);
                conn1.Open();
                string query1 = "SELECT count(*) from Appointment where AppointmentID = @appID";
                SqlCommand command = new SqlCommand(query1, conn1);               
                command.Parameters.AddWithValue("@appID", AppointmentID);
                int count = (int)command.ExecuteScalar();
                if(count == 1)
                {
                    query1 = "Delete from Appointment where AppointmentID = @appID";
                    command.CommandText = query1;
                    command.ExecuteNonQuery();
                    MessageBox.Show("Appointment ID: " + AppointmentID.ToString() + " Cancelled.");
                }
                else
                {
                    MessageBox.Show("Invalid Valid Appointment ID!");
                }
            }
            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();
            string query = "Select * from Appointment where trainerEmail = @trainerEmail";
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@trainerEmail", current_email);
                using (SqlDataAdapter sqlDA = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    sqlDA.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }

            kryptonNumericUpDown1.Value = 0;
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            int AppointmentID = Int32.Parse(kryptonNumericUpDown1.Text);
            if (AppointmentID == 0)
            {
                MessageBox.Show("Select Valid Appointment ID!");
            }
            else
            {
                SqlConnection conn1 = new SqlConnection(ConnectionString.ServerName);
                conn1.Open();
                string query1 = "SELECT count(*) from Appointment where AppointmentID = @appID";
                SqlCommand command = new SqlCommand(query1, conn1);
                command.Parameters.AddWithValue("@appID", AppointmentID);
                int count = (int)command.ExecuteScalar();
                if (count == 1)
                {
                    DateTime date = appointmentdatepicker.Value;
                    DateTime Now = DateTime.Now;
                    if (DateTime.Compare(Now, date) > 0)
                    {
                        MessageBox.Show("Invalid date!");
                    }
                    else
                    {
                        query1 = "UPDATE Appointment set date = @date where AppointmentID = @appID";
                        command.CommandText = query1;
                        command.Parameters.Add("@date", SqlDbType.DateTime).Value = date;
                        command.ExecuteNonQuery();
                        MessageBox.Show("Appointment ID: " + AppointmentID.ToString() + " Rescheduled.");
                        kryptonNumericUpDown1.Value = 0;
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Valid Appointment ID!");
                }
            }
            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();
            string query = "Select * from Appointment where trainerEmail = @trainerEmail";
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@trainerEmail", current_email);
                using (SqlDataAdapter sqlDA = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    sqlDA.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {

        }

        private void Trainer_Appointments_Load(object sender, EventArgs e)
        {

        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            this.Close();
            Trainer_Dashboard trainer = new Trainer_Dashboard(current_email);
            trainer.Show();
        }
    }
}
