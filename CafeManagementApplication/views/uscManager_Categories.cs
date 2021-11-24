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

        private DataTable dt = new DataTable();
        private DataView dv;

        public void LoadListCategorysForForm()
        {
            //Thread loadList = new Thread(() => {
                LoadDataController.Instance.LoadDataTable("uscManager_Categories", dt);
                dv = new DataView(dt);
                dtgvCategories.DataSource = dv;

                CategoryBinding();

            //});
            //loadList.IsBackground = true;
            //loadList.Start();
            
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
            get { return tbCategorySelected.Text; }
            set { tbCategorySelected.Text = value; }
        }
        #endregion

        #region Handler Event
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            #region Validate
            StringBuilder sb = new StringBuilder();
            ValidateForm.Instance.checkCategoryName(tbCategoryName, sb, "Vui nhập tên loại sản phẩm !", true);
            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            #region Handler View
            Category category = ManagerController.Instance.NewData("Category", this);
            string Name = category.NameCategory.ToString();
            dt.Rows.Add(Name);
            dtgvCategories.CurrentCell = dtgvCategories[0, dtgvCategories.RowCount - 1];
            #endregion

            ManagerController.Instance.AddData("Category", category);

            uscManager_Products.Instance.LoadListProducts(false);
        }

        private void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            #region Validate
            StringBuilder sb = new StringBuilder();
            ValidateForm.Instance.checkCategoryName(tbCategoryName, sb, "Vui lòng nhập loại sản phẩm !", true);
            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            #region Handler View
            DataRow rowNew = dt.NewRow();
            rowNew["Tên loại"] = tbCategoryName.Text;
          
            string filter = string.Format("[Tên loại] = '{0}'", tbCategorySelected.Text = tbCategoryName.Tag.ToString());
            DataRow[] rows = dt.Select(filter);

            int index = dt.Rows.IndexOf(rows[0]);
            btnDeleteCategory.Tag = index;
            dt.Rows.RemoveAt(index);
            dt.Rows.InsertAt(rowNew, index);
            dtgvCategories.CurrentCell = dtgvCategories[0, index];
 
            #endregion

            ManagerController.Instance.UpdateData("Category", this);
            uscManager_Products.Instance.LoadListProducts(false);

        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            #region Validate
            StringBuilder sb = new StringBuilder();
            ValidateForm.Instance.checkCategoryName(tbCategoryName, sb, "Vui lòng chọn loại sản phẩm !", false);
            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            #region Handler View
            string filter = string.Format("[Tên loại] = '{0}'", tbCategorySelected.Text = tbCategoryName.Tag.ToString());
            DataRow[] rows = dt.Select(filter);

            int index = dt.Rows.IndexOf(rows[0]);
            btnDeleteCategory.Tag = index;
            dt.Rows.RemoveAt(index);
            #endregion


            ManagerController.Instance.DeleteData("Category", this);
            uscManager_Products.Instance.LoadListProducts(false); 
        }

        private void CategoryBinding()
        {
            tbCategoryName.DataBindings.Add(new Binding("Text", dtgvCategories.DataSource, "Tên loại", true, DataSourceUpdateMode.Never));
            tbCategoryName.DataBindings.Add(new Binding("Tag", dtgvCategories.DataSource, "Tên loại", true, DataSourceUpdateMode.Never));
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            dv.RowFilter = String.Format("[Tên loại] LIKE '%{0}%'", tbSearch.Text);
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
