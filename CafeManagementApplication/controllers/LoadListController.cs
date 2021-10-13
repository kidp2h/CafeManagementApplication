using CafeManagementApplication.models;
using CafeManagementApplication.views;
using System.Windows.Forms;
using MongoDB.Bson;

namespace CafeManagementApplication.controllers
{
    public class LoadListController
    {
        private static LoadListController instance;
        private static readonly object lockObject = new object();
        public static LoadListController Instance
        {
            get
            {
                if (instance == null)
                {
                    lock(lockObject)
                    {
                        if (instance == null) instance = new LoadListController();
                    }
                }        
                return instance;
            }
        }

        private LoadListController() { }

        public void LoadingListForListViewOf(string form, ListView lv)
        {
            lv.Items.Clear();
            if (form == "useManager_Tables")
            {
                dynamic tableList = TableModel.Instance.getListTable();
                foreach (dynamic table in tableList) 
                {
                    ListViewItem tableLvItem = new ListViewItem(table.TableName);
                    tableLvItem.Tag = table.Id;
                    if (table.Status == types.sTable.FULL)
                    {
                        tableLvItem.SubItems.Add("Có người");
                    }
                    else tableLvItem.SubItems.Add("Bàn trống");
                    lv.Items.Add(tableLvItem);
                }
                return;
            }
            if (form == "useManager_Drinks")
            {
                return;
            }
            if (form == "useManager_Users")
            {
                dynamic usersList = UserModel.Instance.getListUser();
                foreach (dynamic user in usersList)
                {
                    ListViewItem lvItem = new ListViewItem(user.Fullname);
                    lvItem.Tag = user.Id;
                    int Age = user.Age;
                    lvItem.SubItems.Add(Age.ToString());
                    string Gender = user.Gender;
                    lvItem.SubItems.Add(Gender);
                    string Username = user.Username;
                    lvItem.SubItems.Add(Username);
                    
                    if (user.Role == 0)
                    {
                        lvItem.SubItems.Add("Nhân viên");
                    }
                    else lvItem.SubItems.Add("Quản lý");
                    
                    lv.Items.Add(lvItem);
                }
                return;

            }
        }

        public void LoadingBillForListViewFormTableID(string tableID)
        {

            uscSale.Instance.getLvBillforOneTable().Items.Clear();
            
            dynamic table = TableModel.Instance.getBillFromIdTable(tableID);
            if(table["billId"] != null)
            {
                uscSale.Instance.BillId = table["billId"].Value.ToString();

                foreach (dynamic product in table["bill"])
                {
                    if(product["product"] != new BsonDocument())
                    {
                        ListViewItem lvItem = new ListViewItem(product["product"]["name"].Value);


                        int price = product["product"]["price"].Value;
                        lvItem.SubItems.Add(price.ToString() + "đ");

                        int amount = product["amount"].Value;
                        lvItem.SubItems.Add(amount.ToString());

                        int totalPriceProduct = price * amount;
                        lvItem.SubItems.Add(totalPriceProduct.ToString() + "đ");

                        uscSale.Instance.getLvBillforOneTable().Items.Add(lvItem);
                    }
                    
                }
                uscSale.Instance.inputTotalPriceProducts = table["subtotal"].Value.ToString() + "đ";
              
            }
            
            
            
            

        }



    }
}
