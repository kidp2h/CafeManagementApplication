﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CafeManagementApplication.views;
using CafeManagementApplication.models;
using System.Windows.Forms;
using MongoDB.Bson;
using System.Diagnostics;

namespace CafeManagementApplication.controllers
{
    class AuthController
    {
        private fLogin _view;
        public AuthController(fLogin view)
        {
            _view = view;
        }

        public void handleLogin()
        {
            dynamic tables = InitializeModels.TableModel.getListTable();
            foreach(dynamic table in tables)
            {
                Debug.WriteLine(table["tableName"].Value);
                //table["tableName"].Value;
            }

            /*fCafeManager f = new fCafeManager();
            string username = this._view.inputUsernameText;
            string password = this._view.inputPasswordText;
            bool result = InitializeModels.UserModel.checkAccount(username, password);
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
            }*/
        }
    }
}
