using System;
using System.Linq;

namespace printMinMax
{
    class Program
    {
        static void Main(string[] args)
        {
            // 5개의 수 입력받음
            int[] numbers = new int[5]; // 배열 생성
            for (int i = 0; i < 5; i++)
            {
                Console.Write("input number : ");
                numbers[i] = int.Parse(Console.ReadLine());
            }

            // 배열 출력 테스트
            foreach (var number in numbers)
            {
                Console.Write(number + " ");
            }

            // Min, Max print
            Console.WriteLine("\nMax value : " + numbers.Max());
            Console.WriteLine("Min value : " + numbers.Min());
        }
    }
}
