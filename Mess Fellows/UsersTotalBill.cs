using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Mess_Fellows
{
    public partial class UsersTotalBill : Form
    {
        private string UserName;
        private string connectionString = "Data Source=DESKTOP-Q37HPHU\\SQLEXPRESS;Initial Catalog=Mess;Integrated Security=True";

        public UsersTotalBill()
        {
            InitializeComponent();

            string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December", };
            comboBox1.Items.AddRange(months);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            UserInterface userinterface = new UserInterface(UserName);
            userinterface.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void UsersTotalBill_Load(object sender, EventArgs e)
        {

        }

        private DataTable GetAmountData(string selectedMonth, string selectedUsername)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT amount FROM rentInput WHERE Month = @Month AND Username = @Username";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Month", selectedMonth);
                    command.Parameters.AddWithValue("@Username", selectedUsername);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }
                }
            }

            return dataTable;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string selectedMonth = comboBox1.SelectedItem.ToString();
            string selectedUsername = textBox2.Text;

            // Get the data from the database and display in DataGridView
            DataTable dataTable = GetAmountData(selectedMonth, selectedUsername);
            dataGridView1.DataSource = dataTable;
        }
    }
}
