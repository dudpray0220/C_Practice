using System;

namespace parsingTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string savePath = @"C:\Mstation\data\temp\00003_11001_20180725_3333_173017.lock";       // 파일 이름
            Console.WriteLine(savePath);

            string re = savePath.Substring(0, savePath.Length - 5);
            string[] split = re.Split(@"\");
            Console.WriteLine(re);

            //foreach (var item in split)
            //{
            //    Console.WriteLine(item);
            //}

            string[] fName = savePath.Substring(0, savePath.Length - 5).Split(@"\"); // 확장자 .lock 빼기 -> \로 나누기
            Console.WriteLine(fName[fName.Length - 1]);
        }
    }
}
