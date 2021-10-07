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
    public partial class uscSale : UserControl
    {
        private static uscSale instance;

        public static uscSale Instance 
        { 
            get
            {
                if(instance == null)
                {
                    instance = new uscSale();
                }
                return instance;
            }
        }

        public uscSale()
        {
            InitializeComponent();

            //



            LoadListTable();
        }

        private void LoadListTable()
        {





        }

    }
}
