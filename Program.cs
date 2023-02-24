namespace ConversionToPostfix
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine(ConversionPostfix.ConvertToPostfix("(2+1)*3+5"));
            Console.WriteLine(ConversionPostfix.ConvertToPostfix("3+4"));
            Console.WriteLine(ConversionPostfix.ConvertToPostfix("(5-4)*2"));
            Console.WriteLine(ConversionPostfix.ConvertToPostfix("2*(3+4)*5"));
        }
    }
}