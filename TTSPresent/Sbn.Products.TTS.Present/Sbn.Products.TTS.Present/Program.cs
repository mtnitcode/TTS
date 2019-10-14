using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sbn.Products.TTS.Present
{

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        public static bool IsProcessOpen(string name)
        {
            int i = 1;
            foreach (Process clsProcess in Process.GetProcesses())
            {
                if (clsProcess.ProcessName == name)
                {
                    if(i++ == 2)
                    return true;
                }
            }
            return false;
        }
        [STAThread]
        static void Main()  
        {
            try
            {

                if (IsProcessOpen(Application.ProductName))
                {
                    MessageBox.Show("برنامه قبلا اجرا شده است!", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Application.ExitThread();
                    Application.Exit();
                    return;
                }

                Thread.CurrentThread.CurrentUICulture = new CultureInfo("fa-IR");
				 System.Globalization.CultureInfo cul = new System.Globalization.CultureInfo("fa-ir");
				//Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture;
				System.Windows.Forms.InputLanguage.CurrentInputLanguage = System.Windows.Forms.InputLanguage.FromCulture(cul);

				Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Main());
            }
            catch(Exception ex)
            {
				Application.Exit();
            }
        }
    }
}
