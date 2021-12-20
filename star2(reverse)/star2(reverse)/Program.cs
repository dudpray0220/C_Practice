using System;

namespace star2_reverse_
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++) // i =0, 1, 2
            {
                //for (int j = 10; j > i + 1; j--) // i = 1, 2, 3
                //{
                //    Console.Write(" ");
                //}
                for (int j = 0; j < 10 - i; j++)
                {
                    Console.Write(" ");
                }
                for (int j = 0; j < i +1; j++) // i = 0, 1, 2
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}
