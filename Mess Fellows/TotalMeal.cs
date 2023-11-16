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
    public partial class TotalMeal : Form
    {
        private string connectionString = "Data Source=DESKTOP-Q37HPHU\\SQLEXPRESS;Initial Catalog=Mess;Integrated Security=True";
        public TotalMeal()
        {
            InitializeComponent();
            LoadMealRecords();
        }

        private void TotalMealForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void LoadMealRecords()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Calculate the start of the current month
                DateTime currentDate = DateTime.Today;
                DateTime startOfMonth = new DateTime(currentDate.Year, currentDate.Month, 1);

                string query = "SELECT username, SUM(meals) AS TotalMeals FROM meals " +
                               "WHERE Date >= @StartDate AND Date <= @EndDate " +
                               "GROUP BY username";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StartDate", startOfMonth);
                    command.Parameters.AddWithValue("@EndDate", currentDate);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Interface inter = new Interface();
            inter.Show();
            this.Hide();
        }

        private void TotalMeal_Load(object sender, EventArgs e)
        {

        }
    }
}
