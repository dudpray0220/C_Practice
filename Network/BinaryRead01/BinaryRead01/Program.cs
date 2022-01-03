using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.IO;

namespace BinaryRead01
{
    class Program
    {
        static void Main(string[] args)
        {
            bool YesNo;
            int Number;
            float Pi;
            string Message;

            TcpClient tcpClient = new TcpClient("localhost", 3000);
            NetworkStream ns = tcpClient.GetStream();
            using (BinaryReader br = new BinaryReader(ns))
            {
                YesNo = br.ReadBoolean();
                Number = br.ReadInt32();
                Pi = br.ReadSingle();
                Message = br.ReadString();
            }
            ns.Close();
            tcpClient.Close();

            Console.WriteLine(YesNo);
            Console.WriteLine(Number);
            Console.WriteLine(Pi);
            Console.WriteLine(Message);
        }
    }
}
