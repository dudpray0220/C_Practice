using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace UdpClientChat
{
    class ChatUdpClient
    {
        UdpClient client = null;
        // 동작 메서드
        public void Run()
        {
            while (true)
            {
                Console.WriteLine("=========클라이언트=========");
                Console.WriteLine("1. 서버연결");
                Console.WriteLine("2. Message 보내기");
                Console.WriteLine("=========================");

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
                                    Console.WriteLine("이미 연결이 돼있어요");
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
                                    Console.WriteLine("먼저 서버와 연결해주세요");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    SendMessage();
                                }
                                break;
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
            // Connection
            client = new UdpClient();
            Console.WriteLine("서버 연결 성공! 이제 Message를 입력해주세요!");
            Console.ReadKey();
        }

        // 전송 메서드
        private void SendMessage()
        {
            // Send Data
            Console.WriteLine("보낼 메세지를 입력해주세요");
            string sMessage = Console.ReadLine();
            byte[] byteData = new byte[sMessage.Length]; // 보내는 메세지 길이에 딱 맞게 할당
            byteData = Encoding.Default.GetBytes(sMessage);

            client.Send(byteData, byteData.Length, "127.0.0.1", 3000);  // Send
            Console.WriteLine("전송 성공!");
            Console.ReadKey();
        }
    }
}
