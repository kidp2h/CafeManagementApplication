using CafeManagementApplication.views;
using System;
using CafeManagementApplication.models;
using System.Threading;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;

namespace CafeManagementApplication.controllers
{
    class PaymentController
    {
        private static PaymentController instance;
        public static PaymentController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PaymentController();
                }
                return instance;
            }
        }

        public void payment(fPay f, string TableId, string BillId)
        {
            if(Int32.Parse(f.inputChargeText) >= 0)
            {
                TableModel.Instance.updateBillForTable(TableId,BillId);
                f.Hide();
            }
            else
            {
                MessageBox.Show("Vc khong du tien :((");
            }
            
        }
    }
}
