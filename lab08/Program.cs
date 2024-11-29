using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace lab08
{
    internal class Program
    {
        public static void printEventString(string Message)
        {
            Console.WriteLine(Message);
        }
        public static void printEventInt(int age)
        {
            Console.WriteLine(age);
        }
        static void Main(string[] args)
        {
            Boss boss1 = new Boss(24, false);
            Boss boss2 = new Boss(45, true);

            boss1.Upgrade += printEventInt;
            boss1.Turnon += printEventString;
            boss2.Upgrade += printEventInt;
            boss2.Turnon += printEventString;

            boss1.countYears(boss1._years);
            boss1.TurnOn();
            boss2.countYears(boss2._years);
            boss2.TurnOn();

            Func<string, string> deleteComas = text => Regex.Replace(text, @"[^\p{L}\p{N}\s]", ""); //regex101.com
            Func<string, string> makeUpper = text => text.ToUpper();
            Func<string, string> addSymbs = text => text + "сырники....мм.м.м.м.. сырлитка хахахаххаах сырлитка";
            Predicate<string> findF = text => text.Contains('f');
            Action<string> printText = text => Console.WriteLine(text);

            string text1 = "посмотрите агентов времени FFFFff";
            string text2 = deleteComas(text1);
            text2 = makeUpper(text2);
            text2 = addSymbs(text2);
            bool f = findF(text2);
            Console.WriteLine(f);
            printText(text2 + text1);
        }
    }
}