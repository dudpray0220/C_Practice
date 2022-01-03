using System;
using System.Net;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Dns01
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress[] IP = Dns.GetHostAddresses("www.naver.com");
            foreach(var HostIp in IP)
            {
                Console.WriteLine("{0} ", HostIp);
                //Console.WriteLine(HostIp);
            }
        }
    }
}
