using project.Business;
using project.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            var userController = new UserService();
            if (userController.LogIn( txtUserName.Text,txtPassword.Text))
            {
                Global.UserId = userController.GetUserId(txtUserName.Text);

                Form1 form = new Form1();
                form.ShowDialog();
                this.Close();
            }
            else
            {
                lblInformation.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SignInForm signIn = new SignInForm();
            signIn.ShowDialog();
            this.Close();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void LogInForm_Load(object sender, EventArgs e)
        {

        }
    }
}
