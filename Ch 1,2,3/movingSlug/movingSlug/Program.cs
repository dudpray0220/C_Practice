using System;
using System.Threading;

namespace movingSlug
{
    class Program
    {
        static void Main(string[] args)
        {
            // 이동제어할 변수
            int x = 1;
            while (x < 100)
            {
                // clean screen, move cursor
                Console.Clear();
                Console.SetCursorPosition(x, 5);

                // print
                if (x % 3 == 0) // 3, 6, 9
                    Console.WriteLine(" __@");
                else if (x % 3 == 1) // 1, 4, 7
                    Console.WriteLine("_^@");
                else // 2, 5, 8
                    Console.WriteLine("^_@");

                // 100 milisecond stop -> x++
                Thread.Sleep(100);
                x++;
            }
        }
    }
}
