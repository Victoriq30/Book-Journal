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
    public partial class SignInForm : Form
    {
        public SignInForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var userController = new UserController();
            var newUser = new User() 
            {
                 Email=txtEmail.Text,
                 Password=txtPassword.Text,
                 Username=txtUsername.Text
            };
            userController.Add(newUser);
            LogInForm logIn = new LogInForm();
            logIn.ShowDialog();
            this.Close();


        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            LogInForm logIn = new LogInForm();
            logIn.ShowDialog();
            this.Close();
        }
    }
}
