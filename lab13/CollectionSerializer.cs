using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace lab13
{
    public class CollectionSerializer<T> : IEnumerable<T>
    {
        private List<T> items;
        public CollectionSerializer() { items = new List<T>(); }
        public void Add(T item)
        {
            items.Add(item);
        }
        public void Serialize(string filename, List<T> obj)
        {
            string serializer = JsonSerializer.Serialize(obj, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filename, serializer);
            Console.WriteLine("collection serializer");
        }
        public void Deserialize(string filename)
        {
            string jsontext = File.ReadAllText(filename);
            List<T> list = JsonSerializer.Deserialize<List<T>>(jsontext);
            foreach (var ship in list)
            {
                Console.WriteLine(ship.ToString());
            }
        }
        public void Clear() { items.Clear(); }
        public void Remove(T item) { items.Remove(item); } 
        public T Get(int index) 
        {
            if (index < 0 || index >= items.Count)
                throw new ArgumentOutOfRangeException(nameof(index), "There is no index like that");
            return items[index]; 
        }
        public IEnumerator<T> GetEnumerator()
        {
            return items.GetEnumerator();
        }
        public int Count { get { return items.Count; } }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
