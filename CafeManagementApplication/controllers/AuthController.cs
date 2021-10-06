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
        private fLogin _view;

        public AuthController(fLogin view)
        {
            _view = view;
        }

        public void handleLogin()
        {
            fCafeManagement f = new fCafeManagement();
            this._view.Hide();
            f.ShowDialog();
            this._view.Show();
        }
        
    }
}
