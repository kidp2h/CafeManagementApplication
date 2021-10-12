using CafeManagementApplication.helpers;
using MongoDB.Driver;

namespace CafeManagementApplication.config
{
    class Database
    {
        private MongoClient client;
        static private IMongoDatabase database;
        public Database()
        {
            this.connectDatabase();
        }

        public void connectDatabase()
        {
            string url = Config.GetValueFromKey("url");
            MongoClientSettings settings = MongoClientSettings.FromConnectionString(url);
            MongoClient mongoClient = new MongoClient(settings);
            this.client = mongoClient;
            IMongoDatabase db = this.client.GetDatabase("Cafe_Management_Application");
            Database.database = db;
        }

        public static  IMongoDatabase getDatabase()
        {
            return database;
        }
    }
}
