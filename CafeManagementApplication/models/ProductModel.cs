using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CafeManagementApplication.config;

namespace CafeManagementApplication.models
{
    class Product : BaseModel<Product>
    {
        [BsonElement("_id")]
        public BsonObjectId Id;
        [BsonElement("nameProduct")]
        public string NameProduct;
        [BsonElement("price")]
        public int Price;
        [BsonElement("category")]
        public string Category;
        public override IMongoCollection<Product> getCollection()
        {
            IMongoDatabase db = Database.getDatabase();
            IMongoCollection<Product> collection = db.GetCollection<Product>("products");
            return collection;
        }
    }
}
