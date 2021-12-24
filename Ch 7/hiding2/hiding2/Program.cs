using System;
using System.Collections.Generic;

namespace hiding2
{
    class Program
    {
        class Animal
        {
            public virtual void Eat()
            {
                Console.WriteLine("냠냠");
            }
        }

        class Dog : Animal
        {
            public new void Eat()
            {
                Console.WriteLine("왈왈!");
            }
        }

        class Cat : Animal
        {
            public override void Eat()
            {
                Console.WriteLine("갸아아아아앙~");
            }
        }

        static void Main(string[] args)
        {
            List<Animal> Animals = new List<Animal>()
            {
                new Dog(), new Cat(), new Dog(), new Cat(),
                new Dog(), new Cat(), new Dog(), new Cat()
            };
            foreach(var item in Animals)
            {
                item.Eat();
            }
        }
    }
}
