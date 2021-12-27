using System;

namespace Generic
{
    class Wanted<T, U>
    where T : IComparable   // T는 IComparable 또는 IComparable의 상속을 받은 것이어야 한다.
    where U : IComparable, IDisposable // U는 IComparable과 IDisposable또는 이러한 것들의 상속을 받은 것이어야 한다.
    {

    }
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
