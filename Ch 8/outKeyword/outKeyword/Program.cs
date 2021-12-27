using System;

namespace outKeyword
{
    class Program
    {
        static void NextPosition(int x, int y , int vx, int vy, out int rx, out int ry)
        {
            // 다음위치 = 현재 위치 + 현재 속도
            rx = x + vx;
            ry = y + vy;
        }

        static void Main(string[] args)
        {
            int x = 0;
            int y = 0;
            int vx = 1;
            int vy = 1;

            Console.WriteLine("현재 좌표 : (" + x + ", " + y + ")");
            NextPosition(x, y, vx, vy, out x, out y); // out 키워드를 붙여서 매개변수를 넣어줘야 함!
            Console.WriteLine("다음 좌표 : (" + x + ", " + y + ")");
        }
    }
}
