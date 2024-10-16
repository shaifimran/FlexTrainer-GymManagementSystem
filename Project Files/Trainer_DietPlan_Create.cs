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
    public partial class Trainer_DietPlan_Create : Form
    {
        string trainerEmail;
        int current_dietPlanID;
        bool isdietPlanCreated = false;
        int current_day;
        public Trainer_DietPlan_Create(string trainerEmail)
        {
            InitializeComponent();
            this.trainerEmail = trainerEmail;
            int.TryParse(label2.Text.Substring(4), out current_day);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            Trainer_Dashboard trainer_Dashboard = new Trainer_Dashboard();
            trainer_Dashboard.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Trainer_DietPlan_Create_Load(object sender, EventArgs e)
        {

        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=Shaif-PC\\SQLEXPRESS;Initial Catalog=FlexTrainer;Integrated Security=True;");
            conn.Open();
            SqlCommand cmd;
            string get_dietPlanId = "SELECT MAX(dietPlanId) From dietPlan ;";
            string check_dietPlan_empty = "SELECT count(*) FROM dietPlan;";


            string mealName = kryptonComboBox2.Text;


            // Validate selection for meal name
            if (string.IsNullOrWhiteSpace(mealName))
            {
                MessageBox.Show("Please select a meal name.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Exit the method to prevent further execution
            }

            if (current_day == 1 && !isdietPlanCreated)
            {

                cmd = new SqlCommand(check_dietPlan_empty, conn);
                int rowCount = (int)cmd.ExecuteScalar();
                current_dietPlanID = 1;

                string create_dietplan_record = "INSERT INTO dietPlan (trainerEmail) VALUES(@trainerEmail);";
                cmd.CommandText = create_dietplan_record;
                cmd.Parameters.Add("@trainerEmail", SqlDbType.VarChar).Value = this.trainerEmail;
                cmd.ExecuteNonQuery();

                isdietPlanCreated = true;
                if (rowCount > 0)
                {
                    cmd.CommandText = get_dietPlanId;
                    current_dietPlanID = (int)cmd.ExecuteScalar() ;
                }

            }

            string add_meal_for_diet = "INSERT INTO diet_meal (day, dietPlanID, mealName) VALUES (@day,@dietPlanID,@mealName);";
            string check_mealName_exists = "SELECT count(*) FROM diet_meal where dietPlanId = @dietPlanID AND mealName=@mealName AND day=@day;";
            cmd = new SqlCommand(check_mealName_exists, conn);
            cmd.Parameters.Add("@day", SqlDbType.Int).Value = current_day;
            cmd.Parameters.Add("@dietPlanID", SqlDbType.Int).Value = current_dietPlanID;
            cmd.Parameters.Add("@mealName", SqlDbType.VarChar).Value = mealName;
            int count = (int)cmd.ExecuteScalar();

            // If count is greater than 0, the meal name already exists
            if (count > 0)
            {
                MessageBox.Show("Meal with the same name already exists for the specified diet plan and day.", "Duplicate meal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Exit the method or perform necessary action
            }

            cmd.CommandText = add_meal_for_diet;
            cmd.ExecuteNonQuery();

            string selectmealsQuery = "SELECT day,mealName FROM diet_meal WHERE dietPlanID = @dietPlanID and day=@day";

            cmd.CommandText = selectmealsQuery;


            // Create a DataTable to hold the retrieved meal data
            DataTable mealTable = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            // Fill the DataTable with the retrieved data
            adapter.Fill(mealTable);


            // Bind the DataTable to 
            kryptonDataGridView1.DataSource = mealTable;
            kryptonDataGridView1.ReadOnly = true;
            cmd.Dispose();
            conn.Close();
        }

        private void kryptonComboBox1_DropDown(object sender, EventArgs e)
        {
            kryptonComboBox1.Items.Clear();
            SqlConnection conn = new SqlConnection("Data Source=Shaif-PC\\SQLEXPRESS;Initial Catalog=FlexTrainer;Integrated Security=True;");
            conn.Open();
            SqlCommand cmd;
            string display_allergens = "SELECT distinct(allergen) From meal ;";
            cmd = new SqlCommand(display_allergens, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string allergen = reader.GetString(0);
                kryptonComboBox1.Items.Add(allergen);
            }


            cmd.Dispose();
            conn.Close();
        }

        private void kryptonComboBox2_DropDown(object sender, EventArgs e)
        {
            kryptonComboBox2.Items.Clear();
            SqlConnection conn = new SqlConnection("Data Source=Shaif-PC\\SQLEXPRESS;Initial Catalog=FlexTrainer;Integrated Security=True;");
            conn.Open();
            SqlCommand cmd;
            string display_meals_specific = "SELECT mealName FROM Meal WHERE allergen != @allergen OR allergen = 'None';";
            string display_meals = "SELECT mealName From meal ;";
            if (kryptonComboBox1.SelectedIndex == -1 || string.IsNullOrEmpty(kryptonComboBox1.Text))
            {
                cmd = new SqlCommand(display_meals, conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string mealName = reader.GetString(0);
                        kryptonComboBox2.Items.Add(mealName);
                    }
                }

            }

            else
            {
                cmd = new SqlCommand(display_meals_specific, conn);
                string allergen = kryptonComboBox1.Text;
                cmd.Parameters.Add("@allergen", SqlDbType.VarChar).Value = allergen;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string mealName = reader.GetString(0);
                        kryptonComboBox2.Items.Add(mealName);
                    }
                }
            }

            cmd.Dispose();
            conn.Close();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (kryptonDataGridView1.RowCount == 0)
            {
                // DataGridView is empty
                MessageBox.Show("No meals added. Please add meals.", "No meals", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // You can add code here to prompt the user to add meals
                return;
            }

            if (current_day == 1)
            {
                string typeOfDiet = kryptonTextBox1.Text;
                string purpose = kryptonTextBox2.Text;
                if (string.IsNullOrEmpty(purpose))
                {
                    MessageBox.Show("Please enter a purpose.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Exit the method to prevent further execution
                }
                if (string.IsNullOrEmpty(typeOfDiet))
                {
                    MessageBox.Show("Please enter a typeOfDiet.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Exit the method to prevent further execution
                }

                string add_typeOfDiet_and_purpose = "UPDATE dietPlan SET typeOfDiet = @typeOfDiet, purpose = @purpose where dietPlanID = @dietPlanID;";
                SqlConnection conn = new SqlConnection("Data Source=Shaif-PC\\SQLEXPRESS;Initial Catalog=FlexTrainer;Integrated Security=True;");
                conn.Open();
                SqlCommand cmd;
                cmd = new SqlCommand(add_typeOfDiet_and_purpose, conn);
                cmd.Parameters.Add("@typeOfDiet", SqlDbType.VarChar).Value = typeOfDiet;
                cmd.Parameters.Add("@purpose", SqlDbType.VarChar).Value = purpose;
                cmd.Parameters.Add("@dietPlanID", SqlDbType.Int).Value = current_dietPlanID;

                cmd.ExecuteNonQuery();
                current_day++;
                label2.Text = "Day " + current_day.ToString();
                this.Controls.Remove(label1);
                this.Controls.Remove(label3);
                this.Controls.Remove(kryptonTextBox1);
                this.Controls.Remove(kryptonTextBox2);
                this.Controls.Remove(kryptonButton2);
                kryptonDataGridView1.DataSource = null;
                kryptonDataGridView1.Rows.Clear();
                int moveAmount = 15;
                label2.Location = new Point(label2.Location.X, label2.Location.Y - moveAmount);
                label4.Location = new Point(label4.Location.X, label4.Location.Y - moveAmount);
                label5.Location = new Point(label5.Location.X, label5.Location.Y - moveAmount);
                kryptonComboBox1.Location = new Point(kryptonComboBox1.Location.X, kryptonComboBox1.Location.Y - moveAmount);
                kryptonComboBox2.Location = new Point(kryptonComboBox2.Location.X, kryptonComboBox2.Location.Y - moveAmount);
                kryptonButton3.Location = new Point(kryptonButton3.Location.X, kryptonButton3.Location.Y - moveAmount);
                cmd.Dispose();
                conn.Close();

            }

            else
            {
                current_day++;
                if (current_day <= 6)
                {
                    label2.Text = "Day " + current_day.ToString();
                    kryptonDataGridView1.DataSource = null;
                    kryptonDataGridView1.Rows.Clear();
                }
            }

            if (current_day == 6)
            {
                kryptonButton1.Text = "Create Diet Plan";
            }

            if (current_day == 7)
            {
                MessageBox.Show($"Diet plan created successfully with ID: {current_dietPlanID}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                Trainer_Dashboard trainer = new Trainer_Dashboard(trainerEmail);
                trainer.Show();
            }
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            this.Close();
            Trainer_Dashboard trainer = new Trainer_Dashboard(trainerEmail);
            trainer.Show();
        }
    }
}
