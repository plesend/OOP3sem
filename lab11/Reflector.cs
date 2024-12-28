using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data;

namespace lab11
{

    public static class Reflector
    {
        public static object Create(object objName, object[] parm)
        {
            Type type = objName.GetType();
            var filledObj = Activator.CreateInstance(type, parm);
            return filledObj;
        }
        public static void GetName(string className)
        {
            Type type = Type.GetType(className);
            Console.WriteLine("The version of the currently executing assembly is: {0}",
            type.Assembly.GetName().Version);
        }
        public static void FindPublicConstructor(string className) 
        {
            Type type = Type.GetType(className);
            ConstructorInfo[] tmp = type.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
            if (tmp == null || tmp.Length < 1)
            {
                Console.WriteLine("Public constructors: false");
            } 
            else
            {
                Console.WriteLine("Public constructors: true");
            }
           
        }
        public static IEnumerable<string> GetPublicMethods(string className)
        {
            Type type = Type.GetType(className);
            MethodInfo[] tmp = type.GetMethods(BindingFlags.Public | BindingFlags.Instance);
            var selectedMethods = from m in tmp select m.Name;
            return selectedMethods;
        }
        
        public static void PrintPublicMethods(string classname)
        {
            Console.WriteLine("\nPublic methods: ");
            foreach (var method in GetPublicMethods(classname))
            {
                Console.WriteLine(method);
            }
        }

        public static IEnumerable<string> GetPropertiesAndFields(string className)
        {
            Type type = Type.GetType(className);
            if (type == null)
            {
                throw new ArgumentException($"Class with name '{className}' not found.");
            }
            PropertyInfo[] tmp = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            FieldInfo[] tmp2 = type.GetFields(BindingFlags.Public | BindingFlags.Instance);
            foreach (var property in tmp)
            {
                yield return property.Name;
            }
            foreach (var field in tmp2)
            {
                yield return field.Name;
            }
        }
        public static void PrintProperties(string classname)
        {
            Console.WriteLine("\nproperties: ");
            foreach (var member in GetPropertiesAndFields(classname))
            {
                Console.WriteLine(member);
            }
        }

        public static IEnumerable<string> GetInterfaces(string className)
        {
            Type type = Type.GetType(className);
            List<string> interfacesList = new List<string>();
            var interfaces = type.GetInterfaces();
            
            foreach(var inter in interfaces)
            {
                interfacesList.Add(inter.Name);
            }
            return interfacesList;
        }

        public static void PrintInterfaces(string classname)
        {
            Console.WriteLine("\ninterfaces: ");
            foreach (var member in GetInterfaces(classname))
            {
                Console.WriteLine(member);
            }
        }

        public static IEnumerable<string> GetMothodsParam(string classname, string parameterTypeName)
        {
            Type type = Type.GetType(classname);
            Type parameterType = Type.GetType(parameterTypeName);
            if (parameterType == null)
            {
                throw new ArgumentException($"Parameter type '{parameterTypeName}' not found.");
            }

            MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

            foreach (var method in methods)
            {
                ParameterInfo[] parameters = method.GetParameters();
                if (parameters.Any(param => param.ParameterType == parameterType))
                {
                    yield return method.Name;
                }
            }
        }

        public static void PrintMethodsByParam(string classname, string type)
        {
            Console.WriteLine("\nmethods by param: ");
            foreach (var member in GetMothodsParam(classname, type))
            {
                Console.WriteLine(member);
            }
        }
        public static void Invoke(object obj, string methodName, string filePath)
        {
            Type type = obj.GetType();
            MethodInfo method = type.GetMethod(methodName);
            if (method == null)
            {
                throw new ArgumentException($"Method '{methodName}' not found in class '{type.Name}'.");
            }

            ParameterInfo[] parameters = method.GetParameters();
            object[] paramValues;

            if (File.Exists(filePath))
            {
                string[] fileContent = File.ReadAllLines(filePath);
                paramValues = fileContent.Select((line, index) =>
                {
                    if (index >= parameters.Length)
                        return null;

                    var parameterType = parameters[index].ParameterType;
                    return Convert.ChangeType(line, parameterType);
                }).ToArray();
            }
            else
            {
                Console.WriteLine($"File not found, generating default values for method parameters.");

                paramValues = parameters.Select(param =>
                {
                    Type paramType = param.ParameterType;

                    if (paramType == typeof(int)) return 0;
                    if (paramType == typeof(string)) return string.Empty;
                    if (paramType == typeof(double)) return 0.0;
                    if (paramType == typeof(bool)) return false;

                    return Activator.CreateInstance(paramType);
                }).ToArray();
            }

            method.Invoke(obj, paramValues);
        }
    }
    public interface IBook
    {
        void PrintReview();
    }
    public class Book : IBook
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public Book(string Name, string Title, string Description)
        {
            this.Name = Name;
            this.Author = Title;
            this.Description = Description;
        }
        public int MethodExample(int param)
        {
            Console.WriteLine("Standart public method");
            return param;
        }

        public void PrintReview()
        {
            Console.WriteLine("Эта книга крутая");
        }

        public override string ToString()
        {
            return $"{Name} by {Author}: {Description}";
        }
    }
}
