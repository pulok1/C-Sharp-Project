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
    public partial class UNameChange : Form
    {
        private string UserName;

        public static class DatabaseHelper
        {
            private static string connectionString = "Data Source=DESKTOP-Q37HPHU\\SQLEXPRESS;Initial Catalog=Mess;Integrated Security=True";

            public static SqlConnection GetConnection()
            {
                return new SqlConnection(connectionString);
            }
        }
        public UNameChange()
        {
            InitializeComponent();
            //textBox2.TextChanged += TextBoxes_TextChanged;
            //textBox3.TextChanged += TextBoxes_TextChanged;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string currentUsername = textBox1.Text;
            string newUsername = textBox2.Text;

            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                connection.Open();

                // Check if the current username exists in the database
                string query = "SELECT COUNT(*) FROM userlogin WHERE username = @username";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", currentUsername);
                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        // Update the username
                        query = "UPDATE userlogin SET username = @newUsername WHERE username = @currentUsername";
                        using (SqlCommand updateCommand = new SqlCommand(query, connection))
                        {
                            updateCommand.Parameters.AddWithValue("@newUsername", newUsername);
                            updateCommand.Parameters.AddWithValue("@currentUsername", currentUsername);
                            updateCommand.ExecuteNonQuery();

                            MessageBox.Show("Username updated successfully.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Current username not found in the database.");
                    }
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            UserInterface ui = new UserInterface(UserName);
            ui.Show();
            this.Hide();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void UNameChange_Load(object sender, EventArgs e)
        {

        }
    }
}
