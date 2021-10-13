using CafeManagementApplication.controllers;
using System;
using System.Threading;
using System.Windows.Forms;

namespace CafeManagementApplication.views
{
    public partial class uscSale : UserControl
    {
        private static uscSale instance;
        private static readonly object lockObject = new object();
        public static uscSale Instance
        {
            get
            {
                if (instance == null)
                {
                    lock(lockObject)
                    {
                        if (instance == null) instance = new uscSale();
                    }    
                }
                return instance;
            }
        }

        private uscSale()
        {
            
            InitializeComponent();
            LoadListTableForForm();

        }

        #region Public Data In View
        public ListView getLvBillforOneTable()
        {
            return lvBillforOneTable;
        }
        public FlowLayoutPanel getFlpTableList()
        {
            return flpTableList;
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
        public string inputSubtotalText
        {
            get { return this.iTotalPriceProducts.Text; }
        }
        public string TableId { get; set; }
        public string TableStatus { get; set; }
        public string BillId { get; set; }
        #endregion

        #region Handler Event
        public void LoadListTableForForm()
        {
            LoadItemController.Instance.LoadingItemTable(flpTableList);
        }
 
        private void btnAdd_Click(object sender, EventArgs e)
        {
            fAddProducts f = new fAddProducts();     
            f.BillID = btnAdd.Tag.ToString();
            f.TableId = this.TableId;
            f.TableStatus = this.TableStatus;
            f.Show();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            
            if(uscSale.Instance.inputSubtotalText != "0")
            {
                fPay f = new fPay();
                f.TableId = TableId;
                f.BillId = BillId; 
                f.inputSubtotalText = uscSale.Instance.inputSubtotalText.Replace("đ","");
                f.ShowDialog();
            }
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadListTableForForm();
        }
        #endregion

       
    }
}
