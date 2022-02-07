using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace TcpClient01
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient tcpClient = new TcpClient("192.168.0.28", 7);
            if (tcpClient.Connected) { Console.WriteLine("Success"); }
            else { Console.WriteLine("Fail"); }

            tcpClient.Close();
            Console.ReadKey();
        }
    }
}
