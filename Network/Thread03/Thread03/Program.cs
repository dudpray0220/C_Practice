using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading;


namespace Thread03
{
    class Program
    {
        static void Func1()
        {
            Console.WriteLine("Print 1");
        }
        static void Func2()
        {
            Console.WriteLine("Print 2");
        }

        static void Main(string[] args)
        {
            Thread th1 = new Thread(new ThreadStart(Func1));
            Thread th2 = new Thread(new ThreadStart(Func2));
            th1.Start();
            th2.Start();
            Console.WriteLine("finish");
            Console.ReadLine();
        }
    }
}
