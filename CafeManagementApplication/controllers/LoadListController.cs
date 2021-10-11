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
    public class LoadListController
    {
        private static LoadListController instance;
        public static LoadListController Instance
        {
            get
            {
                if (instance == null) instance = new LoadListController();
                return instance;
            }
        }



        private LoadListController() { }

        public void LoadingListForListViewOf(string form, ListView lv)
        {
            lv.Items.Clear();
            if (form == "useManager_Tables")
            {

            }
            if (form == "useManager_Drinks")
            {

            }
            if (form == "useManager_Users")
            {
                dynamic usersList = UserModel.Instance.getListUser();
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
                    lvItem.Tag = user.Id;
                    if (user.Role == 0)
                    {
                        lvItem.SubItems.Add("Nhân viên");
                    }
                    else lvItem.SubItems.Add("Quản lý");
                    
                    lv.Items.Add(lvItem);
                }

            }
        }

        public void LoadingBillForListViewFormTableID(string tableID)
        {

            uscSale.Instance.getLvBillforOneTable().Items.Clear();
            
            dynamic table = TableModel.Instance.getBillFromIdTable(tableID);
            if(table != null)
            {
                uscSale.Instance.BtnAddTag = table["billId"].Value.ToString();
                foreach (dynamic product in table["bill"])
                {

                    ListViewItem lvItem = new ListViewItem(product["product"]["name"].Value);
                   

                    int price = product["product"]["price"].Value;
                    lvItem.SubItems.Add(price.ToString()+ "đ");

                    int amount = product["amount"].Value;
                    lvItem.SubItems.Add(amount.ToString());

                    int totalPriceProduct = price * amount;
                    lvItem.SubItems.Add(totalPriceProduct.ToString() + "đ");

                    uscSale.Instance.getLvBillforOneTable().Items.Add(lvItem);
                }
                uscSale.Instance.getITotalPriceProducts().Text = table["subtotal"].Value.ToString() + "đ";
            }
            
            
            
            

        }



    }
}
