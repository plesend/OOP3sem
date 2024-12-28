using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    static class ZESDirInfo
    {
        public static void PrintDirInfo(string dir)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(dir);
            if(dirInfo.Exists )
            {
                Console.WriteLine($"Counted files in dir: {dirInfo.GetFiles().Count()}");
                Console.WriteLine($"Time of creation: {dirInfo.CreationTime}");
                Console.WriteLine($"Amnount of dirs: {dirInfo.GetDirectories().Count()}");
                Console.WriteLine($"Parent: {dirInfo.Parent}");
            }
            Console.WriteLine();
        }
        
    }
}
