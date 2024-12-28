namespace lab14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Processes.ShowProcesses();
            Processes.ShowDomain();
            Threading.StartTimerTask();
            Console.WriteLine();
            Threading.NumsThread(20);
            Threading.MakeThread(20);
            Thread.Sleep(1000);
        }
    }
}