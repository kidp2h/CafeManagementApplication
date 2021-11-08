﻿using CafeManagementApplication.models;
using CafeManagementApplication.views;
using System.Windows.Forms;
using MongoDB.Bson;
using System.Threading;
using System.Collections.Generic;
using System.Data;

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

        //public void LoadingListForListViewOf(string form, ListView lv)
        //{
            
        //    lv.Items.Clear();
        //    if (form == "uscManager_Categories")
        //    {
        //        dynamic categoryList = CategoryModel.Instance.getListCategory();
        //        foreach(dynamic category in categoryList)
        //        {
        //            ListViewItem categoryLvItem = new ListViewItem(category.NameCategory.ToString());
        //            categoryLvItem.Tag = category.NameCategory.ToString();
        //            lv.Items.Add(categoryLvItem);
        //        }
        //        return;
        //    }
        //    if (form == "useManager_Tables")
        //    {
        //        dynamic tableList = TableModel.Instance.getListTable();
        //        foreach (dynamic table in tableList)
        //        {
        //            ListViewItem tableLvItem = new ListViewItem(table.TableName);
        //            if (table.Status == types.sTable.FULL)
        //            {
        //                tableLvItem.SubItems.Add("Có người");
        //            }
        //            else tableLvItem.SubItems.Add("Bàn trống");
        //            lv.Items.Add(tableLvItem);
        //        }
        //        return;
        //    }
        //    if (form == "useManager_Products")
        //    {
        //        dynamic productList = ProductModel.Instance.getListProduct();
        //        foreach(dynamic product in productList)
        //        {
        //            ListViewItem productLvItem = new ListViewItem(product["name"].Value);
        //            string category = product["category"].Value;
        //            productLvItem.SubItems.Add(category);                  
        //            int price = product["price"].Value;
        //            productLvItem.SubItems.Add(price.ToString());
        //            lv.Items.Add(productLvItem);
        //        }
        //        return;
        //    }
        //    if (form == "useManager_Users")
        //    {
        //        dynamic usersList = UserModel.Instance.getListUser();
        //        foreach (dynamic user in usersList)
        //        {
        //            ListViewItem lvItem = new ListViewItem(user.Fullname);
        //            int Age = user.Age;
        //            lvItem.SubItems.Add(Age.ToString());
        //            string Gender = user.Gender;
        //            lvItem.SubItems.Add(Gender);
        //            string Username = user.Username;
        //            lvItem.SubItems.Add(Username);

        //            if (user.Role == 0)
        //            {
        //                lvItem.SubItems.Add("Nhân viên");
        //            }
        //            else lvItem.SubItems.Add("Quản lý");

        //            lv.Items.Add(lvItem);
        //        }
        //        return;

        //    }
        //}

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


        //tải dữ liệu lên cái gridview -- gridview là một cái bảng chứa dữ liệu ở view
        public void LoadingListForDataGirdView(string form, DataTable dt)
        {
            //
            if (form == "uscManager_Tables")
            {
                //gọi model để lấy dữ liệu vào list có kiểu dữ liệu là table
                List<Table> tablesList = TableModel.Instance.getListTable();

                //thêm 2 cột vào đối tượng data table
                dt.Columns.Add("Tên bàn");
                dt.Columns.Add("Trạng thái");


                //lặp qua cái list<table> để lấy từng table
                foreach (Table table in tablesList)
                {
                    //gán giá trị 
                    string Name = table.TableName;
                    string Status = table.Status == types.sTable.FULL ? "Có người" : "Bàn trống";

                    //thêm dữ liệu của từng table vào hàng của data table
                    dt.Rows.Add(Name, Status);
                }

                //kết thúc hàm
                return;
            }

            if (form == "uscManager_Products")
            {
                dynamic productsList = ProductModel.Instance.getListProduct();              
                dt.Columns.Add("Tên món");
                dt.Columns.Add("Tên loại");
                dt.Columns.Add("Giá món");

                foreach (dynamic product in productsList)
                {
                    string Name = product["name"].Value;
                    string category = product["category"].Value;
                    int price = product["price"].Value;
                    dt.Rows.Add(Name, category, price);
                }
                return;
            }
            
            if (form == "uscManager_Categories")
            {
                dynamic categoryList = CategoryModel.Instance.getListCategory();
                dt.Columns.Add("Tên loại");

                foreach (dynamic category in categoryList)
                {
                    string Name = category.NameCategory.ToString();
                    dt.Rows.Add(Name);
                }
                return;
            }

            if (form == "useManager_Users")
            {
                //
                List<User> usersList = UserModel.Instance.getListUser();
                dt.Columns.Add("Họ và tên");
                dt.Columns.Add("Tuổi");
                dt.Columns.Add("Giới tính");
                dt.Columns.Add("Tài khoản");
                dt.Columns.Add("Chức vụ");

                foreach (User user in usersList)
                {
                    string Name = user.Fullname;
                    int Age = user.Age;
                    string Gender = user.Gender;
                    string Username = user.Username;
                    string Role = user.Role == types.Role.MANAGER ? "Quản lý" : "Nhân viên";
                    dt.Rows.Add (Name, Age.ToString(), Gender, Username, Role);
                }
                return;

            }
        }

        public void LoadListForComboBox(ComboBox cb)
        {
            dynamic categorys = CategoryModel.Instance.getListCategory();
            List<string> names = new List<string>();
            foreach (dynamic category in categorys)
            {
                names.Add(category.NameCategory.ToString());
            }
            cb.DataSource = names;
        }
    }
}
