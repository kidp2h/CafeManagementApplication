﻿using System;
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
    public partial class uscSale_Table : UserControl
    {
        public uscSale_Table()
        {
            InitializeComponent();
        }


        #region Getter & Setter Table Name & Status
        private string tableName;
        private string status;

        public string TableName
        {
            get { return tableName; }
            set { tableName = value; lbTableName.Text = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        #endregion

        #region Hover Effect
        
        
            
     
        #endregion

      
    }
}
