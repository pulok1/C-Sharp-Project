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
    public partial class Interface : Form
    {
        bool sidebarExpand;

        //private const string ConnectionString = "Data Source=DESKTOP-Q37HPHU\SQLEXPRESS;Initial Catalog=Mess;Integrated Security=True";
        public Interface()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.Transparent;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            NewAdmin na = new NewAdmin();
            na.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            var usercreate = new UserCreate();
            usercreate.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            AddMembersMoney ad = new AddMembersMoney();
            ad.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            RentToPay rp = new RentToPay();
            rp.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            TotalMeal tm = new TotalMeal();
            tm.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            AddMembersMoney ad = new AddMembersMoney();
            ad.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            RentToPay rp = new RentToPay();
            rp.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            NewAdmin na = new NewAdmin();
            na.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            var usercreate = new UserCreate();
            usercreate.Show();
            this.Hide();
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            TotalMeal tm = new TotalMeal();
            tm.Show();
            this.Hide();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            var registration = new Registration();
            registration.Show();
            this.Hide();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            var changepassword = new ChangePassword();
            changepassword.Show();
            this.Hide();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(sidebarExpand)
            {
                sidebar.Width -= 10;
                if(sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    timer1.Stop();
                }
            }
            else
            {
                sidebar.Width += 10;
                if(sidebar.Width==sidebar.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    timer1.Stop();
                }
            }
        }

        private void FlowLayoutpanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void pictureBox8_Click_1(object sender, EventArgs e)
        {
            var changepassword = new ChangePassword();
            changepassword.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            var changepassword = new ChangePassword();
            changepassword.Show();
            this.Hide();
        }

        private void pictureBox10_Click_1(object sender, EventArgs e)
        {
            if(WindowState==FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else if(WindowState==FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Minimized;
            }
            else if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            var registration = new Registration();
            registration.Show();
            this.Hide();
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            TotalMeal totalmeal = new TotalMeal();
            totalmeal.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            TotalMeal totalmeal = new TotalMeal();
            totalmeal.Show();
            this.Hide();
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            var home = new Homepage();
            home.Show();
            this.Hide();
        }

        private void Interface_Load(object sender, EventArgs e)
        {
           
        }

        private void label15_Click(object sender, EventArgs e)
        {
            RemoveUser ru = new RemoveUser();
            ru.Show();
            this.Hide();
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            RemoveUser ru = new RemoveUser();
            ru.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Changeusername cun = new Changeusername();
            cun.Show();
            this.Hide();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Changeusername cun = new Changeusername();
            cun.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Help h = new Help();
            h.StartPosition = FormStartPosition.CenterScreen;
            h.Show();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Help h = new Help();
            h.StartPosition = FormStartPosition.CenterScreen;
            h.Show();
        }
    }
}
