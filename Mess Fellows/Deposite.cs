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
    public partial class Deposite : Form
    {
        private string UserName;

        public Deposite()
        {
            InitializeComponent();
        }

        private void Deposite_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                var bkash = new Bkash();
                bkash.Show();
                this.Hide();
            }
            else if(radioButton2.Checked)
            {
                var rocket = new Rocket();
                rocket.Show();
                this.Hide();
            }
            else if(radioButton3.Checked)
            {
                var nagad = new Nogod();
                nagad.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please Select A Payment Method!");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            UserInterface u = new UserInterface(UserName);
            u.Show();
            this.Hide();

        }
    }
}
