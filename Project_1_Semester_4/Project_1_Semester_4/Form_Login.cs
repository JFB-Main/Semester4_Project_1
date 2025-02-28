using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_1_Semester_4
{
    public partial class Form_Login : Form
    {
        public Form_Login()
        {
            InitializeComponent();
        }

        private void txUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void bt_Login_Click(object sender, EventArgs e)
        {
            Form_MainMenu form_MainMenuLink = new Form_MainMenu();
            form_MainMenuLink.Show();
            this.Hide();
        }
    }
}
