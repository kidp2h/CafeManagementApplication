using CafeManagementApplication.controllers;
using CafeManagementApplication.models;
using CafeManagementApplication.types;
using System;
using System.Windows.Forms;

namespace CafeManagementApplication.views
{
    public partial class uscManager_Tables : UserControl
    {
        private static uscManager_Tables instance;

        public static uscManager_Tables Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new uscManager_Tables();
                }
                return instance;
            }
        }
        private uscManager_Tables()
        {
            InitializeComponent();
            LoadListController.Instance.LoadingListForListViewOf("useManager_Tables", listViewTableInfor);
        }


        public string inputTableNameText
        {
            get { return iTableName.Text; }
            set { iTableName.Text = value; }
        }

        public sTable inputStatus
        {
            get
            {
                if (iEmptyTable.Checked) return sTable.EMPTY;
                else return sTable.FULL;
            }
            set
            {                                     
             if (value == sTable.EMPTY) iEmptyTable.Checked = true;
             else iFullTable.Checked = true;                
            }
        }

        public string inputTableNameTagText
        {
            get { return iTableName.Tag.ToString(); }
            set { iTableName.Tag = value; }
        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            //Table table = ManagerController.Instance.NewData("Table", this);
            //ListViewItem tableLvItem = new ListViewItem(table.TableName);
            //tableLvItem.SubItems.Add(table.Status == sTable.EMPTY ? "Bàn trống" : "Có người"); 

            //listViewTableInfor.Items.Add(tableLvItem);

            ManagerController.Instance.AddData("Table",this);
            LoadListController.Instance.LoadingListForListViewOf("useManager_Tables", listViewTableInfor);
        }

        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            listViewTableInfor.Items.RemoveAt(int.Parse(btnDeleteTable.Tag.ToString()));
            ManagerController.Instance.DeleteData("Table", this);

        }

        private void listViewTableInfor_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView lvTable = sender as ListView;

            if (lvTable.SelectedItems.Count > 0)
            {
                ListViewItem item = lvTable.SelectedItems[0];
                iTableName.Tag = item.Tag;
                iTableName.Text = item.SubItems[0].Text;
              
                if (item.SubItems[1].Text == "Bàn trống") iEmptyTable.Checked = true;
                else iFullTable.Checked = true;

                btnDeleteTable.Tag = lvTable.Items.IndexOf(item);
            }
        }
    }
}
