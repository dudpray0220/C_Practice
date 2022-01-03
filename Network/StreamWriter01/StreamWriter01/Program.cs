using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.IO;

namespace StreamWriter01
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener tcpListener = new TcpListener(3000);
            tcpListener.Start();
            TcpClient tcpClient = tcpListener.AcceptTcpClient();

            bool YesNo = false;
            int Val1 = 12;
            float Pi = 3.14f;
            string message = "Hello World!";

            NetworkStream ns = tcpClient.GetStream();
            using (StreamWriter sw = new StreamWriter(ns)) // 초기화
            {
                sw.AutoFlush = true;
                sw.WriteLine(YesNo);
                sw.WriteLine(Val1);
                sw.WriteLine(Pi);
                sw.WriteLine(message);
            }
            ns.Close();
            tcpClient.Close();
            tcpListener.Stop();
        }
    }
}
