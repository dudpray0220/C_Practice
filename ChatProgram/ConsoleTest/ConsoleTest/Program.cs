using System;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("이름을 입력하세요");
                string name = Console.ReadLine();

                Console.WriteLine("당신의 이름은 {0} 입니다.", name);

                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
