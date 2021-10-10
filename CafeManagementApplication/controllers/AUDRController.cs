using CafeManagementApplication.models;
using CafeManagementApplication.views;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public dynamic NewData(string nameData, dynamic dataInput)
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
                foreach (dynamic item in dataInput.Controls)
                {
                    if (item.GetType() == typeof(RichTextBox))
                    {
                        if (item.Name == "iName") user.Fullname = item.Text;
                        if (item.Name == "iAge") user.Age = int.Parse(item.Text);
                        if (item.Name == "iUserName") user.Username = item.Text;
                        if (item.Name == "iUserPassword") user.Password = item.Text;
                    }
                    if (item.GetType() == typeof(Panel))
                    {
                        if (item.Name == "pnlGender") foreach (dynamic radio in item.Controls)
                            {
                                if (radio.Checked) user.Gender = radio.Text;
                            }
                        if (item.Name == "pnlRole") foreach (dynamic radio in item.Controls)
                            {
                                if (radio.Checked) if (radio.Text == "Quản lý") user.Role = types.Role.MANAGER;
                                    else user.Role = types.Role.STAFF;
                            }
                    }

                }




                return user;
            }
            return null;
        }

        public void AddData(string nameData, dynamic dataInput)
        {
            if(nameData == "Table")
            {

            }
            if(nameData == "Drink")
            {

            }    
            if (nameData == "User")
            {
                User user = NewData(nameData, dataInput);
                UserModel.Instance.addUser(user);
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


        public void ResetDataInput(dynamic dataInput)
        {
            foreach (dynamic item in dataInput.Controls)
            {
                if (item.GetType() == typeof(RichTextBox))
                {
                    item.Text = "";           
                }
                if (item.GetType() == typeof(Panel))
                {
                    item.Controls[0].Checked = true;     
                }

            }
        }
    }
}
