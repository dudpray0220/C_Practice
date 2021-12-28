using System;

namespace tryCatchFinally
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("input : ");
            string input = Console.ReadLine();

            try
            {
                int index = int.Parse(input);
                Console.WriteLine("input number : " + index);
            }
            catch (Exception exception)
            {
                Console.WriteLine("예외 발생");
                Console.WriteLine(exception.GetType());
                Console.WriteLine(exception.Message);
                Console.WriteLine(exception.StackTrace);
            }
            finally
            {
                Console.WriteLine("program end...");
            }
        }
    }
}
