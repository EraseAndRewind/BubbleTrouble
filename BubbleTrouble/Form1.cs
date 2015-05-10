using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BubbleTrouble
{
    public partial class Form1 : Form
    {
        private readonly int REDUCE = 100;
        private ObjectDoc objectDoc;
        private Timer timer;
        private int left;
        private int top;
        private int width;
        private int height;
        private Image slika;
        public int selected;
        

        public Form1(int i)
        {
            WindowState = FormWindowState.Maximized;
            InitializeComponent();
            this.DoubleBuffered = true;
            timer = new Timer();
            timer.Interval = 1;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
            left = 0;
            top = 0;
            width = this.Width - REDUCE;
            height = this.Height - 90;
            selected = i;
            newGame(3,0,1);
            slika = Properties.Resources.gameoverr2;

            //this.progressBar1.FillStyle = ColorProgressBar.ColorProgressBar.FillStyles.Dashed;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            button1.BackgroundImage = Properties.Resources.btn1;
            button2.BackgroundImage = Properties.Resources.btn1;
            this.button1.Font = new Font("Verdana", 24, FontStyle.Bold);
            this.button2.Font = new Font("Verdana   ", 24, FontStyle.Bold);
            button1.ForeColor = System.Drawing.Color.LightCyan;
            button2.ForeColor = System.Drawing.Color.LightCyan;
            button1.Hide();
            button2.Hide();
         

         }

        void newGame(int player1Life, int player2Life, int level)
        {
            objectDoc = new ObjectDoc(level);
            
            Point p  = new Point(width /2 , height);
            objectDoc.createPlayers(p, player1Life, selected);

            createObjects();

            label1.Text = String.Format("{0} ",player1Life);
            this.label1.Font = new Font("Verdana", 24, FontStyle.Bold);
            label1.ForeColor = System.Drawing.Color.Orange;
            this.label2.Font = new Font("Verdana", 18, FontStyle.Bold);
            label2.ForeColor = System.Drawing.Color.LightBlue;
            this.label4.Font = new Font("Verdana", 18, FontStyle.Bold);
            label4.ForeColor = System.Drawing.Color.LightBlue;
            this.label5.Font = new Font("Verdana", 24, FontStyle.Bold);
            label5.ForeColor = System.Drawing.Color.Orange;
            label5.Text = String.Format("{0} ", level);
         }

        void createObjects()
        {
            if(objectDoc.level == 1)
            {
                Point point = new Point(400, 300);
                objectDoc.spawnBubble(new Bubble(point, 40, Color.Red, 0, 0.5));
            }
            else if (objectDoc.level == 2)
            {
                Point point = new Point(400, 300);
                objectDoc.spawnBubble(new Bubble(point, 40, Color.Red, 0, 0.5));
                point = new Point(200, 300);
                objectDoc.spawnBubble(new Bubble(point, 40, Color.Purple, 180, -0.5));
            }
            else if (objectDoc.level == 3)
            {
                Point point = new Point(500, 300);
                objectDoc.spawnBubble(new Bubble(point, 40, Color.Red, 0, 0.5));
                point = new Point(100, 300);
                objectDoc.spawnBubble(new Bubble(point, 40, Color.Purple, 180, -0.5));
                point = new Point(300, 300);
                objectDoc.spawnBubble(new Bubble(point, 40, Color.Yellow, 0, 0.5));
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {

            progressBar1.Increment(1);
            objectDoc.timeLeft = progressBar1.Maximum - progressBar1.Value;
            Console.WriteLine(objectDoc.player1.life);
            if (objectDoc.restart)
            {
                newGame(objectDoc.player1.life, 0, objectDoc.level);
                progressBar1.Value = 0;
                return;
            }
            //else if (objectDoc.gameOver)
            //{
                //timer.Stop();
                //GameOver go = new GameOver();
                //go.Show();
                
            //}

            objectDoc.checkCollision();
            objectDoc.moveObjects(left, top, width, height);

            Invalidate(true);
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (objectDoc.gameOver)
            {
                //progressBar1.Hide();
                e.Graphics.DrawImage(slika, left, top, width, height);
                button1.Show();
                button2.Show();
                timer.Stop();
                label1.Text = "0";
                //label1.Hide();
                //label2.Hide();
                //label4.Hide();
                //label5.Hide();
                //panel1.BackgroundImage = Properties.Resources.gameover2;
               // panel1.BorderStyle = BorderStyle.None;
              
            }
            else{
            e.Graphics.Clear(Color.White);
            Brush brush = new SolidBrush(Color.DeepSkyBlue);
            //Pen pen = new Pen(brush);

            e.Graphics.FillRectangle(brush, left, top, width, height);
            objectDoc.Draw(e.Graphics);
            }

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
                objectDoc.player1.changeDirection(MovingObject.DIRECTION.STILL);
            else if (e.KeyCode == Keys.Left)
                objectDoc.player1.changeDirection(MovingObject.DIRECTION.STILL);
                
           Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
                objectDoc.player1.changeDirection(MovingObject.DIRECTION.RIGHT);
            else if (e.KeyCode == Keys.Left)
                objectDoc.player1.changeDirection(MovingObject.DIRECTION.LEFT);
            else if (e.KeyCode == Keys.Up)
                objectDoc.FireBullet();
                    
            Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.OpenSelectChar = true;
            this.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.OpenMainMenu = true;
            this.Close();
        }

      }
}
