using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace BubbleTrouble
{
    public partial class SelectCharacter : Form
    {
        public Boolean skipper;
        public Boolean privatee;
        public Boolean rico;
        public Boolean kowalski;
        public int selected;
        private SoundPlayer simpleSound;
        public SelectCharacter()
        {
            InitializeComponent();
            //skipper = false;
            //privatee=false;
            //rico = false;
            //kowalski = false;

            WindowState = FormWindowState.Maximized;
            button1.BackgroundImage = Properties.Resources.skipper;
            button2.BackgroundImage = Properties.Resources.rico;
            button3.BackgroundImage = Properties.Resources.kowalski;
            button4.BackgroundImage = Properties.Resources._private;
            this.BackgroundImage = Properties.Resources.bckg;
            this.label1.Font = new Font("Verdana", 30, FontStyle.Bold);
            label1.ForeColor = System.Drawing.Color.Orange;
            label1.BackColor = Color.Transparent;
            selected = 1;
            SoundPlayer simpleSound;



        }

        private void button1_Click(object sender, EventArgs e)
        {
            //skipper = true;
            //privatee = false;
            //rico = false;
            // kowalski = false;
            selected = 1;
            Program.OpenDetailFormOnClose = true;
            simpleSound = new SoundPlayer(Properties.Resources.skippersound);
            simpleSound.Play();
            this.Close();

        }


        private void button3_Click(object sender, EventArgs e)
        {
            selected = 3;
            Program.OpenDetailFormOnClose = true;
            this.Close();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {

            selected = 2;
            Program.OpenDetailFormOnClose = true;
            simpleSound = new SoundPlayer(Properties.Resources.ricosound1);
            simpleSound.Play();
            this.Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            selected = 3;
            Program.OpenDetailFormOnClose = true;

            simpleSound = new SoundPlayer(Properties.Resources.kowalskisound);
            simpleSound.Play();

            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            selected = 4;
            Program.OpenDetailFormOnClose = true;
            simpleSound = new SoundPlayer(Properties.Resources.privatesound);
            simpleSound.Play();
            this.Close();


        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            simpleSound = new SoundPlayer(Properties.Resources.ricosound1);
            simpleSound.Play();
        }



        private void button3_MouseHover(object sender, EventArgs e)
        {
            simpleSound = new SoundPlayer(Properties.Resources.kowalskisound);
            simpleSound.Play();
        }


        //private void button3_MouseLeave(object sender, EventArgs e)
        //{
        //    if (simpleSound != null)
        //        simpleSound.Stop();
        //}

        private void button4_MouseHover(object sender, EventArgs e)
        {
            simpleSound = new SoundPlayer(Properties.Resources.privatesound);
            simpleSound.Play();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            simpleSound = new SoundPlayer(Properties.Resources.skippersound);
            
            simpleSound.Play();
        }

        

      







    }
}
