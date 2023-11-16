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
    public partial class Rocket : Form
    {
        private const string connectionString = "Data Source=DESKTOP-Q37HPHU\\SQLEXPRESS;Initial Catalog=Mess;Integrated Security=True";
        private string UserName;

        public Rocket()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox2.Text;
            string amount = textBox3.Text;
            string transactionId = textBox1.Text;
            

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO rocket (username, amount, transactionId, date) VALUES (@username, @amount, @transactionId, @date)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@amount", amount);
                    command.Parameters.AddWithValue("@transactionId", transactionId);
                    command.Parameters.AddWithValue("@date", DateTime.Today);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Data inserted successfully.");
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox1.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Data insertion failed.");
                    }
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            UserInterface userinterface = new UserInterface(UserName);
            userinterface.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            UserInterface userinterface = new UserInterface(UserName);
            userinterface.Show();
            this.Hide();
        }

        private void Rocket_Load(object sender, EventArgs e)
        {

        }
    }
}
