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
        
        public Form1()
        {
            InitializeComponent();
            objectDoc = new ObjectDoc();
            this.DoubleBuffered = true;
            timer = new Timer();
            timer.Interval = 1;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
            newGame();
        }

        void newGame()
        {
            left = 0;
            top = 0;
            width = this.Width - REDUCE;
            height = this.Height - REDUCE;

            Point p  = new Point(width /2 , height);
            Player first = new Player(p, 25, 50);
            objectDoc.createPlayers(first);

            
            Point point = new Point(40, 100);
            objectDoc.spawnBubble(new Bubble(point, 20, Color.Red, 0, 10));


        }

        void timer_Tick(object sender, EventArgs e)
        {
            objectDoc.moveObjects(left, top, width, height);
            objectDoc.checkCollision();
            Invalidate(true);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            Brush brush = new SolidBrush(Color.Black);
            Pen pen = new Pen(brush);
            e.Graphics.DrawRectangle(pen, left, top, width, height);
            objectDoc.Draw(e.Graphics);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
                objectDoc.players.First().changeDirection(MovingObject.DIRECTION.STILL);
            else if (e.KeyCode == Keys.Left)
                objectDoc.players.First().changeDirection(MovingObject.DIRECTION.STILL);
            
           Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
                objectDoc.players.First().changeDirection(MovingObject.DIRECTION.RIGHT);
            else if (e.KeyCode == Keys.Left)
                objectDoc.players.First().changeDirection(MovingObject.DIRECTION.LEFT);
            else if (e.KeyCode == Keys.Up)
                objectDoc.FireBullet();
                    
            Invalidate();
                
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

      

    }
}
