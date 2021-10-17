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

        private DataTable dt = new DataTable();
        private DataView dv;
        private uscStatistics()
        {
            InitializeComponent();
            LoadListBillForView();
        }

        public void LoadListBillForView()
        {
            Thread loadList = new Thread(() =>
            {
                BillController.Instance.LoadBill(dt);
                dv = new DataView(dt);
                dtgvBill.DataSource = dv;
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
