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

        private PaymentController() { }

        public void payment(string TableId, string BillId, int sale)
        {
           
           TableModel.Instance.updateTable(TableId,BillId, sale);
            
        }
    }
}
