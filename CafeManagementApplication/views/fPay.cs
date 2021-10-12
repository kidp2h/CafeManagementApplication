using System;
using CafeManagementApplication.controllers;
using System.Windows.Forms;

namespace CafeManagementApplication.views
{
    public partial class fPay : Form
    {
        public fPay()
        {
            InitializeComponent();
        }
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
        private void btnPay_Click(object sender, EventArgs e)
        {
            PaymentController.Instance.payment(this, TableId);
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
    }
}
