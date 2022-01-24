using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using Griffin.WebServer;
using Griffin.WebServer.Modules;

namespace test
{
    class SimpleWebServer
    {
        #region Fields

        private X509Certificate2 certificate;
        int port;
        private HttpServer _listener;
        private HttpWorker _worker;

        #endregion Fields


        #region Constructors

        // 생성자
        public SimpleWebServer(string prefixes, X509Certificate2 certificate)
        {
            Uri uri = new Uri(prefixes);
            this.port = uri.Port;
            this.certificate = certificate;

            _worker = new HttpWorker(); // HttpWorker 객체 선언
            ModuleManager moduleManager = new ModuleManager();
            moduleManager.Add(_worker);
            _listener = new HttpServer(moduleManager); // HttpServer 객체 선언
        }
        #endregion Constructors


        #region Methods 

        public void addUrlAction2(string path, Action<IHttpContext> method)
        {
            _worker.addUrlAction(path, method);
        }

        // 서버 시작 (X509 인증서)
        public void Run()
        {
            _listener.Start(IPAddress.Any, port, certificate);
        }

        // 서버 스탑
        public void Stop()
        {
            _listener.Stop();
        }

        #endregion Methods
    }
}
