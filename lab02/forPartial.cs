using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab02
{
    public partial class House
    {
        public House(int id, int number, int площадь = 3)
        {
            _number = number;
            _objectCount++;
        }
        static House()
        {
            Console.WriteLine("Статический коструктор");
            _objectCount++;
        }
    }
}
