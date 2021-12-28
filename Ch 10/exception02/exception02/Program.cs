using System;

namespace exception02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("input : ");
            try
            {
            string input = Console.ReadLine();
            int[] array = { 52, 3, 12, 151 };

            int index = int.Parse(input);
            Console.WriteLine("input number : " + index);
            Console.WriteLine("배열 요소 : " + array[index]);
            }
            catch (FormatException exception) 
            {
                Console.WriteLine("FormatException 발생");
                Console.WriteLine(exception.GetType() + "이 발생");
            }
            catch (IndexOutOfRangeException exception)
            {
                Console.WriteLine("IndexOutOfRangeException 발생");
                Console.WriteLine(exception.GetType() + "이 발생");
            }
        }
    }
}
