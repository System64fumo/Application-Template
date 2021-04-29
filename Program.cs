using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
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
            Application.Run(new MainPage());
        }
        public static void ReadTheme()
        {
            //Read App Theme
            int AppTheme = (int)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", "AppsUseLightTheme", null);
            if (AppTheme == 0)
            {
                Background = Color.FromArgb(20, 20, 20);
                Color1 = Color.FromArgb(25, 25, 27);
                Text = Color.FromArgb(255, 255, 255);
                Inactive = Color.FromArgb(30, 30, 35);
            }
            else
            {
                Background = Color.FromArgb(250, 250, 250);
                Color1 = Color.FromArgb(240, 240, 240);
                Text = Color.FromArgb(0, 0, 0);
                Inactive = Color.FromArgb(220, 220, 220);
            }
        }
        public static void ReadAccent()
        {
            //Read Accent Color From Registry
            int regValInt = (int)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\DWM", "ColorizationColor", null);
            var regValHex = regValInt.ToString("X");
            string HexColor = regValHex.Remove(0, 2);
            int r, g, b = 0;
            r = int.Parse(HexColor.Substring(0, 2), NumberStyles.AllowHexSpecifier);
            g = int.Parse(HexColor.Substring(2, 2), NumberStyles.AllowHexSpecifier);
            b = int.Parse(HexColor.Substring(4, 2), NumberStyles.AllowHexSpecifier);

            Accent = Color.FromArgb(r, g, b);
            DarkAccent = Color.FromArgb(Math.Max(0, r - 50), Math.Max(0, g - 50), Math.Max(0, b - 50));
        }


        //Colors
        public static Color Accent = Color.FromArgb(50, 50, 65);
        public static Color DarkAccent = Color.FromArgb(40, 40, 55);
        public static Color Inactive = Color.FromArgb(30, 30, 35);
        public static Color Background = Color.FromArgb(20, 20, 20);
        public static Color Color1 = Color.FromArgb(25, 25, 27);
        public static Color Text = Color.FromArgb(255, 255, 255);
    }
}
