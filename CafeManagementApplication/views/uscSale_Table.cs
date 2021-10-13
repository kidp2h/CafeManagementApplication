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

        public string TableName
        {
            get { return tableName; }
            set { tableName = value; lbTableName.Text = value; }
        }

        public string Status
        {
            get { return status; }
            set 
            { 
                status = value;
                if (status == "Có người")
                {
                    lbTableName.ForeColor = Color.White;
                    this.BackColor = Color.Brown;
                }
                else
                {
                    lbTableName.ForeColor = Color.Black;
                    this.BackColor = Color.DarkTurquoise;
                }
                this.backgroundColorCurrent = this.BackColor;
            }
        }

        public string Id
        {
            get { return this.Tag.ToString(); }
        }
        #endregion

        #region Hover Effect      
        private void uscSale_Table_MouseEnter(object sender, EventArgs e)
        {
            if(this.status == "Có người") this.BackColor = Color.Red;
            else this.BackColor = Color.Cyan;
        }

        private void uscSale_Table_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = this.backgroundColorCurrent;
        }

        private void lbTableName_MouseEnter(object sender, EventArgs e)
        {
            uscSale_Table_MouseEnter(null, null);
        }

        private void lbTableName_MouseLeave(object sender, EventArgs e)
        {
            uscSale_Table_MouseLeave(null, null);
        }

        #endregion

        #region Handler Event
        private void uscSale_Table_Click(object sender, EventArgs e)
        {
            LoadListController.Instance.LoadingBillForListViewFormTableID(this.Tag.ToString());
            uscSale.Instance.LblTableName = this.TableName;
            uscSale.Instance.TableId = this.Id;
            uscSale.Instance.TableStatus = this.Status;

        }

        private void lbTableName_Click(object sender, EventArgs e)
        {
            uscSale_Table_Click(null, null);
        }
        #endregion
    }
}
