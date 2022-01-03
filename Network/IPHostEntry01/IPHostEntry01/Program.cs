using System;
using System.Net;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace IPHostEntry01
{
    class Program
    {
        static void Main(string[] args)
        {
            IPHostEntry HostInfo = Dns.GetHostEntry("www.naver.com");

            foreach(IPAddress ip in HostInfo.AddressList)
            {
                Console.WriteLine(ip);
            }
            Console.WriteLine(HostInfo.HostName);
        }
    }
}
