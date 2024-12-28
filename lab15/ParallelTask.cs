using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab15
{
    public class ParallelTask
    {
        public static void CyclesUpgrade()
        {
            int n = 1000000;
            int[] array = new int[n];

            Random r = new Random();
            
            void FillArray(int n)
            {
                array[n] = r.Next();
            }

            Stopwatch sw = new Stopwatch();
            sw.Start();

            Parallel.For(0, n, FillArray);

            Console.WriteLine($"Time of Parallel.For: {sw.Elapsed}");

            sw.Start();
            for(int i = 0; i < n; i++)
            {
                array[i] = r.Next();
            }
            Console.WriteLine($"Time of simple cycle for: {sw.Elapsed}");
        }
    }
}
