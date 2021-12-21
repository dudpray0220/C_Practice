using System;

namespace star3_pyramid_
{
    class Program
    {
        static void Main(string[] args)
        {
            // The longest star : 15 star
            for (int i = 0; i < 16; i = i + 2) // i : 0, 2, 4
            {
                for (int j = 0; j < 16 - i; j=j+2) // j : 0, 2, 4              j < 16, 14, 12
                {
                    Console.Write(" ");
                }
                for (int k = 0; k < i+1; k++) // k ; 0 1 2          k < 1, 3, 5 
                {
                Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}
