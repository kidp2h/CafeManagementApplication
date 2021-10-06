﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CafeManagementApplication.models;
using CafeManagementApplication.controllers;

namespace CafeManagementApplication
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*User UserModel = new User();
            List<User> users = UserModel.getUserById("615b0a0f5683612505cc66c1");
            foreach(User user in users)
            {
                MessageBox.Show(user.Fullname);
            }*/
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            AuthController controller = new AuthController(this);
            controller.handleLogin();
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("hellooooooooooooooooooooo?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        public string inputUsernameText { 
            get { return this.inputUsername.Text; }
            set { this.inputUsername.Text = value; }
        }
        public string inputPasswordText { 
            get { return this.inputPassword.Text; }
            set { this.inputUsername.Text = value; }
        }
    }
}
