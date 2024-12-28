using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
//using System.Runtime.Serialization.Formatters.Soap

namespace lab13
{
    interface ISerializer<T>
    {
        public void Serialize(string path, T obj);
        public void Deserialize(string path);
    }
    public class BinarySerializer<T> : ISerializer<T>
    {
        string path;
        public BinarySerializer(string path) { this.path = path; }

        public void Serialize(string path, T obj)
        {
            BinaryFormatter bin = new BinaryFormatter();
            using (Stream writer = new FileStream(path, FileMode.Create))
            {
                bin.Serialize(writer, obj);
                Console.WriteLine($"serialized by bin in {path}");
            }
        }

        public void Deserialize(string path)
        {
            BinaryFormatter bin = new BinaryFormatter();
            using (Stream writer = new FileStream(path, FileMode.Open))
            {
                var obj = bin.Deserialize(writer);
                Console.WriteLine($"{obj.ToString()}");
            }
        }
    }

    public class JsonSerializer<T> : ISerializer<T>
    {
        public void Serialize(string path, T obj)
        {
            using (Stream writer = new FileStream(path, FileMode.Create))
            {
                System.Text.Json.JsonSerializer.Serialize(writer, obj);
                Console.WriteLine("json serializer");
            }
        }
        public void Deserialize(string path)
        {
            using (Stream writer = new FileStream(path, FileMode.Open))
            {
                var obj = System.Text.Json.JsonSerializer.Deserialize<T>(writer);
                Console.WriteLine(obj.ToString());
            }
        }        
    }

    //public class SoapSerializer<T> : ISerializer<T>
    //{
    //    public void Serialize(string path, T obj)
    //    {
    //        SoapFormatter sp = new SoapFormatter();
    //        using (Stream writer = new FileStream(path, FileMode.Create))
    //        {
    //            sp.Serialize(writer);   
    //        }
    //    }
    //    public void Deserialize(string path)
    //    {
    //        SoapFormatter sp = new SoapFormatter();
    //        using (Stream writer = new FileStream(path, FileMode.Open))
    //        {
    //            var obj = (object)sp.Deserialize(writer);
    //            Console.WriteLine(obj.ToString());
    //        }
    //    }
    //}

    public class XmlSerializer<T> : ISerializer<T> where T : Trial
    {
        public void Serialize(string path, T obj) 
        {
            Type type = obj.GetType();

            XmlSerializer xmlSerializer = new XmlSerializer(type);
            using (Stream writer = new FileStream(path, FileMode.Create))
            {
                xmlSerializer.Serialize(writer, obj);
                Console.WriteLine("xml serializer");
            }
        }
        public void Deserialize(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (FileStream writer = new FileStream(path, FileMode.Open))
            {
                T? ship = xmlSerializer.Deserialize(writer) as T;
                Console.WriteLine(ship.ToString());
            }
        }        
    }
}
