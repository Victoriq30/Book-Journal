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
            var userService = new UserService();
            var newUser = new User();

            newUser.Email = txtEmail.Text;
            newUser.Password = txtPassword.Text;
            newUser.Username = txtUsername.Text;
            
            userService.Add(newUser);

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

        private void SignUpForm_Load(object sender, EventArgs e)
        {

        }
    }
}
