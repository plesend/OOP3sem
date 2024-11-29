using System.Net.Security;
using System.Runtime.CompilerServices;

namespace lab03
{
    public class Set
    {
        public List<int> _elements;
        private Production _production;
        private Developer _developer;
        private static Random random = new Random();
        public Set(IEnumerable<int> elements)
        {
            _elements = new List<int>(elements);
            _developer = new Developer();
        }

        //добавление случайного числа
        public static Set operator ++(Set set)
        {
            set._elements.Add(random.Next(100));
            return set;
        }
        //объединение множест 
        public static Set operator +(Set set1, Set set2) 
        {
            return new Set(set1._elements.Union(set2._elements));
        }
        //сравнение множеств 
        public static bool operator <=(Set set1, Set set2)
        {
            return set1._elements[0] <= set2._elements[0];
        }
        //для симметрии
        public static bool operator >=(Set set1, Set set2)
        {
            return set1._elements[0] >= set2._elements[0];
        }
        public static implicit operator int(Set set)
        {
            return set._elements.Count;
        }
        //доступ к элементу в заданной позиции %
        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= _elements.Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "Ошибка, слишком много");
                }
                return _elements.ElementAt(index);
            }
        }
        public void Print()
        {
            for (int i = 0; i < _elements.Count; i++)
            {
                Console.Write($"{_elements[i]} ");
            }
        }

        public class Production
        {
            private int _ID;

            public int ID { get { return _ID; } set { _ID = value; } }
            public Production()
            {
                _ID = ID;
            }
        }
        public class Developer
        {
            public Developer()
            {
                _fio = "Вкармашкин";
                _idishnik = 234;
                _department = "мультяшкин";
            }
            private string _fio;
            private int _idishnik;
            private string _department;

            public string workerFio { get { return _fio; } set { _fio = value; } }
            public int workerID { get { return _idishnik; } set { _idishnik = value; } }
            public string workerDepartment {  get { return _department; } set { _department = value; } }
        }
    }
    class Program
    {
        static void Main()
        {
            Set set1 = new Set(new List<int> { 1, 2, 3 });
            Set set2 = new Set(new List<int> { 4, 5, 6 });

            Console.WriteLine("Первый: ");
            set1.Print();
            Console.WriteLine("\nВторой: ");
            set2.Print();
            Console.WriteLine();
            set1++;
            Console.WriteLine("После использования ++:");
            set1.Print();
            Console.WriteLine();
            Set unitedSet = set1 + set2;
            Console.WriteLine("Псоле использования +: ");
            unitedSet.Print();
            Console.WriteLine("\nПосле set1 <= set2: " + (set1 <= set2));
            int set1Size = set1;
            Console.WriteLine("Мощность множества: " + set1Size);
            Console.WriteLine("Доступ к элементу в заданной позиции: " + set1[0]);

            Console.WriteLine("Нашли сумму: " + set1.findSum());

            Console.WriteLine("упорядочены?: " + set2.pepepppeppeep());
            string text = "my unfinished symphony";
            Console.WriteLine(text.Encrypt());
        }
    }
}