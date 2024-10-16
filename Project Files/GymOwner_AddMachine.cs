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
    public partial class GymOwner_AddMachine : Form
    {
        string owner_email;
        public GymOwner_AddMachine(string email = "")
        {
            owner_email = email;

            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            this.Close();
            GymOwner_Dashboard gymOwner_Dashboard = new GymOwner_Dashboard();
            gymOwner_Dashboard.Show();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            string machineName = kryptonTextBox1.Text;
            string exerciseName = kryptonComboBox1.Text;
            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();
            SqlCommand cmd;
            string query = "select count(*) from exercise where exerciseName=@exerciseName;";
            cmd = new SqlCommand(query, conn);

            cmd.Parameters.Add("@exerciseName", SqlDbType.VarChar).Value = exerciseName;
            if ((int)cmd.ExecuteScalar() == 0)
            {
                MessageBox.Show("Please select a valid exercise.");
                return;
            }
            //checking if the machine name already exists in the current gym. Cannot have 2 machines with the same name
            query = "select count(*) from gym_machines where machinename=@machinename";
            cmd.Parameters.Add("@machineName", SqlDbType.VarChar).Value = machineName;
            cmd.CommandText = query;
            if ((int)cmd.ExecuteScalar() > 0)
            {
                MessageBox.Show("Machine name already exists in the current gym. Please enter another name.");
                return;
            }
            //retrieve the gymName from owner email

            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = owner_email;
            query = "select gymname from Gym where gymOwner=@email;";
            cmd.CommandText = query;
            string gym_name = cmd.ExecuteScalar().ToString();


            //make insertion into machines table 
            query = "insert into Gym_Machines(gymName, exerciseName, machineName) VALUES(@gymName, @exerciseName, @machineName);";
            cmd.Parameters.Add("@gymName", SqlDbType.VarChar).Value = gym_name;
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Machine Added Successfully!");
        }

        private void GymOwner_AddMachine_Load(object sender, EventArgs e)
        {

        }

        private void kryptonComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();
            string query = "SELECT exerciseName FROM exercise;";
            SqlCommand cmd;
            cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string exerciseName = reader.GetString(0);
                kryptonComboBox1.Items.Add(exerciseName);
            }

        }
    }
}
