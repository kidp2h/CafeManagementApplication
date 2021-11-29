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

        private uscManager_Categories()
        {
            InitializeComponent();
            LoadListCategorysForForm();
        }

        private DataTable dt;
        private DataView dv;

        public void LoadListCategorysForForm()
        {
            dt = new DataTable();
            LoadDataController.Instance.LoadDataTable("uscManager_Categories", dt);
            dv = new DataView(dt);
            dtgvCategories.DataSource = dv;
        }

        private void ResetView()
        {
            ManagerController.Instance.ResetCategoryDataInput(this);
            dtgvCategories.ClearSelection();
        }

        #region Public Data View
        public string inputCategory
        {
            get { return tbCategoryName.Text; }
            set { tbCategoryName.Text = value; }
        }

        public string OldCategoryName
        {
            get { return tbCategoryName.Tag.ToString(); }
            set { tbCategoryName.Tag = value; }
        }
        #endregion

        #region Handler Event
        private void uscManager_Categories_Load(object sender, EventArgs e)
        {
            dtgvCategories.ClearSelection();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            #region Validate
            StringBuilder sb = new StringBuilder();
            ValidateForm.Instance.checkCategoryName(tbCategoryName, sb, "Vui nhập tên loại sản phẩm !", "add");
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
            #endregion

            ManagerController.Instance.AddData("Category", category);
            ResetView();
            MessageBox.Show("ĐÃ THÊM LOẠI MÓN !!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            uscManager_Products.Instance.LoadListProducts();
        }

        private void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            #region Validate
            StringBuilder sb = new StringBuilder();
            ValidateForm.Instance.checkCategoryName(tbCategoryName, sb, "Vui lòng nhập loại sản phẩm !", "update");
            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            #region Handler View
            DataRow rowNew = dt.NewRow();
            rowNew["Tên loại"] = tbCategoryName.Text;
          
            string filter = String.Format("[Tên loại] = '{0}'", OldCategoryName);
            DataRow[] rows = dt.Select(filter);

            int index = dt.Rows.IndexOf(rows[0]);
           
            dt.Rows.RemoveAt(index);
            dt.Rows.InsertAt(rowNew, index);
           
 
            #endregion

            ManagerController.Instance.UpdateData("Category", this);
            ResetView();
            MessageBox.Show("ĐÃ SỬA LOẠI MÓN !!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            uscManager_Products.Instance.LoadListProducts();
           

        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("NẾU XÓA LOẠI MÓN, MÓN CÓ LOẠI NÀY CŨNG MẤT BẠN CÓ MUỐN XÓA ???", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No) return; 

            #region Validate
            StringBuilder sb = new StringBuilder();
            ValidateForm.Instance.checkCategoryName(tbCategoryName, sb, "Vui lòng chọn loại sản phẩm !", "delete");
            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            #region Handler View
            string filter = String.Format("[Tên loại] = '{0}'", OldCategoryName);
            DataRow[] rows = dt.Select(filter);

            int index = dt.Rows.IndexOf(rows[0]);
            dt.Rows.RemoveAt(index);
            #endregion

            ManagerController.Instance.DeleteData("Category", this);
            ResetView();
            uscManager_Products.Instance.LoadListProducts();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            dv.RowFilter = String.Format("[Tên loại] LIKE '%{0}%'", tbSearch.Text);
        }
       
        private void dtgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            DataGridViewRow row = dtgvCategories.Rows[e.RowIndex];

            tbCategoryName.Text = row.Cells[0].Value.ToString();
            tbCategoryName.Tag = row.Cells[0].Value.ToString();
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
