using System;
using System.Collections.Generic;
using System.Linq;

namespace linq01
{
    class Program
    {

        static void Main(string[] args)
        {
            List<int> input = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var output = from item in input
                         where (item > 5) && (item % 2 == 0)
                         orderby item
                         select item;

            foreach (var item in output)
            {
                Console.WriteLine(item);
            }

        }
        // ToArray 메서드 
        public int[] SelectEven(int[] input) // 배열로 반환!
        {
            return (from item in input
                    where item % 2 == 0
                    select item).ToArray<int>();
        }

        // ToList 메서드
        public List<int> SelectEven(List<int> input) // 리스트로 반환!
        {
            return (from item in input
                    where item % 2 == 0
                    select item).ToList<int>();
        }
        
    }
}
