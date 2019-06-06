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
                    Console.Write("calc>");
                    var text = Console.ReadLine();

                    if (string.IsNullOrEmpty(text)) continue;

                    var interpreter = new Interpreter(text);
                    var result = interpreter.Expression();
                    
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