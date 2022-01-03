using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace TcpListener03
{
    class Program
    {
        static void Main(string[] args)
        {
            // Server
            TcpListener tcpListener = new TcpListener(IPAddress.Parse("172.16.5.218"), 7);
            tcpListener.Start();
            Console.WriteLine("대기상태");
            TcpClient tcpClient = tcpListener.AcceptTcpClient();
            
            NetworkStream ns = tcpClient.GetStream();
            byte[] ReceiveMessage = new byte[100];
            ns.Read(ReceiveMessage, 0, 100);
            string strMessage = Encoding.ASCII.GetString(ReceiveMessage);
            Console.WriteLine(strMessage);

            string EchoMessage = "Hi~~!";
            byte[] sendMessage = Encoding.ASCII.GetBytes(EchoMessage);
            ns.Write(sendMessage, 0, sendMessage.Length);
            ns.Close();
            tcpClient.Close();
            tcpListener.Stop();
            Console.ReadKey();
        }
    }
}
