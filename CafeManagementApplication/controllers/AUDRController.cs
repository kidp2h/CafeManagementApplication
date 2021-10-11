using CafeManagementApplication.models;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Windows.Forms;

namespace CafeManagementApplication.controllers
{
    class AUDRController
    {
        private static AUDRController instance;
        public static AUDRController Instance
        {
            get
            {
                if (instance == null) instance = new AUDRController();
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

        public void AddData(string nameData, dynamic view)
        {
            if(nameData == "Table")
            {

            }
            if(nameData == "Drink")
            {

            }    
            if (nameData == "User")
            {
                User user = NewData(nameData, view);
                UserModel.Instance.addUser(user);
                ResetDataInput(view);
            }
        }

        public void UpdateData(string nameData, dynamic dataInput, string dataID)
        {
            if (nameData == "Table")
            {

            }
            if (nameData == "Drink")
            {

            }
            if (nameData == "User")
            {
                User user = NewData(nameData, dataInput);

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

                UserModel.Instance.updateUserById(dataID, update);
            }
        }

        public void DeleteData(string nameData, string dataID)
        {
            if (nameData == "Table")
            {

            }
            if (nameData == "Drink")
            {

            }
            if (nameData == "User")
            {
                UserModel.Instance.deleteUserById(dataID);
            }
        }


        public void ResetDataInput(dynamic view)
        {
            view.inputNameText = "";
            view.inputAge = "";
            view.inputGenderText = "Nam";
            view.inputUsernameText = "";
            view.inputUserpasswordText = "";
            view.inputRole = 0;
        }
    }
}
