using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab13
{
    [Serializable]
    public abstract class Trial
    {
        public abstract void isDone();
    }
    [Serializable]
    public class Test : Trial
    {
        public bool passed {  get; set; }
        public int grade { get; set; }
        public Test(int grade, bool passed)
        {
            this.grade = grade;
            this.passed = passed;
        }
        public Test()
        {

        }

        public override void isDone()
        {
            if (passed == true)
            {
                Console.WriteLine("Exam has been successfully passed.");
            }
            else
            {
                Console.WriteLine("Still need time to get some knowledge huh?");
            }
        }
        public override string ToString()
        {
            return $"grade = {grade}, exam is {passed}";
        }
    }
}
