using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Database_Project_GymTrainer
{
    public partial class Admin_Dashboard : Form
    {
        string current_email;
        public Admin_Dashboard(string current_email = "")
        {
            InitializeComponent();
            this.current_email = current_email;
            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            SqlDataAdapter sqlDA = new SqlDataAdapter("Select * FROM Approval inner join gym on Approval.gymName = gym.gymName where gym.isApproved = 0 AND Approval.adminEmail is null ;",conn);
            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            kryptonDataGridView1.DataSource = dt;
            dt.Dispose();

            conn = new SqlConnection(ConnectionString.ServerName);
            sqlDA = new SqlDataAdapter("Select approvalID, gymOwnerEmail FROM Approval join GymOwner on GymOwner.ownerEmail = Approval.gymOwnerEmail where Gymowner.addedBy is NULL", conn);
            dt = new DataTable();
            sqlDA.Fill(dt);
            kryptonDataGridView2.DataSource = dt;
        }

        private void Admin_Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();
            SqlCommand cmd;
            string check_approvals = "SELECT count(*) FROM Approval;";
            cmd = new SqlCommand(check_approvals, conn);
            if ((int)cmd.ExecuteScalar() == 0)
            {
                MessageBox.Show("No waiting Approvals!");
                return;

            }
            string delete_approval_record = "DELETE FROM Approval;";
            cmd.CommandText = delete_approval_record;
            cmd.ExecuteNonQuery();

            string update_gym_record = "Update Gym SET isApproved = 1, adminEmail = @adminEmail where isApproved = 0;";
            cmd.Parameters.Add("@adminEmail", SqlDbType.VarChar).Value = current_email;
            cmd.CommandText = update_gym_record;
            cmd.ExecuteNonQuery();

            string update_gymowner_record = "Update GymOwner SET addedBy = @adminEmail where addedBy is NULL;";
            cmd.CommandText = update_gymowner_record;
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            MessageBox.Show("All Waiting Approvals Approved!");

            conn = new SqlConnection(ConnectionString.ServerName);
            SqlDataAdapter sqlDA = new SqlDataAdapter("Select * FROM Approval inner join gym on Approval.gymName = gym.gymName where gym.isApproved = 0 AND Approval.location is not null ;", conn);
            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            kryptonDataGridView1.DataSource = dt;
            dt.Dispose();

            conn = new SqlConnection(ConnectionString.ServerName);
            sqlDA = new SqlDataAdapter("Select approvalID, gymOwnerEmail FROM Approval join GymOwner on GymOwner.ownerEmail = Approval.gymOwnerEmail where Gymowner.addedBy is NULL", conn);
            dt = new DataTable();
            sqlDA.Fill(dt);
            kryptonDataGridView2.DataSource = dt;

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_Reports ad = new Admin_Reports(current_email);
            ad.Show();
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            int approval_id = Int32.Parse(kryptonNumericUpDown1.Text);
            if ( approval_id > 0)
            {
                SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
                conn.Open();
                SqlCommand cmd;
                string query = "Select count(*) FROM Approval where approvalID = @appID;";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@appID", SqlDbType.Int).Value = approval_id;
                int count = (int)cmd.ExecuteScalar();
                if ( count == 1 )
                {
                    query = "Select gymOwnerEmail FROM Approval where approvalID = @appID;";
                    cmd.CommandText = query;
                    string returned_string = cmd.ExecuteScalar().ToString();

                    query = "Select gymName FROM Approval where approvalID = @appID;";
                    cmd.CommandText = query;
                    string returned_string_2 = cmd.ExecuteScalar().ToString();

                    if ( returned_string_2 == "")
                    {
                        query = "UPDATE GymOwner SET addedBy = @adminEmail where ownerEmail = @gymOwnerEmail;";
                        cmd.Parameters.Add("@adminemail", SqlDbType.VarChar).Value = current_email;
                        cmd.Parameters.Add("@gymOwnerEmail", SqlDbType.VarChar).Value = returned_string;
                        cmd.CommandText = query;
                        cmd.ExecuteNonQuery();

                        query = "Delete from Approval where approvalID = @appID";
                        cmd.CommandText = query;
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Gym Owner Approved!");
                    }
                    else
                    {
                        query = "UPDATE Gym SET isApproved = 1 where gymName = @gymName;";
                        cmd.Parameters.Add("@gymName", SqlDbType.VarChar).Value = returned_string_2;
                        cmd.CommandText = query;
                        cmd.ExecuteNonQuery();

                        query = "Delete from Approval where approvalID = @appID";
                        cmd.CommandText = query;
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Gym Approved!");
                    }
                    conn = new SqlConnection(ConnectionString.ServerName);
                    SqlDataAdapter sqlDA = new SqlDataAdapter("Select * FROM Approval inner join gym on Approval.gymName = gym.gymName where gym.isApproved = 0 AND Approval.location is not null ;", conn);
                    DataTable dt = new DataTable();
                    sqlDA.Fill(dt);
                    kryptonDataGridView1.DataSource = dt;
                    dt.Dispose();

                    conn = new SqlConnection(ConnectionString.ServerName);
                    sqlDA = new SqlDataAdapter("Select approvalID, gymOwnerEmail FROM Approval join GymOwner on GymOwner.ownerEmail = Approval.gymOwnerEmail where Gymowner.addedBy is NULL", conn);
                    dt = new DataTable();
                    sqlDA.Fill(dt);
                    kryptonDataGridView2.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Invalid Approval ID!");
                }
            }
            else
            {
                MessageBox.Show("Approval ID must be entered!");               
            }
        }

        private void kryptonButton7_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void kryptonNumericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void kryptonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void kryptonDataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            Admin_ApprovedGyms ad = new Admin_ApprovedGyms(current_email);
            ad.Show();
        }
    }
}
