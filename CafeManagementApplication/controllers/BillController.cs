using CafeManagementApplication.models;
using CafeManagementApplication.views;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading;
using System.Data;
using System.Collections.Generic;
using System;

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

        private BillController() { }

        public void LoadBill(DataTable dt)
        {
            dynamic billList = BillsPaidModel.Instance.getListBillsPaid();
            dt.Columns.Add("Tên bàn");
            dt.Columns.Add("Trạng thái");
            dt.Columns.Add("Ngày thanh toán");
            dt.Columns.Add("Tổng tiền");
            dt.Columns.Add("Thành tiền");

            foreach (dynamic bill in billList)
            {
                string Table = bill.TableName.Value;
                string Paid = "Đã thanh toán";
                string PaidTime = bill.PaidTime.ToString();
                PaidTime = PaidTime.Split(' ')[0];
                string Sale = bill.Sale.Value.ToString();
                string Subtotal = bill.Subtotal.Value.ToString();

                dt.Rows.Add(Table, Paid, PaidTime, Subtotal, Sale);
            }

            return;
        }

        public int SubtotalBills()
        {
            dynamic billList = BillsPaidModel.Instance.getListBillsPaid();
            int subtotalBills = 0;
            foreach (dynamic bill in billList)
            {
                
                subtotalBills += Int32.Parse(bill.Sale.Value.ToString());

            }

            return subtotalBills;
        }

        public void AddProductToBill(fAddProducts f,string billId, string productId, int amount)
        {
            //gọi model để thêm product cho bill: id của bill,  tên của sản phẩm, số lượng
            BillModel.Instance.addProductToBill(billId, productId, amount);    
            FilterDefinition<Table> filter = new BsonDocument("bill", new ObjectId(billId));
            TableModel.Instance.updateStatusForTable(filter, types.sTable.FULL);
        }


    }
}
