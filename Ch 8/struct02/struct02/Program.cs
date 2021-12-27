using System;

namespace struct02
{
    class Program
    {
        class PointClass
        {
            public int x;
            public int y;

            public PointClass(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
        
        struct PointStruct
        {
            public int x;
            public int y;

            public PointStruct (int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        static void Main(string[] args)
        {
            // Class
            PointClass pointClassA = new PointClass(10, 20);
            PointClass pointClassB = pointClassA;       // 참조 복사 (메모리 주소)

            pointClassB.x = 100;
            pointClassB.y = 200;

            Console.WriteLine("pointClassA : " + pointClassA.x + ", " + pointClassA.y);
            Console.WriteLine("pointClassB : " + pointClassB.x + ", " + pointClassB.y);
            Console.WriteLine();

            // Struct
            PointStruct pointStructA = new PointStruct(10, 20);
            PointStruct pointStructB = pointStructA;        // 값 복사

            pointStructB.x = 100;
            pointStructB.y = 200;

            Console.WriteLine("pointStructA : " + pointStructA.x + ", " + pointStructA.y);
            Console.WriteLine("pointStructB : " + pointStructB.x + ", " + pointStructB.y);
            Console.WriteLine();
        }
    }
}
