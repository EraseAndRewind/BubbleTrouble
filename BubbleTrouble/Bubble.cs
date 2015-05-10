using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleTrouble
{
    public class Bubble : MovingObject
    {
        private readonly int VELOCITY = 4;
        
        public int radius { get; set; }
        public double angle { get; set; }
        private double velocityX;
        private double velocityY;
        public double dropRate { get; set; }
        public bool delete;

        
        public Bubble(Point currentPosition, int radius, Color color, double angle, double dropRate)
        {
            this.currentPosition = new Point(currentPosition.X, currentPosition.Y);
            this.isColided = false;
            this.radius = radius;
            this.color = color;
            this.angle = angle;
             
            this.dropRate = dropRate;
            velocity = VELOCITY;
            velocityX = (double)(Math.Cos(ConvertToRadians(this.angle)) * velocity);
            velocityY = (double)(Math.Sin(ConvertToRadians(this.angle)) * velocity);
            delete = false;
        }


        public void evaluateAngle()
        {
            velocityX = (double)(Math.Cos(ConvertToRadians(this.angle)) * velocity);
            velocityY = (double)(Math.Sin(ConvertToRadians(this.angle)) * velocity);

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

        public void checkCollision(Player p){
                if (currentPosition.X + radius > p.currentPosition.X - p.playerWidht/2
                    && currentPosition.X - radius < p.currentPosition.X + p.playerWidht/2)
            p.isColided = true;
        }

        public void checkCollision(Bullet bullet)
        {
            
            if (currentPosition.X + radius > bullet.currentPosition.X &&
                currentPosition.X - radius < bullet.currentPosition.X &&
                currentPosition.Y > bullet.endPoint.Y)
            {
                isColided = true;
                if (radius == 10) delete = true;
                bullet.isColided = true;
            }

         
        }

        public void Move(int left, int top, int width, int height)
        {
            double nextX = currentPosition.X + velocityX;
            double nextY = currentPosition.Y + velocityY;
            
            if(nextX - radius < left) 
            {
                //angle -= 180;
                angle = 0;
                dropRate *= -1;
            }
            else if (nextX + radius > width)
            {
                //angle += 180;
                angle = 180;
                dropRate *= -1;
            }
            if (nextY - radius < top )
            {
                delete = true;
                //angle -= 180;
            }
            else if (nextY + radius > height)
            {
                angle = 270 ;
            }

            if(Math.Abs(angle) >= 360 )
            {
                angle -= 360;
            }

            evaluateAngle();
            this.currentPosition = new Point((int)(currentPosition.X + velocityX),
            (int)(currentPosition.Y + velocityY));

            if (angle != 90)
                angle += dropRate;
           
        }
    }
}