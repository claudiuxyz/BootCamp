using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateClassData
{
    public struct Point
    {
        public int x, y;
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    public class CircleData
    {
        private int m_radius;
        private Point m_origin;
        public CircleData(int radius, Point origin)
        {
            m_radius = radius;
            m_origin = origin;
        }

        public int GetRadius() { return m_radius; }

        public Point GetOrigin() { return m_origin; }
    }

    public class Circle
    {
        private CircleData m_data;
        public Circle(int radius, Point origin)
        {
            m_data = new CircleData(radius, origin);
        }

        public int Diameter()
        {
            return m_data.GetRadius() * 2;
        }

        public double Circumference()
        {
            return m_data.GetRadius() * m_data.GetRadius() * Math.PI;
        }

        public void Draw()
        {
            Console.WriteLine($"Circle of circumference {Circumference()} -> origin x={m_data.GetOrigin().x} y={m_data.GetOrigin().y}");
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            var circle = new Circle(10, new Point(3, 8));
            circle.Draw();
            Console.ReadKey();
        }
    }
}
