using System;

namespace sealed2
{
    class Program
    { 
        abstract class Parent
        {
            public abstract void Test();
        }

        class Child : Parent
        {
            public override void Test()
            {

            }
        }

        static void Main(string[] args)
        {

        }
    }
}
