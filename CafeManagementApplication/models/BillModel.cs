using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using CafeManagementApplication.types;
using CafeManagementApplication.config;

namespace CafeManagementApplication.models
{

    class Bill
    {
        [BsonElement("_id")]
        public BsonObjectId Id { get; set; }
        [BsonElement("products")]
        public List<IOderItems> ProductsOrdered { get; set; }
        [BsonElement("subtotal")]
        public int Subtotal { get; set; }
        [BsonElement("table")]
        public BsonObjectId TableId { get; set; }
    }
    class BillModel : BaseModel<Bill>
    {
        private static BillModel instance;
        public static BillModel Instance
        {
            get
            {
                if (instance == null) instance = new BillModel();
                return instance;
            }
        }

        public override IMongoCollection<Bill> getCollection()
        {
            IMongoDatabase db = Database.getDatabase();
            IMongoCollection<Bill> collection = db.GetCollection<Bill>("bills");
            return collection;
        }
    }
}
