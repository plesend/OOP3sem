using System.Reflection.Emit;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filepath = @"D:\лабораторные\ооп\lab12\ConsoleApp1\logFile.json";
            ZESDiskInfo.PrintDiskInfo();
            ZESFileInfo.PrintFileInfo(filepath);
            ZESDirInfo.PrintDirInfo(@"D:\лабораторные\ооп\lab12\ConsoleApp1");
            ZESFileManager.TaskC(@"D:\лабораторные\ооп\lab12\ConsoleApp1\tozip\tozip.rar",
                @"D:\лабораторные\ооп\lab12\ConsoleApp1\archive",
                @"D:\лабораторные\ооп\lab12");
            ZESFileManager.GetFoldersAndFiles(@"D:\лабораторные\ооп\lab12\makeFoldersHere", @"D:\лабораторные\ооп\lab12\stillDontKnow.txt");
            ZESFileManager.TaskB(@"D:\лабораторные\ооп\lab12\makeFoldersHere",
                @"D:\лабораторные\ооп\lab12\ConsoleApp1", "*.json");
            ZESLog.SearchByTimeRange(DateTime.Now.AddHours(-1), DateTime.Now);
            ZESLog.ReadLog();
        }
    }
}