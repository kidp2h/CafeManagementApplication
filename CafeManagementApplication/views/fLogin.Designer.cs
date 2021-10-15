
namespace CafeManagementApplication
{
    partial class fLogin
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fLogin));
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.lblUserPassWord = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.inputPassword = new System.Windows.Forms.TextBox();
            this.inputUsername = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbRemember = new System.Windows.Forms.CheckBox();
            this.pnlLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLogin
            // 
            this.pnlLogin.Controls.Add(this.cbRemember);
            this.pnlLogin.Controls.Add(this.lblUserPassWord);
            this.pnlLogin.Controls.Add(this.lblUserName);
            this.pnlLogin.Controls.Add(this.btnExit);
            this.pnlLogin.Controls.Add(this.btnLogin);
            this.pnlLogin.Controls.Add(this.inputPassword);
            this.pnlLogin.Controls.Add(this.inputUsername);
            this.pnlLogin.Location = new System.Drawing.Point(228, 10);
            this.pnlLogin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(201, 241);
            this.pnlLogin.TabIndex = 0;
            // 
            // lblUserPassWord
            // 
            this.lblUserPassWord.AutoSize = true;
            this.lblUserPassWord.Location = new System.Drawing.Point(17, 97);
            this.lblUserPassWord.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUserPassWord.Name = "lblUserPassWord";
            this.lblUserPassWord.Size = new System.Drawing.Size(53, 13);
            this.lblUserPassWord.TabIndex = 5;
            this.lblUserPassWord.Text = "Mật Khẩu";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(15, 41);
            this.lblUserName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(84, 13);
            this.lblUserName.TabIndex = 4;
            this.lblUserName.Text = "Tên Đăng Nhập";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(109, 180);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(85, 37);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(15, 180);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(83, 37);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // inputPassword
            // 
            this.inputPassword.Location = new System.Drawing.Point(15, 115);
            this.inputPassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.inputPassword.Name = "inputPassword";
            this.inputPassword.Size = new System.Drawing.Size(180, 20);
            this.inputPassword.TabIndex = 1;
            this.inputPassword.Text = "1";
            this.inputPassword.UseSystemPasswordChar = true;
            // 
            // inputUsername
            // 
            this.inputUsername.Location = new System.Drawing.Point(15, 59);
            this.inputUsername.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.inputUsername.Name = "inputUsername";
            this.inputUsername.Size = new System.Drawing.Size(180, 20);
            this.inputUsername.TabIndex = 0;
            this.inputUsername.Text = "admin2";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CafeManagementApplication.Properties.Resources._9203;
            this.pictureBox1.Location = new System.Drawing.Point(1, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(223, 241);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // cbRemember
            // 
            this.cbRemember.AutoSize = true;
            this.cbRemember.Location = new System.Drawing.Point(15, 150);
            this.cbRemember.Name = "cbRemember";
            this.cbRemember.Size = new System.Drawing.Size(93, 17);
            this.cbRemember.TabIndex = 6;
            this.cbRemember.Text = "Nho tai khoan";
            this.cbRemember.UseVisualStyleBackColor = true;
            this.cbRemember.CheckedChanged += new System.EventHandler(this.cbRemember_CheckedChanged);
            // 
            // fLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Coral;
            this.ClientSize = new System.Drawing.Size(433, 261);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pnlLogin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fLogin_FormClosing);
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.Label lblUserPassWord;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox inputPassword;
        private System.Windows.Forms.TextBox inputUsername;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox cbRemember;
    }
}

