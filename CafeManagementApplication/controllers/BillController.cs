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

        public void AddProductToBill(string billId, string productId, int amount)
        {
            BillModel.Instance.addProductToBill(billId, productId, amount);    
            FilterDefinition<Table> filter = new BsonDocument("bill", new ObjectId(billId));
            TableModel.Instance.setStatusForTable(filter, types.sTable.FULL);
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
