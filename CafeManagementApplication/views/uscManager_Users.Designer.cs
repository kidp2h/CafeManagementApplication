
namespace CafeManagementApplication.views
{
    partial class uscManager_Users
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Button btnAdd;
            this.lvUsers = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.tbUserPassword = new System.Windows.Forms.TextBox();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.tbAge = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.pnlGender = new System.Windows.Forms.Panel();
            this.rdoMale = new System.Windows.Forms.RadioButton();
            this.rdoFemale = new System.Windows.Forms.RadioButton();
            this.rdoOther = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlRole = new System.Windows.Forms.Panel();
            this.rdoSaff = new System.Windows.Forms.RadioButton();
            this.rdoManager = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            btnAdd = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.pnlGender.SuspendLayout();
            this.pnlRole.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnAdd.Location = new System.Drawing.Point(0, 0);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(262, 85);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lvUsers
            // 
            this.lvUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lvUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvUsers.FullRowSelect = true;
            this.lvUsers.GridLines = true;
            this.lvUsers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvUsers.HideSelection = false;
            this.lvUsers.Location = new System.Drawing.Point(3, 58);
            this.lvUsers.Name = "lvUsers";
            this.lvUsers.Size = new System.Drawing.Size(1109, 395);
            this.lvUsers.TabIndex = 0;
            this.lvUsers.UseCompatibleStateImageBehavior = false;
            this.lvUsers.View = System.Windows.Forms.View.Details;
            this.lvUsers.SelectedIndexChanged += new System.EventHandler(this.lvUsers_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Họ và tên";
            this.columnHeader1.Width = 316;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tuổi";
            this.columnHeader2.Width = 101;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Giới tính";
            this.columnHeader3.Width = 122;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Tài Khoản";
            this.columnHeader4.Width = 262;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Chức vụ";
            this.columnHeader5.Width = 297;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(btnAdd);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Location = new System.Drawing.Point(758, 459);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(273, 301);
            this.panel1.TabIndex = 4;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(0, 213);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(262, 85);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(0, 107);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(262, 85);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Sửa";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(796, 19);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(123, 33);
            this.button4.TabIndex = 6;
            this.button4.Text = "Tìm kiếm";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // pnlInfo
            // 
            this.pnlInfo.Controls.Add(this.tbUserPassword);
            this.pnlInfo.Controls.Add(this.tbUserName);
            this.pnlInfo.Controls.Add(this.tbAge);
            this.pnlInfo.Controls.Add(this.tbName);
            this.pnlInfo.Controls.Add(this.pnlGender);
            this.pnlInfo.Controls.Add(this.label6);
            this.pnlInfo.Controls.Add(this.label2);
            this.pnlInfo.Controls.Add(this.pnlRole);
            this.pnlInfo.Controls.Add(this.label5);
            this.pnlInfo.Controls.Add(this.label4);
            this.pnlInfo.Controls.Add(this.label3);
            this.pnlInfo.Controls.Add(this.label1);
            this.pnlInfo.Location = new System.Drawing.Point(99, 462);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(599, 305);
            this.pnlInfo.TabIndex = 12;
            // 
            // tbUserPassword
            // 
            this.tbUserPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUserPassword.Location = new System.Drawing.Point(138, 216);
            this.tbUserPassword.Multiline = true;
            this.tbUserPassword.Name = "tbUserPassword";
            this.tbUserPassword.Size = new System.Drawing.Size(441, 33);
            this.tbUserPassword.TabIndex = 27;
            this.tbUserPassword.TextChanged += new System.EventHandler(this.tbUserPassword_TextChanged);
            // 
            // tbUserName
            // 
            this.tbUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUserName.Location = new System.Drawing.Point(138, 164);
            this.tbUserName.Multiline = true;
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(441, 33);
            this.tbUserName.TabIndex = 26;
            this.tbUserName.TextChanged += new System.EventHandler(this.tbUserName_TextChanged);
            // 
            // tbAge
            // 
            this.tbAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAge.Location = new System.Drawing.Point(138, 56);
            this.tbAge.Multiline = true;
            this.tbAge.Name = "tbAge";
            this.tbAge.Size = new System.Drawing.Size(441, 33);
            this.tbAge.TabIndex = 25;
            this.tbAge.TextChanged += new System.EventHandler(this.tbAge_TextChanged);
            // 
            // tbName
            // 
            this.tbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbName.Location = new System.Drawing.Point(138, 7);
            this.tbName.Multiline = true;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(441, 33);
            this.tbName.TabIndex = 14;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // pnlGender
            // 
            this.pnlGender.Controls.Add(this.rdoMale);
            this.pnlGender.Controls.Add(this.rdoFemale);
            this.pnlGender.Controls.Add(this.rdoOther);
            this.pnlGender.Location = new System.Drawing.Point(144, 103);
            this.pnlGender.Name = "pnlGender";
            this.pnlGender.Size = new System.Drawing.Size(336, 45);
            this.pnlGender.TabIndex = 24;
            // 
            // rdoMale
            // 
            this.rdoMale.AutoSize = true;
            this.rdoMale.Checked = true;
            this.rdoMale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoMale.Location = new System.Drawing.Point(3, 10);
            this.rdoMale.Name = "rdoMale";
            this.rdoMale.Size = new System.Drawing.Size(77, 29);
            this.rdoMale.TabIndex = 17;
            this.rdoMale.TabStop = true;
            this.rdoMale.Text = "Nam";
            this.rdoMale.UseVisualStyleBackColor = true;
            // 
            // rdoFemale
            // 
            this.rdoFemale.AutoSize = true;
            this.rdoFemale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoFemale.Location = new System.Drawing.Point(101, 10);
            this.rdoFemale.Name = "rdoFemale";
            this.rdoFemale.Size = new System.Drawing.Size(60, 29);
            this.rdoFemale.TabIndex = 18;
            this.rdoFemale.TabStop = true;
            this.rdoFemale.Text = "Nữ";
            this.rdoFemale.UseVisualStyleBackColor = true;
            // 
            // rdoOther
            // 
            this.rdoOther.AutoSize = true;
            this.rdoOther.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoOther.Location = new System.Drawing.Point(192, 10);
            this.rdoOther.Name = "rdoOther";
            this.rdoOther.Size = new System.Drawing.Size(83, 29);
            this.rdoOther.TabIndex = 19;
            this.rdoOther.TabStop = true;
            this.rdoOther.Text = "Khác";
            this.rdoOther.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 262);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 29);
            this.label6.TabIndex = 21;
            this.label6.Text = "Chức vụ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 29);
            this.label2.TabIndex = 23;
            this.label2.Text = "Tuổi";
            // 
            // pnlRole
            // 
            this.pnlRole.Controls.Add(this.rdoSaff);
            this.pnlRole.Controls.Add(this.rdoManager);
            this.pnlRole.Location = new System.Drawing.Point(141, 256);
            this.pnlRole.Name = "pnlRole";
            this.pnlRole.Size = new System.Drawing.Size(339, 42);
            this.pnlRole.TabIndex = 22;
            // 
            // rdoSaff
            // 
            this.rdoSaff.AutoSize = true;
            this.rdoSaff.Checked = true;
            this.rdoSaff.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoSaff.Location = new System.Drawing.Point(0, 6);
            this.rdoSaff.Name = "rdoSaff";
            this.rdoSaff.Size = new System.Drawing.Size(134, 29);
            this.rdoSaff.TabIndex = 19;
            this.rdoSaff.TabStop = true;
            this.rdoSaff.Text = "Nhân Viên";
            this.rdoSaff.UseVisualStyleBackColor = true;
            // 
            // rdoManager
            // 
            this.rdoManager.AutoSize = true;
            this.rdoManager.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoManager.Location = new System.Drawing.Point(140, 7);
            this.rdoManager.Name = "rdoManager";
            this.rdoManager.Size = new System.Drawing.Size(115, 29);
            this.rdoManager.TabIndex = 18;
            this.rdoManager.Text = "Quản Lý";
            this.rdoManager.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 29);
            this.label5.TabIndex = 16;
            this.label5.Text = "Mật khẩu:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 29);
            this.label4.TabIndex = 15;
            this.label4.Text = "Tài khoản:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 29);
            this.label3.TabIndex = 14;
            this.label3.Text = "Giới tính:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 29);
            this.label1.TabIndex = 12;
            this.label1.Text = "Họ và tên:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(162, 19);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(628, 33);
            this.textBox1.TabIndex = 13;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(1043, 3);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(59, 49);
            this.btnReset.TabIndex = 14;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // uscManager_Users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Controls.Add(this.lvUsers);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.panel1);
            this.Name = "uscManager_Users";
            this.Size = new System.Drawing.Size(1115, 777);
            this.panel1.ResumeLayout(false);
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.pnlGender.ResumeLayout(false);
            this.pnlGender.PerformLayout();
            this.pnlRole.ResumeLayout(false);
            this.pnlRole.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvUsers;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Panel pnlRole;
        private System.Windows.Forms.RadioButton rdoSaff;
        private System.Windows.Forms.RadioButton rdoManager;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rdoOther;
        private System.Windows.Forms.RadioButton rdoFemale;
        private System.Windows.Forms.RadioButton rdoMale;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlGender;
        private System.Windows.Forms.TextBox tbUserPassword;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.TextBox tbAge;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnReset;
    }
}
