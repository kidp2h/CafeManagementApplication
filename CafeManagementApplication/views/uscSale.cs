using CafeManagementApplication.controllers;
using System;
using System.Windows.Forms;

namespace CafeManagementApplication.views
{
    public partial class uscSale : UserControl
    {
        private static uscSale instance;
        public static uscSale Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new uscSale();
                }
                return instance;
            }
        }

        private uscSale()
        {
            
            InitializeComponent();
            LoadListTableForForm();

        }

        public ListView getLvBillforOneTable()
        {
            return lvBillforOneTable;
        }

        public TextBox getITotalPriceProducts()
        {
            return iTotalPriceProducts;
        }
        public string LblTableName
        {
            set { lblTableName.Text = value; }
        }
        public string BtnAddTag
        {
            get { return btnAdd.Tag.ToString(); }
            set { btnAdd.Tag = value; }
        }
       
        public void LoadListTableForForm()
        {
            LoadItemController.Instance.LoadingItemTable(flpTableList);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            fAddProducts f = new fAddProducts();
            
            f.BillID = btnAdd.Tag.ToString();

            f.ShowDialog();
            
            if(f.CheckAdd) LoadListTableForForm();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadListTableForForm();
        }
    }
}
