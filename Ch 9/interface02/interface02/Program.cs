using System;

namespace interface02
{
    class Program
    {
        class Test : IBasic
        {
            public int TestInstanceMethod()
            {
                throw new NotImplementedException();
            }

            public int TestProperty
            {
                get
                {
                    throw new NotImplementedException();
                }
                set
                {
                    throw new NotImplementedException();
                }
            }
        }

        static void Main(string[] args)
        {
            IBasic basic = new Test();
        }
    }
}
