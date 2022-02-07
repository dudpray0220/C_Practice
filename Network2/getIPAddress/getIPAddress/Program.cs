using System;
using System.Net;

namespace getIPAddress
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            // 아래는 모두 동일한 IP 주소 표현
            IPAddress ip1 = IPAddress.Parse("192.168.1.13");
            IPAddress ip2 = new IPAddress(new byte[] { 192, 168, 1, 13 });
            IPAddress ip3 = new IPAddress(218212544);
            Console.WriteLine(ip1.ToString() + " / " + ip2.ToString() + " / " + ip3.ToString());

            // 유용한 IPAddress 메서드
            IPAddress ip = IPAddress.Parse("216.58.216.174");
            byte[] ipbytes = ip.GetAddressBytes(); // IP를 바이트 배열로!
            IPAddress ipv6 = ip.MapToIPv6(); // IPv4를 IPv6로 매핑
            Console.WriteLine(ipbytes + " / " + ipv6 + "\n");


            // 호스트 / 도메인명에서 IP 알아내기

            // 인터넷 호스트명 정보 얻기
            IPHostEntry hostEntry = Dns.GetHostEntry("www.naver.com");

            Console.WriteLine(hostEntry.HostName);
            foreach (var item in hostEntry.AddressList)
            {
                Console.WriteLine(item);
            }

            // 로컬 호스트명 정보 얻기
            string hostname = Dns.GetHostName();
            IPHostEntry localhost = Dns.GetHostEntry(hostname);
            Console.WriteLine("\n" + localhost.HostName);


            // IP에서 호스트명 알아내기 (보통 회사내 인트라넷에서는 잘 동작할 것이고, 인터넷 상에서는 DNS 설정에 따라 동작할 수도 있고 하지 않을 수도 있다.)
            //IPAddress ipaddr = IPAddress.Parse("173.194.126.240");
            //IPHostEntry hostEntry1 = Dns.GetHostEntry(ipaddr);
            //Console.WriteLine(hostEntry1.HostName);


            // EndPoint. TCP나 UDP는 IP 주소와 함께 포트번호를 사용한다. 이러한 종단점(EndPoint)을 표현하기 위해 IPEndPoint 클래스를 사용.
            // IPEndPoint는 IP주소와 포트를 받아들인 것으로 ToString() 메서드를 호출하면 "IP주소:포트" 형식으로 문자열을 리턴
            IPAddress ip4 = IPAddress.Parse("127.0.0.1");
            IPEndPoint ep = new IPEndPoint(ip4, 80);
            Console.WriteLine("\n" + ep.ToString());
        }
    }
}
