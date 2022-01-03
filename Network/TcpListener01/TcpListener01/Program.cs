using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System.Collections.Generic;


namespace TcpListener01
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            TcpListener tcpListener = new TcpListener(ip, 13);
            Console.WriteLine(tcpListener.LocalEndpoint.ToString());
            Console.ReadKey();
        }
    }
}
