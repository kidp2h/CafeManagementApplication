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
    public partial class uscManager_Drinks : UserControl
    {
        private static uscManager_Drinks instance;

        public static uscManager_Drinks Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new uscManager_Drinks();
                }
                return instance;
            }
        }
        private uscManager_Drinks()
        {
            InitializeComponent();
        }


    }
}
