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
    public partial class uscCategory : UserControl
    {
        public uscCategory()
        {
            InitializeComponent();
        }

        #region Getter & Setter
        private string categoryName;
        public string CategoryName
        {
            get { return categoryName; }
            set
            {
                categoryName = value;
                lblCategoryName.Text = value;
            }
        }

        public string CategoryId { get; set; }
        #endregion

        #region Handler Event 
        private void uscCategory_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
