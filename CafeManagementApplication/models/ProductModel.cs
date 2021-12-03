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
        public BsonString NameProduct { get; set; }
        [BsonElement("price")]
        public BsonInt32 Price { get; set; }
        [BsonElement("category")]
        public BsonObjectId Category { get; set; }
        public string CategoryName { get; set; }
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

            //lấy cái collection là products ở trong database (db)
            //1 collection có kiểu dữ liệu là Product
            IMongoCollection<Product> collection = db.GetCollection<Product>("products");
            return collection;
        }

        #region Add Document
        public void addProduct(Product newProduct, string nameCategory)
        {
            IMongoCollection<Product> collection = getCollection();

            //tạo ra một đối tượng filter với kiểu dữ liệu là category có cái key là name: nameCategory
            FilterDefinition<Category> filter = new BsonDocument("name", nameCategory);        
            BsonObjectId id = ObjectId.GenerateNewId(); // tự tạo ra một Id mới 
            if (!CategoryModel.Instance.checkCategory(filter))
            {   //nếu hổng có loại đó thì gọi hàm addCategory để thêm mới 1 object loại vào collection Category của database 
                CategoryModel.Instance.addCategory(new Category { Id = id, NameCategory = nameCategory });

                // tạo mới 1 đối tượng product 
                Product product = new Product { NameProduct = newProduct.NameProduct, Category = id, Price = newProduct.Price };
                collection.InsertOneAsync(product); // thêm vào collection product database
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

        public void updateProductByNameProduct(string nameProduct, UpdateDefinition<Product> update)
        {   
            // tạo ra một đối tượng lọc có kiểu dữ liệu Product (filter) từ một bsondocument có trường name: nameProduct
            FilterDefinition<Product> filter = new BsonDocument("name", nameProduct);
            //tạo ra một đối tượng collection = getCollection
            IMongoCollection<Product> collection = getCollection();           
            collection.UpdateOneAsync(filter, update);
        }
        #endregion

        #region Get Document
        public List<BsonDocument> getListProduct()
        {
            IMongoCollection<Product> collection = getCollection();
            dynamic listProduct = collection.Aggregate()
                // category thứ 2 là local ( local field) , _id là foriegn field join vô categories thì nó sẽ trả về 1 document, sau đó gán lại cho category cuối  
                .Lookup("categories", "category", "_id", "category") //(trả về 1 mảng)
                .Unwind("category") // vì tại lookup trả về 1 mảng object, nên phải unwind để tách mảng ra
                .AppendStage<BsonDocument>("{$set : {'category' : '$category.name'}}") // đặt object category thành tên của category đó 
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

        public BsonObjectId getIdProductByName(string nameProduct)
        {
            FilterDefinition<Product> filter = new BsonDocument("name", nameProduct);
            IMongoCollection<Product> collection = getCollection();
            List<Product> product = collection.Find(filter).ToList();
            return product[0].Id;
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

        #region Check Document 
        public bool isExist(string nameProduct)
        {
            FilterDefinition<Product> filter = new BsonDocument("name", nameProduct);
            IMongoCollection<Product> collection = getCollection();
            List<Product> products = collection.Find(filter).ToList();
            if (products.Count != 0)
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