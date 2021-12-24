﻿using System;

namespace hiding
{
    class Program
    {
        class Parent
        {
            public int variable = 273;
            public void Method()
            {
                Console.WriteLine("parent");
            }
        }

        class Child : Parent
        {
            public new string variable = "string";
            public new void Method()
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
