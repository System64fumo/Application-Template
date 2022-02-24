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
            MainWindow Window = new MainWindow();
            Theme.Initialize(Window); //Initialize the application
            Application.Run(Window);  //Run the application
        }
       
    }
}
