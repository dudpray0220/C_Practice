using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Thread07
{
    class Program
    {
        static void ThreadProc()
        {
            Console.WriteLine("Thread id : {0}", Thread.CurrentThread.GetHashCode());
        }

        static void Main(string[] args)
        {
            Thread th = new Thread(new ThreadStart(ThreadProc));
            th.Start();
            Console.WriteLine("Main Thread id : {0}", Thread.CurrentThread.GetHashCode());
        }
    }
}
