using System;
using System.Windows.Forms;
using CafeManagementApplication.controllers;
using CafeManagementApplication.types;
using CafeManagementApplication.helpers;
using CafeManagementApplication.views;
using System.Threading;
using System.Text;

namespace CafeManagementApplication
{
    public partial class fLogin : Form
    {
        private static fLogin instance;
        
        public static fLogin Instance{   
            get
            {
                if (instance == null)
                {
                    instance = new fLogin();
                }
                return instance;
            }
        }
        public fLogin()
        {
            
            InitializeComponent();
            //check();
        }
        public void actionForm(string action)
        {
            if (action == "show") this.Show();
            else this.Hide();
        }
        /*public void check()
        {
            dynamic result = SaveUser.Instance.checkSession();
            if (result != null)
            {
                this.Hide();
                if (result.Role == Role.MANAGER)
                {
                    Properties.Settings.Default.role = "MANAGER";
                    fCafeManager f = new fCafeManager();
                    f.ShowDialog();
                    this.Hide();
                }
                else
                {
                    Properties.Settings.Default.role = "STAFF";
                    fCafeManager f = new fCafeManager();
                    f.ShowDialog();
                    this.Hide();
                }
            }
            else
            {

                this.Show();
            }
        }*/
        private void fLogin_Load(object sender, System.EventArgs e)
        {
            inputUsernameText = Properties.Settings.Default.username;

        }
        private Role _role;
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            #region Validate
            StringBuilder sb = new StringBuilder();
            ValidateForm.Instance.checkEmpty(tbUsername, sb, "Vui lòng nhập tài khoản !");
            ValidateForm.Instance.checkEmpty(tbPassword, sb, "Vui lòng nhập mật khẩu!");
            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            AuthController.Instance.handleLogin(this);
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        public string inputUsernameText { 
            get { return this.tbUsername.Text; }
            set { this.tbUsername.Text = value; }
        }
        public string inputPasswordText { 
            get { return this.tbPassword.Text; }
            set { this.tbUsername.Text = value; }
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
