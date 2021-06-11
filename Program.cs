using System;
using System.Windows.Forms;

namespace Modern_Application
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Modern_Application.Theme.Read(); // Read the theme
            Application.Run(new MainPage()); //Run the application
        }
       
    }
}
