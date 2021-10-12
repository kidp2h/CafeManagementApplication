
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
            this.SuspendLayout();
            // 
            // btnSale
            // 
            this.btnSale.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSale.Location = new System.Drawing.Point(9, 10);
            this.btnSale.Margin = new System.Windows.Forms.Padding(2);
            this.btnSale.Name = "btnSale";
            this.btnSale.Size = new System.Drawing.Size(115, 46);
            this.btnSale.TabIndex = 1;
            this.btnSale.Text = "BÁN HÀNG";
            this.btnSale.UseVisualStyleBackColor = false;
            this.btnSale.Click += new System.EventHandler(this.btnSale_Click);
            // 
            // btnManager
            // 
            this.btnManager.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManager.Location = new System.Drawing.Point(128, 10);
            this.btnManager.Margin = new System.Windows.Forms.Padding(2);
            this.btnManager.Name = "btnManager";
            this.btnManager.Size = new System.Drawing.Size(115, 46);
            this.btnManager.TabIndex = 2;
            this.btnManager.Text = "QUẢN LÝ";
            this.btnManager.UseVisualStyleBackColor = true;
            this.btnManager.Click += new System.EventHandler(this.btnManager_Click);
            // 
            // btnStatistics
            // 
            this.btnStatistics.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatistics.Location = new System.Drawing.Point(248, 10);
            this.btnStatistics.Margin = new System.Windows.Forms.Padding(2);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Size = new System.Drawing.Size(115, 46);
            this.btnStatistics.TabIndex = 3;
            this.btnStatistics.Text = "THỐNG KÊ";
            this.btnStatistics.UseVisualStyleBackColor = true;
            this.btnStatistics.Click += new System.EventHandler(this.btnStatistics_Click);
            // 
            // pnlModule
            // 
            this.pnlModule.Location = new System.Drawing.Point(13, 62);
            this.pnlModule.Name = "pnlModule";
            this.pnlModule.Size = new System.Drawing.Size(1048, 631);
            this.pnlModule.TabIndex = 4;
            // 
            // fCafeManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Brown;
            this.ClientSize = new System.Drawing.Size(1072, 702);
            this.Controls.Add(this.pnlModule);
            this.Controls.Add(this.btnStatistics);
            this.Controls.Add(this.btnManager);
            this.Controls.Add(this.btnSale);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
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
    }
}