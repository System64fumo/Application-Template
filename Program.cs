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
            ReadAccent(); //Reads Windows accent color
            ReadTheme(); //Reads Windows theme
            Application.Run(new MainPage()); //Run the application
        }
        public static void ReadTheme()
        {
            try
            {
                //Read App Theme
                int AppTheme = (int)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", "AppsUseLightTheme", null);
                if (AppTheme == 0)
                {
                    //Dark mode theme
                    Text = Color.FromArgb(255, 255, 255);
                    Inactive = Color.FromArgb(30, 30, 35);
                    Color1 = Color.FromArgb(25, 25, 27);
                    Background = Color.FromArgb(20, 20, 20);
                }
                else
                {
                    //Light mode theme
                    Text = Color.FromArgb(0, 0, 0);
                    Inactive = Color.FromArgb(220, 220, 220);
                    Color1 = Color.FromArgb(240, 240, 240);
                    Background = Color.FromArgb(250, 250, 250);
                }
            }
            catch
            {
                //Warn the user if an error occurs 
                MessageBox.Show("Unable to read theme type" + Environment.NewLine + "Reverting to defaults" , "Warning");
            }
        }
        public static void ReadAccent()
        {
            try
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
                BrightAccent = Color.FromArgb(Math.Min(255, r + 50), Math.Min(255, g + 50), Math.Min(255, b + 50));
            }
            catch
            {
                //Warn the user if an error occurs 
                MessageBox.Show("Unable to read accent" + Environment.NewLine + "Reverting to defaults", "Warning");
            }
        }

        //Theme
        //If the application detects a panel/button/label with these specified colors it will automatically
        //assign them their correct color from pre defined list
        public static void Theme(Control control)
        {
            if (control.ForeColor != Color.FromArgb(150, 150, 150))
            {
                control.ForeColor = Text;
                if (control.HasChildren)
                {
                    foreach (Control childControl in control.Controls) { Theme(childControl); }
                }
            }
            //Check controls for these colors then apply the correct color to them
            if (control.ForeColor == Color.FromArgb(255, 255, 255)) { control.ForeColor = Text; }
            if (control.BackColor == Color.FromArgb(60, 60, 75)) { control.BackColor = BrightAccent; }
            if (control.BackColor == Color.FromArgb(50, 50, 65)) { control.BackColor = Accent; }
            if (control.BackColor == Color.FromArgb(40, 40, 55)) { control.BackColor = DarkAccent; }
            if (control.BackColor == Color.FromArgb(30, 30, 35)) { control.BackColor = Inactive; }
            if (control.BackColor == Color.FromArgb(25, 25, 27)) { control.BackColor = Color1; }
            if (control.BackColor == Color.FromArgb(20, 20, 20)) { control.BackColor = Background; }
        }


        //Default Colors
        //Use these colors on panels/buttons/labels to automatically theme them on runtime
        public static Color Text = Color.FromArgb(255, 255, 255);
        public static Color BrightAccent = Color.FromArgb(60, 60, 75);
        public static Color Accent = Color.FromArgb(50, 50, 65);
        public static Color DarkAccent = Color.FromArgb(40, 40, 55);
        public static Color Inactive = Color.FromArgb(30, 30, 35);
        public static Color Background = Color.FromArgb(20, 20, 20);
        public static Color Color1 = Color.FromArgb(25, 25, 27);
    }
}
