using CafeManagementApplication.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagementApplication.controllers
{
    class BillController
    {
        private static BillController instance;

        public static BillController Instance
        {
            get
            {
                if (instance == null) instance = new BillController();
                return instance;
            }
        }

        public void AddProductToBill(string billID, string productID )
        {
            BillModel.Instance.addProductToBill(billID, productID);
        } 

    }
}
