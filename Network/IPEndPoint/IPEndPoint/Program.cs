using System;
using System.Net;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace IPEndPoint01
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress IPInfo = IPAddress.Parse("127.0.0.1");
            int Port = 13;
            IPEndPoint EndPointInfo = new IPEndPoint(IPInfo, Port);
            Console.WriteLine("ip : {0}, port {1}", EndPointInfo.Address, EndPointInfo.Port);
            Console.WriteLine(EndPointInfo.ToString());
            Console.ReadKey();
        }
    }
}
