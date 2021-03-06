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
    public partial class uscManager_Users : UserControl
    {
        private static uscManager_Users instance;
        
        public static uscManager_Users Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new uscManager_Users();
                }
                return instance;
            }
        }

        private uscManager_Users()
        {
            InitializeComponent();
            LoadListUsers();
        }

        private DataTable dt;
        private DataView dv;

        public void LoadListUsers()
        {
            dt = new DataTable();
            LoadDataController.Instance.LoadDataTable("useManager_Users", dt);       
            dv = new DataView(dt);
            dtgvUsers.DataSource = dv;

            //set style cho đẹp 
            dtgvUsers.Columns[0].Width = 300;
            dtgvUsers.Columns[1].Width = 100;
           // dtgvUsers.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
           // dtgvUsers.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; 
        }

        private void ResetView()
        {
            ManagerController.Instance.ResetUserDataInput(this);
            dtgvUsers.ClearSelection();
        }

        #region Public Data In View
        public DataTable Dt { get; set; }

        public string inputNameText
        {
            get { return tbName.Text; }
            set { tbName.Text = value;  }
        }

        public string inputAgeText
        {
            get { return tbAge.Text; }
            set { tbAge.Text = value; }
        }

        public string inputUsernameText
        {
            get { return tbUserName.Text; }
            set { tbUserName.Text = value; }
        }

        public string inputUserpasswordText
        {
            get { return tbUserPassword.Text; }
            set { tbUserPassword.Text = value; }
        }

        public string inputGenderText  
        {
            get
            {
                if (rdoMale.Checked) return "Nam";
                else if (rdoFemale.Checked) return "Nữ";
                else return "Khác";
            }
            set
            {
                if (value == "Nam") rdoMale.Checked = true;
                else if (value == "Nữ") rdoFemale.Checked = true;
                else rdoOther.Checked = true;
            }
        }

        public Role inputRole 
        {
            get
            {
                if (rdoManager.Checked) return Role.MANAGER;
                else return Role.STAFF;
            }
            set
            {
                if (value == Role.MANAGER) rdoManager.Checked = true;
                else rdoSaff.Checked = true;
            }
        }

        public string OldUserName
        {
            get { return tbUserName.Tag.ToString(); }
            set { tbUserName.Tag = value; }
        }

        #endregion

        #region Handler Event
        private void uscManager_Users_Load(object sender, EventArgs e)
        {
            dtgvUsers.ClearSelection();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            #region Validate
            StringBuilder sb = new StringBuilder();
            ValidateForm.Instance.checkEmpty(tbName, sb, "Vui lòng nhập họ tên !");
            ValidateForm.Instance.checkAge(tbAge, sb, "Vui lòng nhập tuổi !");
            ValidateForm.Instance.checkUsername(tbUserName, sb, "Vui lòng nhập tài khoản !",true);
            ValidateForm.Instance.checkEmpty(tbUserPassword, sb, "Vui lòng nhập mật khẩu !");

            if (sb.Length > 0)
            {
                //
                MessageBox.Show(sb.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            #region Handler View
            User user = ManagerController.Instance.NewData("User", this);
            string Name = user.Fullname;
            int Age = user.Age;
            string Gender = user.Gender;
            string Username = user.Username;
            string Role = user.Role == types.Role.MANAGER ? "Quản lý" : "Nhân viên";
            

            dt.Rows.Add(Name, Age.ToString(), Gender, Username, Role);
           
            #endregion

            ManagerController.Instance.AddData("User", user);
            ResetView();
            MessageBox.Show("ĐÃ THÊM NGƯỜI DÙNG !!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            #region Validate
            StringBuilder sb = new StringBuilder();
            ValidateForm.Instance.checkUsername(tbUserName, sb, "Vui lòng chọn tài khoản cần sửa !", false);

            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            #region Handler View
            DataRow rowNew = dt.NewRow();
            rowNew["Họ và tên"] = tbName.Text;
            rowNew["Tuổi"] = tbAge.Text;
            if (rdoOther.Checked == true) rowNew["Giới tính"] = "Khác";
            else rowNew["Giới tính"] = rdoMale.Checked == true ? "Nam" : "Nữ";
            rowNew["Tài khoản"] = tbUserName.Text;
            rowNew["Chức vụ"] = rdoManager.Checked == true ? "Quản lý" : "Nhân viên";

            string filter = string.Format("[Tài khoản] = '{0}'", OldUserName);
            DataRow[] rows = dt.Select(filter);

            int index = dt.Rows.IndexOf(rows[0]);
            
            dt.Rows.RemoveAt(index);
            dt.Rows.InsertAt(rowNew, index);
         
            #endregion

            ManagerController.Instance.UpdateData("User", this);
            ResetView();
            MessageBox.Show("ĐÃ SỬA THÔNG TIN NGƯỜI DÙNG !!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            #region Validate
            StringBuilder sb = new StringBuilder();
            ValidateForm.Instance.checkUsername(tbUserName, sb, "Vui lòng chọn tài khoản cần xóa !", false);

            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            #region Handler View
            string filter = String.Format("[Tài khoản] = '{0}'", OldUserName);
            DataRow[] rows = dt.Select(filter);

            int index = dt.Rows.IndexOf(rows[0]);
            dt.Rows.RemoveAt(index);
            #endregion

            ManagerController.Instance.DeleteData("User", this);
            ResetView();
            MessageBox.Show("ĐÃ XÓA NGƯỜI DÙNG !!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        } 

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            dv.RowFilter = String.Format("[Họ và tên] LIKE '%{0}%'", tbSearch.Text);
        }

        private void dtgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            DataGridViewRow row = dtgvUsers.Rows[e.RowIndex];

            tbName.Text = row.Cells[0].Value.ToString();
            tbAge.Text = row.Cells[1].Value.ToString();
            if (row.Cells[2].Value.ToString() == "Nam") rdoMale.Checked = true;
            else if (row.Cells[2].Value.ToString() == "Nữ") rdoFemale.Checked = true; else rdoOther.Checked = true;
            tbUserName.Text = row.Cells[3].Value.ToString();
            tbUserName.Tag = row.Cells[3].Value.ToString();
            if (row.Cells[4].Value.ToString() == "Quản lý") rdoManager.Checked = true; else rdoSaff.Checked = true;

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ResetView();
        }

        #endregion

        #region Effect
        private void tbName_TextChanged(object sender, EventArgs e)
        {
            if(tbName.BackColor != Color.White)
            tbName.BackColor = Color.White;
        }

        private void tbAge_TextChanged(object sender, EventArgs e)
        { 
            if(tbAge.BackColor != Color.White)
            tbAge.BackColor = Color.White;
            
        }

        private void tbUserName_TextChanged(object sender, EventArgs e)
        {
            if(tbUserName.BackColor != Color.White)
            tbUserName.BackColor = Color.White;

        }

        private void tbUserPassword_TextChanged(object sender, EventArgs e)
        {
            if(tbUserPassword.BackColor != Color.White)
            tbUserPassword.BackColor = Color.White;
        }



        #endregion

        

       
    }
}
