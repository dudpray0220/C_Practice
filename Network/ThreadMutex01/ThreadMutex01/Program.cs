using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace ThreadMutex01
{
    class Program
    {
        static Mutex mut = new Mutex();
        static int Count;

        static void ThreadProc()
        {
            mut.WaitOne();
            for (int i=  0; i < 5; i++)
            {
                Count++;
                Console.WriteLine("Thread ID : {0}   result : {1}", Thread.CurrentThread.GetHashCode(), Count);
            }
            mut.ReleaseMutex();
        }

        static void Main(string[] args)
        {
            Thread th1 = new Thread(new ThreadStart(ThreadProc));
            Thread th2 = new Thread(new ThreadStart(ThreadProc));
            th1.Start();
            th2.Start();
        }
    }
}
