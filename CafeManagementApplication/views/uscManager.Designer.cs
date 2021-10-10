
namespace CafeManagementApplication.views
{
    partial class uscManager
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
            this.btnManagerUsers = new System.Windows.Forms.Button();
            this.btnManagerDrinks = new System.Windows.Forms.Button();
            this.btnManagerTables = new System.Windows.Forms.Button();
            this.pnlModule = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnManagerUsers);
            this.panel1.Controls.Add(this.btnManagerDrinks);
            this.panel1.Controls.Add(this.btnManagerTables);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(270, 257);
            this.panel1.TabIndex = 0;
            // 
            // btnManagerUsers
            // 
            this.btnManagerUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManagerUsers.Location = new System.Drawing.Point(3, 151);
            this.btnManagerUsers.Name = "btnManagerUsers";
            this.btnManagerUsers.Size = new System.Drawing.Size(263, 68);
            this.btnManagerUsers.TabIndex = 2;
            this.btnManagerUsers.Text = "Quản Lý Nhân Sự";
            this.btnManagerUsers.UseVisualStyleBackColor = true;
            this.btnManagerUsers.Click += new System.EventHandler(this.btnManagerUsers_Click);
            // 
            // btnManagerDrinks
            // 
            this.btnManagerDrinks.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManagerDrinks.Location = new System.Drawing.Point(3, 77);
            this.btnManagerDrinks.Name = "btnManagerDrinks";
            this.btnManagerDrinks.Size = new System.Drawing.Size(263, 68);
            this.btnManagerDrinks.TabIndex = 1;
            this.btnManagerDrinks.Text = "Quản Lý Món";
            this.btnManagerDrinks.UseVisualStyleBackColor = true;
            this.btnManagerDrinks.Click += new System.EventHandler(this.btnManagerDrinks_Click);
            // 
            // btnManagerTables
            // 
            this.btnManagerTables.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManagerTables.Location = new System.Drawing.Point(3, 3);
            this.btnManagerTables.Name = "btnManagerTables";
            this.btnManagerTables.Size = new System.Drawing.Size(263, 68);
            this.btnManagerTables.TabIndex = 0;
            this.btnManagerTables.Text = "Quản Lý Bàn";
            this.btnManagerTables.UseVisualStyleBackColor = true;
            this.btnManagerTables.Click += new System.EventHandler(this.btnManagerTables_Click);
            // 
            // pnlModule
            // 
            this.pnlModule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlModule.Location = new System.Drawing.Point(275, 0);
            this.pnlModule.Name = "pnlModule";
            this.pnlModule.Size = new System.Drawing.Size(1123, 777);
            this.pnlModule.TabIndex = 1;
            // 
            // uscManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.Controls.Add(this.pnlModule);
            this.Controls.Add(this.panel1);
            this.Name = "uscManager";
            this.Size = new System.Drawing.Size(1398, 777);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnManagerUsers;
        private System.Windows.Forms.Button btnManagerDrinks;
        private System.Windows.Forms.Button btnManagerTables;
        private System.Windows.Forms.Panel pnlModule;
    }
}
