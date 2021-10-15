using CafeManagementApplication.helpers;
using System;
using CafeManagementApplication.controllers;
using System.Windows.Forms;

namespace CafeManagementApplication.views
{
    public partial class fCafeManager : Form
    {
        private static fCafeManager instance;

        public static fCafeManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new fCafeManager();
                }
                return instance;
            }
        }
        public void actionForm(string action) 
        {
            if (action == "show") this.Show();
            else this.Close();
        }


        public fCafeManager()
        {
            InitializeComponent();

            if (Properties.Settings.Default.role == "MANAGER") {
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

        private void btnLogout_Click(object sender, EventArgs e)
        {
            
            this.Close();
            fLogin.Instance.inputUsernameText = Properties.Settings.Default.username;

        }
    }
}
