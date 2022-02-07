using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCPClient1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. IP 주소와 포트를 지정하고 TCP 연결
            TcpClient tc = new TcpClient("127.0.0.1", 7000);
            // TcpClient tc = new TcpClient(localhost, 7000);
            if (tc.Connected) { Console.WriteLine("Success"); }
            else { Console.WriteLine("Fail"); }

            string message = "God bless you";
            byte[] buffer = Encoding.ASCII.GetBytes(message);

            // 2. NetworkStream을 얻어옴
            NetworkStream stream = tc.GetStream();

            // 3. Stream에 바이트 데이터 전송
            stream.Write(buffer, 0, buffer.Length);

            // 4. Stream으로부터 바이트 데이터 읽기
            //byte [] outbuffer = new byte[1024];
            //int nbytes = stream.Read(outbuffer, 0, outbuffer.Length);   
            //string output = Encoding.ASCII.GetString(outbuffer, 0, nbytes); 

            // 4. 서버가 Connection을 닫을 때까지 읽는 경우
            byte [] outbuffer = new byte[1024];
            int nbytes = 0;
            MemoryStream memoryStream = new MemoryStream();
            while ((nbytes = stream.Read(outbuffer, 0, outbuffer.Length)) > 0)
            {
                memoryStream.Write(outbuffer, 0, nbytes);   
            }
            byte [] outbytes = memoryStream.ToArray();
            memoryStream.Close();

            // 5. Stream과 TcpClient 객체 닫기
            stream.Close();
            tc.Close();

            Console.WriteLine(Encoding.ASCII.GetString(outbytes));  
        }
    }
}
