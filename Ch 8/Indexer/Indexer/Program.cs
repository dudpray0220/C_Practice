using System;

namespace Indexer
{
    class SquareCalculator
    {
        public int this[int i]
        {
            get { return i * i; }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SquareCalculator square = new SquareCalculator();
            Console.WriteLine(square[10]);
        }
    }
}
