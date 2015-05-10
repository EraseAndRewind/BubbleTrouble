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
        public int level;
        public int timeLeft { get; set; }
       
        public ObjectDoc(int lvl)
        {
            bubbles = new List<Bubble>();
            bullets = new List<Bullet>();
            canFire = true;
            restart = false;
            gameOver = false;
            level = lvl;
            
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

        public void createPlayers(Point currentPosition, int life, int selected)
        {
            player1 = new Player(currentPosition, life, selected);
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
            if (bubbles.Count == 0)
            {
                restart = true;
                level++;
                return;
            }
            for (int j = bubbles.Count - 1; j >= 0; j--)
            {
                if (bubbles[j].delete) 
                {
                    bubbles.RemoveAt(j);
                    break;
                }

                if (bubbles[j].currentPosition.Y + bubbles[j].radius > player1.currentPosition.Y - player1.playerHeight)
                {
                    bubbles[j].checkCollision(player1);
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
                        double d = Math.Abs(bubbles[j].dropRate);
                        bubbles.Add(new Bubble(bubbles[j].currentPosition, bubbles[j].radius / 2, bubbles[j].color, 300, d * 2));
                        bubbles.Add(new Bubble(bubbles[j].currentPosition, bubbles[j].radius / 2, bubbles[j].color, 240, d *= -2));
                        bubbles.RemoveAt(j);
                    }
                   
                }
            }
            if (player1.isColided)
            {
                player1.RemoveLife();
                if (player1.life == 0) gameOver = true;
                else restart = true;
            }
            if (timeLeft == 0)
            {
                player1.RemoveLife();
                if (player1.life == 0) gameOver = true;
                else restart = true;
            }
        }

    }
}
