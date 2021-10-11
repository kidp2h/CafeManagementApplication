﻿using CafeManagementApplication.views;
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
        public void setView(dynamic view)
        {
            this.view = view;
        }
        public void LoadingInfoProduct(string name, string price, string tag)
        {
            this.view.LblNameText= name;
            this.view.LblNameTag = tag;
            this.view.LblPriceText = price;
        }
    }
}
