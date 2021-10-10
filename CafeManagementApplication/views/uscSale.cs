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
            LoadListTable();
        }

        private void LoadListTable()
        {
           
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

        private void button1_Click(object sender, EventArgs e)
        {
            fDrinksCategory f = new fDrinksCategory();
            f.ShowDialog();
        }


    }
}
