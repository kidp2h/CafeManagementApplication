
namespace CafeManagementApplication.views
{
    partial class uscManager_Tables
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
            this.button4 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAddTable = new System.Windows.Forms.Button();
            this.btnDeleteTable = new System.Windows.Forms.Button();
            this.btnUpdateTabe = new System.Windows.Forms.Button();
            this.lvTableInfor = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.iFullTable = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.iTableName = new System.Windows.Forms.TextBox();
            this.iEmptyTable = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.button4.Location = new System.Drawing.Point(532, 20);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(82, 33);
            this.button4.TabIndex = 10;
            this.button4.Text = "Tìm kiếm";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(9, 20);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(517, 33);
            this.richTextBox1.TabIndex = 9;
            this.richTextBox1.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAddTable);
            this.panel1.Controls.Add(this.btnDeleteTable);
            this.panel1.Controls.Add(this.btnUpdateTabe);
            this.panel1.Location = new System.Drawing.Point(667, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(389, 265);
            this.panel1.TabIndex = 8;
            // 
            // btnAddTable
            // 
            this.btnAddTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold);
            this.btnAddTable.Location = new System.Drawing.Point(64, 3);
            this.btnAddTable.Name = "btnAddTable";
            this.btnAddTable.Size = new System.Drawing.Size(273, 68);
            this.btnAddTable.TabIndex = 1;
            this.btnAddTable.Text = "Thêm";
            this.btnAddTable.UseVisualStyleBackColor = true;
            this.btnAddTable.Click += new System.EventHandler(this.btnAddTable_Click);
            // 
            // btnDeleteTable
            // 
            this.btnDeleteTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold);
            this.btnDeleteTable.Location = new System.Drawing.Point(64, 197);
            this.btnDeleteTable.Name = "btnDeleteTable";
            this.btnDeleteTable.Size = new System.Drawing.Size(273, 68);
            this.btnDeleteTable.TabIndex = 3;
            this.btnDeleteTable.Text = "Xóa";
            this.btnDeleteTable.UseVisualStyleBackColor = true;
            this.btnDeleteTable.Click += new System.EventHandler(this.btnDeleteTable_Click);
            // 
            // btnUpdateTabe
            // 
            this.btnUpdateTabe.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold);
            this.btnUpdateTabe.Location = new System.Drawing.Point(64, 100);
            this.btnUpdateTabe.Name = "btnUpdateTabe";
            this.btnUpdateTabe.Size = new System.Drawing.Size(273, 68);
            this.btnUpdateTabe.TabIndex = 2;
            this.btnUpdateTabe.Text = "Sửa";
            this.btnUpdateTabe.UseVisualStyleBackColor = true;
            this.btnUpdateTabe.Click += new System.EventHandler(this.btnUpdateTabe_Click);
            // 
            // lvTableInfor
            // 
            this.lvTableInfor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lvTableInfor.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvTableInfor.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvTableInfor.FullRowSelect = true;
            this.lvTableInfor.GridLines = true;
            this.lvTableInfor.HideSelection = false;
            this.lvTableInfor.Location = new System.Drawing.Point(9, 62);
            this.lvTableInfor.Name = "lvTableInfor";
            this.lvTableInfor.Size = new System.Drawing.Size(605, 688);
            this.lvTableInfor.TabIndex = 7;
            this.lvTableInfor.UseCompatibleStateImageBehavior = false;
            this.lvTableInfor.View = System.Windows.Forms.View.Details;
            this.lvTableInfor.SelectedIndexChanged += new System.EventHandler(this.listViewTableInfor_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên bàn";
            this.columnHeader1.Width = 299;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Trạng thái ";
            this.columnHeader2.Width = 547;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên bàn";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Trạng thái ";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.iFullTable);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.iTableName);
            this.panel2.Controls.Add(this.iEmptyTable);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(643, 352);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(430, 253);
            this.panel2.TabIndex = 15;
            // 
            // iFullTable
            // 
            this.iFullTable.AutoSize = true;
            this.iFullTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iFullTable.Location = new System.Drawing.Point(276, 141);
            this.iFullTable.Name = "iFullTable";
            this.iFullTable.Size = new System.Drawing.Size(120, 29);
            this.iFullTable.TabIndex = 19;
            this.iFullTable.Text = "Có người";
            this.iFullTable.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label2.Location = new System.Drawing.Point(3, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 29);
            this.label2.TabIndex = 16;
            this.label2.Text = "Trạng thái:";
            // 
            // iTableName
            // 
            this.iTableName.Location = new System.Drawing.Point(138, 49);
            this.iTableName.Multiline = true;
            this.iTableName.Name = "iTableName";
            this.iTableName.Size = new System.Drawing.Size(289, 49);
            this.iTableName.TabIndex = 19;
            // 
            // iEmptyTable
            // 
            this.iEmptyTable.AutoSize = true;
            this.iEmptyTable.Checked = true;
            this.iEmptyTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iEmptyTable.Location = new System.Drawing.Point(138, 140);
            this.iEmptyTable.Name = "iEmptyTable";
            this.iEmptyTable.Size = new System.Drawing.Size(132, 29);
            this.iEmptyTable.TabIndex = 20;
            this.iEmptyTable.TabStop = true;
            this.iEmptyTable.Text = "Bàn trống ";
            this.iEmptyTable.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label3.Location = new System.Drawing.Point(3, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 29);
            this.label3.TabIndex = 17;
            this.label3.Text = "Tên bàn:";
            // 
            // uscManager_Tables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lvTableInfor);
            this.Name = "uscManager_Tables";
            this.Size = new System.Drawing.Size(1115, 770);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDeleteTable;
        private System.Windows.Forms.Button btnUpdateTabe;
        private System.Windows.Forms.Button btnAddTable;
        private System.Windows.Forms.ListView lvTableInfor;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox iTableName;
        private System.Windows.Forms.RadioButton iEmptyTable;
        private System.Windows.Forms.RadioButton iFullTable;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}
