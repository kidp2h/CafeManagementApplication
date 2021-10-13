﻿using CafeManagementApplication.controllers;
using CafeManagementApplication.models;
using CafeManagementApplication.types;
using System;
using System.Threading;
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
        public uscManager_Users()
        {
            InitializeComponent();
            LoadListUsersForForm();
        }

        public void LoadListUsersForForm()
        {
            Thread loadList = new Thread(() => {              
                LoadListController.Instance.LoadingListForListViewOf("useManager_Users", lvUsers);
            });
           
            loadList.Start();
        }


        #region Public Data In View
        public string inputNameText
        {
            get { return tbName.Text; }
            set { tbName.Text = value;  }
        }
        public string inputAgeText
        {
            get { return tbAge.Text; }
            set { tbAge.Text = value; }
        }
        public string inputUsernameText
        {
            get { return tbUserName.Text; }
            set { tbUserName.Text = value; }
        }
        public string inputUserpasswordText
        {
            get { return tbUserPassword.Text; }
            set { tbUserPassword.Text = value; }
        }
        public string inputGenderText
        {
            get
            {
                if (rdoMale.Checked) return "Nam";
                else if (rdoFemale.Checked) return "Nữ";
                else return "Khác";
            }
            set
            {
                if (value == "Nam") rdoMale.Checked = true;
                else if (value == "Nữ") rdoFemale.Checked = true;
                else rdoOther.Checked = true;
            }
        }
        public Role inputRole
        {
            get
            {
                if (rdoManager.Checked) return Role.MANAGER;
                else return Role.STAFF;
            }
            set
            {
                if (value == Role.MANAGER) rdoManager.Checked = true;
                else rdoSaff.Checked = true;
            }
        }
        public string UserId
        {
            get { return tbName.Tag.ToString();}
            set { tbName.Tag = value; }
        }
        #endregion

        #region Handler Event

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ManagerController.Instance.AddData("User", this);
            LoadListUsersForForm();

        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ManagerController.Instance.UpdateData("User", this);
            LoadListUsersForForm();

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            lvUsers.Items.RemoveAt(int.Parse(btnDelete.Tag.ToString()));
            ManagerController.Instance.DeleteData("User", this);
            
        } 
        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadListUsersForForm();
        }
        private void lvUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView lv = sender as ListView;
            
            if(lv.SelectedItems.Count>0)
            {
                ListViewItem item = lv.SelectedItems[0];
                tbName.Tag = item.Tag;
                tbName.Text = item.SubItems[0].Text;
                tbAge.Text = item.SubItems[1].Text;
                if (item.SubItems[2].Text == "Nam") rdoMale.Checked = true;
                else if (item.SubItems[2].Text == "Nữ") rdoFemale.Checked = true;
                else rdoOther.Checked = true;
                tbUserName.Text = item.SubItems[3].Text;
                if (item.SubItems[4].Text == "Quản lý") rdoManager.Checked = true;
                else rdoSaff.Checked = true;

                btnDelete.Tag = lv.Items.IndexOf(item);
            }
        }
        #endregion
    }
}
