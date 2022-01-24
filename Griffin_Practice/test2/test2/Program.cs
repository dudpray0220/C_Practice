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

namespace test2
{
    public partial class MainWindow
    {
        class User
        {
            public int id;
            public string userName;
            public User (int id, string userName)
            {
                this.id = id;
                this.userName = userName;
            }
        }

        class MyModule : IHttpModule
        {
            public void BeginRequest(IHttpContext context)
            {

            }

            public void EndRequest(IHttpContext context)
            {

            }
            public bool Process(Ittp) 
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
