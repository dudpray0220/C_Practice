using System;

namespace throwException01
{
    class Program
    {
        class Box
        {
            private int width;
            public int Width
            {
                get { return width; }
                set
                {
                    if (value > 0) { width = value; }
                    else { throw new Exception("너비는 자연수!"); }
                }
            }
            private int height;
            public int Height
            {
                get { return height; }
                set
                {
                    if (value > 0) { height = value; }
                    else { throw new Exception("높이는 자연수!"); }
                }
            }

            // 생성자
            public Box(int width, int height)
            {
                Width = width;
                Height = height;
            }

            // 인스턴스 메서드
            public int Area()
            {
                return this.width * this.height;
            }
        }
        static void Main(string[] args)
        {
            Box box = new Box(-10, -20);
        }
    }
}
