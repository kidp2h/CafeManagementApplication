﻿using CafeManagementApplication.controllers;
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

        private DataTable dt;
        private DataView dv;
        private BindingSource tableList = new BindingSource();

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
            LoadData();
        } 
        
        private void LoadData()
        {
            dtgvTables.DataSource = tableList;
            LoadListTables();            
        }

        public void LoadListTables(bool status = true)
        {
            bool statusTemp = status;
            //Thread loadList = new Thread(() => {
                //tạo một đối tượng data table
                dt = new DataTable();
                //gọi controler để lấy dữ liệu vào datable từ model
                LoadDataController.Instance.LoadDataTable("uscManager_Tables", dt);   
                //tạo đối tượng data view 
                dv = new DataView (dt);
                tableList.DataSource = dv;

                if(statusTemp) TableBinding();
                

            //});
            //loadList.IsBackground = true;
            //loadList.Start();
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
                return sTable.EMPTY;  //hỏi là lấy giá trị từ đâu ( sTavle.EMPTY là lấy từ chỗ nào )
            }
            set
            {
                if (value == sTable.EMPTY) rdoEmpty.Checked = true;
                else rdoFull.Checked = true;  //hỏi tại sao phải check trong khi return luôn về trống
            }
        }

        public string TableNameTag
        {
            get { return tbTableSelected.Text; }
            set { tbTableSelected.Text = value; }
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

            //dt.Rows.Add(); --> có thể thêm bằng cách này
            DataRow rowNew = dt.NewRow();
            rowNew["Tên bàn"] = tbTableName.Text;
            rowNew["Trạng thái"] = "Bàn trống";
            //--> cách này để tối ưu trải nghiệm người dùng 
            dt.Rows.Add(rowNew);
            dtgvTables.CurrentCell = dtgvTables[0, dt.Rows.IndexOf(rowNew)];
            #endregion

            ManagerController.Instance.AddData("Table", table);
            uscSale.Instance.LoadListTableForForm();
        }

        private void btnUpdateTabe_Click(object sender, EventArgs e)
        {
            #region Validate
            StringBuilder sb = new StringBuilder();
            ValidateForm.Instance.checkTableName(tbTableName, sb, "Vui lòng nhập tên bàn  !", true);
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

            string filter = string.Format("[Tên bàn] = '{0}'", tbTableSelected.Text = tbTableName.Tag.ToString()); //hỏi cái tbTableSelected.Text và  tbTableName.Tag. ở đâu ra
            DataRow[] rows = dt.Select(filter);

            int index = dt.Rows.IndexOf(rows[0]);
            btnDeleteTable.Tag = index;
            dt.Rows.RemoveAt(index);
            dt.Rows.InsertAt(rowNew, index);
            dtgvTables.CurrentCell = dtgvTables[0, index];
            #endregion

            ManagerController.Instance.UpdateData("Table", this);
            uscSale.Instance.LoadListTableForForm();
        }

        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            #region Validate
            StringBuilder sb = new StringBuilder();
            ValidateForm.Instance.checkTableName(tbTableName, sb, "Vui lòng chọn bàn !", false);
            ValidateForm.Instance.checkTableStatus(tbStatus, sb, "Bàn này đang có người không thể xóa !");
            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            #region Handler View
            string filter = string.Format("[Tên bàn] = '{0}'", tbTableSelected.Text = tbTableName.Tag.ToString());  //hỏi cái tbTableSelected.Text và  tbTableName.Tag. ở đâu ra
            DataRow[] rows = dt.Select(filter);

            int index = dt.Rows.IndexOf(rows[0]);
            btnDeleteTable.Tag = index;
            dt.Rows.RemoveAt(index);
            #endregion

            ManagerController.Instance.DeleteData("Table", this);
            uscSale.Instance.LoadListTableForForm();
        }

        private void TableBinding()
        {               
            tbTableName.DataBindings.Add(new Binding("Text", dtgvTables.DataSource, "Tên bàn", true, DataSourceUpdateMode.Never));
            tbTableName.DataBindings.Add(new Binding("Tag", dtgvTables.DataSource, "Tên bàn", true, DataSourceUpdateMode.Never));

            tbStatus.DataBindings.Add(new Binding("Text", dtgvTables.DataSource, "Trạng thái"));

            if (tbStatus.Text == "Có người") rdoFull.Checked = true;
            else rdoEmpty.Checked = true;
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            dv.RowFilter = String.Format("[Tên bàn] LIKE '%{0}%'", tbSearch.Text);
        }

        private void dtgvTables_CurrentCellChanged(object sender, EventArgs e)
        {
            if (tbStatus.Text == "Có người") rdoFull.Checked = true;  //hỏi cái tbStatus ở đâu ra 
            else rdoEmpty.Checked = true;
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
