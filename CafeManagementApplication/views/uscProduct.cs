using CafeManagementApplication.controllers;
using System;
using System.Windows.Forms;

namespace CafeManagementApplication.views
{
    public partial class uscProduct : UserControl
    {   
        public uscProduct()
        {
            InitializeComponent();
        }

        #region Getter & Setter 
        private string productName;
        private string price;

        public string NameProduct
        {
            get { return productName; }
            set { productName = value; lblName.Text = value; }
        }

        public string Price
        {
            get { return price; }
            set { price = value; lblPrice.Text = value; }
        }
        #endregion


        private void uscProduct_Click(object sender, EventArgs e)
        {
            LoadPanelController.Instance.LoadingInfoProduct(this.productName, this.price, this.Tag.ToString());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            LoadPanelController.Instance.LoadingInfoProduct(this.productName, this.price, this.Tag.ToString());
        }
    }
}
