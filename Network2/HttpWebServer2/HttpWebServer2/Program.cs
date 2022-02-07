using System;
using System.Net;
using Griffin.WebServer;
using Griffin.Net;
using Griffin.Container;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace HttpWebServer2
{
    class Program2
    {
        static void Main(string[] args)
        {
            var listener = new HttpListener();
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