using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MongoDB.Driver;
using MongoDB.Bson;
using CafeManagementApplication.types;
using MongoDB.Bson.Serialization.Attributes;
using CafeManagementApplication.config;
using System.Diagnostics;

namespace CafeManagementApplication.models
{
    class TableAggregate : Table
    {

    }
    class Table
    {
        [BsonElement("_id")]
        public BsonObjectId Id { get; set; }
        [BsonElement("tableName")]
        public string TableName { get; set; }

        [BsonElement("status")]
        public sTable Status { get; set; }
        [BsonElement("bill")]
        public BsonObjectId Bill { get; set; }
        public Table() { }
        public Table(string TableName, sTable status)
        {
            this.TableName = TableName;
            this.Status = status;
        }
    }
    class TableModel : BaseModel<Table>
    {
        private static TableModel instance;
        public static TableModel Instance
        {
            get
            {
                if (instance == null) instance = new TableModel();
                return instance;
            }
        }
        public override IMongoCollection<Table> getCollection()
        {
            IMongoDatabase db = Database.getDatabase();
            IMongoCollection<Table> collection = db.GetCollection<Table>("tables");
            return collection;
        }

        private AggregateFluentBase<BsonDocument> lookupDepthTables()
        {
            IMongoCollection<Table> collection = this.getCollection();
            dynamic table = collection.Aggregate()
                .Lookup("bills", "bill", "_id", "bill")
                .Unwind("bill")
                .Unwind("bill.products")
                .Lookup("products", "bill.products.product", "_id", "bill.products.product")
                .Unwind("bill.products.product")
                .Lookup("categories", "bill.products.product.category", "_id", "bill.products.product.category")
                .Unwind("bill.products.product.category")
                .AppendStage<BsonDocument>("{$set : {  'bill.products.product.category': '$bill.products.product.category.name'}}")
                .AppendStage<BsonDocument>("{$addFields : {'total': {$sum : {$multiply : ['$bill.products.product.price','$bill.products.amount']}}}}")
                .Group("{  _id: '$_id', status : { $first: '$status' },tableName : {$first : '$tableName'},'bill': { '$push': '$bill.products'  },'subtotal' : {$sum : '$total'}}")
                .Sort(new BsonDocument("tableName", 1));
            return table;
        }
        public BsonDocument getTableByTableName(string tableName)
        {
            FilterDefinition<BsonDocument> TableName = new BsonDocument("tableName", tableName);
            dynamic table = this.lookupDepthTables().Match(TableName).ToList();
            return table[0];
        }

        public BsonDocument getBillFromIdTable(string idTable)
        {
            FilterDefinition<BsonDocument> _id = new BsonDocument("_id", new ObjectId(idTable));
            dynamic table = this.lookupDepthTables().Match(_id).ToList();
            return table[0];
            
        }
        public List<BsonDocument> getListTable()
        {
            IMongoCollection<Table> collection = this.getCollection();
            dynamic table = this.lookupDepthTables().ToList();
            return table;
        }
        public void addTable(Table newTable)
        {
            IMongoCollection<Table> collection = this.getCollection();
            collection.InsertOneAsync(newTable);
        }
    }
}
