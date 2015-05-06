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
        private bool flag;

        public Bubble(Point currentPosition, int radius, Color color, double angle)
        {
            this.currentPosition = currentPosition;
            this.isColided = false;
            this.radius = radius;
            this.color = color;
            this.angle = ConvertToRadians(angle);

            flag = false;   
            velocity = 10;
            velocityX = (double)(Math.Cos(this.angle) * velocity);
            velocityY = (double)(Math.Sin(this.angle) * velocity);
        }

        public double ConvertToRadians(double angle)
        {
            return (Math.PI / 180.0) * angle;
        }

        override public void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(this.color);
            g.FillEllipse(brush, currentPosition.X - radius , currentPosition.Y - radius, 2 * radius, 2 * radius);
            brush.Dispose();
        }

        override public void checkCollision()
        {

        }

        public void Move(int left, int top, int width, int height)
        {
            double nextX = currentPosition.X + velocityX;
            double nextY = currentPosition.Y + velocityY;

            if(nextX - radius < left || nextX + radius > width)
            {
                velocityX = -velocityX;  
            }
            if (nextY - radius < top || nextY + radius > height)
            {
                velocityY = -velocityY;
            }

            this.currentPosition = new Point((int)(currentPosition.X + velocityX),
            (int)(currentPosition.Y + velocityY));

          }
            
    }
}