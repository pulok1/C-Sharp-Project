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
    public partial class ChangePassword : Form
    {

        public ChangePassword()
        {
            InitializeComponent();
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string oldPassword = textBox2.Text;
            string newPassword = textBox3.Text;

            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-Q37HPHU\\SQLEXPRESS;Initial Catalog=Mess;Integrated Security=True"))
            {
                connection.Open();

                // Check if username and old password match a record
                string query = "SELECT COUNT(*) FROM admin WHERE username = @username AND password = @oldPassword";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@oldPassword", oldPassword);
                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        // Update the password
                        query = "UPDATE admin SET password = @newPassword WHERE username = @username";
                        using (SqlCommand updateCommand = new SqlCommand(query, connection))
                        {
                            updateCommand.Parameters.AddWithValue("@newPassword", newPassword);
                            updateCommand.Parameters.AddWithValue("@username", username);
                            updateCommand.ExecuteNonQuery();

                            MessageBox.Show("Password changed successfully.");


                            var Interface = new Interface();
                            Interface.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or old password.");
                    }
                }
            }
        }
    }
}
