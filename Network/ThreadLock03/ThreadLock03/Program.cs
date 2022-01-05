using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace ThreadLock03
{
    // 다수의 스레드가 하나의 객체를 사용하는 경우
    class ThisLock
    {
        public void IncreaseCount(ref int count)
        {
            count++;
        }
    }
    class Test
    {
        ThisLock lockObject = new ThisLock();
        int Count = 0;

        public void ThreadProc()
        {
            for (int i = 0;  i <3; i++)
            {
                lockObject.IncreaseCount(ref Count);
                Console.WriteLine("Thread ID : {0}   result : {1}", Thread.CurrentThread.GetHashCode(), Count);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Test test = new Test();
            Thread[] threads = new Thread[3];
            for (int i = 0; i< 3; i++)
            {
                threads[i] = new Thread(new ThreadStart(test.ThreadProc));
            }
            for (int i = 0; i < 3; i++)
            {
                threads[i].Start();
            }
        }
    }
}
