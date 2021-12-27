using System;

namespace Practice
{
class Parent
    {
        public virtual int Question() { return 10; }
    }
    class Child : Parent
    {
        public override int Question() { return 20; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Child child = new Child();
            Console.WriteLine(child.Question());
        }
    }
}
