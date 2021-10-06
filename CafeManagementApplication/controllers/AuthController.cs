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
