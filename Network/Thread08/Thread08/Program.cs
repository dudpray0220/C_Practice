using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Thread08
{
    class Program
    {
        static void Func()
        {
            for (int i = 0; i < 30; i++)
            {
                Console.Write("{0} ", i);
                Thread.Sleep(200);
            }
        }

        static void Main(string[] args)
        {
            Thread th = new Thread(new ThreadStart(Func));
            th.Start();
            th.Join();
            Console.WriteLine("\nMain quit");
        }
    }
}
