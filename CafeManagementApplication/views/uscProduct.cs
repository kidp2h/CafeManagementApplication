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
    public partial class uscProduct : UserControl
    {
        private string productName;
        private string price;

        public string ProductName
        {
            get { return productName; }
            set { productName = value; lblName.Text = value; }
        }

        public string Price
        {
            get { return price; }
            set { price = value; lblPrice.Text = value; }
        }

        public uscProduct()
        {
            InitializeComponent();
        }

        private void uscProduct_Click(object sender, EventArgs e)
        {
            LoadPanelController.Instance.LoadingInfoPanel(this.productName, this.price);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            LoadPanelController.Instance.LoadingInfoPanel(this.productName, this.price);
        }
    }
}
