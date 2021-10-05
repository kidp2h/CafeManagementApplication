using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using CafeManagementApplication.types;
using MongoDB.Bson.Serialization.Attributes;
using CafeManagementApplication.config;
using System.Diagnostics;

namespace CafeManagementApplication.models
{
    class User
    {
        [BsonElement("_id")]
        public BsonObjectId Id { get; set; }
        [BsonElement("fullName")]
        public string Fullname { get; set; }
        [BsonElement("age")]
        public int Age { get; set; }
        [BsonElement("username")]
        public string Username { get; set; }
        [BsonElement("password")]
        public string Password { get; set; }
        [BsonElement("role")]
        public Role Role { get; set; }

        public IMongoCollection<User> getCollection()
        {
            IMongoDatabase db = Database.getDatabase();
            IMongoCollection<User> collection = db.GetCollection<User>("users");
            return collection;
        }
        public List<User> getUserById(string id)
        {
            IMongoCollection<User> collection = this.getCollection();
            BsonDocument filter = new BsonDocument("_id", new ObjectId(id));
            List<User> documents = collection.Find(filter).Limit(1).ToList();
            return documents;
        }


        


    }
}
