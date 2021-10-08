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

        private uscSale()
        {
            InitializeComponent();

            LoadListTable();
        }

        private void LoadListTable()
        {
            flpTableList.Controls.Clear();
            TableModel tb = new TableModel();
            List<TableModel> tbList = new List<TableModel>();
            tbList = tb.getTableList();

            foreach(TableModel tbm in tbList)
            {
                uscSale_Table table1 = new uscSale_Table();
                table1.TableName = tbm.Name;
                table1.Status = tbm.Status;
                flpTableList.Controls.Add(table1);
            }



            //uscSale_Table table1 = new uscSale_Table();
            //table1.TableName = "Bàn 1";
            //table1.Status = "Trống";

            //flpTableList.Controls.Add(table1);




        }

        private void button1_Click(object sender, EventArgs e)
        {
            fDrinksCategory f = new fDrinksCategory();
            f.ShowDialog();
        }
    }
}
