using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace ThreadMonitor02
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
        public int Count = 0;

        public void ThreadProc()
        {
            Monitor.Enter(lockObject); // 이 객체를 내가 독점할거야!
            for (int i = 0; i < 3; i++)
            {
                lockObject.IncreaseCount(ref Count);
                Console.WriteLine("Thread ID : {0}   result : {1}", Thread.CurrentThread.GetHashCode(), Count);
            }
            Monitor.Exit(lockObject);
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
