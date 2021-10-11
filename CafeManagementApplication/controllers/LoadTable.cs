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
                a.Controls.Add(temp);
            }
        }
    }
}
