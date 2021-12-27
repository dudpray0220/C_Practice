using System;
using System.IO;

namespace ReadWriteProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            // 파일 생성 로직
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\readWrite.txt";

            if (!File.Exists(path)) // 파일이 없으면 생성
            {
                FileStream stream = File.Create(path);
                stream.Close();
            }
            else // 있으면 로직돌림
            {
                // 파일 내용 유무 판별
                using (StreamReader reader = new StreamReader(path))
                {
                    string line = reader.ReadLine();
                    if (line == null)
                    {
                        Console.WriteLine("파일에 아무 내용도 없어요 ㅋㅋ");
                        Console.Write("내용을 입력해 주세요 : ");
                    }
                }
                // 파일 내용 입력
                using (StreamWriter writer = new StreamWriter(path))
                {
                    writer.Write(Console.ReadLine());
                }

            }

        }
    }
}
