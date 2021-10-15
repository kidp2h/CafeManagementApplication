using CafeManagementApplication.controllers;
using CafeManagementApplication.helpers;
using CafeManagementApplication.models;
using CafeManagementApplication.types;
using System;
using System.Drawing;
using System.Text;
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
            LoadListTablesForForm();
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
            get { return tbTableName.Text; }
            set { tbTableName.Text = value; }
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

        public string TableNameTag
        {
            get { return tbTableName.Tag.ToString(); }
            set { tbTableName.Tag = value; }
        }
        #endregion

        #region Handler Event
 
        private void btnAddTable_Click(object sender, EventArgs e)
        {
            #region Validate
            StringBuilder sb = new StringBuilder();
            ValidateForm.Instance.checkTableName(tbTableName, sb, "Vui lòng nhập tên bàn !", true);
            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            #region Handler View
            Table table = ManagerController.Instance.NewData("Table", this);
            ListViewItem tableItem = new ListViewItem(table.TableName);
            tableItem.SubItems.Add(table.Status == sTable.EMPTY ? "Bàn trống" : "Có người");
            lvTableInfor.Items.Add(tableItem);
            #endregion

            ManagerController.Instance.AddData("Table", table, this);
        }

        private void btnUpdateTabe_Click(object sender, EventArgs e)
        {
            #region Validate
            StringBuilder sb = new StringBuilder();
            ValidateForm.Instance.checkTableName(tbTableName, sb, "Vui lòng nhập tên bàn  !", false);
            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            #region Handler View
            Table table = ManagerController.Instance.NewData("Table", this);
            ListViewItem tableItem = new ListViewItem(table.TableName);
            tableItem.SubItems.Add(table.Status == sTable.EMPTY ? "Bàn trống" : "Có người");
            lvTableInfor.Items.RemoveAt(int.Parse(btnDeleteTable.Tag.ToString()));
            lvTableInfor.Items.Insert(int.Parse(btnDeleteTable.Tag.ToString()), tableItem);
            #endregion

            ManagerController.Instance.UpdateData("Table", this);          
        }

        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            #region Validate
            StringBuilder sb = new StringBuilder();
            ValidateForm.Instance.checkTableName(tbTableName, sb, "Vui lòng nhập tên bàn  !", false);
            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            #region Handler View
            lvTableInfor.Items.RemoveAt(int.Parse(btnDeleteTable.Tag.ToString()));
            #endregion 
            ManagerController.Instance.DeleteData("Table", this);
        }

        private void listViewTableInfor_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView lvTable = sender as ListView;

            if (lvTable.SelectedItems.Count > 0)
            {
                ListViewItem item = lvTable.SelectedItems[0];
                tbTableName.Tag = item.SubItems[0].Text;
                tbTableName.Text = item.SubItems[0].Text;
              
                if (item.SubItems[1].Text == "Bàn trống") iEmptyTable.Checked = true;
                else iFullTable.Checked = true;

                btnDeleteTable.Tag = lvTable.Items.IndexOf(item);
            }
        }
     
        private void button1_Click(object sender, EventArgs e)
        {
            LoadListTablesForForm();
        }

        #endregion

        #region Effect
        private void tbTableName_TextChanged(object sender, EventArgs e)
        {
            if(tbTableName.BackColor != Color.White)
            tbTableName.BackColor = Color.White;
        }
        #endregion
    }
}
