using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading;

namespace Thread04
{

    class Test
    {
        public void Print()
        {
            Console.WriteLine("Thread Print");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Test test1 = new Test();
            Test test2 = new Test();

            Thread th1 = new Thread(new ThreadStart(test1.Print));
            Thread th2 = new Thread(new ThreadStart(test2.Print));
            th1.Start();
            th2.Start();
            Console.ReadLine();
        }
    }
}
