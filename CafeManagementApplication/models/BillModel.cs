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
    class Bill : BaseModel<Bill>
    {
        [BsonElement("_id")]
        public string Id;
        [BsonElement("products")]
        public List<IOderItems> ProductsOrdered;
        [BsonElement("subtotal")]
        public int Subtotal;
        [BsonElement("table"), BsonRepresentationAttribute(BsonType.ObjectId)]
        public string TableId;

        public override IMongoCollection<Bill> getCollection()
        {
            IMongoDatabase db = Database.getDatabase();
            IMongoCollection<Bill> collection = db.GetCollection<Bill>("bills");
            return collection;
        }
    }
}
