using System;

namespace Shadowing
{
    class Program
    {
        public static int number = 10;
        static void Main(string[] args)
        {
            int number = 20;
            Console.WriteLine(number);
        }
    }
}
