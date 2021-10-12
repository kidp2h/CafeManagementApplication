using CafeManagementApplication.views;
using CafeManagementApplication.models;
using System.Windows.Forms;

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
            
            fCafeManager f = new fCafeManager();
            string username = view.inputUsernameText;
            string password = view.inputPasswordText;
            bool result = UserModel.Instance.checkAccount(username, password);
            if (result)
            {
                MessageBox.Show("Dang nhap thanh cong");
                view.Hide();
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
