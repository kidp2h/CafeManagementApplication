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
        public string sale { get; set; }

        #endregion

        #region Handler Event
        private void btnPay_Click(object sender, EventArgs e)
        {
            #region Validate
            StringBuilder sb = new StringBuilder();
            ValidateForm.Instance.checkNumber(tbMoney, sb, "Vui lòng nhập tiền của khách !", "Tiền");
            ValidateForm.Instance.checkCharge(tbCharge, sb, "Tiền không đủ để thanh toán");
            if(sb.Length > 0)
            {
                MessageBox.Show(sb.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            string billInfo = LoadDataController.Instance.GetBillForTableId(this.TableId);
            billInfo += "THÀNH TIỀN: " + inputSubtotalText;

            PaymentController.Instance.payment(TableId, BillId, Int32.Parse(sale));
            
            uscSale.Instance.LoadListTableForForm();

            LoadDataController.Instance.LoadBillOfTableByIdForViewSale(this.TableId);

            uscManager_Tables.Instance.LoadListTables();

            uscStatistics.Instance.LoadListBillForView();

            this.Close();

            MessageBox.Show("ĐÃ THANH TOÁN !!!!\n\n" + billInfo , "Thông báo", MessageBoxButtons.OK );

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
