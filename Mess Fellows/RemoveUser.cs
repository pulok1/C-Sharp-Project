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
    public partial class RemoveUser : Form
    {
        private string connectionString = "Data Source=DESKTOP-Q37HPHU\\SQLEXPRESS;Initial Catalog=Mess;Integrated Security=True";
        public RemoveUser()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Interface i = new Interface();
            i.Show();
            this.Hide();
        }

        private void RemoveUser_Load(object sender, EventArgs e)
        {

        }

        private void DeleteUserByNID(string nidNumber)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM userregistration WHERE nid = @nid";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nid", nidNumber);

                    command.ExecuteNonQuery();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nidNumber = textBox1.Text;

            // Search for the NID number and delete the corresponding row
            DeleteUserByNID(nidNumber);

            MessageBox.Show("User with NID number " + nidNumber + " has been deleted.");

            textBox1.Clear();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
