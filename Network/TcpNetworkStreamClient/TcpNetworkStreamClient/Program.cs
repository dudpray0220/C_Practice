using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace TcpNetworkStreamClient
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient tcpClient = new TcpClient("localhost", 7);
            NetworkStream ns = tcpClient.GetStream();
            Console.WriteLine("클라이언트");
            byte[] Buffer = new byte[1024];
            byte[] SendMessage = Encoding.ASCII.GetBytes("Hello World!");
            ns.Write(SendMessage, 0, SendMessage.Length);
            int TotalCount = 0, ReadCount = 0;

            while (TotalCount < SendMessage.Length)
            {
                ReadCount = ns.Read(Buffer, 0, Buffer.Length);
                TotalCount += ReadCount;

                string RecvMessage = Encoding.ASCII.GetString(Buffer);
                Console.Write(RecvMessage);
            }

            Console.WriteLine("\n받은 문자열 바이트 수 : {0}", TotalCount);
            ns.Close();
            tcpClient.Close();
        }
    }
}
