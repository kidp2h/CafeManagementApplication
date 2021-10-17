using CafeManagementApplication.models;
using CafeManagementApplication.views;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading;
using System.Data;
using System.Collections.Generic;

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

        public void LoadBill(DataTable dt)
        {
            dynamic billList = BillModel.Instance.getListBill();
            dt.Columns.Add("Tên bàn");
            dt.Columns.Add("Trạng thái");
            dt.Columns.Add("Ngày thanh toán");
            dt.Columns.Add("Giảm giá");

            foreach (dynamic bill in billList)
            {
                string Table = bill["table"]["tableName"].Value;
                string Paid;
                if (bill["paid"].Value)
                {
                    Paid = "Bàn đã thanh toán";
                }
                else Paid = "Bàn chưa thanh toán";
                string PaidTime = bill["paidTime"].Value.ToString();
                string Sale = bill["sale"].Value.ToString();

                dt.Rows.Add(Table, Paid, PaidTime, Sale);
            }

            return;
        }

        public void AddProductToBill(fAddProducts f,string billId, string productId, int amount)
        {
            BillModel.Instance.addProductToBill(billId, productId, amount);    
            FilterDefinition<Table> filter = new BsonDocument("bill", new ObjectId(billId));
            TableModel.Instance.updateStatusForTable(filter, types.sTable.FULL);
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
