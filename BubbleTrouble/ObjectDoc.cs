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
        public List<Player> players;
        public ObjectDoc()
        {
            bubbles = new List<Bubble>();
            players = new List<Player>();
        }
        public void Draw(Graphics g)
        {
            foreach(Bubble bubble in bubbles)
            {
                bubble.Draw(g);
            }
            foreach(Player player in players)
            {
                player.Draw(g);
            }
        }

        public void createPlayers(Player player)
        {
            Console.WriteLine("Player Created");
            players.Add(player);
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
            foreach (Player p in players)
            {
                p.Move(left, width);
            }
        }

        

        public void checkCollision()
        {

        }
    }
}
