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
        
       public Player(Point currentPosition, int playerWidht, int playerHeight)
       {
            this.currentPosition = new Point(currentPosition.X, currentPosition.Y);
            this.playerHeight = playerHeight;
            this.playerWidht = playerWidht;
            this.velocityX = 10;
            brush = new SolidBrush(Color.Blue);
            direction = DIRECTION.STILL;
            
        }
        override public void Draw(Graphics g)
        {
            Pen pen = new Pen(brush);
            g.DrawRectangle(pen,currentPosition.X - playerWidht , currentPosition.Y - playerWidht * 2
                , playerWidht, playerHeight);   
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
                if(currentPosition.X - velocityX > 0 )
                {
                    currentPosition = new Point(currentPosition.X - velocityX, currentPosition.Y);
                }
            }
            else if(direction == DIRECTION.RIGHT)
            {
                if (currentPosition.X + velocityX < widht)
                {
                    currentPosition = new Point(currentPosition.X + velocityX, currentPosition.Y);
                }
            }
        }
    }
}
