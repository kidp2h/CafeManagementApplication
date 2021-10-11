﻿using CafeManagementApplication.models;
using CafeManagementApplication.views;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeManagementApplication.controllers
{
    public class LoadItemController
    {
        private static LoadItemController instance;
        public static LoadItemController Instance
        {
            get
            {
                if (instance == null) instance = new LoadItemController();
                return instance;
            }
        }

        private LoadItemController() { }

        public void LoadingItemTable (FlowLayoutPanel flp)
        {
            dynamic tables = TableModel.Instance.getListTable();
            foreach(Table table in tables)
            {
                uscSale_Table temp = new uscSale_Table();
                temp.Tag = table.Id;
                temp.TableName = table.TableName;

                if (table.Status == types.sTable.FULL)
                {
                    temp.Status = "Có người";                 
                }
                else
                {
                    temp.Status = "Bàn trống";                  
                }
                flp.Controls.Add(temp);
            }
        }
        public void LoadingItemProduct(FlowLayoutPanel flp)
        {
            dynamic products = ProductModel.Instance.getListProduct();
            foreach (dynamic product in products)
            {
                uscProduct temp = new uscProduct();
                temp.Tag = product["_id"].Value;
                temp.ProductName = product["name"].Value;
                temp.Price = product["price"].Value.ToString();
                flp.Controls.Add(temp);
            }
        }
    }
}
