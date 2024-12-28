using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    static class ZESFileManager
    {
        public static void GetFoldersAndFiles(string dirpath, string filename)
        {
            if (!Directory.Exists(dirpath))
            {
                Console.WriteLine("There are no dirs like that.");
                return;
            }

            DirectoryInfo dirinfo = new DirectoryInfo(dirpath);
            DirectoryInfo subDir = dirinfo.CreateSubdirectory("new dir");
            string filepath = Path.Combine(subDir.FullName, "dirinfo.txt");
            using (StreamWriter writer = new StreamWriter(filepath))
            {
                writer.WriteLine("List of files: ");
                foreach (var file in dirinfo.GetFiles())
                {
                    writer.WriteLine(file.Name);
                }
                writer.WriteLine("List of dirs: ");
                foreach (var folder in dirinfo.GetDirectories())
                {
                    writer.WriteLine(folder.Name);
                }
            }
            string copyfilepath = Path.Combine(subDir.FullName, "copydirinfo.txt");
            File.Copy(filepath, copyfilepath, true);

            if (File.Exists(Path.Combine(subDir.FullName, filename)))
            {
                File.Delete(Path.Combine(subDir.FullName, filename));
            }

            File.Move(copyfilepath, Path.Combine(subDir.FullName, filename));
            File.Delete(filepath);

            ZESLog.WriteLog(filename, filepath, "GetFoldersAndFiles");

        }
        public static void TaskB(string destination, string source, string extension)
        {
            if (!Directory.Exists(destination))
            {
                Console.WriteLine("No destination");
                return;
            }
            if (!Directory.Exists(source))
            {
                Console.WriteLine("No source");
                return;
            }

            DirectoryInfo dirinfo = new DirectoryInfo(destination);
            DirectoryInfo subdir = dirinfo.CreateSubdirectory("ZESFiles");

            foreach (string filepath in Directory.GetFiles(source, extension))
            {
                string filename = Path.GetFileName(filepath);
                string copyTo = Path.Combine(subdir.FullName, filename);
                File.Copy(filepath, copyTo, true);
            }
            ZESLog.WriteLog("ZESFiles", subdir.FullName, "TaskB");
        }
        public static void TaskC(string destination, string source, string toExtract)
        {
            if (!Directory.Exists(source))
            {
                Console.WriteLine("исходная папка не найдена!!");
                return;
            }
            if (!Directory.Exists(toExtract))
            {
                Console.WriteLine("папка для разархивирования не найдена");
                return;
            }
            if (File.Exists(destination))
            {
                File.Delete(destination);
            }

            ZipFile.CreateFromDirectory(source, destination);
            ZipFile.ExtractToDirectory(destination, toExtract);
            ZESLog.WriteLog("test.zip", source, "TaskC");

        }
    }
}

