using System;
using System.Collections.Generic;
using System.Threading;

namespace firstPractice
{
    class Program
    {
        class MyMath
        {
            public static int Abs(int input)
            {
                if (input >= 0)
                {
                    return input;
                }
                else
                {
                    return -input;
                }
            }
            public static double Abs(double input)
            {
                if (input >= 0)
                {
                    return input;
                }
                else
                {
                    return -input;
                }
            }
            public static long Abs(long input)
            {
                if (input >= 0)
                {
                    return input;
                }
                else
                {
                    return -input;
                }
            }
        }
        public static int a;
        static void Main(string[] args)
        {
            Console.WriteLine(MyMath.Abs(-5));
            Console.WriteLine(MyMath.Abs(5));

            Console.WriteLine(MyMath.Abs(-214748364709));
            Console.WriteLine(MyMath.Abs(214748364709));

            Console.WriteLine(MyMath.Abs(-5.45648));
            Console.WriteLine(MyMath.Abs(5.45648));
        }
    }
}


