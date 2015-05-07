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
        public DIRECTION direction;

        private int playerHeight;
        private int playerWidht;
        private Brush brush;
        private int velocityX;
        private Image img;
        
       public Player(Point currentPosition, int playerWidht, int playerHeight)
       {
            this.currentPosition = new Point(currentPosition.X, currentPosition.Y);
            this.playerHeight = playerHeight;
            this.playerWidht = playerWidht;
            this.velocityX = 10;
            brush = new SolidBrush(Color.Blue);
            direction = DIRECTION.STILL;
            img = Properties.Resources.penguinplayersmallercanavas;
     }
        override public void Draw(Graphics g)
        {
            Pen pen = new Pen(brush);
           // g.DrawRectangle(pen, currentPosition.X - playerWidht/2, currentPosition.Y - playerHeight, 
           //   playerWidht, playerHeight);

            g.DrawImage(img, currentPosition.X - img.Width / 2, currentPosition.Y - img.Height,
                img.Width, img.Height);
           
        }

        override public void checkCollision()
        {
            
        }

        public void changeDirection(DIRECTION direction)
        {
            this.direction = direction;
        }

        public void Move(int left, int widht)
        {
            

            if (direction == DIRECTION.LEFT)
            {
                if (currentPosition.X - velocityX - img.Width / 2 > 0)
                {
                    currentPosition = new Point(currentPosition.X - velocityX, currentPosition.Y);
                }
            }
            else if(direction == DIRECTION.RIGHT)
            {
                if (currentPosition.X + velocityX + img.Height / 4 < widht)
                {
                    currentPosition = new Point(currentPosition.X + velocityX, currentPosition.Y);
                }
            }
        }
    }
}
