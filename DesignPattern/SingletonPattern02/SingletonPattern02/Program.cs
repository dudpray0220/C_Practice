
using System;

namespace SingletonPattern02
{
    // 싱글톤 클래스
    class Singleton
    {   
        // 클래스 변수 선언
        private static Singleton _instance;

        // protected로 생성자 
        protected Singleton() 
        {

        }

        // public static으로 전역에서 접근가능한 method
        public static Singleton Instance()
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }
            return _instance;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Singleton s1 = Singleton.Instance();
            Singleton s2 = Singleton.Instance();

            if (s1 == s2)
            {
                Console.WriteLine("Objects are the same instance");
            }

            // wait for user
            Console.WriteLine(Console.ReadKey().Key);
        }
    }
}
