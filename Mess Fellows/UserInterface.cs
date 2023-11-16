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
    public partial class UserInterface : Form
    {
        bool sidebarexpand;

        private string UserName;
        public UserInterface(string UserName)
        {
            InitializeComponent();
            this.UserName = UserName;
        }

        private void OpenMeal()
        {
            Meal meal = new Meal(UserName);
            meal.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            var deposite = new Deposite();
            deposite.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            var deposite = new Deposite();
            deposite.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            OpenMeal();
            this.Hide();

        }
        private void label2_Click(object sender, EventArgs e)
        {
            OpenMeal();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            ShowMealEstimate showmeal = new ShowMealEstimate();
            showmeal.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            ShowMealEstimate showmeal = new ShowMealEstimate();
            showmeal.Show();
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Homepage home = new Homepage();
            home.Show();
            this.Hide();
        }

        private void sidebarTimer_tick(object sender, EventArgs e)
        {
            if (sidebarexpand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarexpand = false;
                    sidebarTimer.Stop();
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width == sidebar.MaximumSize.Width)
                {
                    sidebarexpand = true;
                    sidebarTimer.Stop();
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            var passwordc = new UPassChange();
            passwordc.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            var passwordc = new UPassChange();
            passwordc.Show();
            this.Hide();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            var usernc = new UNameChange();
            usernc.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            var usernc = new UNameChange();
            usernc.Show();
            this.Hide();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            var help = new Help();
            help.StartPosition = FormStartPosition.CenterScreen;
            help.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            var help = new Help();
            help.StartPosition = FormStartPosition.CenterScreen;
            help.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            UsersTotalBill bill = new UsersTotalBill();
            bill.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            UsersTotalBill bill = new UsersTotalBill();
            bill.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
