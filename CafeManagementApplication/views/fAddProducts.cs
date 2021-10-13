using CafeManagementApplication.controllers;
using System;
using System.Threading;
using System.Windows.Forms;

namespace CafeManagementApplication.views
{
    public partial class fAddProducts : Form
    {
        public fAddProducts()
        {
            
            InitializeComponent();
            LoadItemController.Instance.LoadingItemProduct(flpListProducts);
            LoadPanelController.Instance.setView(this);

        
        }

        #region Public Data In View
      
        public string BillID { get; set; }
        public string TableId { get; set; }
        public string TableStatus { get; set; }
        public string LblNameText
        {
            get { return lblName.Text; }
            set { lblName.Text = value; }
        }
        public string LblPriceText
        {
            get { return lblPrice.Text; }
            set { lblPrice.Text = value; }
        }
        public string LblNameTag
        {
            get { return lblName.Tag.ToString(); }
            set { lblName.Tag = value; }
        }
        public string txtAmount
        {
            get { return txtBoxAmount.Text; }
            set { txtBoxAmount.Text = value; }
        }
        public TextBox tbAmount
        {
            get { return txtBoxAmount; }
        }
        public string tbSubtotal
        {
            set { textBox2.Text = value; }
        }
        #endregion


        #region Handler Event
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (this.txtAmount == "") this.txtAmount = "1";
            BillController.Instance.AddProductToBill(this.BillID, this.LblNameTag, Int32.Parse(this.txtAmount));
            if (this.TableStatus != "Có người")
            {
                Thread t1 = new Thread(() => {
                    Invoke(new Action(() =>
                    {
                        LoadItemController.Instance.LoadingItemTable();
                    }));
                });
                t1.Start();
            }
            Thread t2 = new Thread(() => {
                LoadListController.Instance.LoadingBillForListViewFormTableID(this.TableId);
            });
            t2.Start();
        }



        private void tbAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string amount = this.txtAmount;
                string price = this.LblPriceText;
                this.tbSubtotal = (Int32.Parse(amount) * Int32.Parse(price)).ToString();
            }
            catch
            {

            }
            
        }
        #endregion

    }
}
