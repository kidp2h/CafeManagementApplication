using CafeManagementApplication.models;
using CafeManagementApplication.views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeManagementApplication.controllers
{
    public class LoadingController
    {
        private static LoadingController instance;
        public static LoadingController Instance
        {
            get
            {
                if (instance == null)  instance = new LoadingController();            
                return instance;
            }
        }

        private LoadingController() { }

        public void LoadingListSomeThingForForm(string form)
        {

            List<User> usersList = InitializeModels.UserModel.getListUser();
            foreach (dynamic user in usersList)
            {
               
                ListViewItem lvItem = new ListViewItem(user["fullName"].Value);
                

            }


        }
    }
}
