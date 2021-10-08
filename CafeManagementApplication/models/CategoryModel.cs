using MongoDB.Driver;
using CafeManagementApplication.config;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagementApplication.models
{
    class Category : BaseModel<Category>
    {
        [BsonElement("_id")]
        public BsonObjectId Id;
        [BsonElement("name")]
        public string NameCategory;
        public override IMongoCollection<Category> getCollection()
        {
            IMongoDatabase db = Database.getDatabase();
            IMongoCollection<Category> collection = db.GetCollection<Category>("categories");
            return collection;
        }
    }
}
