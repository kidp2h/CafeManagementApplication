using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CafeManagementApplication.views;
namespace CafeManagementApplication.controllers
{
    class AuthController
    {
        private fLogin view;

        public AuthController(fLogin view)
        {
            this.view = view;
        }

        public void handleLogin()
        {
            fCafeManager f = new fCafeManager();
            this.view.Hide();
            f.ShowDialog();
            this.view.Show();
        }
        
    }
}
