using System;
using System.Net;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Dns02
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress[] iPAddresses = Dns.GetHostAddresses("www.naver.com");
            foreach (var HostIp in iPAddresses)
            {
                Console.WriteLine(HostIp);
            }
        }
    }
}
