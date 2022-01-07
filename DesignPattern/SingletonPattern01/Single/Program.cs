using System;

namespace Single
{
    class Singleton
    {
        private static Singleton staticSingleton; // 클래스 변수 (static)
        public static Singleton Method()         // 클래스 메서드 (static)
        {
            if (staticSingleton == null)
            {
                staticSingleton = new Singleton();
            }
            return staticSingleton;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            // 뭘 하든 각 객체는 모두 같은 객체이다!
            var objectA = Singleton.Method();
            var objectB = Singleton.Method();
            var objectC = Singleton.Method();

            Console.WriteLine(objectA);
            Console.WriteLine(objectB);
            Console.WriteLine(objectC);
        }
    }
}

