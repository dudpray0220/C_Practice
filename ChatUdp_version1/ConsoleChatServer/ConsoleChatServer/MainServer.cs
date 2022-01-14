using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace ConsoleChatServer
{
    class MainServer
    {   // 스레드는 2개 => 1. 클라이언트의 연결 받는 스레드   /   2. 클라이언트의 정보 받고 쏴주는 스레드 (Echo Server)
        UdpClient server = null;
        Thread tStart = null;
        Thread tEcho = null;

        // 생성자 생성 시 서버 시작 스레드 Start
        public MainServer()
        {
            tStart = new Thread(new ThreadStart(AsyncServerStart));
            tStart.Start();
        }

        // 서버 시작 메서드
        public void AsyncServerStart()
        {
            server = new UdpClient(3000);   // Listening
            tEcho = new Thread(new ThreadStart(EchoData));
            tEcho.Start();

            Console.WriteLine("==================서버==================");
        }

        // 클라이언트 이름을 받는 메서드
        private void saveName()
        {

        }

        // 클라이언트 Echo 메서드
        private void EchoData()
        {   
            // 먼저 이름을 받는다.
            string clientName = "";

            IPEndPoint cliRemoteName = new IPEndPoint(IPAddress.Any, 0);
            byte[] receiveName = server.Receive(ref cliRemoteName);
            clientName = Encoding.Default.GetString(receiveName);

            // 그 다음 무한 루프로 메시지를 받는다.
            while (true)
            {
                string receiveMessage = "";    // 초기화

                IPEndPoint cliRemote = new IPEndPoint(IPAddress.Any, 0);
                byte[] receiveData = server.Receive(ref cliRemote);
                receiveMessage = Encoding.Default.GetString(receiveData);

                Console.WriteLine("{0} : {1}", clientName, receiveMessage);

                byte[] sendData = Encoding.Default.GetBytes(receiveMessage);
                server.Send(sendData, sendData.Length, cliRemote);

            }
        }
    }
}
