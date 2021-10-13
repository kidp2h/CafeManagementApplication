using CafeManagementApplication.controllers;
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
            LoadItemController.Instance.LoadingItemProductByCategoryId(LoadPanelController.Instance.View.FlpListProducts, this.CategoryId);
        }
        #endregion

        private void lblCategoryName_Click(object sender, EventArgs e)
        {
            uscCategory_Click(null, null);
        }
    }
}
