using System;
using CafeManagementApplication.controllers;
using System.Windows.Forms;
using System.Threading;
using System.Text;
using CafeManagementApplication.helpers;

namespace CafeManagementApplication.views
{
    public partial class fPay : Form
    {
        public fPay()
        {
            InitializeComponent();
        }

        #region Public Data View
        public string inputMoneyText
        {
            get { return this.tbMoney.Text; }
            set { this.tbMoney.Text = value; }
        }
        public string inputSubtotalText
        {
            get { return this.tbSubtotal.Text; }
            set { this.tbSubtotal.Text = value; }
        }

        public string inputChargeText
        {
            get { return this.tbCharge.Text; }
            set { this.tbCharge.Text = value; }
        }
        public string TableId { get; set; }

        public string BillId { get; set; }
        #endregion

        #region Handler Event
        private void btnPay_Click(object sender, EventArgs e)
        {
            #region Validate
            StringBuilder sb = new StringBuilder();
            ValidateForm.Instance.checkNumber(tbMoney, sb, "Vui lòng nhập tiền của khách !", "Tiền");
            if(sb.Length > 0)
            {
                MessageBox.Show(sb.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            PaymentController.Instance.payment(this, TableId, BillId);
            Thread t1 = new Thread(() =>
            {
                Invoke(new Action(() =>
                {
                    uscSale.Instance.LoadListTableForForm();
                }));
            });
            t1.IsBackground = true;
            t1.Start();

            LoadListController.Instance.LoadingBillForListViewFormTableID(this.TableId);
            uscManager_Tables.Instance.LoadListTables(false);
            uscStatistics.Instance.LoadListBillForView();
        }

        private void tbMoney_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string money = inputMoneyText;
                string subtotal = inputSubtotalText;
                inputChargeText = (Int32.Parse(money) - Int32.Parse(subtotal)).ToString();
            }
            catch
            {
               
            }
        }
      

        private void btnClosed_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
