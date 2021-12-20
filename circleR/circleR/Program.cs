using System;

namespace FirstProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            // 입력
            string input;
            Console.Write("반지름을 입력 : ");
            input = Console.ReadLine();

            // 출력
            var radius = double.Parse(input); // 반지름. 연산을 위해 double로 변환 
            double inputRound = 2 * Math.PI * radius; // 둘레. 
            double inputArea = Math.PI * radius * radius; // 넓이
            Console.WriteLine("\n" + "둘레 : " + inputRound.ToString("0.00")); // 문자열변환으로 출력, 소수 2째자리
            Console.WriteLine("\n" + "넓이 : " + inputArea.ToString("0.00")); // 문자열변환으로 출력, 소수 2째자리
        }
    }
}
