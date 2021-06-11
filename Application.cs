using System;
using System.Drawing;
using System.Windows.Forms;

namespace Modern_Application
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }

        //Titlebar stuff
        Point lastPoint;
        private void Titlebar_MouseDown(object sender, MouseEventArgs e) { lastPoint = new Point(e.X, e.Y); }
        private void Titlebar_MouseMove(object sender, MouseEventArgs e) { if (e.Button == MouseButtons.Left) { this.Left += e.X - lastPoint.X; this.Top += e.Y - lastPoint.Y; } }
        private void ExitButton_Click(object sender, EventArgs e) { Application.Exit(); } //Exits the application
        private void MinimizeButton_Click(object sender, EventArgs e) { WindowState = FormWindowState.Minimized; } //Minimizes the application
        private void MainPage_Load(object sender, EventArgs e)
        {
            Theme.Set(this); //This will theme the application
        }
    }
}
