﻿using project.Business;
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
            var userController = new UserController();
            if (userController.LogIn( txtUserName.Text,txtPassword.Text))
            {
                Form1 form = new Form1();
                form.ShowDialog();
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
        }
    }
}