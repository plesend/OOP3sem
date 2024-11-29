using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab05
{
    public enum ListOfExams
    {
        none,
        eng,
        math,
    }

    public struct ExamInfo
    {
        public ListOfExams ExamType { get; set; }
        public string Name { get; set; }
        public int Difficulty { get; set; }

        public ExamInfo(ListOfExams examtype, string name, int difficulty)
        {
            ExamType = examtype;
            Name = name;
            Difficulty = difficulty;
        }
        public override string ToString()
        {
            return $"{Name}, {ExamType}, сложность - {Difficulty}";
        }
    }
}
