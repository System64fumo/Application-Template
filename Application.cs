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
            //Theme
            foreach (Control c in this.Controls) { Program.Theme(c); } //For each control found in the program this will apply its correct color
            this.BackColor = Program.Background; //Sets the background color of the program
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Program.Accent;
            button2.BackColor = Program.Inactive;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.BackColor = Program.Inactive;
            button2.BackColor = Program.Accent;
        }
    }
}
