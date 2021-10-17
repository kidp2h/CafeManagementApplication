using System;
using System.Windows.Forms;

namespace CafeManagementApplication.views
{
    public partial class uscManager : UserControl
    {
        #region SingleTon
        private static uscManager instance;

        public static uscManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new uscManager();
                }
                return instance;
            }
        }
        private uscManager()
        {
            InitializeComponent();
            btnManagerUsers_Click(null, null);
            btnManagerCategories_Click(null, null);
            btnManagerDrinks_Click(null, null);
            btnManagerTables_Click(null, null);


        }




        #endregion

        private void btnManagerTables_Click(object sender, EventArgs e)
        {
            if (!pnlModule.Controls.Contains(uscManager_Tables.Instance))
            {
                pnlModule.Controls.Add(uscManager_Tables.Instance);
                uscManager_Tables.Instance.Dock = DockStyle.Fill;
                uscManager_Tables.Instance.BringToFront();

            }
            else uscManager_Tables.Instance.BringToFront();

        }

        private void btnManagerDrinks_Click(object sender, EventArgs e)
        {
            if (!pnlModule.Controls.Contains(uscManager_Products.Instance))
            {
                pnlModule.Controls.Add(uscManager_Products.Instance);
                uscManager_Products.Instance.Dock = DockStyle.Fill;
                uscManager_Products.Instance.BringToFront();

            }
            else uscManager_Products.Instance.BringToFront();
        }

        private void btnManagerUsers_Click(object sender, EventArgs e)
        {
            if (!pnlModule.Controls.Contains(uscManager_Users.Instance))
            {
                pnlModule.Controls.Add(uscManager_Users.Instance);
                uscManager_Users.Instance.Dock = DockStyle.Fill;
                uscManager_Users.Instance.BringToFront();

            }
            else uscManager_Users.Instance.BringToFront();
        }

        private void btnManagerCategories_Click(object sender, EventArgs e)
        {
            if (!pnlModule.Controls.Contains(uscManager_Categories.Instance))
            {
                pnlModule.Controls.Add(uscManager_Categories.Instance);
                uscManager_Categories.Instance.Dock = DockStyle.Fill;
                uscManager_Categories.Instance.BringToFront();

            }
            else uscManager_Categories.Instance.BringToFront();
        }
    }
}
