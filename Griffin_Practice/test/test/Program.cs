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
    class Program
    {
        static void Main(string[] args)
        {
            X509Certificate2 test = new X509Certificate2(@"C:/Users/byh/openssl");

            SimpleWebServer simpleWebServer = new SimpleWebServer(@"https://www.localhost.com:8080", test);

            simpleWebServer.Run();
        }
    }
}
