
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
            this.btnTable = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTable
            // 
            this.btnTable.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnTable.BackgroundImage = global::CafeManagementApplication.Properties.Resources.imgTable;
            this.btnTable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTable.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnTable.FlatAppearance.BorderSize = 2;
            this.btnTable.FlatAppearance.MouseDownBackColor = System.Drawing.Color.NavajoWhite;
            this.btnTable.Font = new System.Drawing.Font("Cooper Black", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTable.ForeColor = System.Drawing.Color.Black;
            this.btnTable.Location = new System.Drawing.Point(0, 0);
            this.btnTable.Name = "btnTable";
            this.btnTable.Size = new System.Drawing.Size(130, 130);
            this.btnTable.TabIndex = 4;
            this.btnTable.Text = "button1";
            this.btnTable.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTable.UseVisualStyleBackColor = false;
            this.btnTable.Click += new System.EventHandler(this.btnTable_Click);
            this.btnTable.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnTable_MouseDown);
            this.btnTable.MouseEnter += new System.EventHandler(this.btnTable_MouseEnter);
            this.btnTable.MouseLeave += new System.EventHandler(this.btnTable_MouseLeave);
            this.btnTable.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnTable_MouseUp);
            // 
            // uscSale_Table
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Controls.Add(this.btnTable);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Coral;
            this.Name = "uscSale_Table";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Size = new System.Drawing.Size(130, 130);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnTable;
    }
}
