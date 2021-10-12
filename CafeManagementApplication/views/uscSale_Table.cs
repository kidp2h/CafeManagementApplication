using CafeManagementApplication.controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeManagementApplication.views
{
    public partial class uscSale_Table : UserControl
    {
        private Color backgroundColorCurrent;
        public uscSale_Table()
        {
            InitializeComponent();
            
        }

        #region Getter & Setter Table Name & Status
        private string tableName;
        private string status;
        private string tableId;

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


        #endregion

        private void uscSale_Table_Click(object sender, EventArgs e)
        {
            LoadListController.Instance.LoadingBillForListViewFormTableID(this.Tag.ToString());
            uscSale.Instance.LblTableName = this.TableName;
        }
    }
}
