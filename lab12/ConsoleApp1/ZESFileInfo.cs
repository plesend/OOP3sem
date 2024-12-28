using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    static class ZESFileInfo
    {
        public static void PrintFileInfo(string filepath)
        {
            FileInfo fileInfo = new FileInfo(filepath);
            if(fileInfo.Exists)
            {
                Console.WriteLine($"Full path: {fileInfo.DirectoryName}");
                Console.WriteLine($"Total space: {fileInfo.Length}");
                Console.WriteLine($"Full extension: {fileInfo.Extension}");
                Console.WriteLine($"Name: {fileInfo.Name}");
                Console.WriteLine($"Date of birth: {fileInfo.CreationTime}");
                Console.WriteLine($"Date of last changes: {fileInfo.LastWriteTime}");
            }
            Console.WriteLine();
        }
    }
}
