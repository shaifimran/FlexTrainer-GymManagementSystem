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
    public partial class GymOwner_Report : Form
    {
        string current_email;
        public GymOwner_Report(string current_email = "")
        {
            InitializeComponent();
            this.current_email = current_email;

            for (int i = 1; i <= 10; i++)
            {
                Panel panel = Controls.Find("panel" + i, true).FirstOrDefault() as Panel;
                if (panel != null && i % 2 == 0)
                {
                    panel.Visible = false;
                }
            }
        }

        private void kryptonButton12_Click(object sender, EventArgs e)
        {
            this.Close();
            GymOwner_Dashboard gd = new GymOwner_Dashboard(current_email);
            gd.Show();
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
            ResultingReport rr = new ResultingReport(current_email, "", "", "11");
            rr.Show();
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            ResultingReport rr = new ResultingReport(current_email, "", "", "12");
            rr.Show();
        }

        private void kryptonButton6_Click(object sender, EventArgs e)
        {
            ResultingReport rr = new ResultingReport(current_email, "", "", "13");
            rr.Show();
        }

        private void kryptonButton8_Click(object sender, EventArgs e)
        {
            if (kryptonComboBox1.Text != "")
            {
                ResultingReport rr = new ResultingReport(current_email, kryptonComboBox1.Text, "", "14");
                rr.Show();
            }
            else
            {
                MessageBox.Show("Fill required fields first.");
            }
        }

        private void kryptonComboBox1_DropDown(object sender, EventArgs e)
        {
            kryptonComboBox1.Items.Clear();
            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();
            string query = "SELECT distinct objectives from Member;";
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

        private void kryptonComboBox2_DropDown(object sender, EventArgs e)
        {
            kryptonComboBox2.Items.Clear();
            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();
            string query = "SELECT trainerEmail from Trainer;";
            SqlCommand cmd;
            cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string ss = reader.GetString(0);
                kryptonComboBox2.Items.Add(ss);
            }


            cmd.Dispose();
            conn.Close();
        }

        private void kryptonButton10_Click(object sender, EventArgs e)
        {
            if (kryptonComboBox2.Text != "")
            {
                ResultingReport rr = new ResultingReport(current_email, kryptonComboBox2.Text, "", "15");
                rr.Show();
            }
            else
            {
                MessageBox.Show("Fill required fields first.");
            }
        }

        private void kryptonButton11_Click(object sender, EventArgs e)
        {
            this.Close();
            GymOwner_Report_2 gr = new GymOwner_Report_2(current_email);
            gr.Show();
        }

        private void GymOwner_Report_Load(object sender, EventArgs e)
        {

        }

        private void kryptonComboBox2_DropDown_1(object sender, EventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
