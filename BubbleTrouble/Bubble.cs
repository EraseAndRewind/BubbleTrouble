using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleTrouble
{
    public class Bubble : Object
    {
        public int radius { get; set; }
        public double angle { get; set; }
        
        private double velocityX;
        private double velocityY;

        public Bubble(Point currentPosition, int radius, Color color, double angle)
        {
            this.currentPosition = currentPosition;
            this.isColided = false;
            this.radius = radius;
            this.color = color;
            this.angle = angle;

            velocity = 10;
            velocityX = (double)(Math.Cos(angle) * velocity);
            velocityY = (double)(Math.Sin(angle) * velocity);
        }

        override public void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(this.color);
            g.FillEllipse(brush, currentPosition.X, currentPosition.Y, radius, radius);
            brush.Dispose();
        }

        override public void checkCollision()
        {

        }


        public void Move(int left, int top, int width, int height)
        {
            double nextX = currentPosition.X + velocityX;
            double nextY = currentPosition.Y + velocityY;

            if(nextX - radius <= left || nextX + radius >= width)
            {
                velocityX = -velocityX;  
            }
            if (nextY - radius <= top || nextY + radius >= height)
            {
                velocityY = -velocityY;
            }

            this.currentPosition = new Point((int)(currentPosition.X + velocityX),
            (int)(currentPosition.Y + velocityY));
        }

    }
}
