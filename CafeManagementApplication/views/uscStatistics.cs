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
    }
}
