using System;
using System.Threading;

namespace AsynTest
{
    delegate void myDelegate();
    class Program
    {
        static void Main(string[] args)
        {
            myDelegate a = Func;
            // a(); // 메서드 호출
            //a.Invoke(); // 메서드를 동기적으로 호출
            Thread th = new Thread(new ThreadStart(Func));
            th.Start();
               
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("메인스레드는 이걸 세번 출력해주고 프로그램이 종료될 것이야~");
                Thread.Sleep(100);
            }
        }

        private static void Func()
        {
            Console.WriteLine(Thread.CurrentThread.IsBackground);
            Console.WriteLine(Thread.CurrentThread.IsThreadPoolThread);

            for (int i = 0; i< 10; i++)
            {
                Console.WriteLine(i + 1);
                Thread.Sleep(100);
            }
        }
    }
}
