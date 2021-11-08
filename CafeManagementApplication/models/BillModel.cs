using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson.Serialization.Attributes;
using CafeManagementApplication.config;
using System;

namespace CafeManagementApplication.models
{
    class ListItemOrder : BsonArray
    {
        public BsonObjectId product { get; set; }
        public int amount { get; set; }
    }

    class Bill
    {
        // Định nghĩa các trường của model Bill
        [BsonElement("_id")]
        public BsonObjectId Id { get; set; }
        [BsonElement("products")]
        public ListItemOrder ProductsOrdered { get; set; }
        [BsonElement("table")]
        public BsonObjectId TableId { get; set; }
        [BsonElement("paid")]
        public BsonBoolean Paid { get; set; }
        [BsonElement("paidTime")]
        public DateTime PaidTime { get; set; }
        [BsonElement("sale")]
        public int Sale { get; set; }
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
        // Hàm lấy collection trong database bill hay nói cách khác là lấy tất cả các document trong database bill
        public override IMongoCollection<Bill> getCollection()
        {
            // lấy database
            IMongoDatabase db = Database.getDatabase();
            IMongoCollection<Bill> collection = db.GetCollection<Bill>("bills");
            return collection;
        }

        #region Add Document
        // Thêm bill bàn và insert vào database
        public void addBill(BsonObjectId table, BsonObjectId bill)
        {
            // lấy collection
            IMongoCollection<Bill> collection = this.getCollection();
            // Tạo document bill mới
            Bill newBill = new Bill
            {
                Id = bill,
                ProductsOrdered = new ListItemOrder(),
                TableId = table,
                Paid = false,
                PaidTime = new DateTime(),
                Sale = 0
            };
            collection.InsertOne(newBill);
        }
        // Thêm món vào bill
        public void addProductToBill(string idBill, string idProduct, int amount)
        {
            // Tạo một đối tượng BsonDocument với trường _id có kiểu là ObjectId
            BsonDocument _idBill = new BsonDocument("_id", new ObjectId(idBill));
            IMongoCollection<Bill> collection = this.getCollection();
            // tạo một đối tượng BsonDocument làm điều kiện lọc
            BsonDocument filter = new BsonDocument{
                {"_id",new ObjectId(idBill) },
                {"products.product", new ObjectId(idProduct) },
                {"paid", false }
            };
            // Tìm product theo điều kiện lọc
            List<Bill> listProduct = collection.Find(filter).ToList();
            // nếu không tồn tại thì push product vào mảng products trong collection bills
            if (listProduct.Count == 0)
            {
                UpdateDefinition<Bill> update = new BsonDocument
                    {
                        {"$push", new BsonDocument{
                            {"products", new BsonDocument{
                                {"product", new ObjectId(idProduct)},
                                {"amount",amount }
                            }
                            }}
                        }
                    };
                collection.UpdateOne(_idBill, update);
            }
            // ngược lại, nếu tồn tại thì tăng amount lên một
            else
            {
                UpdateDefinition<Bill> update = new BsonDocument
                    {
                        {"$inc", new BsonDocument
                        {
                            {"products.$.amount" ,amount}
                        } }
                    };
                collection.UpdateOne(filter, update);
            }
        }

        #endregion

        #region Update Document
        public void updateBill(string idBill, UpdateDefinition<Bill> update)
        {
            BsonDocument _idBill = new BsonDocument("_id", new ObjectId(idBill));
            IMongoCollection<Bill> collection = getCollection(); 
            collection.UpdateOne(_idBill, update);
        }
        #endregion

        #region Get document
        // Tìm kiếm sâu 
        private AggregateFluentBase<BsonDocument> lookupDepthBills()
        {
            IMongoCollection<Bill> collection = this.getCollection();
            dynamic bill = collection.Aggregate()
                // bung mảng products trong collection bill
                .Unwind("products")
                // tìm kiếm những document từ collection tables có _id = table và lưu kết quả thành trường table
                .Lookup("tables", "table", "_id", "table")
                // bung mảng object table
                .Unwind("table")
                // Tìm kiếm từ products collection có product trong object products có id = _id trong collection products và lưu kết quả thành trường product trong object products
                .Lookup("products", "products.product", "_id", "products.product")
                // bung mảng product trong object products
                .Unwind("products.product")
                // Tìm kiếm từ categories collection có categoryId trong object products.product bằng với _id trong bảng collection categories
                .Lookup("categories", "products.product.category", "_id", "products.product.category")
                // Bung mảng category trong object products.product
                .Unwind("products.product.category")
                // Thêm một tầng với aggregate là set để set giá trị category trong object products.product bằng với name trong object products.product.category để kết quả gọn hơn dễ tương tác hơn
                .AppendStage<BsonDocument>("{$set : {  'products.product.category': '$products.product.category.name'}}")
                // loại đi trường bill dư thừa trong object table 
                .Project(new BsonDocument("table.bill", 0))
                // Nhóm các document theo trường _id có trường table, product, paid, paidTime, percentSale, subtotal và tính tổng giá bill 
                .Group("{_id: '$_id',table : {$first : '$table'},'products': {$push: '$products'},paid : {$first : '$paid'},paidTime : {$first : '$paidTime'},percentSale : {'$first':'$sale'},sale:{'$first':'$sale'},subtotal : {$sum : {$multiply : ['$products.product.price','$products.amount']}}}")
                // Thêm một tầng với aggregate là addFields để thêm trường sale  tính giá bill sau khi sale x%
                .AppendStage<BsonDocument>("{$addFields :{'sale': {$subtract : ['$subtotal',{$multiply : ['$subtotal',{$divide : ['$sale',100]}]}]}}}")
                // Chỉ lấy các document có subtotal greater than 0 ( >  0)
                .Match(new BsonDocument { { "subtotal", new BsonDocument { { "$gt", 0 } } } });

            return bill;
        }

        public BsonDocument getBillById(string idBill)
        {
            FilterDefinition<BsonDocument> _idBill = new BsonDocument("_id", new ObjectId(idBill));
            dynamic bill = this.lookupDepthBills().Match(_idBill).ToList();
            return bill[0];
        }

        public List<BsonDocument> listBillByDateTime(int day, int month, int year)
        {
            DateTime d1 = new DateTime(year, month, day, 0, 0, 0, DateTimeKind.Utc);
            DateTime d2 = new DateTime(year, month, day, 23, 59, 59, DateTimeKind.Utc);
            FilterDefinition<BsonDocument> match = new BsonDocument { { "paidTime", new BsonDocument { { "$gte", d1 }, { "$lte",d2 } } },{ "paid", new BsonBoolean(true)} };
            dynamic bill = this.lookupDepthBills().Match(match).ToList();
            return bill;
        }
        public List<BsonDocument> getListBill ()
        {
            dynamic bill = this.lookupDepthBills().Match(new BsonDocument{ { "paid", new BsonBoolean(true) } }).ToList();
            return bill;
        }
        public Bill getBillByFilter(FilterDefinition<Bill> filter)
        {
            List<Bill> bill = getCollection().Find(filter).ToList();
            if (bill.Count != 0) return bill[0];
            return null;
        }
        public BsonDocument getTableFromIdBill(string idBill)
        {
            FilterDefinition<BsonDocument> _idBill = new BsonDocument("_id", new ObjectId(idBill));
            dynamic bill = this.lookupDepthBills().Match(_idBill).ToList();
            return bill[0]["table"];
        }
        #endregion

        #region Delete Document
        public void deleteProductFromBill(string idBill, string idProduct)
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
        #endregion

    }
}
