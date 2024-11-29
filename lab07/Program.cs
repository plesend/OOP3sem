using lab07;
using System.Net.Security;
using System.Runtime.CompilerServices;

namespace lab03
{
    class Program
    {
        static void Main()
        {

            Set<object> set = new Set<object>(new List<object> { 1, 3, 5 });
            Set<Question> question1 = new Set<Question>(new List<Question>());

            question1.AddElem(new Question("вопросик", "ответик"));
            question1.AddElem(new Question("вопросик 1", "ответик 1"));
            question1.Print();

            set.AddElem("аааа мир танков!!!!!!!!!");
            set.AddElem(222);
            set.AddElem(12.4);
            int numsForObj = 345;
            object objOfNums = (object)numsForObj;
            set.AddElem(objOfNums);
            set.AddElem("delete this or fumo will reach you");
            set.Print();

            string path = "D:\\лабораторные работы\\ооп\\lab07\\lab07\\бипки.txt";

            set.SaveToFile(path);
            Set<object> setToRead = new Set<object>(new List<object> { 3, 4, 6 });
            Console.WriteLine("\nИз файла прочитали: ");
            setToRead.ReadFromFile(path);
            setToRead.Print();
            
        }
    }
}