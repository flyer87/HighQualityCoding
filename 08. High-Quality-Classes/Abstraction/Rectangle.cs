using System;

namespace Abstraction
{
    class Rectangle : Figure
    {
        public Rectangle(double width, double height)
        {
            if (width <= 0)
            {
                throw new ArgumentOutOfRangeException("Width cannot be negative or 0!");
            }

            if (height <= 0)
            {
                throw new ArgumentOutOfRangeException("Heigth cannot be negative or 0!");
            }

            this.Width = width;
            this.Height = height;
        }

        public double Height { get; private set; }

        public double Width { get; private set; }

        public override double CalcPerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }
    }
}
