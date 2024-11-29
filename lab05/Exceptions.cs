using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab05
{
    public class ExamsException
    {
        public static void Handle (Exception exception) 
        {
            if (exception is NotValidElement notValidElem) { Console.WriteLine($"Тип ошибки {notValidElem.Type}"); }
            Console.WriteLine($"Исключение : {exception.Message}");
            Console.WriteLine($"Исключение вызвано в методе: {exception.TargetSite}");
        }
    }

    public class NotValidElement : Exception 
    {
        public readonly string Type = "Not Valid Input";
        public NotValidElement() { }
        public NotValidElement(string message) : base(message) { }
    }

    public class NotValidTypeOfExam : NotValidElement 
    {
        public NotValidTypeOfExam() { }
        public NotValidTypeOfExam(string message) : base(message) { }
    }

    public class NotValidDifficulty : NotValidElement 
    {
        public NotValidDifficulty() { }
        public NotValidDifficulty(string message) : base(message) { }
    }

    public class NotValidInfo : NotValidElement
    {
        public NotValidInfo() { }
        public NotValidInfo(string message) : base(message) { } 
    }
}
