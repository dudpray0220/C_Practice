using System;

namespace ifElse01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("input : ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.WriteLine("hi");
                    break;
                case "2":
                    Console.WriteLine("hi 2");
                    break;
                case "3":
                    Console.WriteLine("hi 3");
                    break;
                case "4":
                    Console.WriteLine("hi 4");
                    break;
                default:
                    Console.WriteLine("input 1 ~ 4");
                    break;
            }
        }
    }
}