using System;
using System.Xml.Linq;
using System.Linq;

namespace xml01
{
    class Program
    {
        class Weather
        {
            public string Hour { get; set; }
            public string Day { get; set; }
            public string Temp { get; set; }
            public string WdKor { get; set; }
            public string WfKor { get; set; }
            public string Tmn { get; set; }
            public string Tmx { get; set; }
        }
        static void Main(string[] args)
        {
            string url = "http://www.kma.go.kr/wid/queryDFSRSS.jsp?zone=1150061500";
            XElement xElement = XElement.Load(url); // 특정 url에서 XML 가져오기
            var xmlQuery = from item in xElement.Descendants("data") // XML에서 data 태그를 모두 선택!
                           select new Weather()     // 모델 클래스 생성
                           {
                               Hour = item.Element("hour").Value,
                               Day = item.Element("day").Value,
                               Temp = item.Element("temp").Value,
                               WdKor = item.Element("wdKor").Value,
                               WfKor = item.Element("wfKor").Value,
                               Tmn = item.Element("tmn").Value,
                               Tmx = item.Element("tmx").Value,
                           };

            foreach (var item in xmlQuery)
            {
                Console.Write(item.Hour + "\t");
                Console.Write(item.Day + "\t");
                Console.Write(item.Temp + "\t");
                Console.Write(item.WdKor + "\t");
                Console.Write(item.WfKor + "\t");
                Console.Write(item.Tmn + "\t");
                Console.Write(item.Tmx + "\t");
                Console.WriteLine();
            }
        }
    }
}
