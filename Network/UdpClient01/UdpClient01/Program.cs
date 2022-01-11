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
            // UdpClient 객체 생성
            UdpClient cli = new UdpClient();

            string msg = "Hello World~";
            byte[] datagram = Encoding.ASCII.GetBytes(msg);

            // Send Data
            cli.Send(datagram, datagram.Length, "127.0.0.1", 3000);
            Console.WriteLine("[Send] 127.0.0.1:3000로 {0} 바이트 전송", datagram.Length);

            // Receive Data
            // 서버 IP를 담을 변수 생성
            IPEndPoint epRemote = new IPEndPoint(IPAddress.Any, 0);
            byte[] bytes = cli.Receive(ref epRemote);
            string rMessage = Encoding.ASCII.GetString(bytes);
            Console.WriteLine("[Receive] {0} 로부터 {1} 바이트 수신, 수신 내용 : {2}", epRemote.ToString(), bytes.Length, rMessage);

            // UdpClient 객체 닫기
            cli.Close();
        }
    }
}
