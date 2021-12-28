using System;

namespace delegate02
{
    class Program
    {
        public delegate void TestDelegateA(); // 클래스 외부에 선언가능

        static void Main(string[] args)
        {
            // 새로 선언한 델리게이터 자료형으로 변수를 선언
            TestDelegateA delegateA = TestMethod; // 메서드 이름을 이용한 초기화
            TestDelegateA delegateB = delegate () { }; // 무명 델리게이터를 이용한 초기화
            TestDelegateA delegateC = () => { }; // 람다를 이용한 초기화

            // 델리게이터는 일반 메서드처럼 호출 가능
            delegateA();
            delegateB();
            delegateC();
        }

        static void TestMethod()
        {

        }
    }
}
