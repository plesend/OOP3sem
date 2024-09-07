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
            Console.WriteLine($"bool: {wh}");
        }
    }
}