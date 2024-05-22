using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Runtime.CompilerServices;
using System.Formats.Asn1;

namespace Space_Entity
{


    public class Player : Entity
    {
        private int score;
        private double health;

        public Player(
            Canvas MyCanvas,
            string spriteUri,
            float kecepatan = 3,
            double height = 50,
            double width = 60,
            string tag = "Player",
            double posX = 240,
            double posY = 498,
            double health = 100
        ) : base(MyCanvas, kecepatan, height, width, tag, posX, posY, spriteUri)
        {
            score = 0;
            this.health = health;
        }

        public void setHealth(double health)
        {
            this.health = health;
        }

        public void addScore()
        {
            score++;
        }

        public int getScore()
        {
            return score;
        }

        public double getHealth()
        {
            return health;
        }

        public override void Move()
        {
            // no implementation 
        }

        public void Move(bool moveLeft, bool moveRight, bool moveUp, bool moveDown)
        {
            if (moveLeft == true && posX > 0)
            {
                posX -= kecepatan;
                Canvas.SetLeft(element, posX);
            }

            if (moveRight == true && posX + 90 < Application.Current.MainWindow.Width)
            {
                posX += kecepatan;
                Canvas.SetLeft(element, posX);
            }

            if (moveUp == true && posY > 0)
            {
                posY -= kecepatan;
                Canvas.SetTop(element, posY);
            }

            if (moveDown == true && posY + 90 < Application.Current.MainWindow.Height)
            {
                posY += kecepatan;
                Canvas.SetTop(element, posY);
            }
        }

        public bool isDeath()
        {
            return health <= 0;
        }

        // method hit by enemy
    }


}