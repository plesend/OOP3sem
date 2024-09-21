using System.Text;

namespace lab01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            sbyte one = Convert.ToSByte(Console.ReadLine());
            Console.WriteLine($"sbyte: {one}");

            byte two = Convert.ToByte(Console.ReadLine());
            Console.WriteLine($"byte: {two}");

            short three = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine($"short: {three}");

            ushort four = Convert.ToUInt16(Console.ReadLine());
            Console.WriteLine($"ushort: {four}");

            int five = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"int: {five}");

            uint six = Convert.ToUInt32(Console.ReadLine());
            Console.WriteLine($"uint: {six}");

            long seven = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine($"long: {seven}");

            ulong eight = Convert.ToUInt64(Console.ReadLine());
            Console.WriteLine($"ulong: {eight}");

            char nine = Convert.ToChar(Console.ReadLine());
            Console.WriteLine($"char: {nine}");

            float ten = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine($"float: {ten}");

            double eleven = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"sbyte: {eleven}");

            Console.WriteLine("Write true or false\n");
            bool guessTrue = Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine($"bool: {guessTrue}");

            decimal money = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine($"decimal: {money}");

            string name = Console.ReadLine();
            Console.WriteLine($"string: {name}");

            object arrow = Console.ReadLine();
            Console.WriteLine($"bool: {arrow}");

            dynamic wh = Console.ReadLine();
            Console.WriteLine($"bool: {wh}\n gg wp \n");

            //1
            double d = 9.8;
            int i = (int)d;  // Результат: 9

            //2
            float f = 123.45f;
            int s = (int)f;  // Результат: 123

            //3
            object obj = "Hello, world!";
            string str = (string)obj;  // Успешное приведение к строке

            //4
            int number = 42;
            string text = number.ToString();  // Результат: "42"

            //5
            long l = 100000;
            int lll = (int)l;

            //В C# упаковка (boxing) и распаковка (unboxing)
            //используются для преобразования значимых типов
            //(например, int, bool, struct и т.д.) в ссылочные типы и обратно

            //Упаковка — это процесс преобразования значимого типа в объект (ссылочный тип).
            //Когда значимый тип упаковывается, он помещается в объект на куче, и на него создаётся ссылка.

            int numb = 123;         // Значимый тип (int)
            object link = numb;      // Упаковка: значимый тип int преобразуется в object

            //Распаковка — это процесс преобразования объекта (ссылочного типа), который содержит значимый тип, обратно в значимый тип.

            object x = 123;         // Упаковка
            int nu = (int)x;    // Распаковка: объект преобразуется обратно в int

            var nuhuh = 140;
            Console.WriteLine($"Что это?: {nuhuh.GetType()}"); // Выведет: System.Int32
            Console.WriteLine($"Значение: {nuhuh}");

            // Неявно типизированная переменная с типом string
            var nuhuh1 = "мандарины вкусно кушать";
            Console.WriteLine($"Что это?: {nuhuh1.GetType()}"); // Выведет: System.String
            Console.WriteLine($"Значение: {nuhuh1}");

            int? nullableNum = null;
            if (nullableNum.HasValue)
            {
                Console.WriteLine($"Значение: {nullableNum}");
            }
            else
            {
                Console.WriteLine("значение нулл");
            }

            nullableNum = 200;
            if (nullableNum.HasValue)
            {
                Console.WriteLine($"Значение: {nullableNum}");
            }
            else
            {
                Console.WriteLine("значение нулл");
            }

            // Объявление строковых литералов
            string str1 = "Да пусть будет так";
            string str2 = "Пригласил тебя на танцы";
            string str3 = "Да пусть будет так";

            // Сравнение строк
            bool areEqual1 = str1 == str2;  // Логическое сравнение str1 и str2
            bool areEqual2 = str1 == str3;  // Логическое сравнение str1 и str3

            Console.WriteLine($"1 и 2 строчка: {areEqual1}"); // Ожидается: False
            Console.WriteLine($"1 и 3 строчка: {areEqual2}"); // Ожидается: True

            //Сцепление 
            string concatenate = String.Concat(str1, " ", str2);
            Console.WriteLine($"Сцепление: {concatenate}");

            //Копирование 
            string copied = String.Copy(str1);
            Console.WriteLine($"Копирование строки: {copied}");

            //Выделение подстроки 
            string pointOut = str3.Substring(0, 5);
            Console.WriteLine($"Выделение подстроки: {pointOut}");

            //Разделение строки на слова
            string[] words = str3.Split(' ');
            Console.WriteLine("Разделение строки на слова:");
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }

            //Вставка подстроки в заданную позицию
            string insert = str1.Insert(5, " пойдем в макдак");
            Console.WriteLine($"Вставка подстроки: {insert}");

            //Удаление подстроки
            string deleting = str3.Remove(str3.IndexOf("будет"), "будет".Length);
            Console.WriteLine($"Удаление подстроки: {deleting}");

            //пустая строка
            string emptyString = "";

            // Null строка
            string nullString = null;

            // Проверка с использованием string.IsNullOrEmpty
            Console.WriteLine($"Проверка пустой строки: {string.IsNullOrEmpty(emptyString)}");
            Console.WriteLine($"Проверка null строки: {string.IsNullOrEmpty(nullString)}");

            // Создание строки на основе StringBuilder
            StringBuilder sb = new StringBuilder("мне?  за эту разработку премию дадут");

            // Удаление символов с позиции 5 (удалим запятую и пробел после "Hello")
            sb.Remove(3, 2); // 3 позиция, 2 символа
            Console.WriteLine($"Что вышло?: {sb}");

            // Добавление символов в начало строки
            sb.Insert(0, "думаешь, ");
            Console.WriteLine($"Что вышло?: {sb}");

            // Добавление символов в конец строки
            sb.Append("???????????");
            Console.WriteLine($"Что вышло?: {sb}");

            // Создание двумерного массива
            int[,] matrix = {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 }
            };

            // Вывод массива на консоль в виде матрицы
            for (int m = 0; m < matrix.GetLength(0); m++) // Перебираем строки
            {
                for (int j = 0; j < matrix.GetLength(1); j++) // Перебираем столбцы
                {
                    // Форматированный вывод каждого элемента с выравниванием по правому краю (для читаемости)
                    Console.Write($"{matrix[m, j],4} ");
                }
                Console.WriteLine(); // Переход на новую строку после каждой строки массива
            }

            //c
            int max = 2;
            int counter = 0;

            Console.Write("Введите числа для массива: \n");

            float[][] ArrayB = new float[3][];
            ArrayB[0] = new float[2];
            ArrayB[1] = new float[3];
            ArrayB[2] = new float[4];

            for (int j = 0; j < ArrayB.Length; j++)
            {
                for (int k = 0; k < ArrayB[j].Length; k++)
                {
                    ArrayB[j][i] = Convert.ToInt32(Console.ReadLine());
                }
            }

            Console.WriteLine();

            for (int j = 0; j < ArrayB.Length; j++)
            {
                for (int q = 0; q < ArrayB[j].Length; q++)
                {
                    Console.Write($" {ArrayB[j][i]}");
                }
                Console.WriteLine();
            }

            var arrayA = new[] { 1, 2, 3 };
            var strA = "kdsjskjdfsjdfsjio";

            (int, string, char, string, ulong) tuple = (52, "Че", 'A', "Нормис?", 1043242);

            Console.WriteLine($"Первый элемент (int): {tuple.Item1}");
            Console.WriteLine($"Второй элемент (string): {tuple.Item2}");
            Console.WriteLine($"Третий элемент (char): {tuple.Item3}");
            Console.WriteLine($"Четвертый элемент (string): {tuple.Item4}");
            Console.WriteLine($"Пятый элемент (ulong): {tuple.Item5}");

            //полная распаковка
            (int SPB, string question, char letter, string normis, ulong longNum) = tuple;
            Console.WriteLine($"Full unpack: 1. {SPB}, 2. {question}, 3. {letter}, 4. {normis}, 5. {longNum}");

            (int fiftytwo, _, char lett, _, _) = tuple;
            Console.WriteLine($"Partly unpack: 1. {fiftytwo}, 2. {lett}");




            static (int, int, int, char) localFunc(int[] arrayA, string strA)
            {
                int max = arrayA.Max();
                int min = arrayA.Min();
                int sum = arrayA.Sum();

                char letterFirst = strA[0];

                (int, int, int, char) tuple2 = (max, min, sum, letterFirst);
                return tuple2;
            }

            int iMax = int.MaxValue;

            void local1()
            {
                Console.WriteLine("checked ");
                try
                {
                    checked
                    {
                        Console.WriteLine(iMax + 2);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            void local2()
            {
                Console.WriteLine("unchecked");
                unchecked
                {
                    Console.WriteLine(iMax + 2);
                }
            }

            local1();
            local2();
        }
    }
}