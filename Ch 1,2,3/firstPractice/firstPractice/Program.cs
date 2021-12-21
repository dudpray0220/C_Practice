using System;
using System.Threading;

namespace firstPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("first");
            Thread.Sleep(1000);
            Console.WriteLine("second");
            Thread.Sleep(1000);
            Console.WriteLine("third");
        }
    }
}
