using System;
using System.Collections.Generic;
using System.Text;

namespace Delegates
{
    internal class Rectangle
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public Rectangle(double length, double width)
        {
            Length = length;
            Width = width;
        }
        public double GetPerimeter()
        {
            return 2 * (Length + Width);
        }
        public double GetArea()
        {
            return Length * Width;
        }
    }
}
