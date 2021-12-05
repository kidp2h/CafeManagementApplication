using CafeManagementApplication.controllers;
using CafeManagementApplication.helpers;
using CafeManagementApplication.models;
using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CafeManagementApplication.views
{
    public partial class uscManager_Products : UserControl
    {
        private static uscManager_Products instance;

        public static uscManager_Products Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new uscManager_Products();
                }
                return instance;
            }
        }

        private uscManager_Products()
        {
            InitializeComponent();
            LoadListProducts();
        }

        private DataTable dt;
        private DataView dv;
       
        public void LoadListProducts()
        {
            dt = new DataTable();
            LoadDataController.Instance.LoadDataTable("uscManager_Products", dt);
            dv = new DataView(dt);
            dtgvProducts.DataSource = dv;

            LoadDataController.Instance.LoadDataForComboBox(cbCategory);             
        }

        private void ResetView()
        {
            ManagerController.Instance.ResetProductDataInput(this);
            dtgvProducts.ClearSelection();
        }


        #region Public Data View
        public string inputProductNameText
        {
            get { return tbProductName.Text; }
            set { tbProductName.Text = value; }
        }

        public string inputPrice
        {
            get { return tbProductPrice.Text; }
            set { tbProductPrice.Text = value; }
        }

        public string inputCategoryName
        {
            get { return cbCategory.Text; }
            set { cbCategory.SelectedItem = value; }
        }

        public string OldProductName
        {
            get { return tbProductName.Tag.ToString(); }
            set { tbProductName.Tag = value; }
        }

        #endregion

        #region Handler Event
        private void uscManager_Products_Load(object sender, EventArgs e)
        {
            dtgvProducts.ClearSelection();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            #region Validate
            StringBuilder sb = new StringBuilder();
            ValidateForm.Instance.checkProductName(tbProductName, sb, "Vui lòng nhập tên sản phẩm !", "add");
            ValidateForm.Instance.checkNumber(tbProductPrice, sb, "Vui lòng nhập giá sản phẩm !", "Giá sản phẩm");
            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            #region Handler View
            Product product = ManagerController.Instance.NewData("Product", this);
            string Name = product.NameProduct.ToString();
            string Category = product.CategoryName;
            string Price = product.Price.ToString();
            dt.Rows.Add(Name, Category, Price);
            
            #endregion

            ManagerController.Instance.AddData("Product",product);
            ResetView();
            MessageBox.Show("ĐÃ THÊM MÓN MỚI !!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            #region Validate
            StringBuilder sb = new StringBuilder();
            ValidateForm.Instance.checkProductName(tbProductName, sb, "Vui lòng chọn sản phẩm !", "update");
            ValidateForm.Instance.checkNumber(tbProductPrice, sb, "Vui lòng nhập giá sản phẩm !", "Giá sản phẩm");
            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            #region Handler View
            DataRow rowNew = dt.NewRow();
            rowNew["Tên món"] = tbProductName.Text; // tbProductName.Text -- là tên mới của product cần update
            rowNew["Tên loại"] = cbCategory.SelectedItem.ToString();
            rowNew["Giá món"] = tbProductPrice.Text;


            // filter = "[Tên món] = 'ABC'";
            string filter = "[Tên món] = '" + OldProductName + "'";
           

            //trả về cái dòng có "cột [Tên món] có tên là ABC"
            DataRow[] rows = dt.Select(filter);

            //do tên món là duy nhất nên trong rows chỉ có duy nhất: rows[0]
            int index = dt.Rows.IndexOf(rows[0]);
            dt.Rows.RemoveAt(index);
            dt.Rows.InsertAt(rowNew, index);

          
            #endregion

            //sau khi xử lý ở view xong
            // và dữ liệu mới của product nẳm ở những ô input trên view ( ô tsp, ô category, ô giá)
            // this là view
            ManagerController.Instance.UpdateData("Product", this);
            ResetView();
            MessageBox.Show("ĐÃ SỬA MÓN !!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            #region Validate
            StringBuilder sb = new StringBuilder();
            ValidateForm.Instance.checkProductName(tbProductName, sb, "Vui lòng chọn sản phẩm !", "delete");
            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            #region Handler View
            string filter = string.Format("[Tên món] = '{0}'", OldProductName);
            DataRow[] rows = dt.Select(filter);

            int index = dt.Rows.IndexOf(rows[0]);
            dt.Rows.RemoveAt(index);
          
            #endregion

            ManagerController.Instance.DeleteData("Product", this);
            ResetView();
            MessageBox.Show("ĐÃ XÓA MÓN !!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
                                   
        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            //format sẽ thay thế {0} thành cái tbSearch.Text. ví dụ [Tên món] LIKE '%Cafe%'
            dv.RowFilter = String.Format("[Tên món] LIKE '%{0}%'", tbSearch.Text);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ResetView();
        }

        private void dtgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            DataGridViewRow row = dtgvProducts.Rows[e.RowIndex];

            tbProductName.Text = row.Cells[0].Value.ToString();
            tbProductName.Tag = row.Cells[0].Value.ToString();
            cbCategory.SelectedItem = row.Cells[1].Value.ToString(); ;
            tbProductPrice.Text = row.Cells[2].Value.ToString();
        }

        #endregion

        #region Effect
        private void tbProductName_TextChanged(object sender, EventArgs e)
        {
            if (tbProductName.BackColor != Color.White)
                tbProductName.BackColor = Color.White;

        }

        private void tbProductPrice_TextChanged(object sender, EventArgs e)
        {
            if (tbProductPrice.BackColor != Color.White)
                tbProductPrice.BackColor = Color.White;
        }



        #endregion

    }
}
