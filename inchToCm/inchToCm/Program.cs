using System;

namespace FirstProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            // 입력
            string input;
            Console.Write("inch를 입력 : ");
            input = Console.ReadLine();

            // 출력
            double inputInch = double.Parse(input); // 연산을 위해 double로 변환
            double output = inputInch * 2.54;        // 1inch = 2.54cm
            Console.WriteLine("\n" + "cm로 변환 : " + output + ""); // 문자열변환으로 출력
        }
    }
}
