﻿using CafeManagementApplication.controllers;
using System;
using System.Threading;
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
                if (instance == null)
                {
                    instance = new uscSale();
                }
                return instance;
            }
        }

        private uscSale()
        {
            
            InitializeComponent();
            LoadListTableForForm();

        }

        #region Public Data In View
        public ListView getLvBillforOneTable()
        {
            return lvBillforOneTable;
        }
        public FlowLayoutPanel getFlpTableList()
        {
            return flpTableList;
        }
        public TextBox getITotalPriceProducts()
        {
            return iTotalPriceProducts;
        }
        public string LblTableName
        {
            set { lblTableName.Text = value; }
        }
        public string BtnAddTag
        {
            get { return btnAdd.Tag.ToString(); }
            set { btnAdd.Tag = value; }
        }
        public string TableId { get; set; }
        #endregion

        #region Handler Event
        public void LoadListTableForForm()
        {
            LoadItemController.Instance.LoadingItemTable(flpTableList);
        }
 
        private void btnAdd_Click(object sender, EventArgs e)
        {
            fAddProducts f = new fAddProducts();
            
            f.BillID = btnAdd.Tag.ToString();

            f.ShowDialog();

            if (f.CheckAdd)
            {
                Thread status = new Thread(() => {
                     LoadListController.Instance.LoadingBillForListViewFormTableID(this.TableId);
                });
                status.Start();
                LoadListTableForForm();
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            fPay f = new fPay();

            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadListTableForForm();
        }
        #endregion

       
    }
}
