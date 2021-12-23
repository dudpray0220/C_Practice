using System;
using System.Collections.Generic;

namespace fibonacciMethod
{
    class Fibonacci
    {
        private static Dictionary<int, long> memo = new Dictionary<int, long>();  // 계산한 피보나치 수를 저장하는 객체 = 메모화
        public static long Get(int i)
        {
            // 종료조건, 기본값
            if (i < 0) { return 0; }
            if (i == 1) { return 1; }

            // 이미 계산했던 값인지 확인
            if (memo.ContainsKey(i))
            {
                return memo[i];
            }
            // 계산 안했다면 계산
            else
            {
                long value = Get(i - 2) + Get(i - 1);
                memo[i] = value;
                return value;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Fibonacci.Get(45));
            Console.WriteLine(Fibonacci.Get(100));
        }
    }
}
