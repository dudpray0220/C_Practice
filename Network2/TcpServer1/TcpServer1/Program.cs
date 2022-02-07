using System;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace TcpServer1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. 로컬포트 7000을 Listen
            TcpListener tcpListener = new TcpListener(IPAddress.Any, 7000);
            tcpListener.Start();
            Console.WriteLine("대기상태 시작");

            byte[] buffer = new byte[1024];

            //while (true)
            //{
                // 2. TcpClient Connection 요청을 받아들여 서버에서 새 TcpClient 객체를 생성하여 리턴
                TcpClient tc = tcpListener.AcceptTcpClient();
                Console.WriteLine("대기상태 종료");

                // 3. TcpClient 객체에서 NetworkStream을 얻어옴
                NetworkStream stream = tc.GetStream();

                // 4. 클라이언트가 연결을 끊을 때까지 데이타 수신
                int nbytes = 0;
                while ((nbytes = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    // 5. 데이터 그대로 송신
                    stream.Write(buffer, 0, nbytes);
                }
                string receiveMsg = Encoding.ASCII.GetString(buffer);
                Console.WriteLine(receiveMsg);

                // 6. Stream과 TcpClient 객체
                stream.Close();
                tc.Close();

                //7. 계속 반복
            }
        }
    }
//}
