using CafeManagementApplication.controllers;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CafeManagementApplication.views
{
    public partial class uscSale_Table : UserControl
    {
        public uscSale_Table()
        {
            InitializeComponent();

        }

        #region Getter & Setter 
        private string tableName;
        private string status;
        private Color backgroundColorCurrent;
        private Color HoverColorCurrent;

        public string TableName
        {
            get { return tableName; }
            set
            {
                tableName = value; //lbTableName.Text = value;
                btnTable.Text = value;
            }
        }
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                if (status == "Có người")
                {
                    btnTable.ForeColor = Color.White;
                    btnTable.BackColor = Color.FromArgb(139, 0, 0);
                    this.HoverColorCurrent = Color.Red;
                }
                else
                {
                    btnTable.ForeColor = Color.Black;
                    btnTable.BackColor = Color.FromArgb(30, 144, 255);
                    this.HoverColorCurrent = Color.Cyan;
                }
                this.backgroundColorCurrent = btnTable.BackColor;
            }
        }
        public string BillId { get; set; }
        public string Id { get; set; }

        #endregion

        #region Hover Effect      
        private void btnTable_MouseLeave(object sender, EventArgs e)
        {
            btnTable.BackColor = this.backgroundColorCurrent;
        }

        private void btnTable_MouseEnter(object sender, EventArgs e)
        {
            if (this.status == "Có người") btnTable.BackColor = Color.Red;
            else btnTable.BackColor = Color.Cyan;
        }

        private void btnTable_MouseDown(object sender, MouseEventArgs e)
        {
            btnTable.BackColor = Color.NavajoWhite;
        }

        private void btnTable_MouseUp(object sender, MouseEventArgs e)
        {
            btnTable.BackColor = this.HoverColorCurrent;
        }

        #endregion

        #region Handler Event
        private void btnTable_Click(object sender, EventArgs e)
        {
            LoadDataController.Instance.LoadBillOfTableByIdForViewSale(this.Id);
            uscSale.Instance.LblTableName = this.TableName;
            uscSale.Instance.TableId = this.Id;
            uscSale.Instance.TableStatus = this.Status;
            uscSale.Instance.BillId = this.BillId;
        }
        #endregion

    }
}
