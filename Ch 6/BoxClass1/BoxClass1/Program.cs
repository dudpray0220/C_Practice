using System;

namespace BoxClass1
{
    class Program
    {
        class Box
        {   // 변수와 속성
            private int width;
            public int Width // 속성 생성
            {
                get { return width; }
                set
                {
                    if (this.width > 0) { width = value; }
                    else { Console.WriteLine("자연수로 입력해"); }
                }
            }   

            private int height;
            public int Height
            {
                get { return height; }
                set
                {
                    if (this.height > 0) { height = value; }
                    else { Console.WriteLine("자연수로 입력해라"); }
                }
            }

            // 생성자
            public Box(int width, int height)
            {
                Width = width;
                Height = height;
            }

            // 인스턴스 메서드
            public int Area() { return this.width * this.height; }

        }
        static void Main(string[] args)
        {
            Box box = new Box(-10, -20);

            box.Width = -10;
            box.Height = -50;

        }
    }
}
