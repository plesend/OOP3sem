using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab05
{
    public class Session 
    {
        public List<Trial> trials { get; set; }
        public Session()
        {
            trials = new List<Trial>();
        }
        
        public void Add (Trial trial) { trials.Add(trial); }
        public void Remove (Trial trial) { trials.Remove(trial); }
        public void RemoveByInd (int index)
        {
            trials.RemoveAt(index);
        }
        public Trial GetByInd(int index)
        {
            return trials[index];   
        }
        public void PrintContainer()
        {
            {
                Console.WriteLine("Список экзаменов:");
                foreach (var trial in trials)
                {
                    Console.WriteLine(trial.ExamInfo());
                }
            }
        }
    }
}
