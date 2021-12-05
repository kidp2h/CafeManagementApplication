using CafeManagementApplication.controllers;
using CafeManagementApplication.models;
using System;
using System.Text;
using System.Threading;
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

        public void LoadListTableForForm()
        {
            LoadItemController.Instance.LoadingItemTable(flpTableList);
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

        public string inputTotalPriceProducts
        {
            get 
            { 
                return tbTotalPriceProducts.Text;
            }
            set
            {
                tbTotalPriceProducts.Text = value;
            }
        }
        public string inputToTalPriceBill
        {
            get
            {
                return tbTotalPriceBill.Text;
            }
            set
            {
                tbTotalPriceBill.Text = value;
            }
        }
        public string inputSale
        {
            get { return this.tbSale.Text; }
            set { this.tbSale.Text = value; }
        }
        public string LblTableName
        {
            set { lblTableName.Text = value; }
        }
      
        public string BillId { get; set; }
        public string TableId { get; set; }
        public string TableStatus { get; set; }
        #endregion


        #region Handler Event
        private void btnAdd_Click(object sender, EventArgs e)
        {
            fAddProducts f = new fAddProducts();   
            f.BillID = this.BillId;
            f.TableId = this.TableId;
            f.TableStatus = this.TableStatus;
            f.Show();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {        
            if(tbTotalPriceBill.Text != "0đ")
            {
                fPay f = new fPay();
                f.TableId = TableId;
                f.BillId = BillId;
                f.sale = inputSale;
                f.inputSubtotalText = inputToTalPriceBill.Replace("đ","");
                f.Show();
            } 
            else
            {
                MessageBox.Show("Bàn Chưa Có Người");
            }       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadListTableForForm();
        }

        private void tbTotalPriceProducts_TextChanged(object sender, EventArgs e)
        {
            int TotalPriceProducts = Int32.Parse(tbTotalPriceProducts.Text.Replace("đ", ""));
            if (tbSale.Text == "") tbSale.Text = "0";
            int Sale = Int32.Parse(tbSale.Text.ToString());
            int total = TotalPriceProducts - (TotalPriceProducts * Sale) / 100;
            tbTotalPriceBill.Text = total.ToString() + "đ";
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (tbSale.Text == "") tbSale.Text = "0";
            int Sale = Int32.Parse(tbSale.Text.ToString());
            tbSale.Text = "" + (Sale + 5) ;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (tbSale.Text == "") tbSale.Text = "0";          
            int Sale = Int32.Parse(tbSale.Text.ToString());
            if (Sale > 0) tbSale.Text = "" + (Sale - 5);

        }

        private void tbSale_TextChanged(object sender, EventArgs e)
        {
            tbTotalPriceProducts_TextChanged(null, null);
        }
        #endregion

        private void lvBillforOneTable_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvBillforOneTable.SelectedItems.Count >= 1)
            {
                ListViewItem item = lvBillforOneTable.SelectedItems[0];
                string mess = "BẠN CÓ MUỐN HỦY MÓN NÀY KHÔNG ???" + "\n\n" +
                              "\tTÊN MÓN: " + item.Text + "\n" + 
                              "\tGIÁ: " + item.SubItems[1].Text + "\n" +
                              "\tSỐ LƯỢNG: " + item.SubItems[2].Text;
                if(MessageBox.Show( mess, "HỦY MÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    BillModel.Instance.deleteProductFromBillByName(BillId, item.Text);
                    LoadDataController.Instance.LoadBillOfTableByIdForViewSale(TableId);
                    LoadItemController.Instance.LoadingItemTable(flpTableList);
                }

            }
        }
    }
}
