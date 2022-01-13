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
    class ClientManager
    {
        // ConcurrentDictionary는 여러 개의 스레드에서 동시에 액세스할 수 있는 키/값 쌍의 스레드로부터 안전한 컬렉션.
        public static ConcurrentDictionary<int, ClientData> clientDic = new ConcurrentDictionary<int, ClientData>();
        public event Action<string, string> messageParsingAction = null;
        public event Action<string, int> EventHandler = null;

        public void AddClient(UdpClient newClient) // 파라미터 : UdpClient 형태
        {
            ClientData currentClient = new ClientData(newClient);
            try
            {
                currentClient.udpClient.Receive(ref currentClient.remoteEP);
                clientDic.TryAdd(currentClient.clientNumber, currentClient);
            }
            catch (Exception)
            {

            }
        }

        private void DataReceived() 
        { 
        }
    }
}
