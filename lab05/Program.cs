using System.Diagnostics;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;

namespace lab05
{
    public interface IExamination
    {
        bool WasPassed(Question question, string context);
        void DoPass();
        string GetExamName();
        List<Question> GetQuestions();
        string ToString();
        void task4();
    }

    public abstract class Trial : IExamination
    {
        public abstract void task4();
        public ExamInfo ExamDetails;

        public abstract void DoPass();

        public bool WasPassed(Question question, string context)
        {
            Console.WriteLine("Ответ от пользователя: " + context);
            Console.WriteLine("Ответ от экзаменатора: " + question.answer);
            return question.answer == context;
        }

        public abstract string GetExamName();
        public abstract List<Question> GetQuestions();

        public virtual string ExamInfo()
        {
            return "Абстрактный класс для всех экзаменов";
        }

        public override string ToString()
        {
            return "ToString";
        }
    }

    public partial class Test : Trial, IExamination
    {
        List<Question> questions;
        public Test(ListOfExams type, string info, int difficulty, List<Question> questions)
        {            
            
            if (difficulty > 10 || difficulty < 1)
            {
                throw new NotValidDifficulty();
            }

            if (type == ListOfExams.none)
            {
                throw new NotValidTypeOfExam();
            }

            if (info == null)
            {
                throw new NotValidInfo();
            }


            ExamDetails = new ExamInfo(type, info, difficulty);
            this.questions = questions;
        }
        void IExamination.task4()
        {
            Console.WriteLine("Метод, вызван в классе Тест");
        }
        public override void task4()
        {
            Console.WriteLine("return");
        }
        public override string ExamInfo() 
        {
            return ExamDetails.ToString();
        }
        public override string GetExamName()
        {
            return ExamDetails.ExamType.ToString();
        }
        public override List<Question> GetQuestions()
        {
            return questions;
        }

        public override string ToString()
        {
            return "Тест: Что-то расскажу про тест";
        }
        public override int GetHashCode()
        {
            return 56;
        }
        public void tryCatch(int input, int input1)
        {
            try
            {
                double divide = input / input1;
            }
            catch (Exception ex) { throw ex; }
        }
    }


    public partial class GradExam : Trial, IExamination
    {
        List<Question> questions;

        public GradExam(ListOfExams type, string info, int difficulty, List<Question> question)
        {

            if (difficulty > 10 || difficulty < 1)
            {
                throw new NotValidDifficulty();
            }

            if (type == ListOfExams.none)
            {
                throw new NotValidTypeOfExam();
            }

            if (info == null)
            {
                throw new NotValidInfo();
            }

            ExamDetails = new ExamInfo(type, info, difficulty);
            this.questions = questions;
        }
        void IExamination.task4()
        {
            Console.WriteLine("Метод, вызван в классе Тест");
        }
        public override void task4()
        {
            Console.WriteLine("Абстрактный метод из базового класса");
        }
        public override string ExamInfo()
        {
            return ExamDetails.ToString() + "\nGradExam: Тут всё или ничего";
        }
        public override string GetExamName()
        {
            return ExamDetails.ExamType.ToString();
        }
        public override List<Question> GetQuestions()
        {
            return  questions;
        }
        public override string ToString()
        {
            return "GradExam: Что-то рассказала про выпускной ехам";
        }
        
    }

    public sealed class Question
    {
        public string? context { get; set; }
        public string? answer { get; set; }

        public Question(string? answer, string? context)
        {
            this.context = context;
            this.answer = answer;
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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(someObj.ExamInfo());
            Console.ResetColor();
            Console.WriteLine(someObj.ToString());
            Console.WriteLine("переопред хешкод: " + someObj.GetHashCode());
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Debug.Assert(5 > 1);
            Console.WriteLine("Введите тип экзамена: ");

            string typeFromCons = Console.ReadLine();
            ListOfExams type = (ListOfExams)Enum.Parse(typeof(ListOfExams), typeFromCons);

            Console.WriteLine("Введите информацию: ");
            string info = Console.ReadLine();

            Console.WriteLine("Введите сложность экзамена: ");
            int difficulty = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите количество вопросов, которые хотите задать: ");
            int questionQuantity = int.Parse(Console.ReadLine());

            List<Question> list = new List<Question>();

            for (int i = 0; i < questionQuantity; i++)
            {
                Console.WriteLine("Введите вопрос: ");
                string context = Console.ReadLine();
                Console.WriteLine("Введите ответ: ");
                string answer = Console.ReadLine();
                Question question = new(answer, context);
                list.Add(question);
            }
            Trial test = new Test(type, info, difficulty, list);
            test.DoPass();
            Console.WriteLine();
            //////
            test.task4();
            ((IExamination)test).task4();
            //////
            Printer printer = new Printer();

            List<Trial> exams = new List<Trial>();
            exams.Add(test);

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

            Session session = new();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Добавляем в контейнер...");
            session.Add(test);
            Console.WriteLine("Удаляем из контейнера...");
            session.Remove(test);
            Console.WriteLine("Но мы его вернем!!");
            session.Add(test);
            session.RemoveByInd(0);
            session.Add(test);
            session.PrintContainer();
            Console.ResetColor();
            test.GetExamName();
            //1
            try
            {
                Trial testException = new Test(ListOfExams.eng, "Информация об экзамене по англу", 16, list);
            }

            catch (NotValidDifficulty exception)
            {
                ExamsException.Handle(exception);
            }
            finally
            {
                Console.WriteLine("Исключения обработаны\n");
            }

            //2
            try
            {
                Trial testException1 = new Test(ListOfExams.none, "Информация об экзамене", 6, list);
            }
            catch (NotValidTypeOfExam exc)
            {
                ExamsException.Handle(exc);
            }
            finally
            {
                Console.WriteLine("Исключения обработаны\n");
            }
            //3
            try
            {
                Trial testException2 = new GradExam(ListOfExams.eng, null, 6, list);
            }
            catch (NotValidInfo exceptionInfo) 
            {
                ExamsException.Handle(exceptionInfo);
            }
            finally
            {
                Console.WriteLine("Исключения обработаны\n");
            }
            //4

            int input = 3;
            int input1 = 0;
            int divide;
            try
            {
                Test testTryCatch = new Test(ListOfExams.eng, "str", 6, list);
                testTryCatch.tryCatch(input, input1);
            }
            catch (DivideByZeroException exZero)
            {
                ExamsException.Handle(exZero);
                Console.WriteLine("Передаю исключение выше по стеку.");
            }
            finally
            {
                Console.WriteLine("Исключения обработаны\n");
            }            
        }
    }
}