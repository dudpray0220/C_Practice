using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace TcpNetworkStreamServer
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Any, 7);
            tcpListener.Start();
            byte[] Buffer = new byte[1024];
            int TotalByteCount = 0, ReadByteCount = 0;

            Console.WriteLine("서버");

            TcpClient tcpClient = tcpListener.AcceptTcpClient();
            NetworkStream ns = tcpClient.GetStream();

            while (true) // 에코서버의 가장 기본적인 형태 중 하나
            {
                ReadByteCount = ns.Read(Buffer, 0, Buffer.Length);
                if (ReadByteCount ==0)
                {
                    break; // 0이면 읽을 데이터가 없는 것이므로
                }
                TotalByteCount += ReadByteCount;
                ns.Write(Buffer, 0, ReadByteCount);
                Console.Write(Encoding.ASCII.GetString(Buffer));
            }

            ns.Close();
            tcpClient.Close();
            tcpListener.Stop();
        }
    }
}
