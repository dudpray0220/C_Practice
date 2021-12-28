using System;

namespace callBackMethod01
{
    class Program
    {
        public delegate void CustomDelegate();  // 델리게이터 선언

        public void Method(CustomDelegate customDelegate)
        {
            customDelegate(); // 매개변수로 전달된 델리게이터(메서드) 를 호출
        }

        static void Main(string[] args)
        {
        }
    }
}
