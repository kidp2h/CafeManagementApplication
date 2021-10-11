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
        public fAddProducts()
        {
            InitializeComponent();
            LoadItemController.Instance.LoadingItemProduct(flpListProducts);
            LoadPanelController.Instance.setView(this);
        }

        public string LblNameText
        {
            get { return lblName.Text; }
            set { lblName.Text = value; }
        }

        public string LblPriceText
        {
            get { return lblPrice.Text; }
            set { lblPrice.Text = value; }
        }



    }
}
