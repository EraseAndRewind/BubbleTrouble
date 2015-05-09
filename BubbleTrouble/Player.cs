using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleTrouble
{
    public class Player : MovingObject
    {
        public int life;
        public DIRECTION direction;
        public int playerHeight;
        public int playerWidht;
        private Brush brush;
        private int velocityX;
        private Image img;
        
       public Player(Point currentPosition, int life)
       {
            this.currentPosition = new Point(currentPosition.X, currentPosition.Y);
            this.velocityX = 5;
            
            this.life = life;
            brush = new SolidBrush(Color.Blue);
            direction = DIRECTION.STILL;
            img = Properties.Resources.penguinplayersmallercanavas1;
            playerHeight = img.Height;
            playerWidht = img.Width; 
            //playerHeight = 50;
            //playerWidht = 25;
       }
       
       public void RemoveLife()
       {
           life--;
       }
        override public void Draw(Graphics g)
        {
            Pen pen = new Pen(brush);
           
            g.DrawImage(img, currentPosition.X - img.Width / 2, currentPosition.Y - img.Height,
               img.Width, img.Height);
            //g.DrawRectangle(pen, currentPosition.X - playerWidht / 2, currentPosition.Y - playerHeight, playerWidht, playerHeight);
        }

        public void changeDirection(DIRECTION direction)
        {
            this.direction = direction;
        }

        public void Move(int left, int widht)
        {
            if (direction == DIRECTION.LEFT)
            {
                if (currentPosition.X - velocityX - playerWidht / 2 > 0)
                {
                    currentPosition = new Point(currentPosition.X - velocityX, currentPosition.Y);
                }
            }
            else if(direction == DIRECTION.RIGHT)
            {
                if (currentPosition.X + velocityX + playerWidht / 2 < widht)
                {
                    currentPosition = new Point(currentPosition.X + velocityX, currentPosition.Y);
                }
            }
        }
    }
}
