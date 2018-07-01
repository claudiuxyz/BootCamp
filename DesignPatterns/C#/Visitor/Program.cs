using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    //-------------- Visitors ---------------------
    public abstract class Visitor
    {
        public abstract void Visit(Drawing drawing);
        public abstract void Visit(Rectangle rectangle);
        public abstract void Visit(Circle circle);
        public abstract void Visit(Triangle triangle);
    }

    public class Perimeter : Visitor
    {
        public override void Visit(Drawing drawing)
        {
            Console.WriteLine($"Perimeters of items from {drawing.Name} are:"); 
        }

        public override void Visit(Rectangle rectangle)
        {
            Console.WriteLine($"{rectangle.Name} perimeter is {2*rectangle.Height + 2*rectangle.Length}");
        }

        public override void Visit(Circle circle)
        {
            Console.WriteLine($"{circle.Name} perimeter is {circle.Radius * 2 * Math.PI}");
        }

        public override void Visit(Triangle triangle)
        {
            Console.WriteLine($"{triangle.Name} perimeter is {3 * triangle.Length}");
        }
    }
    public class Area : Visitor
    {
        public override void Visit(Drawing drawing)
        {
            Console.WriteLine($"Area of items from {drawing.Name} are:");
        }

        public override void Visit(Rectangle rectangle)
        {
            Console.WriteLine($"{rectangle.Name} Area is {rectangle.Height * rectangle.Length}");
        }

        public override void Visit(Circle circle)
        {
            Console.WriteLine($"{circle.Name} Area is {circle.Radius * circle.Radius * Math.PI}");
        }

        public override void Visit(Triangle triangle)
        {
            Console.WriteLine($"{triangle.Name} Area is { triangle.Length * triangle.Length * Math.Sqrt(3)/4.0}");
        }
    }
    //--------------- Visited ----------------------------------------------
    public abstract class Visited
    {
        public string Name { set; get; }
        public abstract void Accept(Visitor visitor);
    }

    public class Drawing : Visited
    {
        public List<Visited> m_items = new List<Visited>() {
            new Rectangle(10,20),
            new Triangle(15),
            new Circle(13)
        };

        public Drawing()
        {
            Name = "Drawing";
        }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
            foreach (var visited in m_items)
            {
                visited.Accept(visitor);
            }
        }
    }
    public class Rectangle:Visited
    {
        public Rectangle(int length, int height)
        {
            Length = length;
            Height = height;
            Name = "Rectangle";
        }

        public int Length { get; set; }
        public int Height { get; set; }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }
    public class Circle : Visited
    {
        public int Radius { set; get; }
        public Circle(int radius)
        {
            Radius = radius;
            Name = "Circle";
        }
        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }
    public class Triangle : Visited
    {
        public int Length { set; get; }
        public Triangle(int length)
        {
            Length = length;
            Name = "Triangle";
        }
        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }
    //----------------------------------------------------------------
    class Program
    {
        static void Main(string[] args)
        {
            var permiterCalculator = new Perimeter();
            var areaCalculator = new Area();
            var drawing = new Drawing();
            drawing.Accept(permiterCalculator);
            drawing.Accept(areaCalculator);
            Console.ReadKey();
        }
    }
}
