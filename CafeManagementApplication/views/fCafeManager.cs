using CafeManagementApplication.helpers;
using CafeManagementApplication.types;
using System;
using System.Threading;
using System.Windows.Forms;

namespace CafeManagementApplication.views
{
    public partial class fCafeManager : Form
    {

        public fCafeManager(Role role)
        {
            InitializeComponent();

            if (role == Role.MANAGER) {
                btnManager.Enabled = true;
                btnStatistics.Enabled = true;
                btnManager_Click(null, null);
            }
            btnSale_Click(null, null);

            ClockThread.Instance.setLbl(lblTime);
            ClockThread.Instance.Clock();
           
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

        private void fCafeManager_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
