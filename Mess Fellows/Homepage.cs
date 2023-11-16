using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mess_Fellows
{
    public partial class Homepage : Form
    {
        public Homepage()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            var Form1 = new Form1();
            Form1.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            var userlogin = new UserLogin();
            userlogin.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            About a = new About();
            a.StartPosition = FormStartPosition.CenterScreen;
            a.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Help help = new Help();
            help.StartPosition = FormStartPosition.CenterScreen;
            help.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            UserLogin ul = new UserLogin();
            ul.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void Homepage_Load(object sender, EventArgs e)
        {

        }
    }
}
