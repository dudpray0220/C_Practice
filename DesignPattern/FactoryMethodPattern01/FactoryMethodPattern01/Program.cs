using System;

namespace FactoryMethodPattern01
{
    // Product
    public abstract class Shape
    {
        public abstract double GetArea();
    }

    // ConcreteProduct 1
    public class Circle : Shape
    {
        public double Radius;
        public override double GetArea()
        {
            return 2 * Math.PI * Radius;
        }
    }

    // ConcreteProduct 2
    public class Triangle : Shape
    {
        public override double GetArea()
        {
            return 0;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            CircleCreator circleCreator = new CircleCreator();
            circleCreator.Create();
        }
    }
}
