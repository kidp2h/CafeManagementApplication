﻿using CafeManagementApplication.models;
using MongoDB.Bson;
using MongoDB.Driver;

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

        public dynamic NewData(string nameData, dynamic view)
        {
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
                product.NameProduct = view.inputProductNameText;               
                product.Price = int.Parse(view.inputPrice);
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

        public void AddData(string nameData, dynamic data, dynamic view)
        {
            if(nameData == "Table")
            {
                Table table = NewData("Table",view);
                TableModel.Instance.addTable(table);
                ResetTableDataInput(view);
            }
            if(nameData == "Product")
            {
                Product product = NewData("Product", view);
                ProductModel.Instance.addProduct(product, view.inputCategoryText);
                ResetProductDataInput(view);
            }    
            if (nameData == "User")
            {
                UserModel.Instance.addUser(data);
                ResetDataInput(view);
            }
        }

        public void UpdateData(string nameData, dynamic view)
        {
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
                //TableModel.Instance.updateTable(view.TableId, updateTable);
                ResetTableDataInput(view);
            }
            if (nameData == "Product")
            {
                Product product = NewData(nameData, view);
                UpdateDefinition<Product> updateProduct = new BsonDocument
                {

                    { "$set", new BsonDocument
                        {
                            { "name", product.NameProduct },
                            //{ "category", product. },
                            { "price", product.Price },
                        }
                    }
                };
                //ProductModel.Instance.updateProductById(view.Product, updateProduct);
                ResetTableDataInput(view);
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
                            { "password", user.Password },
                            { "role", user.Role },
                        }
                    }
                };

                UserModel.Instance.updateUserById(view.UserId, update);
                ResetDataInput(view);
            }
        }

        public void DeleteData(string nameData, dynamic view)
        {
            if (nameData == "Table")
            {

                TableModel.Instance.removeTable(view.TableId);
                ResetTableDataInput(view);
            }
            if (nameData == "Product")
            {
                ProductModel.Instance.removeProductById(view.ProductId);
                ResetProductDataInput(view);
            }
            if (nameData == "User")
            {
                UserModel.Instance.deleteUserByUsername(view.Username);
                ResetDataInput(view);
            }
        }

        public void ResetDataInput(dynamic view)
        {
            view.inputNameText = "";
            view.inputAgeText = "";
            view.inputGenderText = "Nam";
            view.inputUsernameText = "";
            view.inputUserpasswordText = "";
            view.inputRole = 0;
        }
        public void ResetTableDataInput(dynamic view)
        {
            view.inputTableNameText = "";
            view.inputStatus = 0;
        }

        public void ResetProductDataInput(dynamic view)
        {
            view.inputProductNameText = "";
            view.inputPrice = "";
            view.inputCategoryText = "";
        }
    }
}
