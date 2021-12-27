using System;
using System.IO;

namespace StreamWriterPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamWriter writer = new StreamWriter(@"c:\test\test.txt"))
            {
                writer.WriteLine("Hi Hello");
                writer.WriteLine("StreamWriter 클래스를 사용");
                writer.WriteLine("This is C#");

                for (int i = 0; i < 10; i++)
                {
                    writer.WriteLine("for loop - " + i);
                }
            }
            //Console.WriteLine(File.ReadAllText(@"c:\test\test.txt"));

            using (StreamReader reader = new StreamReader(@"c:\test\test.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
    }
}
