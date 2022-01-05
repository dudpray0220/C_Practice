using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace ThreadLock01
{
    // 정적 변수를 2개의 스레드에서 다루는 예제
    class Test
    {
        static int Count; // 공유자원

        public void ThreadProc()
        {
            for (int i = 0; i< 10; i++)
            {
                Count++;
                Console.WriteLine("Thread ID : {0}   result : {1}", Thread.CurrentThread.GetHashCode(), Count);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Test test = new Test();
            Thread th1 = new Thread(new ThreadStart(test.ThreadProc));
            Thread th2 = new Thread(new ThreadStart(test.ThreadProc));
            th1.Start();
            th2.Start();
        }
    }
}
