﻿using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using CafeManagementApplication.types;
using CafeManagementApplication.config;
using System.Diagnostics;

namespace CafeManagementApplication.models
{
    class ListItemOrder : BsonArray
    {
        public BsonObjectId product { get; set; }
        public int amount { get; set; }
    }

    class Bill
    {
        [BsonElement("_id")]
        public BsonObjectId Id { get; set; }
        [BsonElement("products")]
        public ListItemOrder ProductsOrdered { get; set; }
        [BsonElement("subtotal")]
        public int Subtotal { get; set; }
        [BsonElement("table")]
        public BsonObjectId TableId { get; set; }
    }
    class BillModel : BaseModel<Bill>
    {
        private static BillModel instance;
        public static BillModel Instance
        {
            get
            {
                if (instance == null) instance = new BillModel();
                return instance;
            }
        }

        public override IMongoCollection<Bill> getCollection()
        {
            IMongoDatabase db = Database.getDatabase();
            IMongoCollection<Bill> collection = db.GetCollection<Bill>("bills");
            return collection;
        }

        private AggregateFluentBase<BsonDocument> lookupDepthBills()
        {
            IMongoCollection<Bill> collection = this.getCollection();
            dynamic bill = collection.Aggregate()
                .Unwind("products")
                .Lookup("tables", "table", "_id", "table")
                .Unwind("table")
                .Lookup("products", "products.product", "_id", "products.product")
                .Unwind("products.product")
                .Lookup("categories", "products.product.category", "_id", "products.product.category")
                .Unwind("products.product.category")
                .AppendStage<BsonDocument>("{$set : {  'products.product.category': '$products.product.category.name'}}")
                .Project(new BsonDocument("table.bill", 0))
                .Group("{_id: '$_id',table : {$first : '$table'},'products': {$push: '$products'},subtotal : {$sum : {$multiply : ['$products.product.price','$products.amount']}}}");
            return bill;
        }
        public void addBill(Bill bill)
        {
            IMongoCollection<Bill> collection = this.getCollection();
            collection.InsertOneAsync(bill);
        }
        public BsonDocument getBillById(string idBill)
        {
            FilterDefinition<BsonDocument> _idBill = new BsonDocument("_id", new ObjectId(idBill));
            dynamic bill = this.lookupDepthBills().Match(_idBill).ToList();
            return bill[0];
        }
        public BsonDocument getTableFromIdBill(string idBill)
        {
            FilterDefinition<BsonDocument> _idBill = new BsonDocument("_id", new ObjectId(idBill));
            dynamic bill = this.lookupDepthBills().Match(_idBill).ToList();
            return bill[0]["table"];
        }
        public void addProductToBill(string idBill, string idProduct)
        {
            BsonDocument _idBill = new BsonDocument("_id", new ObjectId(idBill));
            IMongoCollection<Bill> collection = this.getCollection();
            BsonDocument filter = new BsonDocument{
                {"_id",new ObjectId(idBill) },
                {"products.product", new ObjectId(idProduct) }
            };

            List<Bill> listProduct = collection.Find(filter).ToList();
            if(listProduct.Count == 0)
            {
                UpdateDefinition<Bill> update = new BsonDocument
                    {
                        {"$push", new BsonDocument{
                            {"products", new BsonDocument{
                                {"product", new ObjectId(idProduct)},
                                {"amount",1 }
                            }
                            }}
                        }
                    };
                collection.UpdateOne(_idBill, update);
            }
            else
            {
                UpdateDefinition<Bill> update = new BsonDocument
                    {
                        {"$inc", new BsonDocument
                        {
                            {"products.$.amount" ,1}
                        } }
                    };
                collection.UpdateOne(filter, "{$inc :{'products.$.amount' : 1}}");
            }
        }

        public void removeProductFromBill(string idBill, string idProduct)
        {
            BsonDocument _idBill = new BsonDocument("_id", new ObjectId(idBill));
            IMongoCollection<Bill> collection = this.getCollection();
            BsonDocument filter = new BsonDocument{
                {"_id",new ObjectId(idBill) },
                {"products.product", new ObjectId(idProduct) }
            };
            List<Bill> listProduct = collection.Find(filter).ToList();
            UpdateDefinition<Bill> update = new BsonDocument
                    {
                        {"$pull", new BsonDocument{
                            {"products", new BsonDocument{
                                {"product", new ObjectId(idProduct)}
                            }
                            }}
                        }
                    };
            collection.UpdateOne(_idBill, update);
        }
    }
}
