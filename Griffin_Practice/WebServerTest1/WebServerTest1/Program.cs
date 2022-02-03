using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Griffin.Logging;
using Griffin.Logging.Loggers;
using Griffin.WebServer;
using Griffin.WebServer.Files;
using Griffin.WebServer.Modules;
using Griffin.Net.Protocols;
using Griffin.Net;
using Griffin.Net.Channels;

namespace WebServerTest1
{
    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            server.Start();
        }
    }

    public class Server
    {
        private readonly ChannelTcpListener _server;

        // 생성자
        public Server()
        {
            _server = new ChannelTcpListener();
            _server.MessageReceived += OnMessage;
            _server.ClientConnected += OnClientConnected;
            _server.ClientDisconnected += OnClientDisconnected;
        }

        public int LocalPort
        {
            get { return _server.LocalPort; }
        }

        // Start 메서드. 서버시작
        public void Start()
        {
            _server.Start(IPAddress.Any, 0);
        }

        // OnClientConnected메서드. ip를 사용하여 클라이언트에서 연결을 얻었습니다.
        private void OnClientConnected(object sender, ClientConnectedEventArgs e)
        {
            Console.WriteLine("Got connection from client with ip " + e.Channel.RemoteEndpoint);
        }

        // OnClientDisconnected 메서드. 연결해제
        private void OnClientDisconnected(object sender, ClientDisconnectedEventArgs e)
        {
            Console.WriteLine("Disconnected: " + e.Channel.RemoteEndpoint);
        }

        // OnMessage 메서드. 수신.
        private void OnMessage(ITcpChannel channel, object message)
        {
            Console.WriteLine("Server received: " + message);

            // we can send any kind of object, all is serialized per default using DataContractSerializer (모든 종류의 개체를 보낼 수 있으며 모두 DataContractSerializer를 사용하여 기본적으로 직렬화됩니다.)
            channel.Send("Well, hello you too");
        }
    }
}
