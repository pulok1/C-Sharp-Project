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
    public partial class RentToPay : Form
    {
        private string connectionString = "Data Source=DESKTOP-Q37HPHU\\SQLEXPRESS;Initial Catalog=Mess;Integrated Security=True";
        public RentToPay()
        {
            InitializeComponent();
        }

        private void SaveRentPayment(string selectedMonth, int year, int amount)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO rentToPay (month, year, amount) VALUES (@month, @year, @amount)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@month", selectedMonth);
                    command.Parameters.AddWithValue("@year", year);
                    command.Parameters.AddWithValue("@amount", amount);

                    command.ExecuteNonQuery();
                }
            }
        }

        private void ClearInputFields()
        {
            comboBox1.SelectedIndex = -1;
            textBox1.Clear();
            textBox2.Clear();
        }

        private void RentToPay_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectedMonth = comboBox1.SelectedItem.ToString();
            int year = int.Parse(textBox1.Text);
            int amount = int.Parse(textBox2.Text);

            // Save the information in the rentToPay table
            SaveRentPayment(selectedMonth, year, amount);

            MessageBox.Show("Rent payment information has been saved.");

            ClearInputFields();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Interface inter = new Interface();
            inter.StartPosition = FormStartPosition.CenterScreen;
            inter.Show();
            this.Hide();
        }
    }
}
