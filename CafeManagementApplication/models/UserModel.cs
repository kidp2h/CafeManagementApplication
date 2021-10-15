
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Bson;
using CafeManagementApplication.types;
using MongoDB.Bson.Serialization.Attributes;
using CafeManagementApplication.config;
using CafeManagementApplication.helpers;

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
        [BsonElement("gender")]
        public string Gender { get; set; }
        [BsonElement("username")]
        public string Username { get; set; }
        [BsonElement("password")]
        public string Password { get; set; }
        [BsonElement("role")]
        public Role Role { get; set; }
    }
    class UserModel : BaseModel<User>
    {
        private static UserModel instance;
        public static UserModel Instance
        {
            get
            {
                if (instance == null) instance = new UserModel();
                return instance;
            }
        }
        public override IMongoCollection<User> getCollection()
        {
            IMongoDatabase db = Database.getDatabase();
            IMongoCollection<User> collection = db.GetCollection<User>("users");
            return collection;
        }

        #region Add Document
        public void addUser(User newUser)
        {
            newUser.Password = Hash.hashPassword(newUser.Password);
            IMongoCollection<User> collection = this.getCollection();
            collection.InsertOneAsync(newUser);
        }
        #endregion

        #region Update Document
        public void updateUserById(string id, UpdateDefinition<User> newUpdate)
        {
            FilterDefinition<User> _id = new BsonDocument("_id", new ObjectId(id));
            IMongoCollection<User> collection = this.getCollection();
            collection.UpdateOneAsync(_id, newUpdate);
        }

        public void updateUserByUsername(string username, UpdateDefinition<User> newUpdate)
        {
            FilterDefinition<User> _username = new BsonDocument("username", username);
            IMongoCollection<User> collection = this.getCollection();
            collection.UpdateOneAsync(_username, newUpdate);
        }
        #endregion

        #region Get Document
        public User getUserById(string id)
        {
            IMongoCollection<User> collection = this.getCollection();
            BsonDocument filter = new BsonDocument("_id", new ObjectId(id));
            List<User> documents = collection.Find(filter).Limit(1).ToList();
            return documents[0];
        }
        public User getUserByUsername(string username)
        {
            IMongoCollection<User> collection = this.getCollection();
            BsonDocument filter = new BsonDocument("username", username);
            List<User> documents = collection.Find(filter).Limit(1).ToList();
            return documents[0];
        }
        public List<User> getListUser()
        {
            IMongoCollection<User> collection = this.getCollection();
            List<User> listUser = collection.Find(new BsonDocument()).ToList();
            return listUser;
        }

        #endregion

        #region Delete Document
        public void deleteUserById(string id)
        {
            FilterDefinition<User> _id = new BsonDocument("_id", new ObjectId(id));
            IMongoCollection<User> collection = this.getCollection();
            collection.DeleteOneAsync(_id);
        }
        public void deleteUserByUsername(string username)
        {
            FilterDefinition<User> _username = new BsonDocument("username", username);
            IMongoCollection<User> collection = this.getCollection();
            collection.DeleteOneAsync(_username);
        }
        #endregion

        public List<dynamic> checkAccount(string username, string password)
        {
            IMongoCollection<User> collection = this.getCollection();
            BsonDocument filter = new BsonDocument ("username", username);
            List<User> documents = collection.Find(filter).ToList();
            if(documents.Count != 0)
            {
                return new List<dynamic> { documents[0].Role, Hash.verifyPassword(password, documents[0].Password), documents[0] };
            }
            else
            {
                return new List<dynamic> { null, false };
            }
        }
        public bool isExist(string username)
        {
            IMongoCollection<User> collection = this.getCollection();
            BsonDocument filter = new BsonDocument("username", username);
            List<User> documents = collection.Find(filter).ToList();
            if (documents.Count != 0) return true;
            return false;
        }
    }
}
