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
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox9.Clear();

            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            //address of SQL server and database
            string ConnectionString = "Data Source=DESKTOP-Q37HPHU\\SQLEXPRESS;Initial Catalog=Mess;Integrated Security=True";

            //establish connection
            SqlConnection con = new SqlConnection(ConnectionString);

            //open connection
            con.Open();

            //prepare query
            string name = textBox1.Text;
            string age = textBox2.Text;
            string email = textBox3.Text;
            string address = textBox4.Text;
            string nid = textBox5.Text;
            string phoneNumber = textBox6.Text;
            string occupation = textBox7.Text;
            string workingPlace = textBox8.Text;
            string guardian = textBox9.Text;
            string joiningDate = dateTimePicker1.Value.ToString("yyyy-MM-dd"); // Format date as yyyy-MM-dd

            string query = "INSERT INTO userregistration (name, age, email, address, nid, phoneNo, occupation, workingPlace, guardian, joiningDate) " +
                           "VALUES (@name, @age, @email, @address, @nid, @phoneNumber, @occupation, @workingPlace, @guardian, @joiningDate)";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@age", age);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@address", address);
                    command.Parameters.AddWithValue("@nid", nid);
                    command.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                    command.Parameters.AddWithValue("@occupation", occupation);
                    command.Parameters.AddWithValue("@workingPlace", workingPlace);
                    command.Parameters.AddWithValue("@guardian", guardian);
                    command.Parameters.AddWithValue("@joiningDate", joiningDate);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Data inserted successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Error inserting data.");
                    }

                    var usercreateconfirm = new UserCresteConfirm();
                    usercreateconfirm.Show();
                    this.Hide();
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Interface inter = new Interface();
            inter.Show();
            this.Hide();
        }

        private void Registration_Load(object sender, EventArgs e)
        {

        }
    }
}
