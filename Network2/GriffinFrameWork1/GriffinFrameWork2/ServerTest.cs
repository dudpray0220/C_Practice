using System;
using Griffin.Net.Channels;
using Griffin.Net.Protocols.Http;
using Griffin.WebServer;
using Griffin.WebServer.Modules;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using Griffin.Net.Buffers;
using Griffin.Net;
using Griffin.Net.Protocols.Serializers;
using System.Security.Authentication;

namespace GriffinFrameWork2
{
    internal class ServerTest
    {
        static void Main(string[] args)
        {
            var listener = new Griffin.Net.Protocols.Http.HttpListener();
            listener.MessageReceived = OnMessage;
            listener.BodyDecoder = new CompositeBodyDecoder();
            listener.Start(IPAddress.Any, 8083);

            Console.ReadLine();
        }

        private static void OnMessage(ITcpChannel channel, object message)
        {
            var request = (HttpRequestBase)message;
            var response = request.CreateResponse();

            if (request.Uri.AbsolutePath == "/favicon.ico")
            {
                response.StatusCode = 404;
                channel.Send(response);
                return;
            }

            var msg = Encoding.UTF8.GetBytes("Hello world");
            response.Body = new MemoryStream(msg);
            response.ContentType = "text/plain";
            channel.Send(response);

            if (request.HttpVersion == "HTTP/1.0")
                channel.Close();
        }
    }
}
