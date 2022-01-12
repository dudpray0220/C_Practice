using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace AsyncUdpServer01
{   
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Server Console");
            MyServer myServer = new MyServer();
        }
    }
    class MyServer
    {
        UdpClient server = null;
        Thread tStart = null;
        Thread tReceive = null;

        // 생성자!!
        public MyServer()
        {
            tStart = new Thread(new ThreadStart(AsyncServerStart));
            tStart.Start();
        }

        // 서버 시작 메서드
        public void AsyncServerStart()
        {
            // Listening
            server = new UdpClient(3000);
            tReceive = new Thread(new ThreadStart(DataReceived)); // 스레드 안에서 스레드 실행
            tReceive.Start();

            while (true)
            {
                Console.WriteLine("서버 구동 중...");
                Thread.Sleep(1000);
            }
        }

        // 데이터 수신 메서드
        private void DataReceived()
        {
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
