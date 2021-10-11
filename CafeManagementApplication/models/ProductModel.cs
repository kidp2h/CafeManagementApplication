﻿using MongoDB.Driver;
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
    class Product
    {
        [BsonElement("_id")]
        public BsonObjectId Id { get; set; }
        [BsonElement("nameProduct")]
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

        public BsonDocument getListProduct()
        {
            IMongoCollection<Product> collection = this.getCollection();
            dynamic listProduct = collection.Aggregate()
                .Lookup("categories", "category", "_id", "category")
                .Unwind("category")
                .AppendStage<BsonDocument>("{$set : {'category' : '$category.name'}}")
                .ToList();
            return listProduct;
        }
        public void addProduct(Product newProduct)
        {
            IMongoCollection < Product > collection = this.getCollection();
            collection.InsertOneAsync(newProduct);
        }
    }
}
