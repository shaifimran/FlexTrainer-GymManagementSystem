using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using System.Collections;

namespace Database_Project_GymTrainer
{
    public partial class GymOwner_Approval : Form
    {
        string current_email;
        public GymOwner_Approval(string email)
        {
            InitializeComponent();
            this.current_email = email;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void GymOwner_Approval_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            this.Close();
            GymOwner_Dashboard gymOwner_Dashboard = new GymOwner_Dashboard(current_email);
            gymOwner_Dashboard.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            string loc = kryptonTextBox1.Text;
            string gym_name = kryptonTextBox2.Text ;
            string business_plan = kryptonTextBox6.Text;
            string membership_fees = kryptonNumericUpDown2.Text;
            string active_members = kryptonNumericUpDown1.Text;
            string fac_spec = kryptonTextBox5.Text;
            if (string.IsNullOrEmpty(loc) || string.IsNullOrEmpty(gym_name) || string.IsNullOrEmpty(business_plan) || string.IsNullOrEmpty(fac_spec) || string.IsNullOrEmpty(active_members))
            {
                MessageBox.Show("Please enter all compulsory fields!");
            }
            else
            {
                conn.Open();
                SqlCommand cmd;
                string query_approval = "INSERT INTO Approval(gymOwnerEmail,adminEmail,gymName, location, facilitySpecification, activeMembers, businessPlan) VALUES (@gymOwnerEmail, NULL, @gymName, @loc, @fac_spec, @active_members, @business_plan);";
                string query_gym = "INSERT INTO Gym(gymName,gymOwner,adminEmail,isApproved,location,membership_fees,customerSatisfaction,classAttendanceRate,membershipGrowth,financialPerformance) VALUES (@gymName,@gymOwnerEmail,NULL,@isApproved, @loc, @membership_fees,NULL,NULL,NULL,NULL);";
                string gym_check = "SELECT COUNT(*) FROM GYM where gymName = @gymName;";
                cmd = new SqlCommand(gym_check, conn);
                cmd.Parameters.Add("@gymName", SqlDbType.VarChar).Value = gym_name;
                
                int count = (int)cmd.ExecuteScalar();
                if (count > 0)
                {
                    MessageBox.Show("Gym name already exists. Please enter a unique name.");
                    return;
                }
                cmd.Parameters.Add("@gymOwnerEmail", SqlDbType.VarChar).Value = current_email;
                cmd.Parameters.Add("@business_plan", SqlDbType.VarChar).Value = business_plan;
                cmd.Parameters.Add("@loc", SqlDbType.VarChar).Value = loc;
                cmd.Parameters.Add("@fac_spec", SqlDbType.Text).Value = fac_spec;
                cmd.Parameters.Add("@active_members", SqlDbType.Int).Value = Int32.Parse(active_members);
                cmd.Parameters.Add("@isApproved", SqlDbType.Bit).Value = 0;
                cmd.Parameters.Add("@membership_fees",SqlDbType.Int).Value = Int32.Parse(membership_fees);

                cmd.CommandText = query_gym;
                cmd.ExecuteNonQuery();
                cmd.CommandText = query_approval;
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                conn.Close();

                MessageBox.Show("Approval Request Sent Successfully!");

                this.Close();
                GymOwner_Dashboard gymOwner_Dashboard = new GymOwner_Dashboard(current_email);
                gymOwner_Dashboard.Show();
                

            }
        }

        private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
