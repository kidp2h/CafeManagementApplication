using CafeManagementApplication.models;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Windows.Forms;

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

            }
            if (nameData == "Drink")
            {

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

        public void AddData(string nameData,dynamic user, dynamic view)
        {
            if(nameData == "Table")
            {

            }
            if(nameData == "Drink")
            {

            }    
            if (nameData == "User")
            {
                UserModel.Instance.addUser(user);
                ResetDataInput(view);
            }
        }

        public void UpdateData(string nameData, dynamic view)
        {
            if (nameData == "Table")
            {

            }
            if (nameData == "Drink")
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

            }
            if (nameData == "Drink")
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
    }
}
