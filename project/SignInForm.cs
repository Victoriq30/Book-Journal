using project.Business;
using project.Data.Models;
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
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var userController = new UserService();
            var newUser = new User() 
            {
                 Email=txtEmail.Text,
                 Password=txtPassword.Text,
                 Username=txtUsername.Text
            };
            userController.Add(newUser);

            this.Hide();
            LogInForm logIn = new LogInForm();
            logIn.ShowDialog();
            this.Close();


        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogInForm logIn = new LogInForm();
            logIn.ShowDialog();
            this.Close();
        }
    }
}
