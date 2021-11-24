using CafeManagementApplication.config;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagementApplication.models
{
    class BillsPaid
    {
        // Định nghĩa các trường của model Bill
        [BsonElement("_id")]
        public BsonObjectId Id { get; set; }

        [BsonElement("tableName")]
        public BsonString TableName { get; set; }

        //[BsonElement("paid")]
        //public BsonBoolean Paid { get; set; }

        [BsonElement("paidTime")]
        public DateTime PaidTime { get; set; }

        [BsonElement("sale")]
        public BsonInt32 Sale { get; set; }

        [BsonElement("subtotal")]
        public BsonInt32 Subtotal { get; set; }
    }

    class BillsPaidModel : BaseModel<BillsPaid>
    {
        private static BillsPaidModel instance;
        public static BillsPaidModel Instance
        {
            get
            {
                if (instance == null) instance = new BillsPaidModel();
                return instance;
            }
        }
        // Hàm lấy collection trong database bill hay nói cách khác là lấy tất cả các document trong database bill
        public override IMongoCollection<BillsPaid> getCollection()
        {
            // lấy database
            IMongoDatabase db = Database.getDatabase();
            IMongoCollection<BillsPaid> collection = db.GetCollection<BillsPaid>("billsPaid");
            return collection;
        }

        public void addBillPaid(BillsPaid newBillsPaid)
        {
            // lấy collection
            IMongoCollection<BillsPaid> collection = this.getCollection();
            collection.InsertOneAsync(newBillsPaid);
        }


        public List<BillsPaid> getListBillsPaid()
        {
            IMongoCollection<BillsPaid> collection = this.getCollection();
            List<BillsPaid> billsPaid = collection.Find(new BsonDocument()).ToList();
            return billsPaid;
        }
    }
}
