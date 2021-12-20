using CafeManagementApplication.views;
using CafeManagementApplication.models;
using System.Windows.Forms;
using CafeManagementApplication.helpers;
using CafeManagementApplication.types;
using System.Collections.Generic;

namespace CafeManagementApplication.controllers
{
    class AuthController
    {
        private static AuthController instance;
        public static AuthController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AuthController();
                }
                return instance;
            }
        }

        public void handleLogin(fLogin view)
        {
            string username = view.inputUsernameText;
            string password = view.inputPasswordText;
            List<dynamic> result = UserModel.Instance.checkAccount(username, password);
            view.inputPasswordText = "";
            if (result[0] != null && result[1] == true)
            {
                //SaveUser.Instance.saveUserToFile(result[2].Username);
                Properties.Settings.Default.role = result[2].Role.ToString();
                Properties.Settings.Default.fullname = result[2].Fullname;
                MessageBox.Show("Đăng nhập thành công !", "Thông báo");
                view.Hide();
                fCafeManager f = new fCafeManager();
                f.ShowDialog();
                view.Show();
                if (!view.cbRmb)
                {
                    view.inputUsernameText = "";
                }
            }
            else
            {
                MessageBox.Show("Sai thông tin đăng nhập !\nVui lòng xem lại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
    }
}
