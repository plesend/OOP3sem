using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab05
{
    public class Controller
    {
        private Session session { get; set; }
        public List<IExamination> GetByExamName(string name)
        {
            List<IExamination> result = new List<IExamination>();
            foreach (IExamination iexam in session.trials)
            {
                if (iexam.GetExamName() == name)
                {
                    result.Add(iexam);
                }
            }            
            return result;
        }
        public List<IExamination> GetByQuestion(int count)
        {
            List<IExamination> result = new List<IExamination>();
            foreach (IExamination iexam in session.trials)
            {
                if (iexam.GetQuestions().Count() == count)
                {
                    result.Add(iexam);
                }
            }
            return result;
        }
        public int GetAllIExaminations()
        {
            return session.trials.Count();
        }
    }
}
