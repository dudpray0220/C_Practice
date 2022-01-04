using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Thread05
{
    class Program
    {
        static void Func1()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Thread1 Print {0}", i);
            }
        }
        static void Func2()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Thread2 Print {0}", i);
            }
        }
        static void Main(string[] args)
        {
            Thread th1 = new Thread(new ThreadStart(Func1));
            Thread th2 = new Thread(new ThreadStart(Func2));
            th1.Start(); // Thread는 OS에 의해서 실행되므로 Main함수와는 별개! 영향을 안 받음!
            th2.Start();
            Console.WriteLine("Main Exit");
        }
    }
}
