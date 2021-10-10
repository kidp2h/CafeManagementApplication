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

        public List<ListViewItem> LoadingListForListViewOf(string form)
        {   
            List<ListViewItem> listItem = new List<ListViewItem>();
            if (form == "useManager_Tables")
            {

            }
            if (form == "useManager_Drinks")
            {

            }
            if (form == "useManager_Users")
            { 
                dynamic usersList = InitializeModels.UserModel.getListUser();
                foreach (dynamic user in usersList)
                {
                    string name = user.Fullname;
                    ListViewItem lvItem = new ListViewItem(user.Fullname);
                    int Age = user.Age;
                    lvItem.SubItems.Add(Age.ToString());
                    string Gender = user.Gender;
                    lvItem.SubItems.Add(Gender);
                    string Username = user.Username;
                    lvItem.SubItems.Add(Username);
              
                    listItem.Add(lvItem);

                }
                
            }
            

                return listItem;
        }
    }
}
