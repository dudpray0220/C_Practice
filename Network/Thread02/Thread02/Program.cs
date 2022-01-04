using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading;

namespace Thread02
{
    class Test
    {
        public void Print()
        {
            Console.WriteLine("Test!");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Test test = new Test();
            Thread th = new Thread(new ThreadStart(test.Print));
            th.Start();
        }
    }
}
