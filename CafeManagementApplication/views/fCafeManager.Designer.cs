
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
            this.pnlModule = new System.Windows.Forms.Panel();
            this.btnSale = new System.Windows.Forms.Button();
            this.btnManager = new System.Windows.Forms.Button();
            this.btnStatistics = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnlModule
            // 
            this.pnlModule.BackColor = System.Drawing.Color.White;
            this.pnlModule.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlModule.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlModule.ForeColor = System.Drawing.Color.Black;
            this.pnlModule.Location = new System.Drawing.Point(12, 95);
            this.pnlModule.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlModule.Name = "pnlModule";
            this.pnlModule.Size = new System.Drawing.Size(1398, 756);
            this.pnlModule.TabIndex = 0;
            // 
            // btnSale
            // 
            this.btnSale.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSale.Location = new System.Drawing.Point(12, 12);
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
            this.btnManager.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManager.Location = new System.Drawing.Point(171, 12);
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
            this.btnStatistics.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatistics.Location = new System.Drawing.Point(331, 12);
            this.btnStatistics.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Size = new System.Drawing.Size(153, 57);
            this.btnStatistics.TabIndex = 3;
            this.btnStatistics.Text = "THỐNG KÊ";
            this.btnStatistics.UseVisualStyleBackColor = true;
            this.btnStatistics.Click += new System.EventHandler(this.btnStatistics_Click);
            // 
            // fCafeManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1419, 863);
            this.Controls.Add(this.btnStatistics);
            this.Controls.Add(this.btnManager);
            this.Controls.Add(this.btnSale);
            this.Controls.Add(this.pnlModule);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "fCafeManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Phần mềm quản lý quán cafe";
            this.ResumeLayout(false);

        }

        #endregion


        private System.Windows.Forms.Panel pnlModule;
        private System.Windows.Forms.Button btnSale;
        private System.Windows.Forms.Button btnManager;
        private System.Windows.Forms.Button btnStatistics;

    }
}