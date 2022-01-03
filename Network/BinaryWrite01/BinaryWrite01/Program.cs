using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.IO;

namespace BinaryWrite01
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Any, 3000);
            tcpListener.Start();

            TcpClient tcpClient = tcpListener.AcceptTcpClient();
            NetworkStream ns = tcpClient.GetStream();
            using (BinaryWriter bw = new BinaryWriter(ns))
            {
                bool YesNo = true;
                int Number = 123;
                float Pi = 3.14f;
                string Message = "Hello World!!!";

                bw.Write(YesNo);
                bw.Write(Number);
                bw.Write(Pi);
                bw.Write(Message);
            }
            ns.Close();
            tcpClient.Close();
            tcpListener.Stop();
        }
    }
}
