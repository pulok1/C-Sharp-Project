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

namespace Mess_Fellows
{
    public partial class ShowMealEstimate : Form
    {
        private const string ConnectionString = "Data Source=DESKTOP-Q37HPHU\\SQLEXPRESS;Initial Catalog=Mess;Integrated Security=True";
        private string UserName;

        public ShowMealEstimate()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox2.Text.Trim();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                DateTime thirtyDaysAgo = DateTime.Today.AddDays(-30);

                string query = "SELECT SUM(meals) AS total_meals FROM meals WHERE username = @Username AND date >= @StartDate";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@StartDate", thirtyDaysAgo);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                }
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            UserInterface userinterface = new UserInterface(UserName);
            userinterface.Show();
            this.Hide();
        }

        private void ShowMealEstimate_Load(object sender, EventArgs e)
        {

        }
    }
}
