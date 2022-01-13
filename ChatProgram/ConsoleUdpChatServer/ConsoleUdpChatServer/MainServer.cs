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
    public class MainServer
    {
        ClientManager _clientManager = null;
        ConcurrentBag<string> chattingLog = null;   // ConcurrentBag : 스레드로부터 안전한 정렬되지 않은 개체 컬렉션을 나타냅니다.
        ConcurrentBag<string> accessLog = null;
        Thread connectCheckThread = null;            // 하트비트 스레드
        Thread serverRunThread = null;

        // 생성자 (1. ClientManager 객체 생성 / 2. 채팅로그, 접속로그 컬렉션 생성 / 3. 서버 스레드, 하트비트 스레드 시작 
        public MainServer()
        {
            _clientManager = new ClientManager();
            chattingLog = new ConcurrentBag<string>();
            accessLog = new ConcurrentBag<string>();
            //_clientManager.EventHandler += ClientEvent;
            //_clientManager.messageParsingAction += MessageParsing;

            //Task serverStart = Task.Run(() =>
            //{
            //    ServerRun();
            //});
        }

        // 하트비트 스레드 메서드
        private void ConnectCheckLoop()
        {
        }

        // ===============================================================================================
        
        // 서버를 돌리는 메서드
        private void ServerRun()
        {
            UdpClient server = new UdpClient(3000);
        }

        // 기본 콘솔 로직
        public void ConsoleView()
        {
            serverRunThread = new Thread(new ThreadStart(ServerRun));
            serverRunThread.Start();

            while (true)
            {
                Console.WriteLine("=================서버 (1,2,3 미구현)=================");
                Console.WriteLine("1. 현재 접속인원확인");
                Console.WriteLine("2. 접속기록확인");
                Console.WriteLine("3. 채팅로그확인");
                Console.WriteLine("4. 종료!");
                Console.WriteLine("===============================================");

                string key = Console.ReadLine();
                int order = 0;

                if (int.TryParse(key, out order))
                {
                    switch (order)
                    {
                        case 1:
                            {
                                ShowCurrentClient();
                                break;
                            }
                        case 2:
                            {
                                ShowAccessLog();
                                break;
                            }
                        case 3:
                            {
                                ShowChatLog();
                                break;
                            }
                        case 4:
                            {
                                serverRunThread.Interrupt();
                                break;
                            }
                    }
                }
                else
                {
                    Console.WriteLine("잘못 입력했어요");
                    Console.ReadKey();
                    break;
                }
                Console.Clear();
                Thread.Sleep(50);
            }
        }

        // 현재 접속인원확인 메서드
        private void ShowCurrentClient()
        {
            if (ClientManager.clientDic.Count == 0)
            {
                Console.WriteLine("아무도 없습니다...");
                Console.ReadKey();
                return;
            }
            foreach (var item in ClientManager.clientDic)
            {
                Console.WriteLine(item.Value.clientName);
            }
            Console.ReadKey();
        }

        // 접근로그확인 메서드
        private void ShowAccessLog()
        {
            if (accessLog.Count == 0)
            {
                Console.WriteLine("접근기록이 없습니다!");
                Console.ReadKey();
                return;
            }
            foreach (var item in accessLog)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }

        // 채팅로그확인 메서드
        private void ShowChatLog()
        {
            if (chattingLog.Count == 0)
            {
                Console.WriteLine("아무도 대화를 안 했습니다...");
                Console.ReadKey();
                return;
            }
            foreach (var item in chattingLog)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
