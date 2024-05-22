using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Runtime.CompilerServices;
using System.Formats.Asn1;

namespace Space_Entity
{

    public abstract class Entity
    {
        protected Canvas myCanvas;
        protected float kecepatan;
        protected double height, width;
        protected double posX, posY;
        protected string tag;
        protected Rectangle element;
        public Rect hitBox;

        public Entity(
            Canvas myCanvas,
            float kecepatan,
            double height,
            double width,
            string tag,
            double posX,
            double posY,
            string spriteUri = ""
        )
        {
            this.myCanvas = myCanvas;
            this.kecepatan = kecepatan;
            this.height = height;
            this.width = width;
            this.tag = tag;
            this.posX = posX;
            this.posY = posY;

            element = createElement(tag, spriteUri);

            hitBox = new Rect(posX, posY, width, height);
        }

        private Rectangle createElement(string tag, string spriteUri)
        {
            Rectangle tempElement;

            if (tag == "Bullet")
            {
                tempElement = new Rectangle // Canvas tempElement
                {
                    Tag = tag,
                    Height = height,
                    Width = width,
                    Fill = Brushes.White,
                    Stroke = Brushes.Red
                };

                Canvas.SetTop(tempElement, posY);
                Canvas.SetLeft(tempElement, posX);
                myCanvas.Children.Add(tempElement);

                return tempElement;
            }

            ImageBrush sprite = new ImageBrush();
            sprite.ImageSource = new BitmapImage(new Uri(spriteUri));

            tempElement = new Rectangle // Canvas tempElement
            {
                Tag = tag,
                Height = height,
                Width = width,
                Fill = sprite
            };

            Canvas.SetTop(tempElement, posY);
            Canvas.SetLeft(tempElement, posX);
            myCanvas.Children.Add(tempElement);

            return tempElement;
        }

        public void removeFromCanvas()
        {
            myCanvas.Children.Remove(element);
        }

        public double getPositionX()
        {
            return posX;
        }

        public double getPositionY()
        {
            return posY;
        }

        public double getWidth()
        {
            return width;
        }

        public double getHeight()
        {
            return height;
        }

        public Rectangle getElement()
        {
            return element;
        }

        public void Update()
        {
            posX = Canvas.GetLeft(element);
            posY = Canvas.GetTop(element);

            hitBox.X = posX;
            hitBox.Y = posY;

            // UpdateCallback();
        }

        public abstract void Move();

    }

}