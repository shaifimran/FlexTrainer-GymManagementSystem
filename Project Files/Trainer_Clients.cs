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
    public partial class Trainer_Clients : Form
    {
        string trainerEmail;
        public Trainer_Clients(string trainerEmail = "")
        {
            InitializeComponent();
            this.trainerEmail = trainerEmail;

            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();
            string query = "Select memberEmail, memberName, dietPlanID, currentlyFollowingWorkoutPlanID, gymName, objectives " +
                           "From Member where trainerEmail = @trainerEmail AND isApproved = 1";
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@trainerEmail", trainerEmail);
                using (SqlDataAdapter sqlDA = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    sqlDA.Fill(dt);
                    kryptonDataGridView1.DataSource = dt;
                }
            }
        }

        private void Trainer_Clients_Load(object sender, EventArgs e)
        {

        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
