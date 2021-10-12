using CafeManagementApplication.controllers;
using CafeManagementApplication.models;
using CafeManagementApplication.types;
using System;
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
            LoadListController.Instance.LoadingListForListViewOf("useManager_Users", lvUsers);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            User user = ManagerController.Instance.NewData("User", this);
            ListViewItem item = new ListViewItem(user.Fullname);
            item.SubItems.Add(user.Age.ToString());
            item.SubItems.Add(user.Gender);
            item.SubItems.Add(user.Username);
            item.SubItems.Add(user.Role == Role.MANAGER ? "Quản lý" : "Nhân viên");
            lvUsers.Items.Add(item);
            ManagerController.Instance.AddData("User", user, this);

        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ManagerController.Instance.UpdateData("User", this);
            LoadListController.Instance.LoadingListForListViewOf("useManager_Users", lvUsers);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            lvUsers.Items.RemoveAt(int.Parse(btnDelete.Tag.ToString()));

            ManagerController.Instance.DeleteData("User", this);
            
        } 
        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadListController.Instance.LoadingListForListViewOf("useManager_Users", lvUsers);
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
                if (item.SubItems[2].Text == "Nam") rdoMale.Checked = true;
                else if (item.SubItems[2].Text == "Nữ") rdoFemale.Checked = true;
                else rdoOther.Checked = true;
                iUserName.Text = item.SubItems[3].Text;
                if (item.SubItems[4].Text == "Quản lý") rdoManager.Checked = true;
                else rdoSaff.Checked = true;

                btnDelete.Tag = lv.Items.IndexOf(item);
            }
        }

        #region Public Input View
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
        public string inputNameTagText
        {
            get { return iName.Tag.ToString();}
            set { iName.Tag = value; }
        }
        #endregion

        private void lvUsers_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            ListView lv = sender as ListView;

            if (lv.SelectedItems.Count > 0)
            {
                ListViewItem item = lv.SelectedItems[0];
                iName.Tag = item.Tag;
                iName.Text = item.SubItems[0].Text;
                iAge.Text = item.SubItems[1].Text;
                if (item.SubItems[2].Text == "Nam") rdoMale.Checked = true;
                else if (item.SubItems[2].Text == "Nữ") rdoFemale.Checked = true;
                else rdoOther.Checked = true;

                iUserName.Text = item.SubItems[3].Text;
                if (item.SubItems[4].Text == "Quản lý") rdoManager.Checked = true;
                else rdoSaff.Checked = true;

                btnDelete.Tag = lv.Items.IndexOf(item);
            }
        }
    }
}
