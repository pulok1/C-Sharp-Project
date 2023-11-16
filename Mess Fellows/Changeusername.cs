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
    public partial class Changeusername : Form
    {
        public static class DatabaseHelper
        {
            private static string connectionString = "Data Source=DESKTOP-Q37HPHU\\SQLEXPRESS;Initial Catalog=Mess;Integrated Security=True";

            public static SqlConnection GetConnection()
            {
                return new SqlConnection(connectionString);
            }
        }
        public Changeusername()
        {
            InitializeComponent();
            textBox2.TextChanged += TextBoxes_TextChanged;
            textBox3.TextChanged += TextBoxes_TextChanged;

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.LightSkyBlue;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Transparent;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string currentUsername = textBox1.Text;
            string newUsername = textBox2.Text;

            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                connection.Open();

                // Check if the current username exists in the database
                string query = "SELECT COUNT(*) FROM admin WHERE username = @username";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", currentUsername);
                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        // Update the username
                        query = "UPDATE admin SET username = @newUsername WHERE username = @currentUsername";
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }
        private void TextBoxes_TextChanged(object sender, EventArgs e)
        {
            // Clear any existing errors
            errorProvider1.Clear();

            string text1 = textBox2.Text;
            string text2 = textBox3.Text;

            if (text1 == text2)
            {
                button1.Enabled = true;
            }
            else
            {
                // Display error message using ErrorProvider
                errorProvider1.SetError(textBox2, "Texts do not match.");
                button1.Enabled = false;
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            var Interface = new Interface();
            Interface.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Changeusername_Load(object sender, EventArgs e)
        {

        }
    }
}
