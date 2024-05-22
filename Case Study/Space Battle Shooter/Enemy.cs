using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Runtime.CompilerServices;
using System.Formats.Asn1;

namespace Space_Entity
{

    public class Enemy : Entity
    {
        private double damage;

        public Enemy(
            Canvas MyCanvas,
            string spriteUri,
            float kecepatan = 3,
            double height = 50,
            double width = 56,
            string tag = "Enemy",
            double posX = 240,
            double posY = -100,
            double damage = 10
        ) : base(MyCanvas, kecepatan, height, width, tag, posX, posY, spriteUri)
        {
            this.damage = damage;
        }

        public override void Move()
        {
            posY += kecepatan;
            Canvas.SetTop(element, posY);
        }

        public double getDamage()
        {
            return damage;
        }

    }


}