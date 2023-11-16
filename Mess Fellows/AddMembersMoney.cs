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
    public partial class AddMembersMoney : Form
    {
        private SqlConnection connection;
        private string connectionString = "Data Source=DESKTOP-Q37HPHU\\SQLEXPRESS;Initial Catalog=Mess;Integrated Security=True";
        public AddMembersMoney()
        {
            InitializeComponent();
            connection = new SqlConnection(connectionString);
        }

        private void InsertRentDataIntoDatabase(string month, string year, string amount, string username)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string insertQuery = "INSERT INTO rentInput (month, year, amount, username) VALUES (@month, @year, @amount, @username)";

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@month", month);
                    command.Parameters.AddWithValue("@year", year);
                    command.Parameters.AddWithValue("@amount", amount);
                    command.Parameters.AddWithValue("@username", username);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void fillcombo()
        {
            comboBox1.Items.Clear();
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT username FROM userlogin";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["username"].ToString());
            }
            connection.Close();
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ClearInputFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.SelectedIndex = -1; // Clear the selected item
            comboBox2.SelectedIndex = -1; // Clear the selected item
        }

        private void AddMembersMoney_Load(object sender, EventArgs e)
        {
            fillcombo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectedMonth = comboBox2.SelectedItem.ToString();
            string year = textBox1.Text;
            string amount = textBox2.Text;
            string selectedUsername = comboBox1.SelectedItem.ToString();

            // Insert data into the database
            InsertRentDataIntoDatabase(selectedMonth, year, amount, selectedUsername);

            // Provide feedback to the user
            MessageBox.Show("Rent data has been submitted successfully!");

            // Clear input fields for the next entry
            ClearInputFields();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Interface inter= new Interface();
            inter.Show();
            this.Hide();
        }
    }
}
