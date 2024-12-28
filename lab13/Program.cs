using System.Xml.Linq;
using System.Xml;

namespace lab13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Test test1 = new Test(7, true);
            test1.isDone();
            Test test2 = new Test(3, false);
            test2.isDone();
            Test test3 = new Test(4, false);
            test3.isDone();
            Test test4 = new Test(9, true);
            test4.isDone();


            List<Test> list = new List<Test> { test1, test2, test3, test4 };

            CollectionSerializer<Test> cs = new CollectionSerializer<Test>();
            cs.Serialize("list1.json", list);
            cs.Deserialize("list1.json");
            Console.WriteLine();

            JsonSerializer<Test> js = new JsonSerializer<Test>();
            js.Serialize("json.json", test2);
            js.Deserialize("json.json");
            Console.WriteLine();

            XmlSerializer<Test> xml = new XmlSerializer<Test>();
            xml.Serialize("xml.xml", test4 );
            xml.Deserialize("xml.xml");
            Console.WriteLine();

            ///

            XmlDocument xdoc1 = new XmlDocument();
            xdoc1.Load("xml.xml");

            XmlElement? xroot = xdoc1.DocumentElement;

            XmlNodeList? nodes = xroot?.SelectNodes("*");
            foreach (XmlNode node in nodes)
            {
                Console.WriteLine(node.OuterXml);
            }
            XmlNodeList? nodes1 = xroot?.SelectNodes("grades");

            foreach (XmlNode node in nodes1)
            {
                Console.WriteLine(node.OuterXml);
            }

            XDocument xdoc2 = new XDocument();
            XElement test5 = new XElement("test5");
            XElement name = new XElement("name");
            name.Value = "value";
            XAttribute testall = new XAttribute("type", "Type2");
            test5.Add(testall);
            test5.Add(name);

            xdoc2.Add(test5);

            xdoc2.Save("test5.xml");
        }
    }
}