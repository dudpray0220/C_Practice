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
        ConcurrentBag<string> sendMessageListToView = null;
        ConcurrentBag<string> receiveMessageListToView = null;
        private string name = null;     // 멤버변수

        // 서버 구동
        public void Run()
        {
            sendMessageListToView = new ConcurrentBag<string>();
            receiveMessageListToView = new ConcurrentBag<string>();

            receiveMessageThread = new Thread
        }

        // 서버에서 보낸 메시지를 읽어주는 메서드이며 스레드를 생성해 돌려줌.
        public void receiveMessage()
        {
            string receiveMessage = "";
            List<string> receiveMessageList = new List<string>();
            while (true)
            {
                IPEndPoint epRomote = new IPEndPoint(IPAddress.Any, 0); // 서버 IP를 담을 변수 생성
                byte[] receiveByte = client.Receive(ref epRomote);
                receiveMessage = Encoding.Default.GetString(receiveByte);

                string[] receiveMessageArray = receiveMessage.Split('>');
                foreach (var item in receiveMessageArray)
                {
                    if (!item.Contains('<'))
                        continue;
                    // 관리자<TEST>는 서버에서 보내는 하트비트 메시지이니 무시해줍니다. 
                    if (item.Contains("관리자<TEST"))
                        continue;
                    receiveMessageList.Add(item);
                }
                
            }
        }

        // 서버가 보낸 메시지를 역캡슐화하는 과정입니다.
        public void ParsingReceiveMessage(List<string> messageList)
        {
            foreach(var item in messageList)
            {
                
            }
        }
    }
}
