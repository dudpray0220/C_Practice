using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Thread06
{
    class Program
    {
        static void Func()
        {
            int i = 0;
            while (true)
            {
                Console.Write("{0} ", i++);
                Thread.Sleep(300);
            }
        }

        static void Main(string[] args)
        {
            Thread th = new Thread(new ThreadStart(Func));
            th.IsBackground = true;
            th.Start();
            Console.WriteLine("Main Exit");
        }
    }
}
