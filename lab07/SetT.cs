using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab07
{
    public interface ILab07<T>
    {
        void AddElem(T a);
        void RemoveElem(T a);
        T ViewElem(int id);
    }
    public class Set<T> : ILab07<T> where T : class
    {
        public List<T> _elements;

        private Production _production;
        private Developer _developer;
        public Set(List<T> elements)
        {
            _elements = elements;
            _developer = new Developer();
        }
        public void Print()
        {
            for (int i = 0; i < _elements.Count; i++)
            {
                Console.Write($"{_elements[i]} ");
            }
        }
        public void AddElem(T elem)
        {
            try
            {
                _elements.Add( elem );
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("хорошо поработал Add гг вп");
            }
        }
        public void RemoveElem(T elem)
        {
            try
            {
                _elements.Remove(elem);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("хорошо поработал Remove гг вп");
            }
        }
        
        public T ViewElem(int ind)
        {
            return _elements[ind];
        }
        public void SaveToFile(string path)
        {
            try
            {
                using var writer = new StreamWriter(path);
                foreach (var symb in _elements)
                {
                    writer.Write(symb.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void ReadFromFile(string path)
        {
            using var reader = new StreamReader(path);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] elements = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in elements)
                {
                    var value = (T)Convert.ChangeType(item, typeof(T));
                    _elements.Add(value);
                }
            }
        }
        //объединение множест 
        public static Set<T> operator +(Set<T> set1, Set<T> set2)
        {
            return new Set<T>((dynamic)set1._elements.Union(set2._elements));
        }
        //сравнение множеств 
        public static bool operator <=(Set<T> set1, Set<T> set2)
        {
            return (dynamic)set1._elements[0] <= (dynamic)set2._elements[0];
        }
        //для симметрии
        public static bool operator >=(Set<T> set1, Set<T> set2)
        {
            return (dynamic)set1._elements[0] >= (dynamic)set2._elements[0];
        }
        public static implicit operator int(Set<T> set)
        {
            return set._elements.Count;
        }
        //доступ к элементу в заданной позиции %
        public T this[int index]
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
            public string workerDepartment { get { return _department; } set { _department = value; } }
        }
    }
}
