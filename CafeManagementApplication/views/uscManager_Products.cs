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
    }
}
