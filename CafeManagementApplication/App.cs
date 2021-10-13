using System;
using System.Windows.Forms;
using CafeManagementApplication.config;
using CafeManagementApplication.views;

namespace CafeManagementApplication
{
    static class App
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Control.CheckForIllegalCrossThreadCalls = false;
            Database _ = new Database();
            Application.Run(new fCafeManager());
        }
    }
}
