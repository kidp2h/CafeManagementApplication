using CafeManagementApplication.controllers;
using CafeManagementApplication.helpers;
using CafeManagementApplication.models;
using CafeManagementApplication.types;
using System;
using System.Data;
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
            LoadListTables();
        }

        private DataTable dt;
        private DataView dv;

        public void LoadListTables()
        {
            dt = new DataTable();
            //gọi controler để lấy dữ liệu vào datable từ model
            LoadDataController.Instance.LoadDataTable("uscManager_Tables", dt);   
            //tạo đối tượng data view 
            dv = new DataView (dt);
            dtgvTables.DataSource = dv;
           
        }

        private void ResetView()
        {
            ManagerController.Instance.ResetTableDataInput(this);
            dtgvTables.ClearSelection();
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
                if (rdoEmpty.Checked == true)  return sTable.EMPTY;
                return sTable.FULL;
            }
            set
            {
                if (value == sTable.FULL) rdoFull.Checked = true;
                else rdoEmpty.Checked = true;
            }
        }

        public string OldTableName //tên cũ
        {
            get { return tbTableName.Tag.ToString(); }
            set { tbTableName.Tag = value; }
        }
        #endregion

        #region Handler Event
        private void uscManager_Tables_Load(object sender, EventArgs e)
        {
            dtgvTables.ClearSelection();
        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            #region Validate
            StringBuilder sb = new StringBuilder();
            ValidateForm.Instance.checkTableName(tbTableName, sb, "Vui lòng nhập tên bàn !", "add");
            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            #region Handler View
            Table table = ManagerController.Instance.NewData("Table", this);

            //dt.Rows.Add(); --> có thể thêm bằng cách này
            DataRow rowNew = dt.NewRow();
            rowNew["Tên bàn"] = tbTableName.Text;
            rowNew["Trạng thái"] = "Bàn trống";
       
            dt.Rows.Add(rowNew);
            
            #endregion

            ManagerController.Instance.AddData("Table", table);

            ResetView();

            uscSale.Instance.LoadListTableForForm();

        }

        private void btnUpdateTabe_Click(object sender, EventArgs e)
        {
            #region Validate
            StringBuilder sb = new StringBuilder();
            ValidateForm.Instance.checkTableName(tbTableName, sb, "Vui lòng nhập tên bàn  !", "update");

            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            #endregion

            #region Handler View
            DataRow rowNew = dt.NewRow();
            rowNew["Tên bàn"] = tbTableName.Text;
            if (rdoEmpty.Checked == true) rowNew["Trạng thái"] = "Bàn trống";
            else rowNew["Trạng thái"] = "Có người";

            string filter = string.Format("[Tên bàn] = '{0}'", OldTableName); 
            DataRow[] rows = dt.Select(filter);

            int index = dt.Rows.IndexOf(rows[0]);
  
            dt.Rows.RemoveAt(index);
            dt.Rows.InsertAt(rowNew, index);

            #endregion

            ManagerController.Instance.UpdateData("Table", this);

            ResetView();

            uscSale.Instance.LoadListTableForForm();

        }

        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            #region Validate
            StringBuilder sb = new StringBuilder();
            ValidateForm.Instance.checkTableName(tbTableName, sb, "Vui lòng chọn bàn !", "delete");
            ValidateForm.Instance.checkTableStatus(tbStatus, sb, "Bàn này đang có người không thể xóa !");
            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            #region Handler View

            string filter = String.Format("[Tên bàn] = '{0}'", OldTableName);
            DataRow[] rows = dt.Select(filter);

            int index = dt.Rows.IndexOf(rows[0]);
            dt.Rows.RemoveAt(index);
            
            #endregion

            ManagerController.Instance.DeleteData("Table", this);

            ResetView();

            uscSale.Instance.LoadListTableForForm();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            dv.RowFilter = String.Format("[Tên bàn] LIKE '%{0}%'", tbSearch.Text);
        } 

        private void dtgvTables_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            DataGridViewRow row = dtgvTables.Rows[e.RowIndex];

            tbTableName.Text = row.Cells[0].Value.ToString();
            tbTableName.Tag = row.Cells[0].Value.ToString();
            //để validate
            tbStatus.Text = row.Cells[1].Value.ToString();
            if (row.Cells[1].Value.ToString() == "Có người") rdoFull.Checked = true;
            else if (row.Cells[1].Value.ToString() == "Bàn trống") rdoEmpty.Checked = true; 
        }

        #endregion

        #region Effect
        private void tbTableName_TextChanged(object sender, EventArgs e)
        {
            if (tbTableName.BackColor != Color.White)
                tbTableName.BackColor = Color.White;
        }
        #endregion
    }
}
