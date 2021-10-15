using MongoDB.Driver;
using CafeManagementApplication.config;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace CafeManagementApplication.models
{
    class Category
    {
        [BsonElement("_id")]
        public BsonObjectId Id { get; set; }
        [BsonElement("name")]
        public BsonString NameCategory { get; set; }
    }
    class CategoryModel : BaseModel<Category>
    {
        private static CategoryModel instance;
        public static CategoryModel Instance
        {
            get
            {
                if (instance == null) instance = new CategoryModel();
                return instance;
            }
        }

        public override IMongoCollection<Category> getCollection()
        {
            IMongoDatabase db = Database.getDatabase();
            IMongoCollection<Category> collection = db.GetCollection<Category>("categories");
            return collection;
        }

        #region Add Document
        public void addCategory(Category newCategory)
        {
            IMongoCollection<Category> collection = this.getCollection();
            collection.InsertOneAsync(newCategory);
        }
        #endregion

        #region Update Document
        public void updateCategoryByName(string nameCategory, UpdateDefinition<Category> update)
        {
            IMongoCollection<Category> collection = this.getCollection();
            FilterDefinition<Category> filter = new BsonDocument { { "name", nameCategory } };
            collection.UpdateOneAsync(filter, update);
        }
        #endregion

        #region Get Document
        public Category getCategoryByName(string nameCategory)
        {
            IMongoCollection<Category> collection = this.getCollection();
            List<Category> category = collection.Find(new BsonDocument("name", nameCategory)).ToList();
            return category[0];
        }
        public List<Category> getListCategory()
        {
            IMongoCollection<Category> collection = this.getCollection();
            List<Category> category = collection.Find(new BsonDocument()).ToList();
            return category;
        }
        #endregion

        #region Delete Document
        public void deleteCategory(string idCategory)
        {
            IMongoCollection<Category> collection = this.getCollection();
            FilterDefinition<Category> filter = new BsonDocument { { "_id", new ObjectId(idCategory) } };
            collection.DeleteOneAsync(filter);
        }
        public void deleteCategoryByName(string nameCategory)
        {
            IMongoCollection<Category> collection = this.getCollection();
            FilterDefinition<Category> filter = new BsonDocument { { "name", nameCategory } };
            collection.DeleteOneAsync(filter);
        }
        #endregion


        #region Check Document 
        public bool checkCategory(FilterDefinition<Category> category)
        {
            IMongoCollection<Category> collection = this.getCollection();
            List<Category> result = collection.Find(category).ToList();
            if (result.Count != 0) return true;
            return false;
        }
        public bool checkExist(string nameCategory)
        {
            FilterDefinition<Category> filter = new BsonDocument("name", nameCategory);
            IMongoCollection<Category> collection = getCollection();
            List<Category> categories = collection.Find(filter).ToList();
            if (categories.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion



    }
}
