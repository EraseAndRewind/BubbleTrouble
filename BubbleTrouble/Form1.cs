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
        private readonly int REDUCE = 90;
        private ObjectDoc objectDoc;
        private Timer timer;
        private int left;
        private int top;
        private int width;
        private int height;
        

        public Form1()
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
            width = this.Width;
            height = this.Height-REDUCE;
            newGame(3,0,1);

         }

        void newGame(int player1Life, int player2Life, int level)
        {
            objectDoc = new ObjectDoc(level);
            
            Point p  = new Point(width /2 , height);
            Player first = new Player(p, player1Life);
            objectDoc.createPlayers(first);

            createObjects();
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
            else if (objectDoc.gameOver)
            {
                timer.Stop();
            }

            objectDoc.checkCollision();
            objectDoc.moveObjects(left, top, width, height);

            Invalidate(true);
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            Brush brush = new SolidBrush(Color.LightBlue);
            //Pen pen = new Pen(brush);
            e.Graphics.FillRectangle(brush, left, top, width, height);
            objectDoc.Draw(e.Graphics);
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

      }
}
