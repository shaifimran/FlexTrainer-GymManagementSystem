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
    
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin_Login adminLogin = new Admin_Login();
            adminLogin.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Member_Login memberLogin = new Member_Login();
            memberLogin.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GymOwner_Login gymOwnerLogin = new GymOwner_Login();
            gymOwnerLogin.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Trainer_Login trainerLogin = new Trainer_Login();
            trainerLogin.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }


    }
}
