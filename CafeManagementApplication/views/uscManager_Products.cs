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
            LoadData();
        }

        private DataTable dt;
        private DataView dv;
        private BindingSource productList = new BindingSource();


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
            get { return cbCategory.SelectedItem.ToString(); }
            set { cbCategory.SelectedItem = value; }
        }

        public string ProductNameTag
        {
            get { return tbProductSelected.Text; }
            set { tbProductSelected.Text = value; }
        }

        #endregion

        private void LoadData()
        {
            dtgvProducts.DataSource = productList;
            LoadListProducts();
           
        }

       
        public void LoadListProducts(bool status = true)
        {

            bool statusTemp = status;

            //Thread loadList = new Thread(() => {

                dt = new DataTable();
                LoadDataController.Instance.LoadDataTable("uscManager_Products", dt);
                dv = new DataView(dt);
                productList.DataSource = dv;

                LoadDataController.Instance.LoadDataForComboBox(cbCategory);
           
                if (statusTemp) ProductBinding();

            //});
            //loadList.IsBackground = true;
            //loadList.Start();                            
        }

        #region Handler Event
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            #region Validate
            StringBuilder sb = new StringBuilder();
            ValidateForm.Instance.checkProductName(tbProductName, sb, "Vui lòng nhập tên sản phẩm !",true);
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
            dtgvProducts.CurrentCell = dtgvProducts[0, dtgvProducts.RowCount - 1];
            #endregion

            ManagerController.Instance.AddData("Product",product);           
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            #region Validate
            StringBuilder sb = new StringBuilder();
            ValidateForm.Instance.checkProductName(tbProductName, sb, "Vui lòng chọn sản phẩm !", true);
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

            //trước khi xử lý ở view
            tbProductSelected.Text = tbProductName.Tag.ToString(); // tbProductName.Tag -- là tên cũ của product cần update
            // gán vào tbProductSelected.Text để giữ lại cái tên cũ, để update
            // vì sau khi xử lý thì cái tbProductName.Tag bị binding ở dòng dtgvProducts.CurrentCell về cái tên mới và cái tên cũ bị mất đi


            string filter = "[Tên món] = '" + tbProductSelected.Text + "'";
            // filter = "[Tên món] = 'ABC'";

            //trả về cái dòng có "cột [Tên món] có tên là ABC"
            DataRow[] rows = dt.Select(filter);
            //do tên món là duy nhất nên trong rows chỉ có một thằng duy nhất: rows[0]


            int index = dt.Rows.IndexOf(rows[0]);


            dt.Rows.RemoveAt(index);
            dt.Rows.InsertAt(rowNew, index);

            //dòng này chọn lại cái 'phần tử mới update', làm cho dữ liệu binding qua các ô input tương ứng( ô tsp, ô category, ô giá)
            dtgvProducts.CurrentCell = dtgvProducts[0, index];
            #endregion

            //sau khi xử lý ở view xong
            // gọi hàm update và có sẳn tên cũ được lưu ở tbProductSelected.Text 
            // và dữ liệu mới của product nẳm ở những ô input trên view ( ô tsp, ô category, ô giá)
            // this là view
            ManagerController.Instance.UpdateData("Product", this);         
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            #region Validate
            StringBuilder sb = new StringBuilder();
            ValidateForm.Instance.checkProductName(tbProductName, sb, "Vui lòng chọn sản phẩm !", false);
            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            #region Handler View
            string filter = string.Format("[Tên món] = '{0}'", tbProductSelected.Text = tbProductName.Tag.ToString());
            DataRow[] rows = dt.Select(filter);

            int index = dt.Rows.IndexOf(rows[0]);
            btnDeleteProduct.Tag = index;
            dt.Rows.RemoveAt(index);
            #endregion

            ManagerController.Instance.DeleteData("Product", this);          
        }
                                    
        private void ProductBinding()
        {
            // bind dữ liệu của cột"Tên món" trong dtgvProducts.DataSource, vào TextBox: tbProductName qua thuộc tính Text 
            // true là tự động ép kiểu về một kiểu 
            // DataSourceUpdateMode.Never là binding một đường từ DataSource qua TextBox
            tbProductName.DataBindings.Add("Text", dtgvProducts.DataSource, "Tên món", true, DataSourceUpdateMode.Never);
            

            tbProductName.DataBindings.Add("Tag", dtgvProducts.DataSource, "Tên món", true, DataSourceUpdateMode.Never);
            tbProductPrice.DataBindings.Add("Text", dtgvProducts.DataSource, "Giá món", true, DataSourceUpdateMode.Never);
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            //format sẽ thay thế {0} thành cái tbSearch.Text. ví dụ [Tên món] LIKE '%Cafe%'
            dv.RowFilter = String.Format("[Tên món] LIKE '%{0}%'", tbSearch.Text);
        }

        private void dtgvProducts_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                string name = (string)dtgvProducts.SelectedCells[0].OwningRow.Cells["Tên loại"].Value;
                cbCategory.SelectedItem = name;
            }
            catch { }
        }

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

        #endregion

        private void btnNew_Click(object sender, EventArgs e)
        {
            ManagerController.Instance.ResetProductDataInput(this);
        }
    }
}
