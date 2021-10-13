using CafeManagementApplication.controllers;
using CafeManagementApplication.models;
using CafeManagementApplication.types;
using System;
using System.Threading;
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
            LoadListController.Instance.LoadingListForListViewOf("useManager_Tables", lvTableInfor);
        }

        public void LoadListTablesForForm()
        {
            Thread loadList = new Thread(() => {
                LoadListController.Instance.LoadingListForListViewOf("useManager_Tables", lvTableInfor);
            });
            loadList.Start();
        }

        #region Public Data View

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

        public string TableId
        {
            get { return iTableName.Tag.ToString(); }
            set { iTableName.Tag = value; }
        }
        #endregion

        #region Handler Event
 
        private void btnAddTable_Click(object sender, EventArgs e)
        {
           //ManagerController.Instance.AddData("Table",this);
            LoadListTablesForForm();

            Thread t1 = new Thread(() => {
                Invoke(new Action(() =>
                {
                    uscSale.Instance.LoadListTableForForm();
                }));
            });
            t1.Start();
        }

        private void btnUpdateTabe_Click(object sender, EventArgs e)
        {
            ManagerController.Instance.UpdateData("Table", this);
            LoadListTablesForForm();

            Thread t2 = new Thread(() => {
                Invoke(new Action(() =>
                {
                    uscSale.Instance.LoadListTableForForm();
                }));
            });
            t2.Start();
        }

        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            lvTableInfor.Items.RemoveAt(int.Parse(btnDeleteTable.Tag.ToString()));
            ManagerController.Instance.DeleteData("Table", this);

            Thread t3 = new Thread(() => {
                Invoke(new Action(() =>
                {
                    uscSale.Instance.LoadListTableForForm();
                }));
            });
            t3.Start();

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
        #endregion

    }
}
