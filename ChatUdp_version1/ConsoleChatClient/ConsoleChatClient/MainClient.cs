using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace ConsoleChatClient
{
    class MainClient
    {
        UdpClient client = null;
        Thread receiveMessageThread = null;

        // 클라이언트 메인 메서드
        public void Run()
        {
            receiveMessageThread = new Thread(new ThreadStart(ReceiveMessage));  // 서버에서 메시지 받는 메서드는 스레드로 계속 돈다.
            while (true)
            {
                Console.WriteLine("=================클라이언트=================");
                Console.WriteLine("1. 서버연결");
                Console.WriteLine("2. Message 보내기");
                Console.WriteLine("3. 종료!");
                Console.WriteLine("=========================================");

                string key = Console.ReadLine();
                int order = 0;

                if (int.TryParse(key, out order))
                {
                    switch (order)
                    {
                        case 1:
                            {
                                if (client != null)
                                {
                                    Console.WriteLine("이미 연결되어있습니다!");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Connect();
                                }
                                break;
                            }
                        case 2:
                            {
                                if (client == null)
                                {
                                    Console.WriteLine("먼저 서버와 연결해주세요~");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    SendMessage();
                                }
                                break;
                            }
                        case 3:
                            {
                                if (client != null)
                                {
                                    client.Close();
                                }
                                receiveMessageThread.Interrupt();
                                Console.WriteLine("종료 완료...");
                                return;
                            }
                    }
                }
                else
                {
                    Console.WriteLine("잘못 입력했어요");
                    Console.ReadKey();
                }

                Console.Clear();
            }
        }

        // 연결 메서드
        private void Connect()
        {
            client = new UdpClient();
        
            Console.WriteLine("이름을 입력해주세요");
            string name = Console.ReadLine();

            byte[] byteData = new byte[1024];
            byteData = Encoding.Default.GetBytes(name);
            client.Send(byteData, byteData.Length, "172.16.5.218", 3000); // 이름 전송

            receiveMessageThread.Start(); // 스레드 시작 전에 한번 연결을 해주어 에러 제거

            Console.WriteLine("서버 연결 성공! 이제 메시지를 보낼 수 있습니다~");
            Console.ReadKey();
        }

        // 메시지 전송 메서드
        private void SendMessage()
        {
            Console.WriteLine("채팅 시작! (나가려면 exit를 입력해주세요)");
            while (true)
            {
                string sMessage = Console.ReadLine();

                if (sMessage == "exit")
                {
                    break;
                }

                //byte[] sendData = new byte[message.Length];    // 밑에거랑 뭐가 더 좋나?
                //sendData = Encoding.Default.GetBytes(message);

                byte[] sendData = Encoding.Default.GetBytes(sMessage);
                client.Send(sendData, sendData.Length, "172.16.5.218", 3000);
                //Console.WriteLine("전송 성공!");
                //Console.ReadKey();
                
            }
        }

        // 서버로 부터 메시지 받는 메서드 (비동기 스레드로 실행)
        private void ReceiveMessage()
        {
            string rMessage = "";
            while (true)
            {
                //client.Client.Bind(new IPEndPoint(IPAddress.Any, 0));
                IPEndPoint serverRemote = new IPEndPoint(IPAddress.Any, 0);
                byte[] receiveData = client.Receive(ref serverRemote);
                rMessage = Encoding.Default.GetString(receiveData);

                if (rMessage == "")
                {
                    continue;
                }
                Console.WriteLine("{0} : {1}", serverRemote.ToString(), rMessage);
            }
        }
    }
}
