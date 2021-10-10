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
            UserModel.Instance.getListUser();
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
