using Griffin.Net;
using Griffin.Net.Channels;
using Griffin.Net.Protocols;
using System;
using System.Net;

namespace GriffinFrameWork1
{
    internal class ServerTest
    {
        static void Main(string[] args)
        {
            var listener = new HttpListener();
            listener.MessageReceived = OnMessage;
            listener.BodyDecoder = new CompositeBodyDecoder();
            listener.Start(IPAddress.Any, 8083);

            Console.ReadLine();
        }
    }

    public class Server
    {
        private readonly ChannelTcpListener _server;
        
        // 생성자
        public Server ()
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

        public void Start()
        {
            _server.Start(IPAddress.Any, 0);
        }

        private void OnClientConnected(object sender, ClientConnectedEventArgs e)
        {
            Console.WriteLine("Got connection from client with ip " + e.Channel.RemoteEndpoint);
        }

        private void OnClientDisconnected(object sender, ClientDisconnectedEventArgs e)
        {
            Console.WriteLine("Disconnected: " + e.Channel.RemoteEndpoint);
        }

        private void OnMessage(ITcpChannel channel, object message)
        {
            Console.WriteLine("Server received: " + message);
            // 모든 종류의 개체를 보낼 수 있으며 모두 DataContractSerializer를 사용하여 기본적으로 직렬화됩니다.
            channel.Send("Well, God bless you");
        }
    }
}
