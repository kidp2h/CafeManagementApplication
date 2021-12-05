using CafeManagementApplication.controllers;
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

        private uscStatistics()
        {
            InitializeComponent();
            LoadListBillForView();
        }

        public void LoadListBillForView()
        {
            dt = new DataTable();
            BillController.Instance.LoadBill(dt);
            dv = new DataView(dt);
            dtgvBill.DataSource = dv;
            lbSubtotalBills.Text = BillController.Instance.SubtotalBills().ToString();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            dv.RowFilter = String.Format("[Ngày thanh toán] LIKE '{0}*'", dateTimePicker1.Text);   //rowfilter của dataview    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dv.RowFilter = String.Format("[Ngày thanh toán] LIKE '%{0}%'", "");
        }

     
    }
    
}
