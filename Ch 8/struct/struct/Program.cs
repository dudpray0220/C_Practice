using System;

namespace struct01
{
    class Program
    {
        struct Point
        {
            public int x;
            public int y;
            public string testA;           // 초기화 안된 멤버변수이므로 생성자 만들 떄 초기화 해줘야 됨.
            public string testB; // 선언과 동시에 초기화 불가!
            public Program program;

            public Point(int x, int y)     // 멤버변수 testA를 초기화 안 했으므로 오류발생!
            {
                this.x = x;
                this.y = y;
                this.testA = "init";
                this.testB = "init";
                this.program = null;
            }

            public Point(int x, int y, string test)     // 멤버변수 testA를 초기화 안 했으므로 오류발생!
            {
                this.x = x;
                this.y = y;
                this.testA = test;
                this.testB = test;
                this.program = null;
            }
        }
        static void Main(string[] args)
        {
            Point point = new Point();

            Console.WriteLine(point.x);
            Console.WriteLine(point.y);
        }
    }
}
