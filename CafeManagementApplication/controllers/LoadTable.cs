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
            for (int i = 0; i < tables.Count; i++)
            {
                uscSale_Table temp = new uscSale_Table();
                temp.TableName = tables[i]["tableName"].Value;

                if (tables[i]["status"].Value == 1)
                {
                    temp.Status = "Có người";
                    temp.BackColor = Color.FromArgb(255, 192, 192);
                }
                else
                {
                    temp.Status = "Bàn trống";
                    temp.BackColor = Color.FromArgb(255, 128, 0);
                }

                a.Controls.Add(temp);
            }
        }

        /*
           for (int i = doc.Count - 1; i >= 0; i--)
           {
               uscSale_Table temp = new uscSale_Table();
               temp.TableName = doc[i]["tableName"].Value;

               if (doc[i]["status"].Value == 1)
               {
                   temp.Status = "Có người";
                   temp.BackColor = Color.FromArgb(255, 192, 192);
               }
               else
               {
                   temp.Status = "Bàn trống";
                   temp.BackColor = Color.FromArgb(255, 128, 0);
               }

               flpTableList.Controls.Add(temp);
           }
   */
    }
}
