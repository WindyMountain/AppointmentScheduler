using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WendyMonahanC969.Database;
using System.Globalization;

namespace WendyMonahanC969
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DBConnection.startConnection();
            Application.Run(new loginScreen());
            DBConnection.stopConnection();

        }
    }
}
