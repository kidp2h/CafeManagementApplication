using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeManagementApplication.helpers
{
    class ClockThread
    {
        private Label lbl;
        public void setLbl(Label lbl)
        {
            this.lbl = lbl;
        }

        public void Time()
        {
            Thread time = new Thread(() =>
            {
                while(true) 
                {
                    DateTime aDateTime = DateTime.Now;
                    lbl.Text = aDateTime.ToString();
                    Thread.Sleep(1);
                }
            });
            time.IsBackground = true;
            time.Start();
            
        }
    }
}
