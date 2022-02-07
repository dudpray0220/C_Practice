using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
namespace TcpClient2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpClient tcpClient = new TcpClient("localhost", 7000);
            NetworkStream ns = tcpClient.GetStream();
            Console.WriteLine("클라이언트");

            byte[] Buffer = new byte[1024];
            byte[] SendMessage = Encoding.ASCII.GetBytes("Jesus is the King!");
            ns.Write(SendMessage, 0, SendMessage.Length);
            int TotalCount = 0, ReadCount = 0;

            while (TotalCount < SendMessage.Length)
            {
                ReadCount = ns.Read(Buffer, 0, Buffer.Length); // 서버로 부터 읽어옴
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
