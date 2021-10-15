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
    public partial class uscManager_Categories : UserControl
    {
        public static uscManager_Categories instance;
        public static uscManager_Categories Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new uscManager_Categories();
                }
                return instance;
            }
        }
        public uscManager_Categories()
        {
            InitializeComponent();
            LoadListController.Instance.LoadingListForListViewOf("uscManager_Categories", lvCategoryInfor);
        }

        public string inputCategory
        {
            get
            {
                return tbCategoryName.Text;
            }
            set
            {
                tbCategoryName.Text = value;
            }
        }

        public string CategoryTag
        {
            get { return tbCategoryName.Tag.ToString(); }
            set { tbCategoryName.Tag = value; }
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            Category category = ManagerController.Instance.NewData("Category", this);
            ListViewItem categoryItem = new ListViewItem(category.NameCategory.ToString());
            lvCategoryInfor.Items.Add(categoryItem);
            ManagerController.Instance.AddData("Category", category, this);
        }

        private void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            Category category = ManagerController.Instance.NewData("Category", this);
            ListViewItem categoryItem = new ListViewItem(category.NameCategory.ToString());

            lvCategoryInfor.Items.RemoveAt(int.Parse(btnDeleteCategory.Tag.ToString()));
            lvCategoryInfor.Items.Insert(int.Parse(btnDeleteCategory.Tag.ToString()), categoryItem);
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            lvCategoryInfor.Items.RemoveAt(int.Parse(btnDeleteCategory.Tag.ToString()));
            ManagerController.Instance.DeleteData("Category", this);
        }

        private void lvCategoryInfor_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView CategoryLv = sender as ListView;
            if(CategoryLv.SelectedItems.Count > 0)
            {
                ListViewItem item = CategoryLv.SelectedItems[0];
                tbCategoryName.Tag = item.SubItems[0].Text;
                tbCategoryName.Text = item.SubItems[0].Text;

                btnDeleteCategory.Tag = CategoryLv.Items.IndexOf(item);
            }
        }
    }
}
