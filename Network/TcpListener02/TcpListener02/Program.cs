using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace TcpListener02
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Parse("192.168.0.28"), 7);
            tcpListener.Start();
            Console.WriteLine("대기상태 시작");
            TcpClient tcpClient = tcpListener.AcceptTcpClient(); // -> 대기상태
            Console.WriteLine("대기상태 종료");
            tcpListener.Stop();
        }
    }
}
