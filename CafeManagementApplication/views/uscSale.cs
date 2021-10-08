using CafeManagementApplication.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
                if(instance == null)
                {
                    instance = new uscSale();
                }
                return instance;
            }
        }

        public uscSale()
        {
            InitializeComponent();

            LoadListTable();
        }

        private void LoadListTable()
        {   
            flpTableList.Controls.Clear();
            Table tb = new Table();
            List<Table> tables = new List<Table>();
            tables = tb.GetTableList();

            foreach(Table item in tables) {
                uscSale_Table table1 = new uscSale_Table();
                table1.TableName = item.Name;
                table1.Status = item.Status;
                flpTableList.Controls.Add(table1);
            }
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

            flpTableList.Controls.Add(table1);

            uscSale_Table table2 = new uscSale_Table();
            table2.TableName = "Bàn 2";
            table2.Status = "Trống";

            flpTableList.Controls.Add(table2);

            uscSale_Table table3 = new uscSale_Table();
            table3.TableName = "Bàn 3";
            table3.Status = "Trống";

            flpTableList.Controls.Add(table3);
            */

        }

        private void Table()
        {
            throw new NotImplementedException();
        }
    }
}
