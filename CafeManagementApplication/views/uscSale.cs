using CafeManagementApplication.controllers;
using CafeManagementApplication.models;
using CafeManagementApplication.types;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeManagementApplication.views
{
    public partial class uscSale : UserControl
    {
        private static uscSale instance;


        public static uscSale Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new uscSale();
                }
                return instance;
            }
        }

        private uscSale()
        {
            InitializeComponent();
            LoadListTableForForm();
        }


        private void LoadListTableForForm()
        {
            LoadTable.Instance.LoadingTableList(flpTableList);
        }

            /*
            private void LoadListTable()
            {
               // dynamic doc = TableModel.Instance.getListTable();

                /*
               foreach(dynamic table in doc)
               {
                   uscSale_Table temp = new uscSale_Table();
                   temp.TableName = table["tableName"].Value;

                   if (table["status"].Value == 1)
                   {
                       temp.Status = "Có người";
                       temp.BackColor = Color.FromArgb(255, 192, 192);
                   }
                   else
                   {
                       temp.Status = "Bàn trống";
                       temp.BackColor = Color.FromArgb(255, 255, 255);
                   }

                   flpTableList.Controls.Add(temp);
               }
                */
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
            /*
            foreach(Table item in tables)
            {
                uscSale_Table table1 = new uscSale_Table();
                table1.TableName = "Bàn 1";
                table1.Status = "Trống";
                flpTableList.Controls.Add(table1);
            }
            */

            /*
            for (int i = 0; i < tables.Count; i++)
            {
                tables[i].iD = 1;
                tables[i].name = "Bàn 1";
                tables[i].status = "Trống";
                flpTableList.Controls.Add();
            }
            */

            /*
            uscSale_Table table1 = new uscSale_Table();
            table1.TableName = "Bàn 1";
            table1.Status = "Trống";



            //uscSale_Table table1 = new uscSale_Table();
            //table1.TableName = "Bàn 1";
            //table1.Status = "Trống";

            //flpTableList.Controls.Add(table1);



            flpTableList.Controls.Add(table3);
            */

        }
    /*
        private void button1_Click(object sender, EventArgs e)
        {
            fDrinksCategory f = new fDrinksCategory();
            f.ShowDialog();
        }


    }
        */
}
