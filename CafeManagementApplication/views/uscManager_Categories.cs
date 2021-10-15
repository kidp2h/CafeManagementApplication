using CafeManagementApplication.controllers;
using CafeManagementApplication.helpers;
using CafeManagementApplication.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeManagementApplication.views
{
    public partial class uscManager_Categories : UserControl
    {
        private static uscManager_Categories instance;

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
            LoadListCategorysForForm();
        }

        public void LoadListCategorysForForm()
        {
            Thread loadList = new Thread(() => {
                LoadListController.Instance.LoadingListForListViewOf("useManager_Products", lvCategoryInfor);
            });
            loadList.Start();
        }

        #region Public Data View
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

        public string CategoryNameTag
        {
            get { return tbCategoryName.Tag.ToString(); }
            set { tbCategoryName.Tag = value; }
        }
        #endregion

        #region Handler Event
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            #region Validate
            StringBuilder sb = new StringBuilder();
            ValidateForm.Instance.checkCategoryName(tbCategoryName, sb, "Vui lòng nhập tên loại sản phẩm !", true);
            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            #region Handler View
            Category category = ManagerController.Instance.NewData("Category", this);
            ListViewItem categoryItem = new ListViewItem(category.NameCategory.ToString());
            lvCategoryInfor.Items.Add(categoryItem);
            #endregion

            ManagerController.Instance.AddData("Category", category, this);
        }

        private void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            #region Validate
            StringBuilder sb = new StringBuilder();
            ValidateForm.Instance.checkCategoryName(tbCategoryName, sb, "Vui lòng nhập tên loại sản phẩm !", false);
            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            #region Handler View
            Category category = ManagerController.Instance.NewData("Category", this);
            ListViewItem categoryItem = new ListViewItem(category.NameCategory.ToString());
            lvCategoryInfor.Items.RemoveAt(int.Parse(btnDeleteCategory.Tag.ToString()));
            lvCategoryInfor.Items.Insert(int.Parse(btnDeleteCategory.Tag.ToString()), categoryItem);
            #endregion

        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            #region Validate
            StringBuilder sb = new StringBuilder();
            ValidateForm.Instance.checkCategoryName(tbCategoryName, sb, "Vui lòng nhập tên loại sản phẩm !", false);
            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            #region Handler View

            #endregion

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
        #endregion

        #region Effect
        private void tbCategoryName_TextChanged(object sender, EventArgs e)
        {
            if (tbCategoryName.BackColor != Color.White)
            tbCategoryName.BackColor = Color.White;

        }
        #endregion
    }
}
