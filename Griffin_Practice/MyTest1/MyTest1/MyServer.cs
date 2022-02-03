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

namespace MyTest1
{
    class MyServer
    {
        static void Main(string[] args)
        {
            var moduleManager = new ModuleManager();

            // Start the Server
            var server = new HttpServer(moduleManager);
            server.Start(IPAddress.Any, 0);
            Console.WriteLine("PORT " + server.LocalPort);
        }
    }
}
