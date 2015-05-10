using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BubbleTrouble
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            this.BackgroundImage = Properties.Resources.menu;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            button1.Image = Properties.Resources.btn1;
            button2.Image = Properties.Resources.btn1;
            button3.Image = Properties.Resources.btn1;
            this.button1.Font = new Font("Verdana", 24, FontStyle.Bold);
            this.button2.Font = new Font("Verdana", 24, FontStyle.Bold);
            this.button3.Font = new Font("Verdana   ", 24, FontStyle.Bold);
            button1.ForeColor = System.Drawing.Color.LightCyan;
            button2.ForeColor = System.Drawing.Color.LightCyan;
            button3.ForeColor = System.Drawing.Color.LightCyan;
        }

    

        private void button1_Click(object sender, EventArgs e)
        {
            Program.OpenDetailFormOnClose = true;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.OpenSelectChar = true;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            this.Close();
           
        }


    }
}
