using System;

namespace overriding
{
    class Program
    {
        class Parent
        {
            public virtual void Method ()
            {
                Console.WriteLine("parent");
            }
        }

        class Child : Parent
        {
            public override void Method()
            {
                Console.WriteLine("child");
            }
        }

        static void Main(string[] args)
        {
            Child child = new Child();
            child.Method();
            ((Parent)child).Method();
        }
    }
}
