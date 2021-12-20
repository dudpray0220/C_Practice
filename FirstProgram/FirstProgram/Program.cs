using System;

namespace FirstProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            do
            {
                Console.Write("type exit, quit : ");
                input = Console.ReadLine();
            } while (input != "exit"); // exit이 아니면 true -> 계속 돔.
        }
    }
}