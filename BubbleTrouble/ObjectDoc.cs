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
        public Player player1;
        public Player player2;
        public List<Bullet> bullets;
        public bool canFire;
        public bool restart;
        public bool gameOver;

        public ObjectDoc()
        {
            bubbles = new List<Bubble>();
            bullets = new List<Bullet>();
            canFire = true;
            restart = false;
            gameOver = false;
        }

        public void Draw(Graphics g)
        {
            player1.Draw(g);

            foreach(Bubble bubble in bubbles)
            {
                bubble.Draw(g);
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
                Bullet bullet = new Bullet(player1.currentPosition.X, player1.currentPosition.Y);
                
                bullets.Add(bullet);
                canFire = false;
            }
        }

        public void createPlayers(Player player)
        {
            player1 = new Player(player.currentPosition, player.life);
        }

        public void createPlayers(Player player, Player player2)
        {
            player1 = new Player(player.currentPosition, player.life);
        }


        public void spawnBubble(Bubble bubble)
        {
            bubbles.Add(bubble);
        }

        public void moveObjects(int left, int top, int width, int height)
        {

            player1.Move(left, width);

            foreach (Bubble bubble in bubbles)
            {
                bubble.Move(left, top, width, height);
            }
           
            foreach (Bullet bullet in bullets)
            {
                bullet.Move(10);
            }
        }

        public void checkCollision()
        {
            for (int j = bubbles.Count - 1; j >= 0; j--)
            {
                if (bubbles[j].currentPosition.Y + bubbles[j].radius > player1.currentPosition.Y - player1.playerHeight)
                {
                    bubbles[j].checkCollision(player1);
                }
                if (player1.isColided)
                {
                    player1.RemoveLife();
                    if (player1.life == 0) gameOver = true;
                    else restart = true;
                }

                for (int i = bullets.Count - 1; i >= 0; i--)
                {
                    bubbles[j].checkCollision(bullets[i]);
                    if (bullets[i].isColided)
                    {
                        bullets.RemoveAt(i);
                        canFire = true;
                    }

                    if (bubbles[j].delete) bubbles.RemoveAt(j);
                else if (bubbles[j].isColided)
                    {
                        bubbles.Add(new Bubble(bubbles[j].currentPosition, bubbles[j].radius / 2, Color.Red, 270, bubbles[j].dropRate + 1));
                        bubbles.Add(new Bubble(bubbles[j].currentPosition, bubbles[j].radius / 2, Color.Red, 270, -(bubbles[j].dropRate + 1)));
                        bubbles.RemoveAt(j);
                    }
                   
                }
            }
        }

    }
}
