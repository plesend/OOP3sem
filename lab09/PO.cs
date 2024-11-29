using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab09
{
    public class PO
    {
        SortedList<int, PO> collectionPO;
        public string name { get; set; }
        public int releaseYear { get; set; }
        public string developer {  get; set; }

        public PO(string version, int releaseYear, string developer)
        {
            this.name = version;
            this.releaseYear = releaseYear;
            this.developer = developer;
        }

        public override string ToString()
        {
            return ($"Название - {name}, год релиза - {releaseYear}, разраб - {developer}");
        }
    }
    public class POCollection<T> : IList<T> where T : PO
    {
        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public T this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        SortedList<int, PO> collectionPO = new SortedList<int, PO> (); 

        public void Add(T po)
        {
            collectionPO.Add(po.releaseYear, po);
            Console.WriteLine("ПО добавлено");
        }

        public int IndexOf(T item)
        {
            return collectionPO.IndexOfValue(item);
        }

        public void Insert(int index, T item)
        {
            collectionPO[index] = item;
        }

        public void RemoveAt(int index)
        {
            collectionPO.RemoveAt(index);
        }
        public void Clear()
        {
            collectionPO.Clear();
        }

        public bool Contains(T item)
        {
            return collectionPO.ContainsValue(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotSupportedException();
        }

        public bool Remove(T item)
        {
            return collectionPO.Remove(item.releaseYear);
        }
        public void Remove(int n)
        {
            for (int i = 0; i < n; i++)
            {
                collectionPO.RemoveAt(i);
                Console.WriteLine($"ПО удалено по индексу {i}");
            }
           
        }

        public IEnumerator<PO> GetEnumerator()
        {
            return collectionPO.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            throw new NotSupportedException();
        }
    }
}
