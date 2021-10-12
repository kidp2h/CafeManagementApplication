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

        public void payment(fPay f, string TableId)
        {
            if(Int32.Parse(f.inputChargeText) >= 0)
            {
                
                TableModel.Instance.resetTable(TableId);
                uscSale.Instance.LoadListTableForForm();
                
                f.Hide();
            }
            else
            {
                MessageBox.Show("Vc khong du tien :((");
            }
            
        }
    }
}
