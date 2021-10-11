using CafeManagementApplication.controllers;
using CafeManagementApplication.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
        public uscManager_Users()
        {
            InitializeComponent();
            LoadingListUsersForForm();
        }

        private void LoadingListUsersForForm()
        {
            LoadListController.Instance.LoadingListForListViewOf("useManager_Users", lvUsers);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AUDRController.Instance.AddData("User", this);
            LoadingListUsersForForm();
            
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            AUDRController.Instance.UpdateData("User", pnlInfo, iName.Tag.ToString());
            AUDRController.Instance.ResetDataInput(pnlInfo);
            LoadingListUsersForForm();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            AUDRController.Instance.DeleteData("User", iName.Tag.ToString());
            AUDRController.Instance.ResetDataInput(pnlInfo);
            LoadingListUsersForForm();
        }
        private void lvUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView lv = sender as ListView;
            if(lv.SelectedItems.Count>0)
            {
                ListViewItem item = lv.SelectedItems[0];
                iName.Tag = item.Tag;
                iName.Text = item.SubItems[0].Text;
                iAge.Text = item.SubItems[1].Text;
                iUserName.Text = item.SubItems[2].Text;
            }
        }

        public string inputNameText
        {
            get { return iName.Text; }
            set { iName.Text = value;  }
        }
        public string inputAgeText
        {
            get { return iAge.Text; }
            set { iAge.Text = value; }
        }
        public string inputUsernameText
        {
            get { return iUserName.Text; }
            set { iUserName.Text = value; }
        }
        public string inputUserpasswordText
        {
            get { return iUserPassword.Text; }
            set { iUserPassword.Text = value; }
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
        public int inputRole
        {
            get
            {
                if (rdoManager.Checked) return 1;
                else return 0;
            }
            set
            {
                if (value == 1) rdoManager.Checked = true;
                else rdoSaff.Checked = true;
            }
        }

    }
}
