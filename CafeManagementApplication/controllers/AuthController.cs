﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CafeManagementApplication.views;
using CafeManagementApplication.models;
using System.Windows.Forms;

namespace CafeManagementApplication.controllers
{
    class AuthController
    {
        private fLogin _view;
        private readonly User UserModel;
        public AuthController(fLogin view)
        {
            _view = view;
            UserModel = new User();
        }

        public void handleLogin()
        {
            fCafeManager f = new fCafeManager();
            string username = this._view.inputUsernameText;
            string password = this._view.inputPasswordText;
            bool result = this.UserModel.checkAccount(username, password);
            if (result)
            {
                MessageBox.Show("Dang nhap thanh cong");
                this._view.Hide();
                f.ShowDialog();
                this._view.Show();
            }
            else
            {
                MessageBox.Show("Dang nhap that bai");
            }
        }
    }
}
