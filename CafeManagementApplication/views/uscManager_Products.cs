using CafeManagementApplication.controllers;
using CafeManagementApplication.models;
using System;
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

        public string inputProductNameText
        {
            get { return tbProductName.Text; }
            set { tbProductName.Text = value; }
        }

        public string inputCategoryName
        {
            get { return tbProductCategory.Text; }
            set { tbProductCategory.Text = value; }
        }


        public string inputPrice
        {
            get { return tbProductPrice.Text; }
            set { tbProductPrice.Text = value; }
        }

        public string ProductName
        {
            get { return tbProductName.Tag.ToString(); }
            set { tbProductName.Tag = value; }
        }

        private uscManager_Products()
        {
            InitializeComponent();
            LoadListController.Instance.LoadingListForListViewOf("useManager_Products", lvProductInfor);
        }

        public void LoadListProductsForForm()
        {
            Thread loadList = new Thread(() => {
                LoadListController.Instance.LoadingListForListViewOf("useManager_Products", lvProductInfor);
            });
            loadList.Start();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {   
            Product product = ManagerController.Instance.NewData("Product", this);
            ListViewItem productItem = new ListViewItem(product.NameProduct);
            productItem.SubItems.Add(product.CategoryName);
            productItem.SubItems.Add(product.Price.ToString());
            lvProductInfor.Items.Add(productItem);
            ManagerController.Instance.AddData("Product",product, this);           
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {          
            ManagerController.Instance.UpdateData("Product", this);
            LoadListProductsForForm();
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            lvProductInfor.Items.RemoveAt(int.Parse(btnDeleteProduct.Tag.ToString()));
            ManagerController.Instance.DeleteData("Product", this);          
        }

        private void lvProductInfor_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView lvProduct = sender as ListView;

            if (lvProduct.SelectedItems.Count > 0)
            {
                ListViewItem item = lvProduct.SelectedItems[0];
                tbProductName.Tag = item.SubItems[0].Text;
                tbProductName.Text = item.SubItems[0].Text;
                tbProductCategory.Text = item.SubItems[1].Text;
                tbProductPrice.Text = item.SubItems[2].Text;
                btnDeleteProduct.Tag = lvProduct.Items.IndexOf(item);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadListProductsForForm();
        }
    }
}
