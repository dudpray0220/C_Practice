using System;
using System.IO;

namespace FileIO_Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String folderName = @"C:\Mstation\data\temp\";
            string newFolderName = @"C:\Mstation\data\snd\";
            DirectoryInfo directory = new DirectoryInfo(folderName);

            foreach (FileInfo file in directory.GetFiles())
            {
                if (file.Extension.ToLower().CompareTo(".lock") == 0)
                {
                    string fileNameOnly = file.Name.Substring(0, file.Name.Length - 5) + ".snd";     // 확장자만 빼기
                    String fullFileName = file.FullName;

                    Console.WriteLine(fullFileName);
                    Console.WriteLine(fileNameOnly);
                    Console.WriteLine(newFolderName + fileNameOnly);

                    File.Move(fullFileName, newFolderName + fileNameOnly);
                }
            }
        }
    }
}
