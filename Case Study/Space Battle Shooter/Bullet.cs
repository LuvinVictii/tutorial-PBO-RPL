using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Runtime.CompilerServices;
using System.Formats.Asn1;

namespace Space_Entity
{

    public class Bullet : Entity
    {

        public Bullet(
            Canvas MyCanvas,
            double posX,
            double posY,
            float kecepatan = 3,
            double height = 20,
            double width = 5,
            string tag = "Bullet"
        ) : base(MyCanvas, kecepatan, height, width, tag, posX, posY)
        { }

        public override void Move()
        {
            posY -= kecepatan;
            Canvas.SetTop(element, posY);
        }


    }

}