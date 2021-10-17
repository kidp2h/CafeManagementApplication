
namespace CafeManagementApplication.views
{
    partial class fCafeManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fCafeManager));
            this.btnSale = new System.Windows.Forms.Button();
            this.btnManager = new System.Windows.Forms.Button();
            this.btnStatistics = new System.Windows.Forms.Button();
            this.pnlModule = new System.Windows.Forms.Panel();
            this.lblTime = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblFullName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSale
            // 
            this.btnSale.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSale.Location = new System.Drawing.Point(23, 25);
            this.btnSale.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSale.Name = "btnSale";
            this.btnSale.Size = new System.Drawing.Size(153, 57);
            this.btnSale.TabIndex = 1;
            this.btnSale.Text = "BÁN HÀNG";
            this.btnSale.UseVisualStyleBackColor = false;
            this.btnSale.Click += new System.EventHandler(this.btnSale_Click);
            // 
            // btnManager
            // 
            this.btnManager.Enabled = false;
            this.btnManager.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManager.Location = new System.Drawing.Point(181, 25);
            this.btnManager.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnManager.Name = "btnManager";
            this.btnManager.Size = new System.Drawing.Size(153, 57);
            this.btnManager.TabIndex = 2;
            this.btnManager.Text = "QUẢN LÝ";
            this.btnManager.UseVisualStyleBackColor = true;
            this.btnManager.Click += new System.EventHandler(this.btnManager_Click);
            // 
            // btnStatistics
            // 
            this.btnStatistics.Enabled = false;
            this.btnStatistics.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatistics.Location = new System.Drawing.Point(341, 25);
            this.btnStatistics.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Size = new System.Drawing.Size(153, 57);
            this.btnStatistics.TabIndex = 3;
            this.btnStatistics.Text = "THỐNG KÊ";
            this.btnStatistics.UseVisualStyleBackColor = true;
            this.btnStatistics.Click += new System.EventHandler(this.btnStatistics_Click);
            // 
            // pnlModule
            // 
            this.pnlModule.Location = new System.Drawing.Point(28, 89);
            this.pnlModule.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlModule.Name = "pnlModule";
            this.pnlModule.Size = new System.Drawing.Size(1397, 777);
            this.pnlModule.TabIndex = 4;
            // 
            // lblTime
            // 
            this.lblTime.AllowDrop = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.Gold;
            this.lblTime.Location = new System.Drawing.Point(716, 13);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(180, 69);
            this.lblTime.TabIndex = 5;
            this.lblTime.Text = "12:52 PM";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLogout
            // 
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(1136, 44);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(142, 37);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblFullName
            // 
            this.lblFullName.Font = new System.Drawing.Font("Wide Latin", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullName.ForeColor = System.Drawing.Color.Gold;
            this.lblFullName.Location = new System.Drawing.Point(963, 9);
            this.lblFullName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(483, 44);
            this.lblFullName.TabIndex = 8;
            this.lblFullName.Text = "x";
            this.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fCafeManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Brown;
            this.ClientSize = new System.Drawing.Size(1449, 884);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.pnlModule);
            this.Controls.Add(this.btnStatistics);
            this.Controls.Add(this.btnManager);
            this.Controls.Add(this.btnSale);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "fCafeManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần mềm quản lý quán cafe";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSale;
        private System.Windows.Forms.Button btnManager;
        private System.Windows.Forms.Button btnStatistics;
        private System.Windows.Forms.Panel pnlModule;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblFullName;
    }
}