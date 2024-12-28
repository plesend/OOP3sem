using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab14
{
    public class Processes
    {
        public static void ShowProcesses()
        {
            try
            {
                var processes = Process.GetProcesses();
                foreach (var process in processes)
                {
                    Console.WriteLine($"Id: {process.Id}");
                    Console.WriteLine($"Config details: {process.ProcessName}");
                    Console.WriteLine($"Process priority: {process.BasePriority}");
                    Console.WriteLine($"Time of launching: {process.StartTime}");
                    Console.WriteLine($"Current state: {process.Responding}");
                    Console.WriteLine($"Time of working: {process.TotalProcessorTime}");
                    Console.WriteLine($"Time of processor: {process.UserProcessorTime}");
                }
                Console.WriteLine($"Processes count : {processes.Count()}");
            }
            catch
            {

            }
        }
        public static void ShowDomain()
        {
            AppDomain domain = AppDomain.CurrentDomain;
            Console.WriteLine("=== Current Domain Info ===");
            Console.WriteLine($"name: {domain.FriendlyName}");
            Console.WriteLine($"Config details: {domain.SetupInformation}");
            var assemblies = domain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                Console.WriteLine(assembly.FullName);
            }
        }
    }
}
