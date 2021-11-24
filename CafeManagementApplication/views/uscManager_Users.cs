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
        private DataTable dt = new DataTable();
        private DataView dv;

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
        
        public void LoadListUsers()
        {
                LoadDataController.Instance.LoadDataTable("useManager_Users", dt);
               
                dv = new DataView(dt);

                dtgvUsers.DataSource = dv;

                //set style cho đẹp 
                dtgvUsers.Columns[0].Width = 300;
                dtgvUsers.Columns[1].Width = 100;
                dtgvUsers.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtgvUsers.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                UserBinding();
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
        public string inputGenderText  //hỏi
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
        public Role inputRole  //hỏi 
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
        public string UserId
        {
            get { return tbName.Tag.ToString();}
            set { tbName.Tag = value; }
        }

        public string UserNameTag
        {
            get { return tbUserName.Text; }
            set { tbUserName.Text = value; }
        }
        #endregion

        #region Handler Event

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
            dtgvUsers.CurrentCell = dtgvUsers[0, dtgvUsers.RowCount -1 ];
            #endregion

            ManagerController.Instance.AddData("User", user);
            

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

            string filter = string.Format("[Tài khoản] = '{0}'", tbUserName.Tag.ToString());
            DataRow[] rows = dt.Select(filter);

            int index = dt.Rows.IndexOf(rows[0]);
            //btnDelete.Tag = index;
            dt.Rows.RemoveAt(index);
            dt.Rows.InsertAt(rowNew, index);
            dtgvUsers.CurrentCell = dtgvUsers[0, index];
            #endregion

            ManagerController.Instance.UpdateData("User", this);
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
            string filter = String.Format("[Tài khoản] = '{0}'", tbUserName.Tag.ToString());
            DataRow[] rows = dt.Select(filter);

            int index = dt.Rows.IndexOf(rows[0]);
            //btnDelete.Tag = index;
            dt.Rows.RemoveAt(index);
            #endregion

            ManagerController.Instance.DeleteData("User", this);
            
        } 

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            dv.RowFilter = String.Format("[Họ và tên] LIKE '%{0}%'", tbSearch.Text);
        }


        private void dtgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            //if (tbGender.Text == "Nam") rdoMale.Checked = true;
            //else if (tbGender.Text == "Nữ") rdoFemale.Checked = true; else rdoOther.Checked = true;
            //if (tbRole.Text == "Quản lý") rdoManager.Checked = true; else rdoSaff.Checked = true;

        }

        private void UserBinding()
        {
            tbName.DataBindings.Add(new Binding("Text", dtgvUsers.DataSource, "Họ và tên", true, DataSourceUpdateMode.Never));         
            tbAge.DataBindings.Add(new Binding("Text", dtgvUsers.DataSource, "Tuổi", true, DataSourceUpdateMode.Never));

            tbUserName.DataBindings.Add(new Binding("Text", dtgvUsers.DataSource, "Tài khoản", true, DataSourceUpdateMode.Never));
            tbUserName.DataBindings.Add(new Binding("Tag", dtgvUsers.DataSource, "Tài khoản", true, DataSourceUpdateMode.Never));
            tbGender.DataBindings.Add(new Binding("Text", dtgvUsers.DataSource, "Giới tính"));

            if (tbGender.Text == "Nam") rdoMale.Checked = true;
            else if (tbGender.Text == "Nữ") rdoFemale.Checked = true; else rdoOther.Checked = true;
            tbRole.DataBindings.Add(new Binding("Text", dtgvUsers.DataSource, "Chức vụ"));
            if (tbRole.Text == "Quản lý") rdoManager.Checked = true; else rdoSaff.Checked = true;
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

        private void resertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManagerController.Instance.ResetDataInput(this);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ManagerController.Instance.ResetDataInput(this);
        }

        private void dtgvUsers_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (tbGender.Text == "Nam") rdoMale.Checked = true;
            else if (tbGender.Text == "Nữ") rdoFemale.Checked = true; else rdoOther.Checked = true;
            if (tbRole.Text == "Quản lý") rdoManager.Checked = true; else rdoSaff.Checked = true;
        }
    }
}
