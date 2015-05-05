using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleTrouble
{
    public class ObjectDoc
    {
        public List<Bubble> bubbles;
        public ObjectDoc()
        {
            bubbles = new List<Bubble>();
        }
        public void Draw(Graphics g)
        {
            foreach(Bubble bubble in bubbles)
            {
                bubble.Draw(g);
            }
        }

        public void spawnBubble(Bubble bubble)
        {
            bubbles.Add(bubble);
        }

        public void moveObjects(int left, int top, int width, int height)
        {
            foreach (Bubble bubble in bubbles)
            {
                bubble.Move(left, top, width, height);
            }
        }

        public void checkCollision()
        {

        }
    }
}
