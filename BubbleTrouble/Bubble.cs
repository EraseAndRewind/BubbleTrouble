using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleTrouble
{
    public class Bubble
    {
        public Point currentPosition { get; set; }
        public int radius { get; set; }
        public double angle { get; set; }
        public Color color { get; set; }
        public double velocity { get; set; }

        private double velocityX;
        private double velocityY;

        public bool isColided { get; set; }

        public Bubble(Point currentPosition, int radius, Color color, double angle)
        {
            this.currentPosition = currentPosition;
            this.radius = radius;
            this.color = color;
            this.angle = angle;

            isColided = false;
            velocity = 10;
            velocityX = (double)(Math.Cos(angle) * velocity);
            velocityY = (double)(Math.Sin(angle) * velocity);
        }
        
    }
}
