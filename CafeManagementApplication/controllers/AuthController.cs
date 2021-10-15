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

                if (result[0] != null)
                {
                    SaveUser.Instance.saveUserToFile(result[2].Username);
                    MessageBox.Show("Dang nhap thanh cong");
                    view.Hide();
                    fCafeManager f = new fCafeManager(result[0]);
                    f.ShowDialog();
                    view.Show();

                }
                else
                {
                    MessageBox.Show("Dang nhap that bai");
                }
           
            

        }
    }
}
