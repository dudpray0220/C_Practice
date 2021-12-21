using System;

namespace FirstProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo info = Console.ReadKey();
            switch (info.Key)
            {
                case ConsoleKey.UpArrow:
                    Console.WriteLine("up");
                    break;
                case ConsoleKey.DownArrow:
                    Console.WriteLine("DownArrow");
                    break;
                case ConsoleKey.RightArrow:
                    Console.WriteLine("RightArrow");
                    break;
                case ConsoleKey.LeftArrow:
                    Console.WriteLine("LeftArrow");
                    break;
                case ConsoleKey.D:
                    Console.WriteLine("\nbyebye");
                    break;
                default:
                    Console.WriteLine("hi");
                    break;
            }
        }
    }
}
