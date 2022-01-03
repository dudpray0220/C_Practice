using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace TcpClient03
{
    class Program
    {
        static void Main(string[] args)
        {
            // Client
            TcpClient tcpClient = new TcpClient("172.16.5.218", 7);
            if (tcpClient.Connected)
            {
                Console.WriteLine("서버 연결 성공");
                NetworkStream ns = tcpClient.GetStream();
                string message = "Hello World!";
                byte[] SendByteMessage = Encoding.ASCII.GetBytes(message);
                ns.Write(SendByteMessage, 0, SendByteMessage.Length);

                byte[] ReceiveByteMessage = new byte[32];
                ns.Read(ReceiveByteMessage, 0, 32);
                string ReceiveMessage = Encoding.ASCII.GetString(ReceiveByteMessage);
                Console.WriteLine(ReceiveMessage);
                ns.Close();
            }
            else
            {
                Console.WriteLine("서버 연결 실패!!!");
            }
            tcpClient.Close();
            Console.ReadKey();
        }
    }
}
