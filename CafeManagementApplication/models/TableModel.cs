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
    class Table : BaseModel<Table>
    {
        [BsonElement("_id")]
        public BsonObjectId Id { get; set; }
        [BsonElement("tableName")]
        public string TableName { get; set; }

        [BsonElement("status")]
        public sTable status { get; set; }
        [BsonElement("bill")]
        public BsonObjectId Bill { get; set; }

        public override IMongoCollection<Table> getCollection()
        {
            IMongoDatabase db = Database.getDatabase();
            IMongoCollection<Table> collection = db.GetCollection<Table>("tables");
            return collection;
        }

        private IAggregateFluent<dynamic> lookupDepthTable()
        {
            IMongoCollection<Table> collection = this.getCollection();
            dynamic table = collection.Aggregate()
                .Lookup("bills", "bill", "_id", "bill")
                .Unwind("bill")
                .Unwind("bill.products")
                .AppendStage<BsonDocument>("{$addFields : {  'subtotal':{    $add : ['$bill.subtotal']  }}}")
                .AppendStage<BsonDocument>("{$addFields : {  'status': '$status'}}")
                .Lookup("products", "bill.products.product", "_id", "bill.products.product")
                .Unwind("bill.products.product")
                .Lookup("categories", "bill.products.product.category", "_id", "bill.products.product.category")
                .Unwind("bill.products.product.category")
                .AppendStage<BsonDocument>("{$set : {  'bill.products.product.category': '$bill.products.product.category.name'}}")
                .Group("{  _id: '$_id', status : { $first: '$status' }, subtotal : {$first : '$subtotal'},tableName : {$first : '$tableName'},'bill': { '$push': '$bill.products'  }}");
            return table;
        }
        public BsonDocument getTableByTableName(string tableName)
        {
            FilterDefinition<dynamic> TableName = new BsonDocument("tableName", tableName);
            dynamic table = this.lookupDepthTable().Match(TableName).ToList();
            return table;
        }

        public BsonDocument getBillFromIdTable(string idTable)
        {
            FilterDefinition<dynamic> _id = new BsonDocument("_id", new ObjectId(idTable));
            dynamic table = this.lookupDepthTable().Match(_id).ToList();
            return table["bill"][0];
            
        }
        public List<BsonDocument> getListTable()
        {
            IMongoCollection<Table> collection = this.getCollection();
            dynamic table = this.lookupDepthTable().ToList();
            return table;
        }
        public void addTable(Table newTable)
        {
            IMongoCollection<Table> collection = this.getCollection();
            collection.InsertOne(newTable);
        }
    }
}
