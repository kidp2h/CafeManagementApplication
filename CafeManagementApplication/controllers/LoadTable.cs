using CafeManagementApplication.models;
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
    public class LoadTable
    {
        private static LoadTable instance;
        public static LoadTable Instance
        {
            get
            {
                if (instance == null) instance = new LoadTable();
                return instance;
            }
        }

        private LoadTable() { }

        public void LoadingTableList (FlowLayoutPanel a)
        {
            dynamic tables = TableModel.Instance.getListTable();
            foreach(dynamic table in tables)
            {
                uscSale_Table temp = new uscSale_Table();
                temp.Tag = table["_id"].Value;
                temp.TableName = table["tableName"].Value;

                if (table["status"].Value == 1)
                {
                    temp.Status = "Có người";                 
                }
                else
                {
                    temp.Status = "Bàn trống";                  
                }
                a.Controls.Add(temp);
            }
        }
    }
}
