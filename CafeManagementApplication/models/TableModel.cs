using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Bson;
using CafeManagementApplication.types;
using MongoDB.Bson.Serialization.Attributes;
using CafeManagementApplication.config;
using System.Threading;
using CafeManagementApplication.views;
using System;

namespace CafeManagementApplication.models
{
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
            IMongoCollection<Table> collection = getCollection();
            AggregateUnwindOptions<BsonDocument> options = new AggregateUnwindOptions<BsonDocument> {
                PreserveNullAndEmptyArrays = true,
            };

            dynamic table = collection.Aggregate()
                .Lookup("bills", "bill", "_id", "bill")
                .Unwind("bill", options)
                .Unwind("bill.products", options)
                .Lookup("products", "bill.products.product", "_id", "bill.products.product")
                .Unwind("bill.products.product",options)
                .Lookup("categories", "bill.products.product.category", "_id", "bill.products.product.category")
                .Unwind("bill.products.product.category", options)
                .AppendStage<BsonDocument>("{$set : {  'bill.products.product.category': '$bill.products.product.category.name'}}")
                .AppendStage<BsonDocument>("{$addFields : {'total': {$sum : {$multiply : ['$bill.products.product.price','$bill.products.amount']}}}}")
                .Group("{  _id: '$_id', status : { $first: '$status' },tableName : {$first : '$tableName'}, 'billId' : {'$first': '$bill._id'},'bill': { '$push': '$bill.products'  },'subtotal' : {$sum : '$total'}}")
                .Sort(new BsonDocument("tableName", 1));
            return table;
        }

        #region Add Document
        public void addTable(Table newTable)
        {
            Table table = new Table
            {
                Id = ObjectId.GenerateNewId(),
                TableName = newTable.TableName,
                Status = sTable.EMPTY,
                Bill = ObjectId.GenerateNewId()

            };
            IMongoCollection<Table> collection = getCollection();
            collection.InsertOneAsync(table);
            Thread tBill = new Thread(() =>
            {
                BillModel.Instance.addBill(table.Id, table.Bill);
            });
            tBill.Start();

        }
        #endregion

        #region Update Document
        public void updateStatusForTable(FilterDefinition<Table> filter, sTable status)
        {
            IMongoCollection<Table> collection = getCollection();
            UpdateDefinition<Table> update = new BsonDocument
            {
                {"$set", new BsonDocument
                {
                    {"status", status}
                } }
            };
            collection.UpdateOneAsync(filter, update);
        }
        public void updateBillForTable(string idTable, string idBill)
        {
            FilterDefinition<Table> _idTable = new BsonDocument("_id", new ObjectId(idTable));
            IMongoCollection<Table> collection = getCollection();
            UpdateDefinition<Table> update = new BsonDocument
            {
                {"$set", new BsonDocument
                {
                    {"bill", new ObjectId(idBill)}
                } }
            };
            collection.UpdateOneAsync(_idTable, update);
        }

        public void updateTableByNameTable(string nameTable, UpdateDefinition<Table> update)
        {
            FilterDefinition<Table> _nameTable = new BsonDocument("tableName", nameTable);
            IMongoCollection<Table> collection = getCollection();
            collection.UpdateOneAsync(_nameTable, update);
        }
        public void updateTableByIdTable(string idTable, UpdateDefinition<Table> update)
        {
            FilterDefinition<Table> _nameTable = new BsonDocument("_id", new ObjectId(idTable) );
            IMongoCollection<Table> collection = getCollection();
            collection.UpdateOneAsync(_nameTable, update);
        }

        public void updateTable(string idTable, string oldBillId)
        {
            FilterDefinition<Table> filter = new BsonDocument("_id", idTable);
            BsonObjectId _idTable = new BsonObjectId(idTable);
            BsonObjectId newIdBill = ObjectId.GenerateNewId();
            BillModel.Instance.addBill(_idTable, newIdBill);
            Thread s1 = new Thread(() =>
            {
                UpdateDefinition<Table> update = new BsonDocument
                {
                    {"$set", new BsonDocument
                    {
                        {"bill", newIdBill},
                        {"status",sTable.EMPTY }
                    } }
                };
                TableModel.Instance.updateTableByIdTable(idTable, update);
            });
            s1.IsBackground = true;
            s1.Start();
            Thread s2 = new Thread(() =>
            {
                UpdateDefinition<Bill> update = new BsonDocument
                {
                        {"$set", new BsonDocument{
                            {"paid", true }, 
                            {"paidTime", DateTime.Now}
                        }}
                };
                BillModel.Instance.updateBill(oldBillId, update);
            });
            s2.IsBackground = true;
            s2.Start();
        }
        #endregion

        #region Get Document
        public dynamic getTableByFilter(FilterDefinition<BsonDocument> filter)
        {
            dynamic table = lookupDepthTables().Match(filter).ToList();
            if (table.Count != 0) return table[0];
            return null;
        }

        public dynamic getBillFromIdTable(string idTable)
        {
            FilterDefinition<BsonDocument> _id = new BsonDocument("_id", new ObjectId(idTable));
            dynamic table = lookupDepthTables().Match(_id).ToList();
            if (table.Count != 0) return table[0];
            return null;
        }
        public List<Table> getListTable()
        {
            IMongoCollection<Table> collection = getCollection();
            dynamic table = collection.Find(new BsonDocument()).ToList();
            return table;
        }
        #endregion

        #region Delete Document
        public void deleteTable(string idTable)
        {
            FilterDefinition<Table> _idTable = new BsonDocument("_id", new ObjectId(idTable));
            IMongoCollection<Table> collection = getCollection();
            collection.DeleteOneAsync(_idTable);
        }
        public void deleteTableByTableName(string tableName)
        {
            FilterDefinition<Table> _tableName = new BsonDocument("tableName", tableName);
            IMongoCollection<Table> collection = getCollection();
            collection.DeleteOneAsync(_tableName);
        }
        #endregion
    }
}
