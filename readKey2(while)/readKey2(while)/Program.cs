using System;

namespace readKey2_while_
{
    class Program
    {
        static void Main(string[] args)
        {
            bool state = true;
            int x = 0;
            int y = 0;
            while (state)
            {
                ConsoleKeyInfo info = Console.ReadKey();
                switch (info.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (y > 5)
                        {
                            y -= 5;
                        }
                        Console.SetCursorPosition(x, y);
                        Console.WriteLine("Up");
                        break;


                    case ConsoleKey.DownArrow:
                        y += 5;
                        Console.SetCursorPosition(x, y);
                        Console.WriteLine("Down");
                        break;

                    case ConsoleKey.RightArrow:
                        x += 5;
                        Console.SetCursorPosition(x, y);
                        Console.WriteLine("RightArrow");
                        break;

                    case ConsoleKey.LeftArrow:
                        if (x > 5)
                        {
                            x -= 5;
                        }
                        Console.SetCursorPosition(x, y);
                        Console.WriteLine("LeftArrow");
                        break;

                    case ConsoleKey.D: // d키 누르면 종료
                        state = false;
                        break;

                    default: // 그 외 다른키 누르면 초기화 후 hi 출력
                        x = 0;
                        y = 0;
                        Console.SetCursorPosition(x, y);
                        Console.WriteLine("hi");
                        break;
                }
            }
        }
    }
}