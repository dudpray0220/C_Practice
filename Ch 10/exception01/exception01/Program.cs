using System;

namespace exception01
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = { "가", "나" };
            Console.Write("input number : ");
            int input = int.Parse(Console.ReadLine());

            // exception 
            if (input < array.Length)
            {
                Console.WriteLine("location is " + array[input] + "!");
            }
            else
            {
                Console.WriteLine("out of range");
            }
        }
    }
}
