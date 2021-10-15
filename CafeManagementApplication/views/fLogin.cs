using System;
using System.Windows.Forms;
using CafeManagementApplication.controllers;
using CafeManagementApplication.types;
using CafeManagementApplication.helpers;
using CafeManagementApplication.views;
using System.Threading;

namespace CafeManagementApplication
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
           
            InitializeComponent();
            //this.WindowState = FormWindowState.Minimized;
            //this.ShowInTaskbar = false;
            check();
            
        }
        public void check()
        {
            dynamic result = SaveUser.Instance.checkSession();
            if (result != null)
            {
                this.Hide();
                if (result.Role == Role.MANAGER)
                {
                    fCafeManager f = new fCafeManager(Role.MANAGER);
                    f.ShowDialog();
                    this.Hide();
                }
                else
                {
                    fCafeManager f = new fCafeManager(Role.STAFF);
                    f.ShowDialog();
                    this.Hide();
                }
            }
            else
            {

                this.Show();
            }
        }
        private Role _role;
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            AuthController.Instance.handleLogin(this);
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
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

        private void cbRemember_CheckedChanged(object sender, EventArgs e)
        {
            if (cbRemember.Checked)
            {
                Properties.Settings.Default.username = inputUsernameText;
                Properties.Settings.Default.password = inputPasswordText;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.Reset();
            }
        }
    }
}
