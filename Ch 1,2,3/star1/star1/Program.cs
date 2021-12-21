using System;

namespace star1
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++) // 0, 1, 2
            {
                for (int j = 0; j < i + 1; j++) // i = 1, 2, 3
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}
