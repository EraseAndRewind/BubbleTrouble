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
        public Point endPoint;
        
        public Bullet(int x, int y)
        {
            this.currentPosition = new Point(x, y);
            brush = new SolidBrush(Color.Black);
            endPoint = new Point(this.currentPosition.X, this.currentPosition.Y);
            isColided = false;
        }

        public void Move(int distance)
        {
            if (endPoint.Y - distance > 0)
                endPoint = new Point(currentPosition.X, endPoint.Y - distance);
            else if (!isColided)
            {
                isColided = true;
            }
        }
         
        public override void Draw(System.Drawing.Graphics g)
        {
            //Pen pen = new Pen(brush);
            Pen greenPen = new Pen(Color.GreenYellow, 5);
            g.DrawLine(greenPen, currentPosition,endPoint);
           // g.DrawLine(pen, currentPosition, endPoint);
        }

    }
}
