using System;

namespace delegateCalculate
{
    class Program
    {
        public delegate void SendString(string message); // 델리게이터 선언

        static void Main(string[] args)
        {
            SendString sayHello, sayGoodbye, multiDelegate; // 새로 선언한 델리게이터 자료형으로 변수 선언

            sayHello = Hello;
            sayGoodbye = Goodbye;

            multiDelegate = sayHello + sayGoodbye;  // multiDelegate는 두 개의 델리게이터 변수가 합쳐진 것.
            multiDelegate("byh");                           // 두 개의 메서드가 모두 호출!

            Console.WriteLine();

            multiDelegate -= sayHello;      // multiDelegate에서 sayHello 제거!
            multiDelegate("byh");             // sayGoodbye만 호출 (하나의 메서드만!)
        }

        public static void Hello(string message)
        {
            Console.WriteLine("안녕하세요" + message + "씨!");
        }

        public static void Goodbye(string message)
        {
            Console.WriteLine("안녕히 가세요" + message + "씨!");
        }
    }
}
