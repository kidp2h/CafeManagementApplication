
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAddTable = new System.Windows.Forms.Button();
            this.btnDeleteTable = new System.Windows.Forms.Button();
            this.btnUpdateTable = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rdoEmpty = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rdoFull = new System.Windows.Forms.RadioButton();
            this.tbTableName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.dtgvTables = new System.Windows.Forms.DataGridView();
            this.tbStatus = new System.Windows.Forms.TextBox();
            this.tbTableSelected = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvTables)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAddTable);
            this.panel1.Controls.Add(this.btnDeleteTable);
            this.panel1.Controls.Add(this.btnUpdateTable);
            this.panel1.Location = new System.Drawing.Point(743, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(267, 261);
            this.panel1.TabIndex = 8;
            // 
            // btnAddTable
            // 
            this.btnAddTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold);
            this.btnAddTable.Location = new System.Drawing.Point(3, 3);
            this.btnAddTable.Name = "btnAddTable";
            this.btnAddTable.Size = new System.Drawing.Size(260, 68);
            this.btnAddTable.TabIndex = 1;
            this.btnAddTable.Text = "Thêm";
            this.btnAddTable.UseVisualStyleBackColor = true;
            this.btnAddTable.Click += new System.EventHandler(this.btnAddTable_Click);
            // 
            // btnDeleteTable
            // 
            this.btnDeleteTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold);
            this.btnDeleteTable.Location = new System.Drawing.Point(3, 190);
            this.btnDeleteTable.Name = "btnDeleteTable";
            this.btnDeleteTable.Size = new System.Drawing.Size(264, 68);
            this.btnDeleteTable.TabIndex = 3;
            this.btnDeleteTable.Text = "Xóa";
            this.btnDeleteTable.UseVisualStyleBackColor = true;
            this.btnDeleteTable.Click += new System.EventHandler(this.btnDeleteTable_Click);
            // 
            // btnUpdateTable
            // 
            this.btnUpdateTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold);
            this.btnUpdateTable.Location = new System.Drawing.Point(3, 97);
            this.btnUpdateTable.Name = "btnUpdateTable";
            this.btnUpdateTable.Size = new System.Drawing.Size(264, 68);
            this.btnUpdateTable.TabIndex = 2;
            this.btnUpdateTable.Text = "Sửa";
            this.btnUpdateTable.UseVisualStyleBackColor = true;
            this.btnUpdateTable.Click += new System.EventHandler(this.btnUpdateTabe_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rdoEmpty);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.rdoFull);
            this.panel2.Controls.Add(this.tbTableName);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(643, 352);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(430, 253);
            this.panel2.TabIndex = 15;
            // 
            // rdoEmpty
            // 
            this.rdoEmpty.AutoSize = true;
            this.rdoEmpty.Checked = true;
            this.rdoEmpty.Enabled = false;
            this.rdoEmpty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoEmpty.ForeColor = System.Drawing.Color.Maroon;
            this.rdoEmpty.Location = new System.Drawing.Point(155, 140);
            this.rdoEmpty.Name = "rdoEmpty";
            this.rdoEmpty.Size = new System.Drawing.Size(132, 29);
            this.rdoEmpty.TabIndex = 20;
            this.rdoEmpty.TabStop = true;
            this.rdoEmpty.Text = "Bàn trống ";
            this.rdoEmpty.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.Location = new System.Drawing.Point(3, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 29);
            this.label1.TabIndex = 21;
            this.label1.Text = "Trạng Thái:";
            // 
            // rdoFull
            // 
            this.rdoFull.AutoSize = true;
            this.rdoFull.Enabled = false;
            this.rdoFull.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoFull.ForeColor = System.Drawing.Color.Maroon;
            this.rdoFull.Location = new System.Drawing.Point(305, 141);
            this.rdoFull.Name = "rdoFull";
            this.rdoFull.Size = new System.Drawing.Size(120, 29);
            this.rdoFull.TabIndex = 19;
            this.rdoFull.Text = "Có người";
            this.rdoFull.UseVisualStyleBackColor = true;
            // 
            // tbTableName
            // 
            this.tbTableName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTableName.Location = new System.Drawing.Point(138, 57);
            this.tbTableName.Name = "tbTableName";
            this.tbTableName.Size = new System.Drawing.Size(289, 34);
            this.tbTableName.TabIndex = 19;
            this.tbTableName.TextChanged += new System.EventHandler(this.tbTableName_TextChanged);
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
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImage = global::CafeManagementApplication.Properties.Resources.Search;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(564, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(47, 33);
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // tbSearch
            // 
            this.tbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearch.Location = new System.Drawing.Point(9, 18);
            this.tbSearch.Multiline = true;
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(605, 35);
            this.tbSearch.TabIndex = 22;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // dtgvTables
            // 
            this.dtgvTables.AllowUserToAddRows = false;
            this.dtgvTables.AllowUserToDeleteRows = false;
            this.dtgvTables.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvTables.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgvTables.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvTables.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dtgvTables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvTables.Location = new System.Drawing.Point(9, 60);
            this.dtgvTables.Name = "dtgvTables";
            this.dtgvTables.ReadOnly = true;
            this.dtgvTables.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dtgvTables.RowHeadersVisible = false;
            this.dtgvTables.RowHeadersWidth = 25;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgvTables.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dtgvTables.RowTemplate.Height = 24;
            this.dtgvTables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvTables.Size = new System.Drawing.Size(602, 707);
            this.dtgvTables.TabIndex = 24;
            this.dtgvTables.CurrentCellChanged += new System.EventHandler(this.dtgvTables_CurrentCellChanged);
            // 
            // tbStatus
            // 
            this.tbStatus.Location = new System.Drawing.Point(564, 19);
            this.tbStatus.Name = "tbStatus";
            this.tbStatus.Size = new System.Drawing.Size(10, 22);
            this.tbStatus.TabIndex = 25;
            // 
            // tbTableSelected
            // 
            this.tbTableSelected.Location = new System.Drawing.Point(529, 28);
            this.tbTableSelected.Name = "tbTableSelected";
            this.tbTableSelected.Size = new System.Drawing.Size(10, 22);
            this.tbTableSelected.TabIndex = 26;
            // 
            // uscManager_Tables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Controls.Add(this.dtgvTables);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tbStatus);
            this.Controls.Add(this.tbTableSelected);
            this.Name = "uscManager_Tables";
            this.Size = new System.Drawing.Size(1115, 770);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvTables)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDeleteTable;
        private System.Windows.Forms.Button btnUpdateTable;
        private System.Windows.Forms.Button btnAddTable;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbTableName;
        private System.Windows.Forms.RadioButton rdoEmpty;
        private System.Windows.Forms.RadioButton rdoFull;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.DataGridView dtgvTables;
        private System.Windows.Forms.TextBox tbStatus;
        private System.Windows.Forms.TextBox tbTableSelected;
        private System.Windows.Forms.Label label1;
    }
}
