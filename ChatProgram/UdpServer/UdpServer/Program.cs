using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace UdpServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Server Console");

            // Listening
            UdpClient server = new UdpClient(3000);

            // Receive Data
            while (true)
            {
                IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0); // 들어오는 모든 IP, PORT에 대해서 엔드포인트 remoteIP에 저장
                byte[] dgram = server.Receive(ref remoteEP);
                string rMessage = Encoding.Default.GetString(dgram);
                Console.WriteLine("\n클라이언트 IP주소 : {0} \n수신 메시지 : {1}", remoteEP.ToString(), rMessage);
            }
        }
    }
}
