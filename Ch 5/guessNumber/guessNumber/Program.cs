using System;

namespace guessNumber
{
    class Program
    {
        static void Main(string[] args)
        {   // 정답 난수 생성
            Random random = new Random(); // 난수 생성을 위한 클래스
            int answer = random.Next(1, 15); // 난수 (1 ~ 15)

            Console.WriteLine("1 ~ 15까지 중 맞춰보세요~ ㅋㅋ 3번 안에 맞추면 인정합니다.\n");

            while (true)
            {
                Console.Write("숫자를 입력해보세요 : ");
                int guessNum = int.Parse(Console.ReadLine()); // 정답 입력받음

                if (answer > guessNum)
                {
                    Console.WriteLine(guessNum + "보다는 큰 숫자입니다. \n");
                }
                else if (answer < guessNum)
                {
                    Console.WriteLine(guessNum + "보다는 작은 숫자입니다. \n");
                }
                else
                {
                    Console.WriteLine("정답입니다. 훌륭하군요");
                    break;
                }
            }
        }
    }
}
