using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace ConsoleUdpChatClient
{
    class ConsoleClient
    {
        UdpClient client = null;
        Thread receiveMessageThread = null;
        ConcurrentBag<string> sendMessageListToView = null; // 보낸 메시지 확인
        ConcurrentBag<string> receiveMessageListToView = null; // 받은 메시지 확인
        private string name = null;     // 멤버변수

        // 구동
        public void Run()
        {
            sendMessageListToView = new ConcurrentBag<string>();
            receiveMessageListToView = new ConcurrentBag<string>();

            receiveMessageThread = new Thread(new ThreadStart(ReceiveMessage));

            while (true)
            {
                Console.WriteLine("=================클라이언트=================");
                Console.WriteLine("1. 서버연결");
                Console.WriteLine("2. Message 보내기");
                Console.WriteLine("3. 보낸 Message 확인");
                Console.WriteLine("4. 받은 Message 확인");
                Console.WriteLine("5. 종료!");
                Console.WriteLine("=========================================");

                string key = Console.ReadLine();
                int order = 0;

                if (int.TryParse(key, out order))
                {
                    switch (order)
                    {
                        case CaseDefine.CONNECT:
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
                        case CaseDefine.SEND_MESSAGE:
                            if (client == null)
                            {
                                Console.WriteLine("먼저 서버와 연결해주세요!");
                                Console.ReadKey();
                            }
                            else
                            {
                                SendMessage();
                            }
                            break;
                        case CaseDefine.SEND_MSG_VIEW:
                            {
                                SendMessageView();
                                break;
                            }
                        case CaseDefine.RECEIVE_MSG_VIEW:
                            {
                                ReceiveMessageView();
                                break;
                            }
                        case CaseDefine.EXIT:
                            {
                                if (client != null)
                                {
                                    client.Close();
                                }
                                receiveMessageThread.Interrupt();
                                return;
                            }
                    }
                }
                else
                {
                    Console.WriteLine("잘못 입력했어요!");
                    Console.ReadKey();
                }
                Console.Clear();
            }
        }

        // 서버에 접속하는 메서드입니다.
        private void Connect()
        {
            Console.WriteLine("이름을 입력해");

            name = Console.ReadLine();

            string parsedName = "%^&" + name;
            if (parsedName == "%^&")
            {
                Console.WriteLine("이름을 제대로 입력해주세요!");
                Console.ReadKey();
                return;
            }
            // 이름이 잘 생성됐으면 UdpClient 객체 생성
            client = new UdpClient();  

            byte[] byteData = new byte[1024];
            byteData = Encoding.Default.GetBytes(parsedName);
            client.Send(byteData, byteData.Length, "127.0.0.1", 3000);   // 서버에 이름을 보냄!

            receiveMessageThread.Start(); // 클라이언트는 서버에 접속하고, 서버로부터 메시지 받는 것은 비동기스레드로 계속 돔! 

            Console.WriteLine("서버 연결 성공! 이제 메시지를 보낼 수 있습니다~");
            Console.ReadKey();
        }

        // 사용자가 메시지를 보내는 기능입니다. sendMessageListToView에 Add하여 SendMessageView와 연관!
        private void SendMessage()
        {
            string getUserList = string.Format("{0}<GiveMeUserList>", name);
            byte[] getUserByte = Encoding.Default.GetBytes(getUserList);

            Console.WriteLine("받는 사람을 입력하세요");
            string receiver = Console.ReadLine();

            Console.WriteLine("보낼 메시지를 입력해주세요");
            string message = Console.ReadLine();

            if (string.IsNullOrEmpty(receiver) || string.IsNullOrEmpty(message)) // 둘 중에 null or "" 가 있으면
            {
                Console.WriteLine("받는 사람과 보낼 메시지를 제대로 입력해주세요");
                Console.ReadKey();
                return;     //return 하면 메서드에서 나오므로, else 안 써도 됨!
            }
            string parsedMessage = string.Format("{0}<{1}>", receiver, message);

            byte[] byteData = new byte[parsedMessage.Length]; // 딱 이만큼만 할당해줌!
            byteData = Encoding.Default.GetBytes(parsedMessage);
            client.Send(byteData, byteData.Length, "127.0.0.1", 3000);  // parsedMessage 전송

            sendMessageListToView.Add(string.Format("[{0}] Receiver : {1}, Message {2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), receiver, message)); // List에 담아줌 (보낸 메시지 확인위해!)
            Console.WriteLine("전송 성공!");
            Console.ReadKey();
        }

        // 사용자에게 보낸 메시지를 확인하는 기능입니다.
        private void SendMessageView()
        {
            if (sendMessageListToView.Count == 0)
            {
                Console.WriteLine("보낸 메시지가 없습니다");
                Console.ReadKey();
                return;
            }
            else
            {
                foreach (var item in sendMessageListToView)
                {
                    Console.WriteLine(item);
                }
                Console.ReadKey();
            }
        }

        // 사용자로부터 받은 메시지를 확인하는 기능입니다.
        private void ReceiveMessageView()
        {
            if (receiveMessageListToView.Count == 0) // 요소가 없으면
            {
                Console.WriteLine("받은 메시지가 없습니다");
                Console.ReadKey();
                return;
            }
            foreach (var item in receiveMessageListToView)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }

        // 서버에서 보낸 메시지를 읽어주는 메서드이며 스레드를 생성해 돌려줌 (Connect 메서드에서)
        private void ReceiveMessage()
        {
            string receiveMessage = "";
            List<string> receiveMessageList = new List<string>();
            while (true)
            {
                IPEndPoint serverRemote = new IPEndPoint(IPAddress.Any, 0); // 서버 IP를 담을 변수 생성
                byte[] receiveByte = client.Receive(ref serverRemote);
                receiveMessage = Encoding.Default.GetString(receiveByte);

                string[] receiveMessageArray = receiveMessage.Split('>');    // ("{0}<{1}>", receiver, message) 이 형태로 주고 받기때문!
                foreach (var item in receiveMessageArray)
                {
                    if (!item.Contains('<')) // item이 <를 포함하지 않으면
                        continue;

                    // 관리자<TEST>는 서버에서 보내는 하트비트 메시지이니 무시해줍니다. 
                    if (item.Contains("관리자<TEST"))
                        continue;

                    receiveMessageList.Add(item); // 위 2개가 아닌것만 추가함!
                }
                ParsingReceiveMessage(receiveMessageList);
                Thread.Sleep(500);
            }
        }

        // 서버가 보낸 메시지를 역캡슐화하는 과정입니다.
        private void ParsingReceiveMessage(List<string> messageList) // 파라미터는 List<string>인 List
        {
            foreach (var item in messageList)
            {
                string sender = "";
                string message = "";
                
                if (item.Contains('<'))
                {
                    string[] splitedMsg = item.Split('<');   // ("{0}<{1}>", receiver, message) 이 형태로 주고 받기때문!

                    sender = splitedMsg[0];
                    message = splitedMsg[1];

                    if (sender == "관리자")
                    {
                        string userList = "";
                        string[] splitedUser = message.Split('$');
                        foreach (var el in splitedUser)
                        {
                            if (string.IsNullOrEmpty(el))
                                continue;
                            userList += el + " ";
                        }
                        Console.WriteLine(string.Format("[현재 접속인원] {0}", userList));
                        messageList.Clear();
                        return;
                    }
                    // 관리자가 보낸게 아니면
                    Console.WriteLine(string.Format("[메시지가 도착했습니다] {0} : {1}", sender, message));
                    receiveMessageListToView.Add(string.Format("[{0}] Sender : {1}, Message {2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), sender, message));  // 받은 메시지 확인위해!
                }
            }
            messageList.Clear();
        }
    }
}
