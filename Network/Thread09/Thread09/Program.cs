using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using System.Text;
using System.Collections.Generic;


namespace Thread09
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread th = new Thread(new ThreadStart(ThreadProc1));
            th.Start();

            Console.WriteLine("Main ID {0}", Thread.CurrentThread.GetHashCode());
            Console.WriteLine("Main Exit");
        }
        
        private static void ThreadProc1()
        {
            Console.WriteLine("ThreadProc1 ID {0}", Thread.CurrentThread.GetHashCode());
            Thread th = new Thread(new ThreadStart(ThreadProc2));
            th.Start();

            for (int i =0; i < 10; i++)
            {
                Console.Write("{0} ", i * 10);
                Thread.Sleep(200);

                if (i == 3)
                {
                    Console.WriteLine("ThreadProc1 Exit");
                }
            }
        }

        static void ThreadProc2()
        {
            Console.WriteLine("ThreadProc2 ID {0}", Thread.CurrentThread.GetHashCode());
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine("{0} ", i);
                Thread.Sleep(200);
            }
            Console.WriteLine("ThreadProc2 Exit");
        }
    }
}
