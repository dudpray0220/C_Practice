using System;

namespace multiply1_20
{
    class Program
    {
        static void Main(string[] args)
        {
            long total = 1;
            for (int i = 1; i <= 20; i++)
            {
                total *= i;
            }
            Console.WriteLine(total);
        }
    }
}
