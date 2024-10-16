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
    public partial class Admin_Reports_2 : Form
    {
        string current_admin;
        public Admin_Reports_2(string current_admin = "")
        {
            InitializeComponent();

            for (int i = 1; i <= 10; i++)
            {
                Panel panel = Controls.Find("panel" + i, true).FirstOrDefault() as Panel;
                if (panel != null && i % 2 == 0)
                {
                    panel.Visible = false;
                }
            }

            this.current_admin = current_admin;
        }

        private void kryptonButton12_Click(object sender, EventArgs e)
        {
            Admin_Reports ad = new Admin_Reports(current_admin);
            ad.Show();
            Close();
        }

        private void Admin_Reports_2_Load(object sender, EventArgs e)
        {

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

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            ResultingReport rp = new ResultingReport("","","","6");
            rp.Show();
        }

        private void kryptonComboBox4_DropDown(object sender, EventArgs e)
        {
            kryptonComboBox4.Items.Clear();
            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();
            string query = "SELECT distinct machineName From Gym_Machines;";
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

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            if (kryptonComboBox4.Text != "" )
            {
                ResultingReport rp = new ResultingReport(kryptonComboBox4.Text,"", "", "7");
                rp.Show();
            }
            else
            {
                MessageBox.Show("Fill required fields first.");
            }
        }

        private void kryptonButton6_Click(object sender, EventArgs e)
        {
            ResultingReport rp = new ResultingReport("", "", "", "8");
            rp.Show();
        }

        private void kryptonComboBox1_DropDown(object sender, EventArgs e)
        {
            kryptonComboBox1.Items.Clear();
            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();
            string query = "SELECT ownerEmail From GymOwner;";
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

        private void kryptonButton8_Click(object sender, EventArgs e)
        {
            if (kryptonComboBox1.Text != "")
            {
                ResultingReport rp = new ResultingReport(kryptonComboBox1.Text, "", "", "9");
                rp.Show();
            }
            else
            {
                MessageBox.Show("Fill required fields first.");
            }
        }

        private void kryptonButton10_Click(object sender, EventArgs e)
        {
            ResultingReport rp = new ResultingReport("" , "", "", "10");
            rp.Show();
        }
    }
}
