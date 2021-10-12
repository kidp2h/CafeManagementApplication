﻿using CafeManagementApplication.controllers;
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

        public string BillID { get; set; }
  
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

        public string LblNameTag
        {
            get { return lblName.Tag.ToString(); }
            set { lblName.Tag = value; }
        }
        public string txtAmount
        {
            get { return txtBoxAmount.Text; }
        }
        public TextBox tbAmount
        {
            get { return txtBoxAmount; }
        }
        public string tbSubtotal
        {
            set { textBox2.Text = value; }
        }


        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if(this.BillID != null)
            {
                BillController.Instance.AddProductToBill(this.BillID, this.LblNameTag, Int32.Parse(this.txtAmount));
            }
            else
            {
                //BillController.Instance.addBillToTable(this.BillID, this.LblNameTag, Int32.Parse(this.txtAmount));
            }
            
        }

        private void tbAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string amount = this.txtAmount;
                string price = this.LblPriceText;
                this.tbSubtotal = (Int32.Parse(amount) * Int32.Parse(price)).ToString();
            }
            catch
            {

            }
            
        }
    }
}
