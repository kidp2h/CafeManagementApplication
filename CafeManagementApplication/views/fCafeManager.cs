using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CafeManagementApplication.models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CafeManagementApplication.views
{
    public partial class fCafeManager : Form
    {
        public fCafeManager()
        {
            TableModel.Instance.getBillFromIdTable("615ebc8515dd66d62ee953b3");
            //BillModel.Instance.addProductToBill("616028b2d76cf098b584633e", "615eef9df8a6f5d3953719d7");
            InitializeComponent();
            btnManager_Click(null, null);
            btnSale_Click(null, null);
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            if(!pnlModule.Controls.Contains(uscSale.Instance))
            {
                pnlModule.Controls.Add(uscSale.Instance);
                uscSale.Instance.Dock = DockStyle.Fill;
                uscSale.Instance.BringToFront(); 
            }
            else uscSale.Instance.BringToFront();

        }

        private void btnManager_Click(object sender, EventArgs e)
        {
            
            if (!pnlModule.Controls.Contains(uscManager.Instance))
            {
                pnlModule.Controls.Add(uscManager.Instance);
                uscManager.Instance.Dock = DockStyle.Fill;
                uscManager.Instance.BringToFront();

            }
            else uscManager.Instance.BringToFront();
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            if (!pnlModule.Controls.Contains(uscStatistics.Instance))
            {
                pnlModule.Controls.Add(uscStatistics.Instance);
                uscStatistics.Instance.Dock = DockStyle.Fill;
                uscStatistics.Instance.BringToFront();
                
            }
            else uscStatistics.Instance.BringToFront();
        }
    }
}
