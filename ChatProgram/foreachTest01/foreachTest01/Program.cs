using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace foreachTest01
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> intList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            List<string> strList = new List<string>();

            for (int i = 0; i < 10; i++)
            {
                strList.Add("byh " + i);
            }


            foreach (var str in strList)
            {
                if (str.Contains('3'))
                    continue;

                Console.WriteLine(str);
            }

            Console.WriteLine();
            foreach (var item in intList)
            {
                if (item < 5)
                    continue;

                Console.WriteLine("{0} abc", item);
            }

            Console.WriteLine("{0} : <{1}>", "abc", "byh");
        }
    }
}
