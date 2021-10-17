using System.Data;
using System.Windows.Forms;

namespace CafeManagementApplication.views
{ 
    public partial class uscStatistics : UserControl
    {   
        private static uscStatistics instance;
        private DataTable dt = new DataTable();
        private DataView dv;
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


    }
}
