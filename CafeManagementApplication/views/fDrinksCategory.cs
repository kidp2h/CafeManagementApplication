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
    public partial class fDrinksCategory : Form
    {
        public fDrinksCategory()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            uscProducts usc = new uscProducts();
            flpListProducts.Controls.Add(usc);
        }
    }
}
