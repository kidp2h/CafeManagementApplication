using CafeManagementApplication.controllers;
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
            List<ListViewItem> listItem = LoadingListViewController.Instance.LoadingListForListViewOf("useManager_Users");
            lvUsers.VirtualListSize = 1000;
            foreach(var item in listItem)
            {
                lvUsers.Items.Add(item);
            }
        }
    }
}
