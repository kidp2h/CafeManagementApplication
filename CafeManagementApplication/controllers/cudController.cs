using CafeManagementApplication.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagementApplication.controllers
{
    public class cudController
    {
        private cudController instance;
        public cudController Instance
        {
            get
            {
                if (instance == null) instance = new cudController();
                return instance;
            }
        }
        private cudController() { }

        public void AddData(string nameData, dynamic data)
        {
            if(nameData == "User")
            {
                UserModel.Instance.addUser(data);
            }
        }
    }
}
