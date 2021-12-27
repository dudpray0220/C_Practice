using System;

namespace interface03
{
    class Program
    {
        class Parent { }
        class Child : Parent, IDisposable, IComparable // 인터페이스 다중상속
        {
            public void Dispose() // IDisposable 인터페이스 구현
            {
                throw new NotImplementedException();
            }
            public int CompareTo(object obj) // IComparable 인터페이스 구현
            {
                throw new NotImplementedException();
            }

        }
        
        static void Main(string[] args)
        {
            // 3 종류로 자료형 변환이 가능해짐! (추가로 자기자신)
            Child child = new Child();
            Parent childAsParent = new Child();
            IDisposable childAsDisposable = new Child();
            IComparable childAsComparable = new Child();
        }
    }
}
