using System;

namespace _3.Extract_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] filePath = Console.ReadLine().Split("\\");

            string[] token = filePath[filePath.Length - 1].Split(".");
            string fileName = token[0];
            string fileExtension = token[1];
            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {fileExtension}");

        }
    }
}
