using CafeManagementApplication.controllers;
using CafeManagementApplication.models;
using CafeManagementApplication.types;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeManagementApplication.views
{
    public partial class uscSale : UserControl
    {
        private static uscSale instance;
        public ListView getLvBillforOneTable()
        {
            return lvBillforOneTable;
        }

        public TextBox getITotalPriceProducts()
        {
            return iTotalPriceProducts;
        }

        public static uscSale Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new uscSale();
                }
                return instance;
            }
        }

        private uscSale()
        {
            InitializeComponent();
            LoadListTableForForm();

        }

        private void LoadListTableForForm()
        {
            LoadTable.Instance.LoadingTableList(flpTableList);
        }

   
    }
}
