using System;

namespace multiplyMethod
{
    class Program
    {
        class Byh
        {
            public long Multiply(int min, int max)
            {
                long output = 1; // 곱셈이므로 오버플로우 때문에 long으로 해줌
                for (int i = min; i <= max; i++)
                {
                    output *= i;
                }
                return output;
            }
        }
        static void Main(string[] args)
        {
            Byh byh = new Byh();
            Console.WriteLine(byh.Multiply(1, 20));
        }
    }
}
