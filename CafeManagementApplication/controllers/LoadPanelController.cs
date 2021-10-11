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
        private static LoadPanelController instance;
        public static LoadPanelController Instance
        {
            get
            {
                if (instance == null) instance = new LoadPanelController();
                return instance;
            }
        }

        private dynamic view;
        public void setView(fAddProducts view)
        {
            this.view = view;
        }
        public void LoadingInfoPanel(string name, string price)
        {
            this.view.LblNameText= name;
            this.view.LblPriceText = price;
        }
    }
}
