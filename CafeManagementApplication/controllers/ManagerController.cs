using CafeManagementApplication.helpers;
using CafeManagementApplication.models;
using CafeManagementApplication.types;
using MongoDB.Bson;
using MongoDB.Driver;
using System;

namespace CafeManagementApplication.controllers
{
    class ManagerController
    {
        private static ManagerController instance;

        public static ManagerController Instance
        {
            get
            {
                if (instance == null) instance = new ManagerController();
                return instance;
            }
        }

        private ManagerController() { }
             
        public dynamic NewData(string nameData, dynamic view)
        {
            if (nameData == "Category")
            {
                Category category = new Category();
                category.NameCategory = view.inputCategory;
                return category;
            }
            if (nameData == "Table")
            {
                Table table = new Table();
                table.TableName = view.inputTableNameText;
                table.Status = view.inputStatus;
                return table;
            }
            if (nameData == "Product")
            {

                Product product = new Product();
                // lấy dữ liệu ở 3 cái ô input trên view
                product.NameProduct = view.inputProductNameText;
                product.CategoryName = view.inputCategoryName;
                product.Price = int.Parse(view.inputPrice);
                
                // trả về đối tượng có dữ liệu
                return product;
            }
            if (nameData == "User")
            {
                User user = new User();
                user.Fullname = view.inputNameText;
                user.Age = int.Parse(view.inputAgeText);
                user.Gender = view.inputGenderText;
                user.Username = view.inputUsernameText;
                user.Password = view.inputUserpasswordText;
                user.Role = view.inputRole; 
                return user;
                
            }
            return null;
        }

        public void AddData(string nameData, dynamic data)
        {
            if (nameData == "Category")
            {
                CategoryModel.Instance.addCategory(data);
                return;
            }
            if (nameData == "Table")
            {
                TableModel.Instance.addTable(data);
                return;
            }
            if(nameData == "Product")
            {               
                ProductModel.Instance.addProduct(data, data.CategoryName);
                return;
            }    
            if (nameData == "User")
            {
                UserModel.Instance.addUser(data);
                return;
            }
        }

        public void UpdateData(string nameData, dynamic view)
        {
            if (nameData == "Category")
            {
                Category category = NewData(nameData, view);
                UpdateDefinition<Category> updateCategory = new BsonDocument
                {

                    { "$set", new BsonDocument
                        {
                            { "name", category.NameCategory},                   
                        }
                    }
                };
                CategoryModel.Instance.updateCategoryByName(view.OldCategoryName, updateCategory);
                return;
            }
            if (nameData == "Table")
            {
                Table table = NewData(nameData, view);                
                UpdateDefinition<Table> updateTable = new BsonDocument
                {

                    { "$set", new BsonDocument
                        {
                            { "tableName", table.TableName},                         
                            { "status", table.Status },
                        }
                    }
                };              
                TableModel.Instance.updateTableByNameTable(view.OldTableName, updateTable);

                return;
            }
            if (nameData == "Product")
            {
                // tạo ra một đối tượng product mới, truyền view dô để lấy dữ liệu ở view
                Product product = NewData(nameData, view);

                // tạo một đối tượng update của mongo

                UpdateDefinition<Product> updateProduct = new BsonDocument
                {
                    //hàm set để set lại thuộc tính của product trong database
                    {"$set", new BsonDocument{
                        {"name", product.NameProduct},
                        {"price", product.Price }
                    }}
                };

                //gọi hàm ở model truyền vào tên cũ của product: view.ProductNameTag và đối tượng update
                ProductModel.Instance.updateProductByNameProduct(view.OldProductName, updateProduct);
                return;
            }
            if (nameData == "User")
            {
                User user = NewData(nameData, view);
                UpdateDefinition<User> update = new BsonDocument
                {

                    { "$set", new BsonDocument
                        {
                            { "fullName", user.Fullname },
                            { "age", user.Age },
                            { "gender", user.Gender },
                            { "username", user.Username },
                            { "password", Hash.hashPassword(user.Password)},
                            { "role", user.Role },
                        }
                    }
                };
                UserModel.Instance.updateUserByUsername(view.OldUserName, update);
                return;
            }
        }

        public void DeleteData(string nameData, dynamic view)
        {
            if (nameData == "Category")
            {
                CategoryModel.Instance.deleteCategoryByName(view.OldCategoryName);
                return;
            }
            if (nameData == "Table")
            {
                TableModel.Instance.deleteTableByTableName(view.OldTableName);
                return;
            }
            if (nameData == "Product")
            {
                ProductModel.Instance.deleteProductByNameProduct(view.OldProductName);

                return;
            }
            if (nameData == "User")
            {
                UserModel.Instance.deleteUserByUsername(view.OldUserName);
                return;
            }
        }

        public void ResetUserDataInput(dynamic view)
        {
            view.inputNameText = "";
            view.inputAgeText = "";
            view.inputGenderText = "Nam";
            view.inputUsernameText = "";
            view.OldUserName = "";
            view.inputUserpasswordText = "";
            view.inputRole = 0;
        }

        public void ResetTableDataInput(dynamic view)
        {
            view.inputTableNameText = "";
            view.OldTableName = "";
            view.inputStatus = sTable.EMPTY;
        }

        public void ResetProductDataInput(dynamic view)
        {
            view.inputProductNameText = "";
            view.OldProductName = "";
            view.inputPrice = "";
            view.inputCategoryName = "";
        }

        public void ResetCategoryDataInput(dynamic view)
        {
            view.inputCategory = "";
            view.OldCategoryName = "";
        }
    }
}
