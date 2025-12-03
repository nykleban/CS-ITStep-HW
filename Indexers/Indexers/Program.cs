using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal abstract class GeometricShape
{
    public abstract double GetArea();
    public abstract double GetPerimeter();
}

internal class Triangle : GeometricShape
{
    private int a, b, c; 

    public int A { get { return a; } set { if (value >= 0) a = value; } }
    public int B { get { return b; } set { if (value >= 0) b = value; } }
    public int C { get { return c; } set { if (value >= 0) c = value; } }

    public Triangle()
    {
        A = 0;
        B = 0;
        C = 0;
    }
    public Triangle(int a, int b, int c)
    {
        A = a;
        B = b;
        C = c;
    }

    public override double GetArea()
    {
        double p = (A + B + C) / 2.0;
        return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
    }

    public override double GetPerimeter()
    {
        return A + B + C;
    }
}

internal class Square : GeometricShape
{
    private int a;
    public int A { get { return a; } set { if (value >= 0) a = value; } }

    public Square() { A = 0; }
    public Square(int a) { A = a; }

    public override double GetArea()
    {
        return A * A;
    }

    public override double GetPerimeter()
    {
        return A * 4;
    }
}

internal class Rhombus : GeometricShape 
{
    private int a, h;
    public int A { get { return a; } set { if (value >= 0) a = value; } }
    public int H { get { return h; } set { if (value >= 0) h = value; } }

    public Rhombus() { A = 0; H = 0; }
    public Rhombus(int a, int h) { A = a; H = h; }

    public override double GetArea()
    {
        return A * H;
    }

    public override double GetPerimeter()
    {
        return A * 4;
    }
}

internal class Rectangle : GeometricShape
{
    private int a, b;
    public int A { get { return a; } set { if (value >= 0) a = value; } }
    public int B { get { return b; } set { if (value >= 0) b = value; } }

    public Rectangle() { A = 0; B = 0; }
    public Rectangle(int a, int b) { A = a; B = b; }

    public override double GetArea()
    {
        return A * B;
    }

    public override double GetPerimeter()
    {
        return A + A + B + B;
    }
}

internal class Parallelogram : GeometricShape
{
    private int a, b, h;
    public int A { get { return a; } set { if (value >= 0) a = value; } }
    public int B { get { return b; } set { if (value >= 0) b = value; } }
    public int H { get { return h; } set { if (value >= 0) h = value; } }

    public Parallelogram() { A = 0; H = 0; B = 0; }
    public Parallelogram(int a, int b, int h) { A = a; H = h; B = b; }

    public override double GetArea()
    {
        return A * H;
    }

    public override double GetPerimeter()
    {
        return A * 2 + B * 2;
    }
}

internal class Trapezoid : GeometricShape
{
    private int a, b, h;
    public int A { get { return a; } set { if (value >= 0) a = value; } }
    public int B { get { return b; } set { if (value >= 0) b = value; } }
    public int H { get { return h; } set { if (value >= 0) h = value; } }

    public Trapezoid() { A = 0; H = 0; B = 0; }
    public Trapezoid(int a, int b, int h) { A = a; H = h; B = b; }

    public override double GetArea()
    {
        return ((A + B) * H) / 2.0; 
    }

    public override double GetPerimeter()
    {

        double leg = Math.Sqrt(Math.Pow((Math.Abs(A - B) / 2.0), 2) + H * H);
        return A + B + 2 * leg;
    }
}

internal class Circle : GeometricShape
{
    private int r; 
    public int R { get { return r; } set { if (value >= 0) r = value; } }

    public Circle() { R = 0; }
    public Circle(int r) { R = r; }

    public override double GetArea()
    {
        return 3.14 * (R * R);
    }

    public override double GetPerimeter()
    {
        return 2 * 3.14 * R;
    }
}

internal class Ellipse : GeometricShape
{
    private int r1, r2; // Виправлено: додані поля
    public int R1 { get { return r1; } set { if (value >= 0) r1 = value; } }
    public int R2 { get { return r2; } set { if (value >= 0) r2 = value; } }

    public Ellipse() { R1 = 0; R2 = 0; }
    public Ellipse(int r1, int r2) { R1 = r1; R2 = r2; }

    public override double GetArea()
    {
        return 3.14 * (R1 * R2);
    }

    public override double GetPerimeter()
    {
        double perimeter = 2 * 3.14 * Math.Sqrt((R1 * R1 + R2 * R2) / 2.0);
        return perimeter;
    }
}

internal class ComposedFigure
{
    private GeometricShape[] gh;
    public ComposedFigure(params GeometricShape[] gh)
    {
        this.gh = gh;
    }
    public double GetTotalArea()
    {
        double totalArea = 0;
        foreach (var shape in gh)
        {
            totalArea += shape.GetArea();
        }
        return totalArea;
    }
    public double GetTotalPerimeter()
    {
        double totalPer = 0;
        foreach (var shape in gh)
        {
            totalPer += shape.GetPerimeter();
        }
        return totalPer;
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        GeometricShape[] shapes = new GeometricShape[]
        {
            new Triangle(3, 4, 5),
            new Square(4),
            new Rhombus(5, 6),
            new Rectangle(4, 5),
            new Parallelogram(4, 5, 6),
            new Trapezoid(4, 10, 4), 
            new Circle(7),
            new Ellipse(5, 6)
        };
        double totalArea = 0;
        double totalPerimeter = 0;
        foreach (var shape in shapes)
        {
            Console.WriteLine($"Type: {shape.GetType().Name, -20} Area: {shape.GetArea(),-20} Perimeter: {shape.GetPerimeter(),-20}");
            totalArea += shape.GetArea();
            totalPerimeter += shape.GetPerimeter();
        }
        Console.WriteLine($"\nTotal Area: {totalArea}");
        Console.WriteLine($"Total Perimeter: {totalPerimeter:F2}");

        Console.WriteLine(new string('-', 40));

        ComposedFigure composed = new ComposedFigure(shapes);
        Console.WriteLine($"Total Area: {composed.GetTotalArea()}");
        Console.WriteLine($"Total Perimeter: {composed.GetTotalPerimeter():F2}");
    }
}