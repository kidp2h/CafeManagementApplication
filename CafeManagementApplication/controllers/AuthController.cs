using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CafeManagementApplication.views;
using CafeManagementApplication.models;
namespace CafeManagementApplication.controllers
{
    class AuthController : fLogin
    {
        private fLogin _view;
        private User UserModel;

        public AuthController(fLogin view)
        {
            _view = view;
            UserModel = new User();   
        }

        public void handleLogin()
        {
            fCafeManagement f = new fCafeManagement();
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
