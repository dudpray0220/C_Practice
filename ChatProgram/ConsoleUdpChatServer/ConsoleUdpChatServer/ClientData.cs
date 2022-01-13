using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace ConsoleUdpChatServer
{
    class ClientData
    {
        public UdpClient udpClient { get; set; }
        public byte[] readData { get; set; }
        public StringBuilder currentMsg { get; set; }
        public string clientName { get; set; }
        public int clientNumber { get; set; }
        public IPEndPoint remoteEP;

        // 생성자
        public ClientData(UdpClient udpClient)
        {
            currentMsg = new StringBuilder();
            readData = new byte[1024];

            this.udpClient = udpClient;

            remoteEP = new IPEndPoint(IPAddress.Any, 0);
            //readData = udpClient.Receive(ref remoteEP);

            char[] splitDivision = new char[2];
            splitDivision[0] = '.';
            splitDivision[1] = ':';

            string[] temp = null;

            temp = udpClient.Client.LocalEndPoint.ToString().Split(splitDivision);

            this.clientNumber = int.Parse(temp[3]);
        }
    }
}
