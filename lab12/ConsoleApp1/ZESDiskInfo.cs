using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    static class ZESDiskInfo
    {
        public static void PrintDiskInfo()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine($"Drive free space: {drive.AvailableFreeSpace}");
                Console.WriteLine($"Drive file system: {drive.DriveFormat}");

                if(drive.IsReady)
                {
                    Console.WriteLine($"Drive name: {drive.Name}");
                    Console.WriteLine($"AvailableFreeSpace: {drive.AvailableFreeSpace}");
                    Console.WriteLine($"TotalFreeSpace: {drive.TotalFreeSpace}");
                    Console.WriteLine($"VolumeLabel: {drive.VolumeLabel}");
                }
            }
            Console.WriteLine();

        }
    }
}
