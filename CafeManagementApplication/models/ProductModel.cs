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

        #region Add Document
        public void addProduct(Product newProduct, string nameCategory)
        {
            IMongoCollection<Product> collection = getCollection();
            FilterDefinition<Category> filter = new BsonDocument("name", nameCategory);
            BsonObjectId id = ObjectId.GenerateNewId();
            if (!CategoryModel.Instance.checkCategory(filter))
            {
                CategoryModel.Instance.addCategory(new Category { Id = id, NameCategory = nameCategory });
                Product product = new Product { NameProduct = newProduct.NameProduct, Category = id, Price = newProduct.Price };
                collection.InsertOneAsync(product);
            }
            else
            {
                Category category = CategoryModel.Instance.getCategoryByName(nameCategory);
                Product product = new Product { NameProduct = newProduct.NameProduct, Category = category.Id, Price = newProduct.Price };
                collection.InsertOneAsync(product);
            }
        }
        #endregion

        #region Update Document
        public void updateProductById(string productId, string nameProduct, int price, string category)
        {
            FilterDefinition<Product> filter = new BsonDocument("_id", new ObjectId(productId));
            FilterDefinition<Category> cfilter = new BsonDocument("name", category);
            IMongoCollection<Product> collection = getCollection();
            if (!CategoryModel.Instance.checkCategory(cfilter))
            {
                BsonObjectId id = ObjectId.GenerateNewId();
                CategoryModel.Instance.addCategory(new Category { Id = id, NameCategory = category });
                UpdateDefinition<Product> update = new BsonDocument
                {
                    {"$set", new BsonDocument{
                        {"name", nameProduct},
                        {"price", price },
                        {"category",id }
                    }}
                };
                collection.UpdateOneAsync(filter, update);
            }
            else
            {
                UpdateDefinition<Product> update = new BsonDocument
                {
                    {"$set", new BsonDocument{
                        {"name", nameProduct},
                        {"price", price }
                    }}
                };
                collection.UpdateOneAsync(filter, update);
            }

        }

        public void updateProductByNameProduct(string nameProduct, int price, string category)
        {
            FilterDefinition<Product> filter = new BsonDocument("name", nameProduct);
            FilterDefinition<Category> cfilter = new BsonDocument("name", category);
            IMongoCollection<Product> collection = getCollection();
            if (!CategoryModel.Instance.checkCategory(cfilter))
            {
                BsonObjectId id = ObjectId.GenerateNewId();
                CategoryModel.Instance.addCategory(new Category { Id = id, NameCategory = category });
                UpdateDefinition<Product> update = new BsonDocument
                {
                    {"$set", new BsonDocument{
                        {"name", nameProduct},
                        {"price", price },
                        {"category",id }
                    }}
                };
                collection.UpdateOneAsync(filter, update);
            }
            else
            {
                UpdateDefinition<Product> update = new BsonDocument
                {
                    {"$set", new BsonDocument{
                        {"name", nameProduct},
                        {"price", price }
                    }}
                };
                collection.UpdateOneAsync(filter, update);
            }
        }
        #endregion

        #region Get Document
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

        public List<BsonDocument> getListProductByCategory(string idCategory)
        {
            IMongoCollection<Product> collection = getCollection();
            dynamic listProduct = collection.Aggregate()
                .Lookup("categories", "category", "_id", "category")
                .Unwind("category")
                .Match(new BsonDocument("category._id", new ObjectId(idCategory)))
                .AppendStage<BsonDocument>("{$set : {'category' : '$category.name'}}")
                .ToList();
            return listProduct;
        }
        #endregion

        #region Delete Document
        public void deleteProductById(string productId)
        {
            FilterDefinition<Product> filter = new BsonDocument("_id", new ObjectId(productId));
            IMongoCollection<Product> collection = this.getCollection();
            collection.DeleteOneAsync(filter);
        }
        public void deleteProductByNameProduct(string nameProduct)
        {
            FilterDefinition<Product> filter = new BsonDocument("name", nameProduct);
            IMongoCollection<Product> collection = this.getCollection();
            collection.DeleteOneAsync(filter);
        }
        #endregion

    }
}