using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lads0
{
    public class Rectangle
    {
        // Свойства класса
        public Point2D TopLeft { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Rectangle(Point2D topLeft, int width, int height)
        {
            TopLeft = topLeft;
            Width = width;
            Height = height;
        }
        public void AddX(int x)
        {
            TopLeft.AddX(x);
        }

        public void AddY(int y)
        {
            TopLeft.AddY(y);
        }
        public Point2D[] GetPoints()
        {
            Point2D topRight = new Point2D(TopLeft.X + Width, TopLeft.Y);
            Point2D bottomRight = new Point2D(TopLeft.X + Width, TopLeft.Y + Height);
            Point2D bottomLeft = new Point2D(TopLeft.X, TopLeft.Y + Height);

            return new Point2D[] { TopLeft, topRight, bottomRight, bottomLeft };
        }
    }
}
