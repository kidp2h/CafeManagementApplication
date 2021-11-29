using System;
using System.Windows.Forms;
using CafeManagementApplication.controllers;
using CafeManagementApplication.types;
using CafeManagementApplication.helpers;
using CafeManagementApplication.models;
using System.Text;
using CafeManagementApplication.views;
using System.Threading;

namespace CafeManagementApplication
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            BillModel.Instance.listBillByDateTime(14,10,2021);
            InitializeComponent();
        }
        public void actionForm(string action)
        {
            if (action == "show") this.Show();
            else this.Hide();
        }
      
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

            if (MessageBox.Show("BẠN CÓ MUỐN THOÁT ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question ) != DialogResult.OK)
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
            set { this.tbPassword.Text = value; }
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
