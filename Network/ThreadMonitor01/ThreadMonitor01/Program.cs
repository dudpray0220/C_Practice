using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace ThreadMonitor01
{   // lock과 동일하게 private object obj = new object()를 사용하여 동기화를 하는 예
    class Test
    {
        int Count;
        object obj = new object();
        public void IncreaseCount()
        {
            Monitor.Enter(obj);
            for (int i = 0; i < 5; i++)
            {
                Count++;
                Console.WriteLine("Thread ID : {0}   result : {1}", Thread.CurrentThread.GetHashCode(), Count);
            }
            Monitor.Exit(obj);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Test test = new Test();
            Thread th1 = new Thread(new ThreadStart(test.IncreaseCount));
            Thread th2 = new Thread(new ThreadStart(test.IncreaseCount));
            th1.Start();
            th2.Start();
        }
    }
}
