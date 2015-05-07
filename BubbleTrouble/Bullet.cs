using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleTrouble
{
    public class Bullet : MovingObject
    {
        private Brush brush;
        private Point endPoint;
        public bool delete;

        public Bullet(Point currentPosition)
        {
            this.currentPosition = new Point(currentPosition.X, currentPosition.Y);
            brush = new SolidBrush(Color.Black);
            endPoint = new Point(this.currentPosition.X, this.currentPosition.Y);
            delete = false; 
        }


        public void Move(int distance)
        {
            if (endPoint.Y - distance > 0)
                endPoint = new Point(currentPosition.X, endPoint.Y - distance);
            else if (!delete)
            {
                Console.WriteLine("bullet Should have been deleted");
                delete = true;
            }
        }
         
        public override void checkCollision()
        {
            
        }

        public override void Draw(System.Drawing.Graphics g)
        {
            Pen pen = new Pen(brush);
            g.DrawLine(pen, currentPosition, endPoint);
        }

    }
}
