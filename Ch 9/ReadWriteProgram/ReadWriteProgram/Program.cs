using System;
using System.IO;

namespace ReadWriteProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            // 파일생성 
            //string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\readWrite.txt";
            //if (!File.Exists(path)) // 파일이 없으면 파일 생성
            //{
            //    FileStream stream = File.Create(path);
            //    stream.Close();
            //}

            // 경로 변수
            string path = @"C:\test\readWrite.txt";

            using (StreamReader reader = new StreamReader(path))
            using (StreamWriter writer = new StreamWriter(path))
            {
                string line = reader.ReadLine();
                if (line == null) // 내용이 없으면
                {
                    Console.WriteLine("파일에 아무 내용도 없어요 ㅋㅋ");
                    Console.Write("저장할 문자열을 입력해주세요 : ");
                    writer.Write(Console.ReadLine());
                    Console.WriteLine("저장완료!");
                }
                else // 내용이 있으면
                {
                    Console.Write("이전에 입력한 내용 : ");
                    while (line != null) // 반복문으로 여러 줄 읽기
                    {
                        Console.Write(line + ", ");
                    }
                    Console.Write("저장할 문자열을 입력해주세요 : ");
                    writer.Write(Console.ReadLine());
                    Console.WriteLine("저장완료!");
                }
            }
        }
    }
}
