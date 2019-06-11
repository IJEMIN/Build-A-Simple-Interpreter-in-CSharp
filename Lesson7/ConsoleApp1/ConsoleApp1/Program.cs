using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.Write("spi>");
                    var text = Console.ReadLine();

                    if (string.IsNullOrEmpty(text)) continue;

                    var lexer = new Lexer(text);
                    var parser = new Parser(lexer);
                    var interpreter = new Interpreter(parser);
                    var result = interpreter.Interpret();
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
    }
}