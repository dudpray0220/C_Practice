using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace UdpServer01
{
    class Program
    {
        static void Main(string[] args)
        {
            // UdpClient 객체 생성. 포트 3000에서 Listening
            UdpClient srv = new UdpClient(3000);

            // 클라이언트 IP를 담을 변수
            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);
            while(true)
            {
                // Receive Data
                byte[] dgram = srv.Receive(ref remoteEP);
                string rMessage = Encoding.ASCII.GetString(dgram);
                Console.WriteLine("[Receive] {0} 로부터 {1} 바이트 수신, 수신내용 : {2}", remoteEP.ToString(), dgram.Length, rMessage);

                // Send Data
                srv.Send(dgram, dgram.Length, remoteEP); // 바이트로 받았으니 인코딩 불필요!
                Console.WriteLine("[Send] {0} 로 {1} 바이트 송신", remoteEP.ToString(), dgram.Length);
            }
        }
    }
}
