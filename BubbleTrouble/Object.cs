using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleTrouble
{
    public abstract class Object
    {   
        public Point currentPosition { get; set; }
        public Color color { get; set; }
        public bool isColided { get; set; }
        public double velocity { get; set; }
        public abstract void Draw(Graphics g);
        public abstract void checkCollision();
    }
}