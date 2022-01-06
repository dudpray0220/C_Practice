using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace UdpClient01
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient udpClient = new UdpClient("localhost", 3000);

            string message = "Hi Hello Friend";
            byte[] SendMessage = Encoding.ASCII.GetBytes(message);

            udpClient.Send(SendMessage, SendMessage.Length);
            Console.WriteLine("{0} 바이트 전송", SendMessage.Length);

            IPEndPoint epRemote = new IPEndPoint(IPAddress.Any, 3000);
            byte[] bytes = udpClient.Receive(ref epRemote);
            Console.WriteLine("{0}로부터 {1} 바이트 수신", epRemote.ToString(), bytes.Length);

            udpClient.Close();
        }
    }
}
