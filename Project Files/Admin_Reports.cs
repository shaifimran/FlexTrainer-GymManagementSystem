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
    public partial class Admin_Reports : Form
    {
        string current_admin;
        public Admin_Reports(string admin = "")
        {
            this.current_admin = admin;
            InitializeComponent();
            for (int i = 1; i <= 10; i++)
            {
                Panel panel = Controls.Find("panel" + i, true).FirstOrDefault() as Panel;
                if (panel != null && i % 2 == 0)
                {
                    panel.Visible = false;
                }
            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (kryptonComboBox1.Text != "" && kryptonComboBox2.Text != "")
            {
                ResultingReport rp = new ResultingReport(kryptonComboBox1.Text, kryptonComboBox2.Text, "", "1");
                rp.Show();
            }
            else
            {
                MessageBox.Show("Fill required fields first.");
            }
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 10; i++)
            {
                Panel panel = Controls.Find("panel" + i, true).FirstOrDefault() as Panel;
                if (panel != null && i % 2 == 0)
                {
                    panel.Visible = (panel == panel1);
                    panel.Visible = (panel == panel2);
                }
            }
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 10; i++)
            {
                Panel panel = Controls.Find("panel" + i, true).FirstOrDefault() as Panel;
                if (panel != null && i % 2 == 0)
                {
                    panel.Visible = (panel == panel3);
                    panel.Visible = (panel == panel4);
                }
            }
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void Admin_Reports_Load(object sender, EventArgs e)
        {

        }

        private void kryptonButton5_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 10; i++)
            {
                Panel panel = Controls.Find("panel" + i, true).FirstOrDefault() as Panel;
                if (panel != null && i % 2 == 0)
                {
                    panel.Visible = (panel == panel5);
                    panel.Visible = (panel == panel6);
                }
            }
        }

        private void kryptonButton7_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 10; i++)
            {
                Panel panel = Controls.Find("panel" + i, true).FirstOrDefault() as Panel;
                if (panel != null && i % 2 == 0)
                {
                    panel.Visible = (panel == panel7);
                    panel.Visible = (panel == panel8);
                }
            }
        }

        private void kryptonButton9_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 10; i++)
            {
                Panel panel = Controls.Find("panel" + i, true).FirstOrDefault() as Panel;
                if (panel != null && i % 2 == 0)
                {
                    panel.Visible = (panel == panel9);
                    panel.Visible = (panel == panel10);
                }
            }
        }

        private void kryptonButton11_Click(object sender, EventArgs e)
        {
            Admin_Reports_2 ad2 = new Admin_Reports_2(current_admin);
            ad2.Show();
            this.Hide();
        }

        private void kryptonButton12_Click(object sender, EventArgs e)
        {
            Admin_Dashboard ad = new Admin_Dashboard(current_admin);
            this.Hide();
            ad.Show();
        }

        private void kryptonComboBox2_DropDown(object sender, EventArgs e)
        {
            string gym = kryptonComboBox1.Text;
            if (gym == "")
            {
                MessageBox.Show("Select gym first!");
                return;
            }
            kryptonComboBox2.Items.Clear();
            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();
            string query = "SELECT trainerEmail From GymTrainers where gymName = @gym ;";
            SqlCommand cmd;
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add("@gym", SqlDbType.VarChar).Value = gym;
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string ss = reader.GetString(0);
                kryptonComboBox2.Items.Add(ss);
            }


            cmd.Dispose();
            conn.Close();
        }

        private void kryptonComboBox1_DropDown(object sender, EventArgs e)
        {
            kryptonComboBox1.Items.Clear();
            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();
            string query = "SELECT gymName From Gym ;";
            SqlCommand cmd;
            cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string ss = reader.GetString(0);
                kryptonComboBox1.Items.Add(ss);
            }


            cmd.Dispose();
            conn.Close();
        }

        private void kryptonComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void kryptonComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void kryptonComboBox4_DropDown(object sender, EventArgs e)
        {
            kryptonComboBox4.Items.Clear();
            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();
            string query = "SELECT gymName From Gym ;";
            SqlCommand cmd;
            cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string ss = reader.GetString(0);
                kryptonComboBox4.Items.Add(ss);
            }


            cmd.Dispose();
            conn.Close();
        }

        private void kryptonComboBox3_DropDown(object sender, EventArgs e)
        {
            kryptonComboBox3.Items.Clear();
            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();
            string query = "SELECT dietplanID from DietPlan;";
            SqlCommand cmd;
            cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int ss = reader.GetInt32(0);
                kryptonComboBox3.Items.Add(ss);
            }


            cmd.Dispose();
            conn.Close();
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            if (kryptonComboBox3.Text != "" && kryptonComboBox4.Text != "")
            {
                ResultingReport rp = new ResultingReport(kryptonComboBox4.Text, kryptonComboBox3.Text, "", "2");
                rp.Show();
            }
            else
            {
                MessageBox.Show("Fill required fields first.");
            }
        }

        private void kryptonComboBox6_DropDown(object sender, EventArgs e)
        {
            kryptonComboBox6.Items.Clear();
            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();
            string query = "SELECT trainerEmail From Trainer;";
            SqlCommand cmd;
            cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string ss = reader.GetString(0);
                kryptonComboBox6.Items.Add(ss);
            }

            cmd.Dispose();
            conn.Close();
        }

        private void kryptonComboBox5_DropDown(object sender, EventArgs e)
        {
            kryptonComboBox5.Items.Clear();
            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();
            string query = "SELECT dietplanID from DietPlan;";
            SqlCommand cmd;
            cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int ss = reader.GetInt32(0);
                kryptonComboBox5.Items.Add(ss);
            }


            cmd.Dispose();
            conn.Close();
        }

        private void kryptonButton6_Click(object sender, EventArgs e)
        {
            if (kryptonComboBox5.Text != "" && kryptonComboBox6.Text != "")
            {
                ResultingReport rp = new ResultingReport(kryptonComboBox6.Text, kryptonComboBox5.Text, "", "3");
                rp.Show();
            }
            else
            {
                MessageBox.Show("Fill required fields first.");
            }
        }

        private void kryptonComboBox8_DropDown(object sender, EventArgs e)
        {
            kryptonComboBox8.Items.Clear();
            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();
            string query = "SELECT gymName From Gym ;";
            SqlCommand cmd;
            cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string ss = reader.GetString(0);
                kryptonComboBox8.Items.Add(ss);
            }


            cmd.Dispose();
            conn.Close();
        }

        private void kryptonComboBox7_DropDown(object sender, EventArgs e)
        {
            string gym = kryptonComboBox8.Text;
            if (gym == "")
            {
                MessageBox.Show("Select Gym First.");
                return;
            }

            kryptonComboBox7.Items.Clear();
            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();
            string query = "SELECT machineName From Gym_Machines where gymName = @gym ;";
            SqlCommand cmd;
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add("@gym", SqlDbType.VarChar).Value = gym;
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string ss = reader.GetString(0);
                kryptonComboBox7.Items.Add(ss);
            }


            cmd.Dispose();
            conn.Close();
        }

        private void kryptonComboBox9_DropDown(object sender, EventArgs e)
        {
            kryptonComboBox9.Items.Clear();
            for (int i = 1; i <= 6; i++)
            {
                kryptonComboBox9.Items.Add(i);
            }
        }

        private void kryptonButton8_Click(object sender, EventArgs e)
        {
            if (kryptonComboBox8.Text != "" && kryptonComboBox7.Text != "" && kryptonComboBox9.Text != "")
            {
                ResultingReport rp = new ResultingReport(kryptonComboBox8.Text, kryptonComboBox7.Text, kryptonComboBox9.Text, "4");
                rp.Show();
            }
            else
            {
                MessageBox.Show("Fill required fields first.");
            }
        }

        private void kryptonButton10_Click(object sender, EventArgs e)
        {
            ResultingReport rp = new ResultingReport("", "", "", "5");
            rp.Show();
        }
    }
}
