using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace UdpClientChat
{
    class Program
    {
        static void Main(string[] args)
        {
            ChatUdpClient chatUdpClient = new ChatUdpClient();
            chatUdpClient.Run();
        }
    }
}
