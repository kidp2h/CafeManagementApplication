﻿
namespace CafeManagementApplication.views
{
    partial class uscSale_Table
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbTableName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Location = new System.Drawing.Point(-7, 131);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(224, 33);
            this.panel1.TabIndex = 2;
            // 
            // lbTableName
            // 
            this.lbTableName.Font = new System.Drawing.Font("Cooper Black", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTableName.ForeColor = System.Drawing.Color.White;
            this.lbTableName.Location = new System.Drawing.Point(-1, 104);
            this.lbTableName.Name = "lbTableName";
            this.lbTableName.Size = new System.Drawing.Size(132, 31);
            this.lbTableName.TabIndex = 3;
            this.lbTableName.Text = "Table 1";
            this.lbTableName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbTableName.Click += new System.EventHandler(this.lbTableName_Click);
            this.lbTableName.MouseEnter += new System.EventHandler(this.lbTableName_MouseEnter);
            this.lbTableName.MouseLeave += new System.EventHandler(this.lbTableName_MouseLeave);
            // 
            // uscSale_Table
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BackgroundImage = global::CafeManagementApplication.Properties.Resources.imgTable;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbTableName);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Coral;
            this.Name = "uscSale_Table";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Size = new System.Drawing.Size(130, 135);
            this.Click += new System.EventHandler(this.uscSale_Table_Click);
            this.MouseEnter += new System.EventHandler(this.uscSale_Table_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.uscSale_Table_MouseLeave);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbTableName;
    }
}
