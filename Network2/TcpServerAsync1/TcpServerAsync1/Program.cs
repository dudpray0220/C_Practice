using System.Net.Sockets;
using System.Net;
using System;
using System.Threading.Tasks;
using System.Text;

namespace TcpServerAsync1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AsyncEchoServer().Wait();
        }
    
        // 비동기 메서드
        async static Task AsyncEchoServer()
        {
            TcpListener listener = new TcpListener(IPAddress.Any, 7000);
            listener.Start();   
            while (true)
            {
                // 비동기 Accept
                TcpClient tc = await listener.AcceptTcpClientAsync().ConfigureAwait(false);
                // 새 쓰레드에서 처리
                Task.Factory.StartNew(AsyncTcpProcess, tc);
            }
        }

        async static void AsyncTcpProcess (object o)
        {
            TcpClient tc = (TcpClient)o;

            int Max_Size = 1024;
            NetworkStream stream = tc.GetStream();

            // 비동기 수신
            var buff = new byte[Max_Size];
            var nbytes = await stream.ReadAsync(buff, 0, buff.Length).ConfigureAwait(false);    
            if (nbytes > 0)
            {
                string msg = Encoding.ASCII.GetString(buff, 0, buff.Length);
                Console.WriteLine("수신 : " + msg + " at " + DateTime.Now);

                // 비동기 송신
                await stream.WriteAsync(buff, 0, nbytes).ConfigureAwait(false);
            }

            stream.Close();
            tc.Close();
        }
    }
}
