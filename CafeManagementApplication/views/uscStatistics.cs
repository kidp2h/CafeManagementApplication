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
        private BindingSource billList = new BindingSource();
        

        private uscStatistics()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            dtgvBill.DataSource = billList;
            LoadListBillForView();
            lbSubtotalBills.Text = BillController.Instance.SubtotalBills().ToString();
        }

        public void LoadListBillForView()
        {
            //Thread loadList = new Thread(() =>
            //{
                dt = new DataTable();
                BillController.Instance.LoadBill(dt);
                dv = new DataView(dt);
                billList.DataSource = dv;
               

            //});
            //loadlist.isbackground = true;
            //loadlist.start();
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
