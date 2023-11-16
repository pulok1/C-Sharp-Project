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
    public partial class UserLogin : Form
    {
        private string connectionString = "Data Source=DESKTOP-Q37HPHU\\SQLEXPRESS;Initial Catalog=Mess;Integrated Security=True";
        public UserLogin()
        {
            InitializeComponent();
        }

        public string UserName { get; set; }


        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            UserName = textBox1.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM userlogin WHERE username = @username AND password = @password";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", (password));

                    int matchingUsersCount = (int)command.ExecuteScalar();

                    if (matchingUsersCount > 0)
                    {
                        MessageBox.Show("Login successful!");

                        UserInterface userinterface = new UserInterface(UserName);
                        userinterface.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.");
                    }
                }
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Homepage hm = new Homepage();
            hm.StartPosition = FormStartPosition.CenterScreen;
            hm.Show();
            this.Hide();
        }

        private void UserLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
