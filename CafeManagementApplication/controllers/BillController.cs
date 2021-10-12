using CafeManagementApplication.models;
using CafeManagementApplication.views;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading;


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

        public void AddProductToBill(string billID, string productID, int amount)
        {
            BillModel.Instance.addProductToBill(billID, productID, amount);
            Thread status = new Thread(() => {
                FilterDefinition<Table> filter = new BsonDocument("bill", new ObjectId(billID));
                TableModel.Instance.setStatusForTable(filter, types.sTable.FULL);
            });
            Thread loadTable = new Thread(() => {
                
                uscSale.Instance.LoadListTableForForm();
            });
            status.IsBackground = true;
            status.Start();
            
        }
        public void AddProductToBill(string billID)
        {
           /* Bill newBill = new Bill
            {
                ProductsOrdered = new ListItemOrder(),
                TableId = new ObjectId(idTable)
            };
            BillModel.Instance.addBill(newBill);*/
        }

    }
}
