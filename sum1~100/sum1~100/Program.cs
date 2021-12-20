using System;

namespace sum1_100
{
    class Program
    {
        static void Main(string[] args)
        {
            int total = 0;

            for (int i = 1; i <= 100; i++)
            {
                total += i;     // total = total + i
            }
            Console.WriteLine(total);
        }
    }
}
