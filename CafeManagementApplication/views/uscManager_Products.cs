using CafeManagementApplication.controllers;
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

        public string inputCategoryText
        {
            get { return tbProductCategory.Text; }
            set { tbProductCategory.Text = value; }
        }

        public string inputPrice
        {
            get { return tbProductPrice.Text; }
            set { tbProductPrice.Text = value; }
        }

        public string ProductId
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

        private void btnAddProduct_Click(object sender, System.EventArgs e)
        {
            ManagerController.Instance.AddData("Product", this);
            LoadListProductsForForm();
        }

        private void btnDeleteProduct_Click(object sender, System.EventArgs e)
        {
            lvProductInfor.Items.RemoveAt(int.Parse(btnDeleteProduct.Tag.ToString()));
            ManagerController.Instance.DeleteData("Product", this);
            LoadListProductsForForm();
        }

        private void lvProductInfor_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ListView lvProduct = sender as ListView;

            if (lvProduct.SelectedItems.Count > 0)
            {
                ListViewItem item = lvProduct.SelectedItems[0];
                tbProductName.Tag = item.Tag;
                tbProductName.Text = item.SubItems[0].Text;

                btnDeleteProduct.Tag = lvProduct.Items.IndexOf(item);
            }
        }
    }
}
