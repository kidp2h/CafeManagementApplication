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
            btnManagerTables_Click(null,null);
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
            if (!pnlModule.Controls.Contains(uscManager_Drinks.Instance))
            {
                pnlModule.Controls.Add(uscManager_Drinks.Instance);
                uscManager_Drinks.Instance.Dock = DockStyle.Fill;
                uscManager_Drinks.Instance.BringToFront();

            }
            else uscManager_Drinks.Instance.BringToFront();
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
    }
}
