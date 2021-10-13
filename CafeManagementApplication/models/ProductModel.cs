using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Linq;
using CafeManagementApplication.config;

namespace CafeManagementApplication.models
{
    class Product
    {
        [BsonElement("_id")]
        public BsonObjectId Id { get; set; }
        [BsonElement("name")]
        public string NameProduct { get; set; }
        [BsonElement("price")]
        public int Price { get; set; }
        [BsonElement("category")]
        public BsonObjectId Category { get; set; }
    }
    class ProductModel : BaseModel<Product>
    {
        private static ProductModel instance;
        public static ProductModel Instance
        {
            get
            {
                if (instance == null) instance = new ProductModel();
                return instance;
            }
        }
        public override IMongoCollection<Product> getCollection()
        {
            IMongoDatabase db = Database.getDatabase();
            IMongoCollection<Product> collection = db.GetCollection<Product>("products");
            return collection;
        }

        public List<BsonDocument> getListProduct()
        {
            IMongoCollection<Product> collection = getCollection();
            dynamic listProduct = collection.Aggregate()
                .Lookup("categories", "category", "_id", "category")
                .Unwind("category")
                .AppendStage<BsonDocument>("{$set : {'category' : '$category.name'}}")
                .ToList();
            return listProduct;
        }
        public void addProduct(Product newProduct, string nameCategory)
        {
            IMongoCollection < Product > collection = getCollection();
            FilterDefinition < Category > filter = new BsonDocument("name", nameCategory);
            BsonObjectId id = ObjectId.GenerateNewId();
            if (!CategoryModel.Instance.checkCategory(filter))
            {
                CategoryModel.Instance.addCategory(new Category { Id = id, NameCategory = nameCategory });
                Product product = new Product { NameProduct = newProduct.NameProduct, Category = id, Price = newProduct.Price };
                collection.InsertOneAsync(product);
            }
            else {
                Category category = CategoryModel.Instance.getCategoryByName(nameCategory);
                Product product = new Product { NameProduct = newProduct.NameProduct, Category = category.Id , Price = newProduct.Price };
                collection.InsertOneAsync(product);
            }
        }
        public void removeProductById(string productId)
        {
            FilterDefinition<Product> filter = new BsonDocument("_id", new ObjectId(productId));
            IMongoCollection<Product> collection = this.getCollection();
            collection.DeleteOneAsync(filter);
        }
        public void updateProductById(string productId, UpdateDefinition<Product> update)
        {
            FilterDefinition<Product> filter = new BsonDocument("_id", new ObjectId(productId));
            IMongoCollection<Product> collection = getCollection();
            collection.UpdateOneAsync(filter, update);
        }
    }
}
