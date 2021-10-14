using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeManagementApplication.helpers
{
    public class ClockThread
    {
        private static ClockThread instance;
        public static ClockThread Instance
        {
            get
            {
                if (instance == null) instance = new ClockThread();
                return instance;
            }
        }
        private Label lbl;
        public void setLbl(Label lbl)
        {
            this.lbl = lbl;
        }

        public void Clock()
        {
            
            Thread time = new Thread(() =>
            {
                while (true)
                {
                    DateTime aDateTime = DateTime.Now;
                    try
                    {
                        lbl.Text = aDateTime.ToString();
                    }
                    catch (Exception e) { }
                    Thread.Sleep(1);
                }
            });
            time.IsBackground = true;
            time.Start();
    
        }

       
    }
}
