using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modern_Application
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
            Program.ReadAccent(); //Reads Windows accent color
            Program.ReadTheme(); //Reads Windows theme
        }

        Point lastPoint;
        private void Titlebar_MouseDown(object sender, MouseEventArgs e) { lastPoint = new Point(e.X, e.Y); }
        private void Titlebar_MouseMove(object sender, MouseEventArgs e) { if (e.Button == MouseButtons.Left) { this.Left += e.X - lastPoint.X; this.Top += e.Y - lastPoint.Y; } }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit(); //Exits the application
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized; //Minimizes the application
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            this.BackColor = Program.Background; //Sets the background color of the program
            Titlebar.ForeColor = Program.Text; //Sets the text color on the titlebar
            ExitButton.ForeColor = Program.Text;
            MinimizeButton.ForeColor = Program.Text;
            Panel1.BackColor = Program.Color1; //Sets the panel's color
            button1.ForeColor = Program.Text; //Set button1's text color
            button1.BackColor = Program.Accent; //Set button1's background color
            button2.ForeColor = Program.Text;
            button2.BackColor = Program.Inactive;
            Label.ForeColor = Program.Text; //Sets the text color for the label , in this case its the "Hello World !" Label
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
