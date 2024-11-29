using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab07
{
    public class Question
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
            return $"Question: {context ?? "No context provided\n"}";
        }
    }
}
