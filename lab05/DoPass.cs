using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab05
{
    public partial class Test : Trial
    {
        public override void DoPass()
        {
            bool passed = false;
            foreach (Question question in GetQuestions())
            {
                Console.WriteLine("Вопрос: " + question.context);
                IExamination exam = this as IExamination;
                Console.WriteLine("Введите ответ: ");
                string answer = Console.ReadLine();
                passed = exam != null && exam.WasPassed(question, answer);
            }

            Console.WriteLine("Тест: " + passed);
        }
    }
    public partial class GradExam : Trial, IExamination
    {
        public override void DoPass()
        {
            bool passed = false;
            foreach (Question question in GetQuestions())
            {
                Console.WriteLine("Вопрос: " + question.context);
                IExamination exam = this as IExamination;
                Console.WriteLine("Введите ответ: ");
                string answer = Console.ReadLine();
                passed = exam != null && exam.WasPassed(question, answer);
            }
            Console.WriteLine("Выпускной экзамен: " + passed);
        }
    }

}
