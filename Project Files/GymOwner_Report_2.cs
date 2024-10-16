using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_Project_GymTrainer
{
    public partial class GymOwner_Report_2 : Form
    {
        string owner_email;
        public GymOwner_Report_2(string owner_email = "")
        {
            InitializeComponent();
            this.owner_email = owner_email;

            for (int i = 1; i <= 10; i++)
            {
                Panel panel = Controls.Find("panel" + i, true).FirstOrDefault() as Panel;
                if (panel != null && i % 2 == 0)
                {
                    panel.Visible = false;
                }
            }
        }

        private void GymOwner_Report_2_Load(object sender, EventArgs e)
        {

        }

        private void kryptonButton12_Click(object sender, EventArgs e)
        {
            this.Close();
            GymOwner_Report gr = new GymOwner_Report(owner_email);
            gr.Show();
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
            ResultingReport rr = new ResultingReport(owner_email,"","","16");
            rr.Show();
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            ResultingReport rr = new ResultingReport(owner_email, "", "", "17");
            rr.Show();
        }

        private void kryptonButton6_Click(object sender, EventArgs e)
        {
            ResultingReport rr = new ResultingReport(owner_email, "", "", "18");
            rr.Show();
        }

        private void kryptonButton8_Click(object sender, EventArgs e)
        {
            ResultingReport rr = new ResultingReport(owner_email, "", "", "19");
            rr.Show();
        }

        private void kryptonButton10_Click(object sender, EventArgs e)
        {
            ResultingReport rr = new ResultingReport(owner_email, "", "", "20");
            rr.Show();
        }
    }
}
