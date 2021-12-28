using System;
using System.Collections.Generic;

namespace list01
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            List<int> output = new List<int>();

            foreach (var item in input)
            {
                if (item % 2 == 0)
                {
                    output.Add(item);
                }
            }

            foreach(var item in output)
            {
                Console.WriteLine(item);
            }
            //return output;
        }
    }
}
