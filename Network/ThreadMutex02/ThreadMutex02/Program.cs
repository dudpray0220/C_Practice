using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace ThreadMutex02
{
    class Thislock
    {
        public void IncreaseCount(ref int count)
        {
            count++;
        }
    }
    class Test
    {
        Thislock lockObject = new Thislock();
        Mutex mutex = new Mutex();
        public int Count = 0;

        public void ThreadProc()
        {
            mutex.WaitOne();

            for (int i = 0; i < 3; i++)
            {
                lockObject.IncreaseCount(ref Count);
                Console.WriteLine("Thread ID : {0}   result : {1}", Thread.CurrentThread.GetHashCode(), Count);
            }

            mutex.ReleaseMutex();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Test test = new Test();
            Thread[] threads = new Thread[3];
            for (int i = 0; i < 3; i++)
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
