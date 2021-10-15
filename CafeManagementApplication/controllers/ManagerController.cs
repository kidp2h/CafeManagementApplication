using CafeManagementApplication.models;
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
                product.NameProduct = view.inputProductNameText;
                product.CategoryName = view.inputCategoryName;
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
            if (nameData == "Category")
            {
                CategoryModel.Instance.addCategory(data);
                ResetCategoryDataInput(view);
                return;
            }
            if (nameData == "Table")
            {
                TableModel.Instance.addTable(data);
                ResetTableDataInput(view);
                return;
            }
            if(nameData == "Product")
            {               
                ProductModel.Instance.addProduct(data, view.inputCategoryName);
                ResetProductDataInput(view);
                return;
            }    
            if (nameData == "User")
            {
                UserModel.Instance.addUser(data);
                ResetDataInput(view);
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
                CategoryModel.Instance.updateCategoryByName(view.CategoryNameTag, updateCategory);
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
                TableModel.Instance.updateTableByNameTable(view.TableNameTag, updateTable);
                ResetTableDataInput(view);
                return;
            }
            if (nameData == "Product")
            {
                ProductModel.Instance.updateProductByNameProduct(view.ProductNameTag, Int32.Parse(view.inputPrice), view.inputCategoryName);
                ResetProductDataInput(view);
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
                            { "password", user.Password },
                            { "role", user.Role },
                        }
                    }
                };
                UserModel.Instance.updateUserByUsername(view.UserNameTag, update);
                ResetDataInput(view);
                return;
            }
        }

        public void DeleteData(string nameData, dynamic view)
        {
            if (nameData == "Category")
            {
                CategoryModel.Instance.deleteCategoryByName(view.CategoryNameTag);
                ResetCategoryDataInput(view);
            }
            if (nameData == "Table")
            {
                TableModel.Instance.deleteTableByTableName(view.TableNameTag);
                ResetTableDataInput(view);
                return;
            }
            if (nameData == "Product")
            {
                ProductModel.Instance.deleteProductByNameProduct(view.ProductNameTag);
                ResetProductDataInput(view);
                return;
            }
            if (nameData == "User")
            {
                UserModel.Instance.deleteUserByUsername(view.UserNameTag);
                ResetDataInput(view);
                return;
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
            view.inputCategoryName = "";
        }
        public void ResetCategoryDataInput(dynamic view)
        {
            view.inputCategory = "";
        }
    }
}
