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
    public partial class UserCresteConfirm : Form
    {
        public UserCresteConfirm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            if (radioButton1.Checked)
            {
                var usercreate = new UserCreate();
                usercreate.Show();
                this.Hide();
            }
            else if(radioButton2.Checked)
            {
                var Interface = new Interface();
                Interface.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please select one,");
            }
        }

        private void UserCresteConfirm_Load(object sender, EventArgs e)
        {

        }
    }
}
