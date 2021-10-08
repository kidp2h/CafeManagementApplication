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
    public partial class uscManager : UserControl
    {
        private static uscManager instance;

        public static uscManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new uscManager();
                }
                return instance;
            }
        }
        private uscManager()
        {
            InitializeComponent();
        }

        
    }
}
