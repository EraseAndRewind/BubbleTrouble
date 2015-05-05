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
        public abstract Point currentPosition { get; set; }
        public abstract Color color { get; set; }
        public abstract bool isColided { get; set; }
        public abstract double velocity { get; set; }
        public abstract void Draw(Graphics g);
        public abstract void checkColision();
    }
}