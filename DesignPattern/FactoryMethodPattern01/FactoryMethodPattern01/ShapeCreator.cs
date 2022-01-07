using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern01
{
    // Creator
    public abstract class ShapeCreator
    {
        public abstract Shape Create();
    }

    // ConcretCreator1
    public class CircleCreator : ShapeCreator
    {
        public override Shape Create()
        {
            return new Circle();
        }
    }

    // ConcretCreator2
    public class TriangleCreator : ShapeCreator
    {
        public override Shape Create()
        {
            return new Triangle();
        }
    }
}
