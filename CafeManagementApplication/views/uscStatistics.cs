﻿using CafeManagementApplication.controllers;
using CafeManagementApplication.models;
using System;
using System.Windows.Forms;
using System.Data;
using System.Threading;

namespace CafeManagementApplication.views
{ 
    public partial class uscStatistics : UserControl
    {   
        private static uscStatistics instance;
        public static uscStatistics Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new uscStatistics();
                }
                return instance;
            }
        }

        private DataTable dt;
        private DataView dv;
        private BindingSource billList = new BindingSource();

        private uscStatistics()
        {
            InitializeComponent();
            Load();
        }

        private void Load()
        {
            dtgvBill.DataSource = billList;
            LoadListBillForView();
        }

        public void LoadListBillForView(bool status = true)
        {
            Thread loadList = new Thread(() =>
            {
                dt = new DataTable();
                BillController.Instance.LoadBill(dt);
                dv = new DataView(dt);
                billList.DataSource = dv;
            });
            loadList.IsBackground = true;
            loadList.Start();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            dv.RowFilter = String.Format("[Ngày thanh toán] LIKE '{0}*'", dateTimePicker1.Text);       
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dv.RowFilter = String.Format("[Ngày thanh toán] LIKE '%{0}%'", "");
        }


    }
}
