using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace ConsoleUdpChatClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleClient consoleClient = new ConsoleClient();
            consoleClient.Run();
        }
    }
}
