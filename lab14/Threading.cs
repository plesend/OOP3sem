using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab14
{
    public class Threading
    {
        public static bool firstThreadIsOn = true;
        void ShowMainStats()
        {
            Thread thread = Thread.CurrentThread;

            Console.WriteLine($"Name: {thread.Name}");
            Console.WriteLine($"Id: {thread.ManagedThreadId}");
            Console.WriteLine($"Priority: {thread.Priority}");
            Console.WriteLine($"Some other stats: {thread.ThreadState}");
        }

        public static void NumsThread(int n)
        {
            Thread thread = new Thread(NumsThreadOutput);
            thread.Name = "task3";
            thread.Start();

            void NumsThreadOutput()
            {
                List<int> numbers = new List<int>();
                for (int i = 2; i < n; i++)
                {
                    numbers.Add(i);
                }
                for (int i = 0; i < numbers.Count; i++)
                {
                    for (int j = 2; j < n; j++)
                    {
                        numbers.Remove(numbers[i] * j);
                    }
                }
                Console.WriteLine(string.Join(",", numbers));
            }
        }
        public static void MakeThread(int n)
        {
            Thread second = new Thread(PrintNonEven);
            Thread first = new Thread(PrintEven);

            first.Priority = ThreadPriority.Lowest;
            second.Priority = ThreadPriority.Highest;
            first.Start();
            second.Start();


            // действия, выполняемые в главном потоке
            void PrintEven()
            {
                second.Join();
                for (int i = 0; i <= n; i += 2)
                {
                    Console.WriteLine($"Четный поток: {i}\n");
                    Thread.Sleep(300);
                }
            }

            // действия, выполняемые во втором потокке
            void PrintNonEven()
            {
                for (int i = 1; i <= n; i += 2)
                {
                    Console.WriteLine($"Нечетный поток: {i}\n");
                    Thread.Sleep(300);
                }

            }
        }

        public static void StartTimerTask()
        {
            Timer timer = new Timer(TimerCallback, null, 0, 1000); // Таймер с интервалом в 1 секунду

            void TimerCallback(object state)
            {
                Console.WriteLine($"Current time: {DateTime.Now}");
            }
        }
    }
}
