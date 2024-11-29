using System.Runtime.Serialization;

namespace lab04
{
    public interface IExamination
    {
        bool WasPassed(string context);
        void DoPass(string questionToAsk);
        string ToString();
    }

    public abstract class Trial : IExamination
    {
        public abstract void DoPass(string questionToAsk);

        public bool WasPassed(string context)
        {
            return context.Contains("is");
        }

        public virtual string ExamInfo()
        {
            return "Абстрактный класс для всех экзаменов";
        }

        public override string ToString()
        {
            return "Переопределили тустринг";
        }
    }

    public class Test : Trial
    {
        public override void DoPass(string context)
        {
            Question question = new Question(context);

            Console.WriteLine(question);
            Console.WriteLine("Пожалуйста, введите ответ: ");

            IExamination exam = this as IExamination;
            bool passed = exam != null && exam.WasPassed(Console.ReadLine());

            Console.WriteLine("Тест: " + passed);
        }

        public override string ExamInfo()
        {
            return "Тест: это тест, часть испытания";
        }

        public override string ToString()
        {
            return "Тест: Что-то расскажу про тест";
        }
    }

    public class GradExam : Trial, IExamination
    {
        public override void DoPass(string context)
        {
            Question question = new Question(context);

            Console.WriteLine(question);
            Console.WriteLine("Пожалуйста, введите ответ: ");

            IExamination exam = this as IExamination;
            bool passed = exam != null && exam.WasPassed(Console.ReadLine());
            if (passed)
            {
                Console.WriteLine("Вы набрали 100 баллов");
            }
            else { Console.WriteLine("Вы не набрали 100 баллов!!!!!!!!!!!!!"); }
        }

        public override string ExamInfo()
        {
            return "GradExam: Тут всё или ничего";
        }

        public override string ToString()
        {
            return "GradExam: Что-то рассказала про выпускной ехам";
        }
        public override int GetHashCode()
        {
            return 56;
        }
    }

    public sealed class Question
    {
        string? context { get; set; }

        public Question(string? context)
        {
            this.context = context;
        }
        public override string ToString()
        {
            return $"Question: {context ?? "No context provided"}";
        }
    }

    public class Printer
    {
        public void IAmPrinting(Trial someObj)
        {
            Console.WriteLine("Type of object: " + someObj.GetType().Name);
            Console.WriteLine(someObj.ExamInfo());
            Console.WriteLine(someObj.ToString());
            Console.WriteLine("переопред хешкод: " + someObj.GetHashCode());
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("В ответ запишите слово, которое подойдёт по смыслу.");
            Trial test = new Test();
            test.DoPass("Weed __ smokeable");
            Console.WriteLine();
            Trial gradExam = new GradExam();

            gradExam.DoPass("Grass __ green");
            Console.WriteLine();

            Printer printer = new Printer();

            Trial[] exams = { test, gradExam };
            foreach (var exam in exams)
            {
                printer.IAmPrinting(exam);
                if (exam is Test)
                {
                    Console.WriteLine("Это тест");
                }
                else if (exam is GradExam)
                {
                    Console.WriteLine("Это выпускной ехам");
                }
                Console.WriteLine();
            }
            GradExam x = test as GradExam;
            if (x != null)
            {
                Console.WriteLine("Это de");
            }
        }
    }
}