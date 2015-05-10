using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace BubbleTrouble
{

    public partial class MainMenu : Form
    {
        SoundPlayer simpleSound;
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
            simpleSound = new SoundPlayer(Properties.Resources.theme_song);
            simpleSound.Play();
        }

    

        private void button1_Click(object sender, EventArgs e)
        {
            Program.OpenDetailFormOnClose = true;
            simpleSound.Stop();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.OpenSelectChar = true;
            simpleSound.Stop();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            simpleSound.Stop();
            this.Close();
           
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.ForeColor = System.Drawing.Color.Orange;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.ForeColor = System.Drawing.Color.Orange;
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.ForeColor = System.Drawing.Color.Orange;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = System.Drawing.Color.LightCyan;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.ForeColor = System.Drawing.Color.LightCyan;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.ForeColor = System.Drawing.Color.LightCyan;
        }

       


    }
}
