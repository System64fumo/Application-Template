using Microsoft.Win32;
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Modern_Application
{
    class Theme
    {
        public static int AppTheme = (int)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", "AppsUseLightTheme", null);
        public static void Read()
        {
            //[Read theme]
            if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", "AppsUseLightTheme", null) == null)
            {
                MessageBox.Show("Failed to read Windows Theme" + Environment.NewLine + "Reverting to backup Theme", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); //Show warning
            }
            else //Read App Theme
            {
                if (AppTheme == 0) //Load Dark Mode theme
                {
                    Background = Color.FromArgb(20, 20, 20);
                    Panel = Color.FromArgb(25, 25, 27);
                    Text = Color.FromArgb(255, 255, 255);
                    Inactive = Color.FromArgb(30, 30, 35);
                }
                else //Load Light Mode theme
                {
                    Background = Color.FromArgb(250, 250, 250);
                    Panel = Color.FromArgb(230, 230, 230);
                    Text = Color.FromArgb(0, 0, 0);
                    Inactive = Color.FromArgb(220, 220, 220);
                }
            }

            //[Read accent]
            if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\DWM", "ColorizationColor", null) == null)
            {
                MessageBox.Show("Failed to read Accent Color" + Environment.NewLine + "Reverting to backup Accent Color", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); //Show warning
            }
            else
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
                BrightAccent = Color.FromArgb(Math.Min(255, r + 100), Math.Min(255, g + 100), Math.Min(255, b + 100));
            }
        }
        public static void Set(Control control) //This will check if your app contains any of the predefined colors and theme them accordingly
        {
            if (control.ForeColor != Color.FromArgb(150, 150, 150))
            {
                control.ForeColor = Text;
                if (control.HasChildren) { foreach (Control childControl in control.Controls) { Theme.Set(childControl); } }
            }
            if (control.BackColor == Color.FromArgb(50, 50, 65)) { control.BackColor = Accent; }
            if (control.BackColor == Color.FromArgb(60, 60, 75)) { control.BackColor = BrightAccent; }
            if (control.BackColor == Color.FromArgb(40, 40, 55)) { control.BackColor = DarkAccent; }
            if (control.BackColor == Color.FromArgb(30, 30, 35)) { control.BackColor = Inactive; }
            if (control.BackColor == Color.FromArgb(20, 20, 20)) { control.BackColor = Background; }
            if (control.BackColor == Color.FromArgb(25, 25, 27)) { control.BackColor = Panel; }
            if (control.ForeColor == Color.FromArgb(255, 255, 255)) { control.ForeColor = Text; }
        }


        //These are the colors that you can use                           [ Light Mode ]|[ Dark Mode  ]
        public static Color Accent = Color.FromArgb(50, 50, 65);       // | 50 50 65    | 50 50 65    |
        public static Color BrightAccent = Color.FromArgb(60, 60, 75); // | 60 60 75    | 60 60 75    |
        public static Color DarkAccent = Color.FromArgb(40, 40, 55);   // | 40 40 55    | 40 40 55    |
        public static Color Inactive = Color.FromArgb(30, 30, 35);     // | 220 220 220 | 30 30 35    |
        public static Color Background = Color.FromArgb(20, 20, 20);   // | 250 250 250 | 20 20 20    |
        public static Color Panel = Color.FromArgb(25, 25, 27);        // | 230 230 230 | 25 25 27    |
        public static Color Text = Color.FromArgb(255, 255, 255);      // | 0 0 0       | 255 255 255 |
        public static Color Disabled = Color.FromArgb(150, 150, 150);  // | 150 150 150 | 150 150 150 |

    }
}
