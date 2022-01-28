using System;
using System.IO;
using System.Net;
using System.Text;

namespace browserTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "https://www.naver.com";
            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            //전달할 파라메타
            string sendData = "param1=1&param2=2";

            byte[] buffer;
            buffer = Encoding.Default.GetBytes(sendData);
            request.ContentLength = buffer.Length;

            Stream sendStream = request.GetRequestStream();
            sendStream.Write(buffer, 0, buffer.Length);
            sendStream.Close();

            //System.Diagnostics.Process.Start("https://www.naver.com");
        }
    }
}
