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
    public partial class fAddProducts : Form
    {
        private fAddProducts instance;
        public fAddProducts Instance
        {
            get
            {
                if (instance == null) instance = new fAddProducts();
                return instance;
            }
        }
        public Panel getPnlInfo()
        {
            return pnlInfo;
        }

        public fAddProducts()
        {
            InitializeComponent();
            uscManager.Instance.Show();
            LoadItemController.Instance.LoadingItemProduct(flpListProducts);
        }

    }
}
