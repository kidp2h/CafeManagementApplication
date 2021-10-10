using MongoDB.Driver;
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

    class Bill
    {
        [BsonElement("_id")]
        public BsonObjectId Id { get; set; }
        [BsonElement("products")]
        public List<IOderItems> ProductsOrdered { get; set; }
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

        public AggregateFluentBase<BsonDocument> lookupDepthBills()
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
            dynamic bill = this.lookupDepthBills().Match(new BsonDocument("_id", new ObjectId(idBill))).ToList();
            return bill[0];
        }
        public BsonDocument getTableFromIdBill(string idBill)
        {
            /*FilterDefinition<dynamic> _idBill = new BsonDocument("_id", new ObjectId(idBill));*/
            dynamic bill = this.lookupDepthBills().Match(new BsonDocument("_id", new ObjectId(idBill))).ToList();
            return bill[0]["table"];
        }
    }
}
