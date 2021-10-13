using CafeManagementApplication.models;
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
            if (nameData == "Drink")
            {
                Product product = new Product();
                product.NameProduct = view.inputProductNameText;
                product.Category = view.inputCategoryText;
                product.Price = view.inputPrice;
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

        public void AddData(string nameData, dynamic view)
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
                ProductModel.Instance.addProduct(product);
            }    
            if (nameData == "User")
            {
                User user = NewData("User", view);
                UserModel.Instance.addUser(user);
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
                TableModel.Instance.updateTable(view.inputTableNameTagText, updateTable);
                ResetTableDataInput(view);
            }
            if (nameData == "Product")
            {

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

                UserModel.Instance.updateUserById(view.inputNameTagText, update);
                ResetDataInput(view);
            }
        }

        public void DeleteData(string nameData, dynamic view)
        {
            if (nameData == "Table")
            {

                TableModel.Instance.removeTable(view.inputTableNameTagText);
            }
            if (nameData == "Product")
            {

            }
            if (nameData == "User")
            {
                UserModel.Instance.deleteUserById(view.inputNameTagText);
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
    }
}
