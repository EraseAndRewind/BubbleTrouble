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
        public List<Bullet> bullets;
        public bool canFire;
        public ObjectDoc()
        {
            bubbles = new List<Bubble>();
            players = new List<Player>();
            bullets = new List<Bullet>();
            canFire = true;
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
            foreach (Bullet bullet in bullets)
            {
                bullet.Draw(g);
            }
        }

        public void FireBullet()
        {
            if(canFire)
            {
                Bullet bullet = new Bullet(players[0].currentPosition);
                bullets.Add(bullet);
                canFire = false;
            }
        }

        public void createPlayers(Player player)
        {
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
            foreach (Bullet bullet in bullets)
            {
                bullet.Move(10);
            }
        }

        
        public void checkCollision()
        {

            for (int i = bullets.Count - 1; i >= 0; i--)
            {
                if (bullets[i].isColided)
                {
                    bullets.RemoveAt(i);
                    canFire = true;
                }
            }
        }
    }
}
