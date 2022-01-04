using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading;

namespace Thread01
{
    class Program
    {
        static void Func()
        {
            Console.WriteLine("스레드에서 호출");
        }

        static void ParameterizedFunc2(object obj)
        {
            for (int i = 0; i < (int)obj; i++)
                Console.WriteLine("Parameterized 스레드에서 호출 : {0}", i);
        }

        static void Main(string[] args)
        {
            //Thread th = new Thread(new ThreadStart(Func)); // 이 코드를 많이 씀!
            //ThreadStart thStart = new ThreadStart(Func);
            //Thread th = new Thread(thStart);
            //th.Start();

            int i = 5;
            Thread th2 = new Thread(new ParameterizedThreadStart(ParameterizedFunc2));
            th2.Start(i);
        }
    }
}
