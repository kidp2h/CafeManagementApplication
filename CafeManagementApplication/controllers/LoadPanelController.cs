using CafeManagementApplication.views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeManagementApplication.controllers
{
    class LoadPanelController
    {
        public void LoadingInfoPanel()
        {
            fAddProducts f = new fAddProducts();
            Panel temp = f.getPnlInfo();
            foreach(dynamic control in temp.Controls)
            {
                if (control.Name == "lblName") control.Text = "hello";
            }
        }
    }
}
