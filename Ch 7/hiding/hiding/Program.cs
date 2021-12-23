using System;

namespace hiding
{
    class Program
    {
        class Parent
        {
               public void Method()
            {
                Console.WriteLine("parent");
            }
        }

        class Child : Parent
        {
            public void Method()
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
