using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Griffin.Logging;
using Griffin.Logging.Loggers;
using Griffin.Net.Channels;
using Griffin.WebServer;
using Griffin.WebServer.Files;
using Griffin.WebServer.Modules;

namespace SslGriffinDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fileService = new DiskFileService("/", string.Format(@"C:\Users\{0}\Downloads", Environment.UserName));
            var module = new FileModule(fileService)
            {
                AllowFileListing = true,
            };


        }
    }

    public class HttpsServer
    {
        private readonly ModuleManager _moduleManager = new ModuleManager();
        private Griffin.Net.Protocols.Http.HttpListener _listener;

        // 생성자
        public HttpsServer(FileModule module) // 파일을 담는 파라미터, 모듈매니저 파라미터에 넣음
        {
            if (module == null) throw new ArgumentNullException("Module");
            _moduleManager.Add(module);
        }
    }
}
