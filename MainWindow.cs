using System;
using System.Windows.Forms;

namespace Modern_Application
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            //Theme.EnableAcrylic(this, AcrylicLabel);              //Enable acrylic here to make titlebar acrylic (Note it blurs the titlebar too)
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            int r = Theme.Accent.R;
            int g = Theme.Accent.G;
            int b = Theme.Accent.B;
            Theme.EnableAcrylic(this, AcrylicLabel);                //Enables acrylic on the AcrylicLabel

            //[DWM Settings]
            //WindowUtils.changeTitlebarBackColor(this, r, g, b);   //Uncomment to make the titlebar's background color match the accent color
            //WindowUtils.changeTitlebarForeColor(this, r, g, b);   //Uncomment to make the titlebar's text color match the accent color
            //WindowUtils.changeBorderColor(this, r, g, b);         //Uncomment to make the border's color match the accent color
            //WindowUtils.changeRounding(this, false);              //Uncomment to disable rounding
            //WindowUtils.flipTitlebar(this,true);                  //Uncomment to flip the titlebar

            //[How to use the color pallet]
            //AcrylicLabel.BackColor = Theme.Accent;                //Change the Acrylic label color to the accent color
        }
    }
}
