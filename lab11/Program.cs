namespace lab11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Reflector.GetName("lab11.Book");
            Reflector.FindPublicConstructor("lab11.Book");
            Reflector.PrintPublicMethods("lab11.Book");
            Reflector.PrintProperties("lab11.Book");
            Reflector.PrintInterfaces("lab11.Book");
            Reflector.PrintMethodsByParam("lab11.Book", "System.Int32");
            Book book = new Book("BookName", "BookTitle", "BookDescription");
            book.MethodExample(42);
            Console.WriteLine();
            Reflector.Invoke(book, "MethodExample", "D:\\лабораторные\\ооп\\lab11\\lab11\\file.txt");
            var book1 = Reflector.Create(book, new object[] { "Thriller Trainee", "Wang Ya", "The washed-up magician Zong Jiu transmigrated into a horror, infinite flow novel about a survival show, taking the place of the cannon fodder who died tragically in the first evaluation round." });
            Console.WriteLine(book1.ToString());
        }
    }
}