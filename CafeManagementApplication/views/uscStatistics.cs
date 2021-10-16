using CafeManagementApplication.models;
using System;
using System.Windows.Forms;

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
        private uscStatistics()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            string[] time = dateTimePicker1.Text.Split('/');
            int day = Int32.Parse(time[0]);
            int month = Int32.Parse(time[1]);
            int year = Int32.Parse(time[2]);
            dynamic result =  BillModel.Instance.listBillByDateTime(day, month, year);
            Console.WriteLine("xx");


        }
    }
}
