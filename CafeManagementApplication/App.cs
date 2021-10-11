using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CafeManagementApplication.config;
using CafeManagementApplication.views;
using MongoDB.Driver;
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
            Database _ = new Database();
            Application.Run(new fDrinksCategory());
        }
    }
}
