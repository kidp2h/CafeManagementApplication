﻿using CafeManagementApplication.controllers;
using CafeManagementApplication.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeManagementApplication.views
{
    public partial class uscManager_Users : UserControl
    {
        private static uscManager_Users instance;
        public static uscManager_Users Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new uscManager_Users();
                }
                return instance;
            }
        }
        private uscManager_Users()
        {
            InitializeComponent();
            LoadingListUsersForForm();

        }

        private void LoadingListUsersForForm()
        {
            LoadingController.Instance.LoadingListSomeThingForForm("useManager_Users");
        }

        public ListView getListView()
        {
            return lvUsers;
        }
    }
}
