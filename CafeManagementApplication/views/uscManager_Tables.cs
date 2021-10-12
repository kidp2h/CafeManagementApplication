using System;
using System.Windows.Forms;

namespace CafeManagementApplication.views
{
    public partial class uscManager_Tables : UserControl
    {
        private static uscManager_Tables instance;

        public static uscManager_Tables Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new uscManager_Tables();
                }
                return instance;
            }
        }
        private uscManager_Tables()
        {
            InitializeComponent();
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void inputName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void uscManager_Tables_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
