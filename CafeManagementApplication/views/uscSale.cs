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
        public Boolean CheckAdd { get; set; }

        private void LoadListTableForForm()
        {
            LoadItemController.Instance.LoadingItemTable(flpTableList);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            fAddProducts f = new fAddProducts();
            f.Show();
            f.BillID = btnAdd.Tag.ToString();
            
           
           
            if (btnAdd.Tag != null)
            {
                f.BillID = btnAdd.Tag.ToString();
            }

            f.ShowDialog();

            this.CheckAdd = f.CheckAdd;



        }

        
    }
}
