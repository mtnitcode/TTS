using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Calendar
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {


            System.Globalization.CultureInfo cul = new System.Globalization.CultureInfo("fa-ir");
            System.Windows.Forms.InputLanguage.CurrentInputLanguage = System.Windows.Forms.InputLanguage.FromCulture(cul);

            Application.EnableVisualStyles();
            Application.Run( new Form1() );
        }
    }
}