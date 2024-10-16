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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Database_Project_GymTrainer
{
    public partial class Member_BookAppointment : Form
    {
        string owner_email, member_email, gymName,trainer_email ;
        public Member_BookAppointment(string owner = "",string member = "", string gym = "", string trainer_email = "")
        {
            InitializeComponent();
            this.owner_email = owner;
            this.member_email = member; 
            this.gymName = gym;
            this.trainer_email = trainer_email;

            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();
            string query = "Select * from Appointment where memberEmail = @memberEmail";
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
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            this.Close();
            Member_Dashboard member = new Member_Dashboard(owner_email, member_email, gymName);
            member.Show();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void kryptonButton8_Click(object sender, EventArgs e)
        {
            string app_description = kryptonRichTextBox1.Text;
            DateTime date = appointmentdatepicker.Value;
            DateTime Now = DateTime.Now;

            if (DateTime.Compare(Now, date) > 0)
            {
                MessageBox.Show("Invalid date!");
            }
            else
            {
                if (app_description == "")
                {
                    MessageBox.Show("Appointment Description cannot be empty!");
                }
                else
                {
                    SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
                    conn.Open();
                    string query = "insert into Appointment(trainerEmail,memberEmail,appointmentDescription,date) values " +
                        "(@trainerEmail,@memberEmail,@appointmentDes,@date);";
                    SqlCommand cmd = new SqlCommand(query,conn);
                    cmd.CommandText = query;
                    cmd.Parameters.Add("@memberEmail", SqlDbType.VarChar).Value = member_email;
                    cmd.Parameters.Add("@trainerEmail", SqlDbType.VarChar).Value = trainer_email;
                    cmd.Parameters.Add("@appointmentDes", SqlDbType.VarChar).Value = app_description;
                    cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = date;
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Appointment Added!");

                    kryptonRichTextBox1.Text = "";

                    conn = new SqlConnection(ConnectionString.ServerName);
                    conn.Open();
                    query = "Select * from Appointment where memberEmail = @memberEmail";
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
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            int app_id = Int32.Parse(kryptonNumericUpDown1.Text);
            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();
            string query = "Select count(*) from Appointment where AppointmentID = @appid;";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandText = query;
            cmd.Parameters.Add("@appid", SqlDbType.Int).Value = app_id;
            int count = (int)cmd.ExecuteScalar();
            if(count>0)
            {
                query = "delete from Appointment where AppointmentID = @appid;";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                MessageBox.Show("Appointment with ID " + app_id.ToString() + " Successfully Deleted!");

                conn = new SqlConnection(ConnectionString.ServerName);
                conn.Open();
                query = "Select * from Appointment where memberEmail = @memberEmail";
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
            }
            else
            {
                MessageBox.Show("Invalid Appointment ID.");
            }

        }

        private void kryptonNumericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Member_BookAppointment_Load(object sender, EventArgs e)
        {

        }

        private void kryptonRichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
